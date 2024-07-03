using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Memento.Models;

namespace Memento.Helpers
{

    static class BackupFolders
    {
        public static string GetBaseFolder()
        {
            Process me = Process.GetCurrentProcess();
            string parentFileName = me.Parent().MainModule!.FileName;
            string myFileName = me.MainModule!.FileName;
            string target = Path.GetFileName(parentFileName) == Path.GetFileName(myFileName) ? parentFileName : myFileName;
            return Path.GetDirectoryName(target);
        }
        private static string GetBackupFolder(string backupFolder)
        {
            string backups = PathCombineMultiple(GetBaseFolder(), "Saves", backupFolder);
            Directory.CreateDirectory(backups);
            return backups;
        }

        public static string GetBackupFolder(this GameProfile profile)
        {
            return GetBackupFolder(profile.BackupFolder);
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

        public static int MakeBackup(this GameProfile profile, DateTime x)
        {
            string targetPath = GetTargetBackupFolder(profile.BackupFolder, x);
            string savesFolder = profile.GetSavesFolder();
            if (string.IsNullOrEmpty(profile.BackupFilter))
            {
                CopyFolder(savesFolder, targetPath);
                return -1;
            }

            int counter = 0;
            foreach (string path in ApplyFilter(savesFolder, profile.BackupFilter))
            {
                string target = path.Replace(savesFolder, targetPath);
                Directory.CreateDirectory(Path.GetDirectoryName(target)!);
                File.Copy(path, target, true);
                counter++;
            }
            return counter;
        }

        public static void RestoreBackup(this GameProfile profile, string backupPath)
        {
            CopyFolder(backupPath,profile.GetSavesFolder());
        }

        private static IEnumerable<string> ApplyFilter(string path, string filter)
        {
            path = Path.GetFullPath(path);
            foreach (string newPath in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                string segment = newPath[(path.Length + 1)..];
                if (Regex.IsMatch(segment, filter ?? ""))
                {
                    yield return newPath;
                }
            }
        }

        public static void DeleteSavesFolder(this GameProfile profile)
        {
            if (string.IsNullOrEmpty(profile.BackupFilter))
            {
                Directory.Delete(profile.GetSavesFolder(), true);
            }
            else
            {
                foreach(string path in ApplyFilter(profile.GetSavesFolder(), profile.BackupFilter))
                {
                    File.Delete(path);
                }
            }
        }

        //private static DateTime? ParseDatePart(string part, params string[] patterns)
        //{
        //    foreach (string pattern in patterns)
        //    {
        //        DateTime result;
        //        if (DateTime.TryParseExact(part, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
        //        {
        //            return result;
        //        }
        //    }
        //    return null;
        //}

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
            bool BeforeCurrent(string path) => currentBackupFolder == null || (string.CompareOrdinal(path, currentBackupFolder) < 0);
            string ReconstructFullPath(string basePath) => PathCombineMultiple((new[] { basePath }).Union(pathParts).ToArray());
            bool IsPathValid(string path) => BackupPath.FromPath(ReconstructFullPath(path)) != null;

            return candidateFolders.OrderByDescending(x => x).Where(x => IsPathValid(x) && BeforeCurrent(x)).Take(2);
        }

        internal static readonly string[] StringArray = ["00.00.00"];
        internal static readonly string[] StringArray0 = ["01", "00.00.00"];

        private static string FindNextBackupFolder(string backupsBaseFolder, string currentBackupFolder = null)
        {
            IEnumerable<string> candidateFolders = Directory.GetDirectories(backupsBaseFolder);
            IEnumerable<string> monthFolders = FoldFolders(candidateFolders, StringArray0, currentBackupFolder);

            candidateFolders = monthFolders.Select(Directory.GetDirectories).SelectMany(x => x);
            IEnumerable<string> dayFolders = FoldFolders(candidateFolders, StringArray, currentBackupFolder);

            candidateFolders = dayFolders.Select(Directory.GetDirectories).SelectMany(x => x);
            return FoldFolders(candidateFolders, Array.Empty<string>(), currentBackupFolder).FirstOrDefault();
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
            return GetBackupsDescending(profile.GetBackupFolder());
        }
    }
}
