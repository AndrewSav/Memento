using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Memento.Helpers
{
    class BackupPath
    {
        private string _base;
        private string _month;
        private string _day;
        private string _time;
        private string _customLabel;
        private DateTime _timestamp;

        private BackupPath() { }

        public BackupPath ApplyLabel(string newLabel)
        {
            return new BackupPath
            {
                _month = _month,
                _day = _day,
                _time = _time,
                _base = _base,
                _timestamp = _timestamp,
                _customLabel = newLabel
            };
        }

        public string GetLabel()
        {
            return string.IsNullOrEmpty(_customLabel) ? LabelFromTimestamp(_timestamp) : _customLabel;
        }

        public bool IsSameIgnoreLabel(BackupPath other)
        {
            return _base == other._base
                && _month == other._month
                && _day == other._day
                && _time == other._time
                && _timestamp == other._timestamp;
        }

        public static BackupPath FromDateTime(DateTime timestamp, string savesFolder)
        {
            return new BackupPath
            {
                _month = timestamp.ToString("yyyy-MM"),
                _day = timestamp.ToString("dd"),
                _time = timestamp.ToString("HH.mm.ss"),
                _base = savesFolder,
                _timestamp = timestamp,
                _customLabel = ""
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
                _time = tokens[0],
                _day = tokens[1],
                _month = tokens[2],
                _base = basePath
            };

            (result._time, result._customLabel) = SplitTimeAndLabel(result._time);

            DateTime? timePart = ParseDatePart(result._time, "HH.mm.ss", "HH.mm.ss_manual", "HH.mm.ss_restore");
            DateTime? dayPart = ParseDatePart(result._day, "dd");
            DateTime? monthPart = ParseDatePart(result._month, "yyyy-MM");

            if (!timePart.HasValue || !dayPart.HasValue || !monthPart.HasValue)
            {
                return null;
            }

            result._timestamp = new DateTime(
                monthPart.Value.Year,
                monthPart.Value.Month,
                dayPart.Value.Day,
                timePart.Value.Hour,
                timePart.Value.Minute,
                timePart.Value.Second);
            return result;
        }

        public override string ToString()
        {
            string result = Path.Combine(_base, _month);
            result = Path.Combine(result, _day);
            result = Path.Combine(result, _time);
            if (!string.IsNullOrEmpty(_customLabel))
            {
                result += $" - {_customLabel}";
            }
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
