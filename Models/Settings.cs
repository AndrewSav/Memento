using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Memento.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Settings
    {

        public string LogFileName { get; set; }
        public string LogSizeLimitBytes { get; set; }
        public string LogRetainedCountLimit { get; set; }
        public List<GameProfile> Profiles { get; set; }
        public string DefaultProfile { get; set; }
        public int StabilizationTimeSeconds { get; set; }
        public Dictionary<string, Dictionary<string, List<string>>> PrefixMap { get; set; }

        public static Settings Load(string path)
        {
            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
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
