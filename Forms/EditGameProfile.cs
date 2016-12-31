using System;
using System.Collections.Generic;
using Memento.Models;
using Microsoft.WindowsAPICodePack.Dialogs;

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
        public IEnumerable<string> ExistingProfileNames { get; set; }
        public bool Deleted { get; private set; }
        public bool Updated { get; private set; }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Deleted = true;
            Close();
        }

        private void buttonSavesFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = textSavesFolder.Text.Trim()
            };
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textSavesFolder.Text = cofd.FileName;
            }
        }

        private void buttonGameExecutable_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog
            {
                Filters =
                {
                    new CommonFileDialogFilter
                    {
                        DisplayName = "Executable",
                        Extensions = { "exe" },
                        ShowExtensions = true                    
                    }               
                }
            };
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
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
