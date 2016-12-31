using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class FastBackupSearcher
    {
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

        public static string FindFirst2(string backups, string current)
        {
            string[] z = Directory.GetDirectories(backups);
            var b1 = z.OrderByDescending(x => x).Where(x => BackupPath.FromPath(PathCombineMultiple(x, "01", "00.00.00")) != null && (current == null || (string.CompareOrdinal(x, current) < 0))).Take(2);
            if (!b1.Any()) return null;
            z = b1.Select(Directory.GetDirectories).SelectMany(x=>x).ToArray();
            var b2 = z.OrderByDescending(x => x).Where(x => BackupPath.FromPath(Path.Combine(x, "00.00.00")) != null && (current == null || (string.CompareOrdinal(x, current) < 0))).Take(2);
            if (!b2.Any()) return null;
            z = b2.Select(Directory.GetDirectories).SelectMany(x => x).ToArray();
            var b3 = z.OrderByDescending(x => x).FirstOrDefault(x => BackupPath.FromPath(x) != null && (current == null || (string.CompareOrdinal(x, current) < 0)));
            return b3;
        }

        
        public static string FindNext(string current)
        {
            BackupPath backupPath = BackupPath.FromPath(current);
            Debug.Assert(backupPath != null);

            string withoutTime = Path.GetDirectoryName(current);
            string next = GetPreviousFolder(withoutTime, backupPath.Time);

            if (next != null)
            {
                return next;
            }

            string withoutDay = Path.GetDirectoryName(withoutTime);
            next = GetPreviousFolder(withoutDay, backupPath.Day);

            if (next != null)
            {
                string[] d = Directory.GetDirectories(next);
                Array.Sort(d);
                next = null;
                for (int i = d.Length - 1; i >= 0; i++)
                {
                    if (BackupPath.FromPath(d[i]) != null)
                    {
                        next = d[i];
                        break;
                    }                    
                }
            }

            if (next != null)
            {
                return next;
            }

            string withoutMonth = Path.GetDirectoryName(withoutDay);
            next = GetPreviousFolder(withoutMonth, backupPath.Month);

            if (next != null)
            {
                string[] d = Directory.GetDirectories(next);
                Array.Sort(d);
                next = null;
                for (int i = d.Length - 1; i >= 0; i++)
                {
                    if (BackupPath.FromPath(Path.Combine(d[i],"00.00.00")) != null)
                    {
                        next = d[i];
                        break;
                    }
                }
            }

            if (next != null)
            {
                return next;
            }

            if (next != null)
            {
                string[] d = Directory.GetDirectories(next);
                Array.Sort(d);
                next = null;
                for (int i = d.Length - 1; i >= 0; i++)
                {
                    if (BackupPath.FromPath(d[i]) != null)
                    {
                        next = d[i];
                        break;
                    }
                }
            }

            if (next != null)
            {
                return next;
            }

            return null;
        }

        private static string GetPreviousFolder(string basePath, string current)
        {
            string[] directories = Directory.GetDirectories(basePath);
            Array.Sort(directories);
            string previous = null;
            foreach (string directory in directories)
            {
                if (Path.GetFileName(directory) == current)
                {
                    return previous;
                }
                previous = directory;
            }
            return null;
        }
    }
}
