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
        private static readonly Dictionary<string, Logger> Loggers = [];
        private static readonly object Lock = new();
        public static Logger GetLoggerForFolder(string folderName)
        {
            if (!Loggers.ContainsKey(folderName))
            {
                lock (Lock)
                {
                    if (!Loggers.ContainsKey(folderName))
                    {
                        string configPath = Path.Combine(BackupFolders.GetBaseFolder(), "settings.json");
                        Settings settings = Settings.Load(configPath);

                        List<KeyValuePair<string, string>> serilogSettings = [];

                        string logFilename = Environment.ExpandEnvironmentVariables(settings.LogFileName);
                        string logRetainedCountLimit = Environment.ExpandEnvironmentVariables(settings.LogRetainedCountLimit);
                        string logSizeLimitBytes = Environment.ExpandEnvironmentVariables(settings.LogSizeLimitBytes);

                        serilogSettings.Add(new("write-to:File.path", Path.Combine(folderName, logFilename)));
                        serilogSettings.Add(new("write-to:File.fileSizeLimitBytes", logSizeLimitBytes));
                        serilogSettings.Add(new("write-to:File.retainedFileCountLimit", logRetainedCountLimit));
                        serilogSettings.Add(new("using:File", "Serilog.Sinks.File"));

                        Loggers[folderName] = new LoggerConfiguration().ReadFrom.KeyValuePairs(serilogSettings).CreateLogger();
                    }
                }
            }

            return Loggers[folderName];
        }
    }
}
