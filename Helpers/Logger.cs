using System;
using System.Collections.Generic;
using System.IO;
using Memento.Models;
using Serilog;
using Serilog.Core;

namespace Memento.Helpers
{
    static class LoggerHelper
    {               
        public static Logger GetLoggerForFolder(string folderName)
        {
            string configPath = Path.Combine(BackupFolders.GetBaseFolder(), "settings.json");
            Settings settings = Settings.Load(configPath);

            List<KeyValuePair<string, string>> serilogSettings = new List<KeyValuePair<string, string>>();

            string logFilename = Environment.ExpandEnvironmentVariables(settings.LogFileName);
            string logRetainedCountLimit = Environment.ExpandEnvironmentVariables(settings.LogRetainedCountLimit);
            string logSizeLimitBytes = Environment.ExpandEnvironmentVariables(settings.LogSizeLimitBytes);

            serilogSettings.Add(new KeyValuePair<string, string>("write-to:RollingFile.pathFormat", Path.Combine(folderName, logFilename)));
            serilogSettings.Add(new KeyValuePair<string, string>("write-to:RollingFile.fileSizeLimitBytes", logSizeLimitBytes));
            serilogSettings.Add(new KeyValuePair<string, string>("write-to:RollingFile.retainedFileCountLimit", logRetainedCountLimit));
            serilogSettings.Add(new KeyValuePair<string, string>("using:RollingFile", "Serilog.Sinks.RollingFile"));

            return new LoggerConfiguration().ReadFrom.KeyValuePairs(serilogSettings).CreateLogger();
        }
    }
}
