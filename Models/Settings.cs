using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Memento.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Settings
    {

        public string SchemaVersion { get; set; }
        public string LogFileName { get; set; }
        public string LogSizeLimitBytes { get; set; }
        public string LogRetainedCountLimit { get; set; }
        public List<GameProfile> Profiles { get; set; }
        public string DefaultProfile { get; set; }
        public int StabilizationTimeSeconds { get; set; }

        public static Settings Load(string path)
        {
            return Migrate(JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path)), path);
        }

        private static Settings Migrate(Settings s, string path)
        {
            if (s.SchemaVersion == null)
            {
                s.SchemaVersion = "1";
                foreach (GameProfile p in s.Profiles)
                {
                    if (p.GameExecutableCollection == null)
                    {
#pragma warning disable CS0612 // Type or member is obsolete
                        p.GameExecutableCollection = new Dictionary<string, string> { { Environment.MachineName, p.GameExecutable } };
                    }
                    p.GameExecutable = null;
                    if (p.SavesFolderCollection == null)
                    {
                        p.SavesFolderCollection = new Dictionary<string, string> { { Environment.MachineName, p.SavesFolder } };
                    }
                    p.SavesFolder = null;
#pragma warning restore CS0612 // Type or member is obsolete
                }
                s.Save(path);
            }
            return s;
        }
        public static void Save(string path, Settings settings)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(settings, Formatting.Indented));
        }

        public void Save(string path)
        {
            Save(path, this);
        }
    }
}
