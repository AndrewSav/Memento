using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Serilog;
using Serilog.Core;

namespace Memento.Helpers
{
    static class LoggerHelper
    {
        public static Logger GetLoggerForFolder(string folderName)
        {
            string settingPrefix = "serilog:";
            string key = "write-to:RollingFile.pathFormat";

            List<KeyValuePair<string, string>> settings = ConfigurationManager.AppSettings.AllKeys
                .Select(k => new KeyValuePair<string, string>(k, ConfigurationManager.AppSettings[k]))            
                .Where(k => k.Key.StartsWith(settingPrefix))
                .Select(k => new KeyValuePair<string, string>(
                    k.Key.Substring(settingPrefix.Length),
                    Environment.ExpandEnvironmentVariables(k.Value)))
                .ToList();

            string fileName = settings.FirstOrDefault(x => x.Key == key).Value ?? "log-{Date}.txt";
            settings = settings.Where(x => x.Key != key).ToList();
            KeyValuePair<string,string> path = new KeyValuePair<string, string>(key, Path.Combine(folderName, fileName));
            settings.Add(path);

            return new LoggerConfiguration().ReadFrom.KeyValuePairs(settings).CreateLogger();

        }
    }
}
