﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Memento.Models
{
    public class GameProfile
    {
        public string ProfileName { get; set; }
        public string SavesFolder { get; set; }
        public string GameExecutable { get; set; }
        public bool KillBeforeRestore { get; set; }
        public bool DontWarnOnRestore { get; set; }
        public bool BackupBeforeRestoring { get; set; }
        public bool BackupOnStartWatching { get; set; }
        public bool WriteLog { get; set; }
        public void Load(GameProfile copy)
        {
            ProfileName = copy.ProfileName;
            SavesFolder = copy.SavesFolder;
            GameExecutable = copy.GameExecutable;
            KillBeforeRestore = copy.KillBeforeRestore;
            DontWarnOnRestore = copy.DontWarnOnRestore;
            BackupBeforeRestoring = copy.BackupBeforeRestoring;
            BackupOnStartWatching = copy.BackupOnStartWatching;
            WriteLog = copy.WriteLog;
        }

        public string GetValidateMessage(IEnumerable<string> existingProfiles, string originalProfileName)
        {
            if (string.IsNullOrEmpty(ProfileName))
            {
                return "Profile name cannot be empty";
            }
            if (ProfileName.StartsWith("<"))
            {
                return "Profile name cannot start with '<'";
            }
            if (ProfileName != originalProfileName && existingProfiles != null && existingProfiles.Contains(ProfileName))
            {
                return "Profile with this name already exists";
            }
            if (!Directory.Exists(SavesFolder))
            {
                return "Saves folder with this path does not exist";
            }
            if (!File.Exists(GameExecutable))
            {
                return "Game executable with this path does not exist";
            }
            if (string.IsNullOrEmpty(GameExecutable) && KillBeforeRestore)
            {
                return "'Kill game before restore' requires Game Executable";
            }
            if (DontWarnOnRestore && KillBeforeRestore)
            {
                return "'Do not warn when restoring' is not valid with 'Kill game before restore'";
            }
            return null;
        }

        public override string ToString()
        {
            return ProfileName;
        }
    }
}
