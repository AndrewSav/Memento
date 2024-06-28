using Memento.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Memento.Models
{
    public class GameProfile
    {
        public GameProfile()
        {
            SavesFolderCollection = [];
            GameExecutableCollection = [];
            WatchSubdirectories = true;
        }
            
        private string _backupFolder;

        public string ProfileName { get; set; }
        public string BackupFolder
        {
            get => _backupFolder ?? (ProfileName == "<New>" ? null : ProfileName);
            set => _backupFolder = value;
        }
        public Dictionary<string,string> SavesFolderCollection { get; set; }
        public Dictionary<string, string> GameExecutableCollection { get; set; }
        [Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SavesFolder { get; set; }
        [Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string GameExecutable { get; set; }
        public string WatchFilter { get; set; }
        public bool WatchSubdirectories { get; set; }
        public string BackupFilter { get; set; }
        public bool KillBeforeRestore { get; set; }
        public bool DontWarnOnRestore { get; set; }
        public bool DeleteBeforeRestoring { get; set; }
        public bool BackupBeforeRestoring { get; set; }
        public bool BackupOnStartWatching { get; set; }
        public bool WriteLog { get; set; }
        public bool ShowNumberOfFiles { get; set; }
        public bool DeleteWithoutConfirmation { get; set; }
        [CLSCompliant(false)]
        public uint MinimumBackupInterval { get; set; }
        public void Load(GameProfile copy)
        {
            ProfileName = copy.ProfileName;
            BackupFolder = copy.BackupFolder;
            SavesFolderCollection = copy.SavesFolderCollection.ToDictionary(e => e.Key,e => e.Value);
            GameExecutableCollection = copy.GameExecutableCollection.ToDictionary(e => e.Key, e => e.Value);
            WatchFilter = copy.WatchFilter;
            WatchSubdirectories = copy.WatchSubdirectories;
            BackupFilter = copy.BackupFilter;
            KillBeforeRestore = copy.KillBeforeRestore;
            DontWarnOnRestore = copy.DontWarnOnRestore;
            DeleteBeforeRestoring = copy.DeleteBeforeRestoring;
            BackupBeforeRestoring = copy.BackupBeforeRestoring;
            BackupOnStartWatching = copy.BackupOnStartWatching;
            WriteLog = copy.WriteLog;
            ShowNumberOfFiles = copy.ShowNumberOfFiles;
            DeleteWithoutConfirmation = copy.DeleteWithoutConfirmation;
            MinimumBackupInterval = copy.MinimumBackupInterval;
        }
        
        private void Log(string s)
        {
            var logger = WriteLog ? LoggerHelper.GetLoggerForFolder(this.GetBackupFolder()) : null;
            logger?.Information(s);
        }

        private static string Replace(string source, string search, string replace)
        {
            return Regex.Replace(source, Regex.Escape(search), replace.Replace("$", "$$"), RegexOptions.IgnoreCase);
        }

        private string DetectPath(Dictionary<string,string> pathCollection, Dictionary<string, Dictionary<string, List<string>>> prefixMap)
        {
            Log($"Detecting path for {ProfileName} on {Environment.MachineName}");

            if (!prefixMap.TryGetValue(Environment.MachineName, out Dictionary<string, List<string>> localPrefixes))
            {
                Log($"No prefixes are found in the Prefix map for {Environment.MachineName}");
                return null;
            }

            foreach (KeyValuePair<string, string> pair in pathCollection)
            {
                Log($"Detecting based on existing path '{pair.Value}' for {pair.Key}");
                if (prefixMap.TryGetValue(pair.Key, out Dictionary<string, List<string>> prefixes))
                {
                    List<KeyValuePair<string, List<string>>> pp = prefixes.Where(x => x.Value.Any(y => pair.Value.ToLowerInvariant().StartsWith(y.ToLowerInvariant()))).ToList();
                    if (pp.Count == 0)
                    {
                        Log($"No prefix from prefix map for {pair.Key} matched {pair.Value}");
                        continue;
                    }
                    if (pp.Count > 1)
                    {
                        Log($"More than one prefix from prefix map for {pair.Key} matched {pair.Value}");
                        foreach (KeyValuePair<string, List<string>> matched in pp)
                        {
                            string val = string.Join(", ", matched.Value);
                            Log($"Match: {matched.Key}: {val}");
                        }
                    }
                    KeyValuePair<string, List<string>> prefix = pp[0];
                    string displayValue = string.Join(", ", prefix.Value);
                    Log($"Matched: {prefix.Key}: {displayValue}");

                    if (!localPrefixes.TryGetValue(prefix.Key, out List<string> localPrefixValues))
                    {
                        Log($"No prefix key {prefix.Key} found for {Environment.MachineName}");
                        continue;
                    }

                    if (localPrefixValues.Count == 0)
                    {
                        Log($"The prefix array is empty for {prefix.Key} on {Environment.MachineName}");
                        continue;
                    }

                    string GetPath(string localPrefix)
                    {
                        foreach (string v in prefix.Value)
                        {
                            if (pair.Value.ToLowerInvariant().StartsWith(v.ToLowerInvariant()))
                            {
                                return Replace(pair.Value, v, localPrefix);
                            }
                        }

                        throw new ApplicationException("Unexpected code path");
                    }

                    string UseFirstPrefix()
                    {
                        Log($"Using prefix {prefix.Key}, value {localPrefixValues[0]} for {Environment.MachineName}");
                        string path = GetPath(localPrefixValues[0]);
                        Log($"Detected path {path}");
                        return path;
                    }

                    if (localPrefixValues.Count == 1)
                    {
                        return UseFirstPrefix();
                    }

                    foreach (string prefixValue in localPrefixValues)
                    {
                        Log($"Checking prefix {prefix.Key}, value '{prefixValue}' for an existing path");
                        string path = GetPath(prefixValue);
                        if (File.Exists(path) && Directory.Exists(path))
                        {
                            Log($"Using prefix value {prefixValue}");
                            Log($"Detected path {path}");
                            return path;
                        }
                    }

                    Log("No existing path found with any given prefix. Using the first one");
                    return UseFirstPrefix();

                }

                Log($"No prefixes are found in the Prefix map for {pair.Key}");
            }

            Log("Prefix search did not find any matches");
            return null;
        }

        //private static readonly Dictionary<string, Dictionary<string, List<string>>> PrefixMap = new() 
        //{
        //    ["IREALM2022"]= new()
        //    {
        //        ["UserProfilePrefix"] = [@"C:\Users\andrewsav\"],
        //        ["SteamPathPrefix"] = [@"D:\steam\", @"C:\steam\"]
        //    },
        //    ["13960-ASAV"] = new()
        //    {
        //        ["UserProfilePrefix"] = [@"C:\Users\admas$\"],
        //        ["SteamPathPrefix"] = [@"D:\Misc\steam\"]
        //    }
        //};

        public string GetSavesFolder()
        {

            if (SavesFolderCollection.TryGetValue(Environment.MachineName, out string folder))
            {
                return folder;
            }

            string path = DetectPath(SavesFolderCollection, Forms.Memento.Settings.PrefixMap);
            if (Directory.Exists(path))
            {
                SavesFolderCollection[Environment.MachineName] = path;
            }
            return path;
        }
        public string GetGameExecutable()
        {
            if (GameExecutableCollection.TryGetValue(Environment.MachineName, out string executable))
            {
                return executable;
            }

            string path = DetectPath(GameExecutableCollection, Forms.Memento.Settings.PrefixMap);
            if (File.Exists(path))
            {
                GameExecutableCollection[Environment.MachineName] = path;
            }
            return path;
        }
        public void SetSavesFolder(string value)
        {
            SavesFolderCollection[Environment.MachineName] = value;
        }
        public void SetGameExecutable(string value)
        {
            GameExecutableCollection[Environment.MachineName] = value;
        }

        public string GetValidateMessage(IEnumerable<string> existingProfiles, string originalProfileName, bool isCloning)
        {
            if (string.IsNullOrEmpty(ProfileName))
            {
                return "Profile name cannot be empty";
            }
            if (ProfileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return $"Profile name cannot have illegal characters";
            }
            if ((ProfileName != originalProfileName || isCloning) && existingProfiles != null && existingProfiles.Contains(ProfileName))
            {
                return "Profile with this name already exists";
            }
            if (!Directory.Exists(GetSavesFolder()))
            {
                return "Saves folder with this path does not exist";
            }
            if (!File.Exists(GetGameExecutable()))
            {
                return "Game executable with this path does not exist";
            }
            if (string.IsNullOrEmpty(GetGameExecutable()) && KillBeforeRestore)
            {
                return "'Kill game before restore' requires Game Executable";
            }
            if (DontWarnOnRestore && KillBeforeRestore)
            {
                return "'Do not warn when restoring' is not valid with 'Kill game before restore'";
            }
            if (ShowNumberOfFiles && string.IsNullOrEmpty(BackupFilter))
            {
                return "'Show number of files backed up' is not valid if 'Backup Filter' is not set";
            }
            if (!string.IsNullOrEmpty(BackupFilter))
            {
                try
                {
                    Regex _ = new(BackupFilter);
                } catch (RegexParseException)
                {
                    return "Could not parse 'Backup Filter' as a Regular Expression";
                }
            }
            return null;
        }

        public override string ToString()
        {
            return ProfileName;
        }
    }
}
