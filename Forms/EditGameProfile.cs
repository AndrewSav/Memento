using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Memento.Models;
using System.Linq;

namespace Memento.Forms
{
    public partial class EditGameProfile : MetroFramework.Forms.MetroForm
    {
        public EditGameProfile()
        {
            InitializeComponent();
        }

        public GameProfile Profile
        {
            get
            {
                SavesFolder[Environment.MachineName] = textSavesFolder.Text.Trim();
                GameExecutable[Environment.MachineName] = textGameExecutable.Text.Trim();
                return new()
                {
                    ProfileName = textProfileName.Text.Trim(),
                    BackupFolder = _backupFolder ?? textProfileName.Text.Trim(),
                    SavesFolderCollection = SavesFolder,
                    GameExecutableCollection = GameExecutable,
                    DeleteBeforeRestoring = toggleDeleteBeforeRestoring.Checked,
                    BackupBeforeRestoring = toggleBackupBeforeRestoring.Checked,
                    DontWarnOnRestore = toggleDontWarnOnRestore.Checked,
                    KillBeforeRestore = toggleKillBeforeRestore.Checked,
                    BackupOnStartWatching = toggleBackupOnStartWatching.Checked,
                    WriteLog = toggleWriteLog.Checked,
                    BackupFilter = _backupFilter,
                    WatchFilter = _watchFilter,
                    WatchSubdirectories = _watchSubdirectories,
                    ShowNumberOfFiles = toggleShowNumberOfFiles.Checked,
                    DeleteWithoutConfirmation = toggleDeleteWithoutConfirmation.Checked,
                    MinimumBackupInterval = uint.Parse(textMinimumInterval.Text)

                };
            }
            set
            {
                textProfileName.Text = value.ProfileName;
                _backupFolder = value.BackupFolder;
                textSavesFolder.Text = value.GetSavesFolder();
                SavesFolder = value.SavesFolderCollection.ToDictionary(e => e.Key, e => e.Value);
                textGameExecutable.Text = value.GetGameExecutable();
                GameExecutable = value.GameExecutableCollection.ToDictionary(e => e.Key, e => e.Value);
                toggleDeleteBeforeRestoring.Checked = value.DeleteBeforeRestoring;
                toggleBackupBeforeRestoring.Checked = value.BackupBeforeRestoring;
                toggleDontWarnOnRestore.Checked = value.DontWarnOnRestore;
                toggleKillBeforeRestore.Checked = value.KillBeforeRestore;
                toggleBackupOnStartWatching.Checked = value.BackupOnStartWatching;
                toggleWriteLog.Checked = value.WriteLog;
                _backupFilter = value.BackupFilter;
                _watchFilter = value.WatchFilter;
                _watchSubdirectories = value.WatchSubdirectories;
                toggleShowNumberOfFiles.Checked = value.ShowNumberOfFiles;
                toggleDeleteWithoutConfirmation.Checked = value.DeleteWithoutConfirmation;
                textMinimumInterval.Text = value.MinimumBackupInterval.ToString();
            }
        }

        public string InitialProfileName { get; set; }
        public IEnumerable<string> ExistingProfileNames { get; set; }
        public IEnumerable<string> ExistingBackupFolders { get; set; }
        public bool Deleted { get; private set; }
        public bool Updated { get; private set; }
        public bool Cloned { get; private set; }
        private string _backupFolder;
        private Dictionary<string, string> SavesFolder { get; set; }
        private Dictionary<string, string> GameExecutable { get; set; }

        private string _backupFilter;
        private string _watchFilter;
        private bool _watchSubdirectories;


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Deleted = true;
            Close();
        }

        private void buttonSavesFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                SelectedPath = textSavesFolder.Text.Trim()
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textSavesFolder.Text = dialog.SelectedPath;
            }
        }

        private void buttonGameExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Executables (*.exe)|*.exe",
                DefaultExt = "exe"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textGameExecutable.Text = dialog.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ProcessUserChange()) return;
            Updated = true;
            Close();
        }

        private bool ProcessUserChange(bool isCloning = false)
        {
            if (!uint.TryParse(textMinimumInterval.Text, out _))
            {
                labelWarning.Text = "The interval should be a number in minutes";
                labelWarning.Visible = true;
                return false;
            }
            
            string message = Profile.GetValidateMessage(ExistingProfileNames, InitialProfileName, isCloning);
            if (message != null)
            {
                labelWarning.Text = message;
                labelWarning.Visible = true;
                return false;
            }

            if (isCloning)
            {
                _backupFolder = Profile.ProfileName;
            }

            // Check that if backup folder changed it does not point to an existing backup folder (belonging to a different profile)
            if ((_backupFolder != Profile.BackupFolder || isCloning) && ExistingBackupFolders.Contains(Profile.BackupFolder))
            {
                _backupFolder += Profile.BackupFolder + $" - {DateTime.Now:dd MMM yyyy HH.mm.ss}";
            }
            return true;
        }

        private void linkAdvancedFiltering_Click(object sender, EventArgs e)
        {
            AdvancedFiltering advancedFiltering = new();
            advancedFiltering.Profile = Profile;
            advancedFiltering.ShowDialog(this);
            if (advancedFiltering.Updated)
            {
                GameProfile profile = advancedFiltering.Profile;
                _backupFilter = profile.BackupFilter;
                _watchFilter = profile.WatchFilter;
                _watchSubdirectories = profile.WatchSubdirectories;
            }
        }
        private void buttonClone_Click(object sender, EventArgs e)
        {
            if (!ProcessUserChange(isCloning: true)) return;
            Cloned = true;
            Close();
        }
    }
}
