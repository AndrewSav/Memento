﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Memento.Helpers
{
    class BackupPath
    {
        public string Base { get; private set; }
        public string Month { get; private set; }
        public string Day { get; private set; }
        public string Time { get; private set; }
        public string Label { get; private set; }

        private BackupPath() { }

        public static BackupPath FromDateTime(DateTime timestamp, string savesFolder)
        {
            return new BackupPath
            {
                Month = timestamp.ToString("yyyy-MM"),
                Day = timestamp.ToString("dd"),
                Time = timestamp.ToString("HH.mm.ss"),
                Base = savesFolder,
                Label = LabelFromTimestamp(timestamp)
            };
        }

        private static string LabelFromTimestamp(DateTime timestamp)
        {
            return timestamp.ToString("d MMM yyyy HH:mm:ss");
        }
        public static BackupPath FromPath(string path)
        {
            if (path == null)
            {
                return null;
            }
            string[] tokens = path.Split('\\');
            if (tokens.Length < 4)
            {
                return null;
            }
            string basePath = string.Join("\\",tokens.Take(tokens.Length - 3).ToArray());
            Array.Reverse(tokens);
            BackupPath result = new BackupPath
            {
                Time = tokens[0],
                Day = tokens[1],
                Month = tokens[2],
                Base = basePath
            };

            (string time, string label) = SplitTimeAndLabel(result.Time);

            DateTime? timePart = ParseDatePart(time, "HH.mm.ss", "HH.mm.ss_manual", "HH.mm.ss_restore");
            DateTime? dayPart = ParseDatePart(result.Day, "dd");
            DateTime? monthPart = ParseDatePart(result.Month, "yyyy-MM");

            if (!timePart.HasValue || !dayPart.HasValue || !monthPart.HasValue)
            {
                return null;
            }

            result.Label = string.IsNullOrEmpty(label) ? LabelFromTimestamp(new DateTime(
                monthPart.Value.Year,
                monthPart.Value.Month,
                dayPart.Value.Day,
                timePart.Value.Hour,
                timePart.Value.Minute,
                timePart.Value.Second)): label;
            return result;
        }


        public override string ToString()
        {
            string result = Path.Combine(Base, Month);
            result = Path.Combine(result, Day);
            result = Path.Combine(result, Time);
            return result;
        }
        
        private static (string time, string label) SplitTimeAndLabel(string timeLabelPart)
        {
            int indexOfMinus = timeLabelPart.IndexOf('-');
            if (indexOfMinus < 0)
            {
                return (timeLabelPart, "");
            }
            else
            {
                string time = timeLabelPart.Substring(0, indexOfMinus);
                string label = timeLabelPart.Substring(indexOfMinus);
                if (label.Length > 0)
                {
                    label = label.Substring(1);
                }
                return (time.Trim(), label.Trim());
            }
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
    }
}
