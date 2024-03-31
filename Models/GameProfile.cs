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

        public string GetSavesFolder()
        {
            if (SavesFolderCollection.ContainsKey(Environment.MachineName))
            {
                return SavesFolderCollection[Environment.MachineName];
            }

            return SavesFolderCollection.Count > 0 ? SavesFolderCollection[SavesFolderCollection.Keys.First()] : null;
        }
        public string GetGameExecutable()
        {
            if (GameExecutableCollection.ContainsKey(Environment.MachineName))
            {
                return GameExecutableCollection[Environment.MachineName];
            }

            return GameExecutableCollection.Count > 0 ? GameExecutableCollection[GameExecutableCollection.Keys.First()] :  null;
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
