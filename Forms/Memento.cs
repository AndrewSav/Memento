using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memento.Helpers;
using Memento.Models;
using MetroFramework.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using Serilog.Core;

namespace Memento.Forms
{
    public partial class Memento : MetroFramework.Forms.MetroForm
    {
        private Settings _settings;
        private readonly string _configPath = Path.Combine(BackupFolders.GetBaseFolder(), "settings.json");
        private List<MetroRadioButton> _radioButtons;
        private IDisposable _watcherObservableDisposable;
        private GameProfile _selectedItem;
        private Logger _logger;

        public Memento()
        {
            InitializeComponent();
        }

        private void Memento_Load(object sender, EventArgs e)
        {
            if (File.Exists(_configPath))
            {
                _settings = Settings.Load(_configPath);
                comboProfiles.Items.Add(new GameProfile {ProfileName = "<New>"});
                foreach (GameProfile gameProfile in _settings.Profiles)
                {
                    comboProfiles.Items.Add(gameProfile);
                }

                GameProfile selected = _settings.Profiles.FirstOrDefault(x => x.ProfileName == _settings.DefaultProfile);
                if (selected != null)
                {
                    comboProfiles.SelectedItem = selected;
                }
                else
                {
                    comboProfiles.SelectedIndex = 0;
                }
            }

            _radioButtons =
                panelBackups.Controls.OfType<MetroRadioButton>().Where(x => x.Name != "radioSpecific").ToList();
            _radioButtons.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            comboProfiles_SelectedIndexChanged(comboProfiles, new EventArgs());
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            string tagRunning = "Running";
            CleanUpWatcher();
            if (buttonStartStop.Tag as string == tagRunning)
            {
                // Stopping
                buttonStartStop.Tag = null;
                buttonStartStop.Text = @"Start watching";
                linkBackup.Enabled = true;
                comboProfiles.Enabled = true;
                buttonEdit.Enabled = true;
            }
            else
            {
                // Starting
                Log("Starting watching");
                if (_selectedItem.BackupOnStartWatching)
                {
                    DoBackup();
                }
                buttonStartStop.Text = @"Stop watching";
                buttonStartStop.Tag = tagRunning;
                linkBackup.Enabled = false;
                comboProfiles.Enabled = false;
                buttonEdit.Enabled = false;
                watcher = new FileSystemWatcher(_selectedItem.SavesFolder) { IncludeSubdirectories = true };
                var changed = Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Changed");
                var deleted = Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Deleted");
                var renamed = Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Renamed");
                var created = Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Created");
                _watcherObservableDisposable = changed
                    .Merge(deleted)
                    .Merge(renamed)
                    .Merge(created)
                    .Select(x => DateTime.Now)
                    .Throttle(TimeSpan.FromSeconds(_settings.StabilizationTimeSeconds))
                    .Subscribe(x =>
                    {
                        Log($"Save change detected. Timestamp {x:HH:mm:ss}");
                        _selectedItem.MakeBackup(x);
                        Invoke((Action)UpdateRadioButtons);
                    });
                watcher.EnableRaisingEvents = true;
            }
        }

        private void UpdateRadioButtons()
        {
            string selectBackup = panelBackups.Controls.OfType<MetroRadioButton>().First(x => x.Checked).Tag as string;
            foreach (MetroRadioButton button in _radioButtons)
            {
                button.Visible = false;
            }
            GetRadioButtons(_selectedItem);
            MetroRadioButton selectedRadio = panelBackups.Controls.OfType<MetroRadioButton>().FirstOrDefault(x => x.Tag as string == selectBackup);
            selectedRadio = selectedRadio ?? radioSpecific;
            selectedRadio.Checked = true;
            selectedRadio.Tag = selectBackup;
            selectedRadio.Text = BackupFolders.GetLabelFromPath(selectBackup) ?? @"none";
        }


        private MetroRadioButton GetSelectedRadioButton()
        {
            return panelBackups.Controls.OfType<MetroRadioButton>().First(x => x.Checked);
        }
        private void CleanUpWatcher()
        {
            _watcherObservableDisposable?.Dispose();
            _watcherObservableDisposable = null;
            watcher?.Dispose();
            watcher = null;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditGameProfile editGameProfile = new EditGameProfile();
            GameProfile currentProfile = comboProfiles.SelectedItem as GameProfile;
            if (currentProfile != null)
            {
                editGameProfile.Profile = currentProfile;
                editGameProfile.InitialProfileName = currentProfile.ProfileName;
                editGameProfile.ExistingProfileNames = _settings.Profiles.Select(x => x.ProfileName);
            }

            editGameProfile.ShowDialog(this);

            if (editGameProfile.Deleted && ((GameProfile) comboProfiles.SelectedItem).ProfileName != "<New>")
            {
                _settings.Profiles = _settings.Profiles.Where(x => x != comboProfiles.SelectedItem).ToList();
                comboProfiles.Items.Remove(comboProfiles.SelectedItem);
                _settings.Save(_configPath);
                comboProfiles.SelectedIndex = comboProfiles.Items.Count > 1 ? 1 : 0;
            }

            if (editGameProfile.Updated)
            {
                GameProfile newProfile = editGameProfile.Profile;
                GameProfile selectedItem = (GameProfile) comboProfiles.SelectedItem;
                if (selectedItem.ProfileName != "<New>")
                {
                    selectedItem.Load(newProfile);
                    comboProfiles.Items.Remove(selectedItem);
                    comboProfiles.Items.Add(selectedItem);
                    comboProfiles.SelectedItem = selectedItem;
                }
                else
                {
                    comboProfiles.Items.Add(newProfile);
                    _settings.Profiles = _settings.Profiles.Union(new[] {newProfile}).ToList();
                    comboProfiles.SelectedItem = newProfile;
                }
                _settings.DefaultProfile = newProfile.ProfileName;
                _settings.Save(_configPath);
            }
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = false;
            _selectedItem = (GameProfile) comboProfiles.SelectedItem;
            _settings.DefaultProfile = _selectedItem.ProfileName;
            _settings.Save(_configPath);

            // Form not fully loaded yet
            if (_radioButtons == null)
            {
                return;
            }

            ResetLastBackupsPanel();
            if (_selectedItem.ProfileName != "<New>")
            {
                LoadProfile(_selectedItem);
            }
        }

        private void ResetLastBackupsPanel()
        {
            linkBackup.Visible = true;
            linkBackup.Enabled = false;
            buttonStartStop.Visible = true;
            linkRestore.Enabled = false;
            buttonStartStop.Enabled = false;
            linkSelect.Enabled = false;
            foreach (MetroRadioButton button in _radioButtons)
            {
                button.Visible = false;
            }
            labelNoBackupsFound.Visible = true;
            radioSpecific.Text = @"none";
            radioSpecific.Tag = null;
            radioSpecific.Checked = true;
            labelWarning.Visible = false;

            linkRunGame.Enabled = false;
            linkKillGame.Enabled = false;
            linkOpenBackupsFolder.Enabled = false;
            linkOpenSavesFolder.Enabled = false;
        }

        private void LoadProfile(GameProfile profile)
        {
            if (!Directory.Exists(profile.SavesFolder))
            {
                labelWarning.Visible = true;
                labelWarning.Text = @"Saves Folder not found!";
                return;
            }

            if (!File.Exists(profile.GameExecutable))
            {
                labelWarning.Visible = true;
                labelWarning.Text = @"Game executable not found!";
                return;
            }

            GetRadioButtons(profile);

            linkSelect.Enabled = true;
            buttonStartStop.Visible = true;
            buttonStartStop.Enabled = true;
            linkBackup.Visible = true;
            linkBackup.Enabled = true;
            linkRunGame.Enabled = true;
            linkKillGame.Enabled = true;
            linkOpenBackupsFolder.Enabled = true;
            linkOpenSavesFolder.Enabled = true;

            _logger?.Dispose();
            _logger = _selectedItem.WriteLog ? LoggerHelper.GetLoggerForFolder(BackupFolders.GetBackupsFolder(_selectedItem.ProfileName)) : null;
            Log($"Profile selected {_selectedItem.ProfileName}");
        }

        private void GetRadioButtons(GameProfile profile)
        {
            string[] last = profile.GetBackupsDescending().Take(10).ToArray();

            if (last.Length > 0)
            {
                labelNoBackupsFound.Visible = false;
                for (int i = 0; i < last.Length; i++)
                {
                    string label = BackupFolders.GetLabelFromPath(last[i]);
                    if (label == null)
                    {
                        ResetLastBackupsPanel();
                        labelWarning.Visible = true;
                        labelWarning.Text = @"Backup location corrupted";
                        break;
                    }
                    _radioButtons[i].Text = label;
                    _radioButtons[i].Tag = last[i];
                    _radioButtons[i].Visible = true;
                    _radioButtons[i].Checked = false;
                }
            }
        }

        private void radioLastest_Click(object sender, EventArgs e)
        {
            MetroRadioButton button = (MetroRadioButton) sender;
            if (!button.Checked)
            {
                return;
            }
            linkRestore.Enabled = button.Tag != null;
        }
        private void linkSelect_Click(object sender, EventArgs e)
        {
            Log("Selecting specific backup");
            string backups = _selectedItem.GetBackupsFolder();
            string backup = _selectedItem.GetBackupsDescending().FirstOrDefault();

            CommonOpenFileDialog cofd = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = backup ?? backups
            };
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Log($"Selected {cofd.FileName}");
                string label = BackupFolders.GetLabelFromPath(cofd.FileName);
                if (label != null)
                {
                    Log($"Corresponds to {label}");
                    radioSpecific.Text = label;
                    radioSpecific.Tag = cofd.FileName;
                    radioSpecific.Checked = true;
                }
                else
                {
                    Log("Selected folder path cannot be parsed");
                    MessageBox.Show(this, @"Folder path cannot be parsed", @"Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        private void linkOpenSavesFolder_Click(object sender, EventArgs e)
        {
            Process.Start(_selectedItem.SavesFolder);
        }

        private void linkOpenBackupsFolder_Click(object sender, EventArgs e)
        {
            Process.Start(BackupFolders.GetBackupsFolder(_selectedItem.ProfileName));
        }

        private void linkRunGame_Click(object sender, EventArgs e)
        {
            ProcessStartInfo si = new ProcessStartInfo
            {
                FileName = _selectedItem.GameExecutable,
                // ReSharper disable once AssignNullToNotNullAttribute
                WorkingDirectory = Path.GetDirectoryName(_selectedItem.GameExecutable)
            };
            Process.Start(si);
        }

        private void linkKillGame_Click(object sender, EventArgs e)
        {
            GameProcess.KillProcess(_selectedItem.GameExecutable);
        }

        private void BlockPanel()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
            }
            panelBackups.Enabled = false;
        }
        private void RestorePanel()
        {
            if (!string.IsNullOrEmpty(watcher?.Path))
            {
                watcher.EnableRaisingEvents = true;
            }
            panelBackups.Enabled = true;
        }
        private void linkRestore_Click(object sender, EventArgs e)
        {
            Log("Restore requested");
            string backupToRestore = GetSelectedRadioButton().Tag as string;
            BlockPanel();

            if (_selectedItem.KillBeforeRestore)
            {
                Log("Killing game process");
                GameProcess.KillProcess(_selectedItem.GameExecutable);
            }

            if (!_selectedItem.DontWarnOnRestore && GameProcess.FindProcess(_selectedItem.GameExecutable).Any())
            {
                Log("Warning user that game process is up");
                DialogResult dr = MessageBox.Show(this,
                    @"The game is currently running. It is recommended to quit the game before proceeding. Proceed?",
                    @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (dr == DialogResult.No)
                {
                    Log("User chose not to proceed");
                    RestorePanel();
                    return;
                }
                Log("User chose to proceed");
            }

            Log($"Restoring {backupToRestore}");
            Task.Factory.StartNew(() =>
                {
                    if (_selectedItem.BackupBeforeRestoring)
                    {
                        _selectedItem.MakeBackup(DateTime.Now);
                    }
                    _selectedItem.RestoreBackup(backupToRestore);
                })
                .ContinueWith((x) =>
                {
                    RestorePanel();
                    UpdateRadioButtons();
                    Log("Restore finished");
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void linkBackup_Click(object sender, EventArgs e)
        {
            DoBackup();
        }

        private void DoBackup()
        {
            DateTime now = DateTime.Now;
            Log($"Backing up {now:dd MMM yyyy HH:mm:ss}");
            BlockPanel();
            Task.Factory.StartNew(() => { _selectedItem.MakeBackup(DateTime.Now); })
                .ContinueWith((x) =>
                {
                    RestorePanel();
                    UpdateRadioButtons();
                    Log("Backup finished");
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Log(string message)
        {
            _logger?.Information(message);
        }
    }
}
