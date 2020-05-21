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
                return new GameProfile
                {
                    ProfileName = textProfileName.Text.Trim(),
                    BackupFolder = backupFolder ?? textProfileName.Text.Trim(),
                    SavesFolder = textSavesFolder.Text.Trim(),
                    GameExecutable = textGameExecutable.Text.Trim(),
                    BackupBeforeRestoring = toggleBackupBeforeRestoring.Checked,
                    DontWarnOnRestore = toggleDontWarnOnRestore.Checked,
                    KillBeforeRestore = toggleKillBeforeRestore.Checked,
                    BackupOnStartWatching = toggleBackupOnStartWatching.Checked,
                    WriteLog = toggleWriteLog.Checked
                };
            }
            set
            {
                textProfileName.Text = value.ProfileName;
                backupFolder = value.BackupFolder;
                textSavesFolder.Text = value.SavesFolder;
                textGameExecutable.Text = value.GameExecutable;
                toggleBackupBeforeRestoring.Checked = value.BackupBeforeRestoring;
                toggleDontWarnOnRestore.Checked = value.DontWarnOnRestore;
                toggleKillBeforeRestore.Checked = value.KillBeforeRestore;
                toggleBackupOnStartWatching.Checked = value.BackupOnStartWatching;
                toggleWriteLog.Checked = value.WriteLog;
            }
        }

        public string InitialProfileName { get; set; }
        public string InitialBackupFolder { get; set; }
        public IEnumerable<string> ExistingProfileNames { get; set; }
        public IEnumerable<string> ExistingBackupFolders { get; set; }
        public bool Deleted { get; private set; }
        public bool Updated { get; private set; }
        private string backupFolder;


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Deleted = true;
            Close();
        }

        private void buttonSavesFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cofd = new FolderBrowserDialog
            {                
                SelectedPath = textSavesFolder.Text.Trim()
            };
            if (cofd.ShowDialog() == DialogResult.OK)
            {
                textSavesFolder.Text = cofd.SelectedPath;
            }
        }

        private void buttonGameExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog cofd = new OpenFileDialog
            {
                Filter = "Executables (*.exe)|*.exe",
                DefaultExt = "exe"
            };
            if (cofd.ShowDialog() == DialogResult.OK)
            {
                textGameExecutable.Text = cofd.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (InitialBackupFolder != Profile.BackupFolder && ExistingBackupFolders != null && ExistingBackupFolders.Contains(Profile.BackupFolder))
            {
                backupFolder += Profile.BackupFolder + $" - {DateTime.Now:dd MMM yyyy HH.mm.ss}";
            }
            string message = Profile.GetValidateMessage(ExistingProfileNames, InitialProfileName);
            if (message == null)
            {
                Updated = true;
                Close();
            }
            else
            {
                labelWarning.Text = message;
                labelWarning.Visible = true;
            }
        }
    }
}
