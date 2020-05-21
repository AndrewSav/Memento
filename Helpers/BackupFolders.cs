using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Memento.Models;

namespace Memento.Helpers
{

    static class BackupFolders
    {
        public static string GetBaseFolder()
        {
            Process me = Process.GetCurrentProcess();
            string parentFileName = me.Parent().MainModule.FileName;
            string myFileName = me.MainModule.FileName;
            string target = Path.GetFileName(parentFileName) == Path.GetFileName(myFileName) ? parentFileName : myFileName;
            return Path.GetDirectoryName(target);
        }
        private static string GetBackupsFolder(string backupFolder)
        {
            string backups = PathCombineMultiple(GetBaseFolder(), "Saves", backupFolder);
            Directory.CreateDirectory(backups);
            return backups;
        }

        public static string GetBackupsFolder(this GameProfile profile)
        {
            return GetBackupsFolder(profile.BackupFolder);
        }

        private static void CopyFolder(string source, string target)
        {
            Directory.CreateDirectory(target);
            foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(source, target));
            }
            foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(source, target), true);
            }
        }

        private static string GetTargetBackupFolder(string profileName, DateTime lastChange)
        {
            string backups = PathCombineMultiple(GetBaseFolder(), "Saves", profileName);
            return BackupPath.FromDateTime(lastChange, backups).ToString();
        }

        public static void MakeBackup(this GameProfile profile, DateTime x)
        {
            CopyFolder(profile.SavesFolder, GetTargetBackupFolder(profile.ProfileName, x));
        }
        public static void RestoreBackup(this GameProfile profile, string backupPath)
        {
            CopyFolder(backupPath,profile.SavesFolder);
        }

        private static DateTime? ParseDatePart(string part, params string[] patterns)
        {
            foreach (string pattern in patterns)
            {
                DateTime result;
                if (DateTime.TryParseExact(part, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    return result;
                }
            }
            return null;
        }

        public static string GetLabelFromPath(string s)
        {
            return BackupPath.FromPath(s)?.GetLabel();
        }

        private static string PathCombineMultiple(params string[] parts)
        {
            if (parts == null)
            {
                return null;
            }
            string result = string.Empty;
            foreach (string part in parts)
            {
                result = Path.Combine(result, part);
            }
            return result;
        }


        private static IEnumerable<string> FoldFolders(IEnumerable<string> candidateFolders, IEnumerable<string> pathParts, string currentBackupFolder)
        {
            Func<string, bool> beforeCurrent = path => currentBackupFolder == null || (string.CompareOrdinal(path, currentBackupFolder) < 0);
            Func<string, string> reconstructFullPath = basePath => PathCombineMultiple((new[] { basePath }).Union(pathParts).ToArray());
            Func<string, bool> isPathValid = path => BackupPath.FromPath(reconstructFullPath(path)) != null;

            return candidateFolders.OrderByDescending(x => x).Where(x => isPathValid(x) && beforeCurrent(x)).Take(2);
        }

        private static string FindNextBackupFolder(string backupsBaseFolder, string currentBackupFolder = null)
        {
            IEnumerable<string> candidateFolders = Directory.GetDirectories(backupsBaseFolder);
            IEnumerable<string> monthFolders = FoldFolders(candidateFolders, new[] {"01", "00.00.00"}, currentBackupFolder);

            candidateFolders = monthFolders.Select(Directory.GetDirectories).SelectMany(x => x);
            IEnumerable<string> dayFolders = FoldFolders(candidateFolders, new[] { "00.00.00" }, currentBackupFolder);

            candidateFolders = dayFolders.Select(Directory.GetDirectories).SelectMany(x => x);
            return FoldFolders(candidateFolders, new string[0], currentBackupFolder).FirstOrDefault();
        }

        private static IEnumerable<string> GetBackupsDescending(string backupsBaseFolder)
        {
            string current = FindNextBackupFolder(backupsBaseFolder);
            while (current != null)
            {
                yield return current;
                current = FindNextBackupFolder(backupsBaseFolder, current);
            }
        }
        public static IEnumerable<string> GetBackupsDescending(this GameProfile profile)
        {
            return GetBackupsDescending(profile.GetBackupsFolder());
        }
    }
}
