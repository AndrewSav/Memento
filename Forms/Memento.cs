﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memento.Helpers;
using Memento.Models;
using MetroFramework.Controls;
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
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName);
            linkVersion.Text = $"v{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}";

            if (!File.Exists(_configPath))
            {
                new Settings
                {
                    LogFileName = "log-{Date}.txt",
                    LogRetainedCountLimit = "9",
                    LogSizeLimitBytes = "1000000",
                    StabilizationTimeSeconds = 5,
                    DefaultProfile = "<New>",
                    Profiles = new List<GameProfile>()
                }.Save(_configPath);
            }

            _settings = Settings.Load(_configPath);
            comboProfiles.Items.Add(new GameProfile { ProfileName = "<New>" });
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


        private void SelectNoneBackup()
        {
            radioSpecific.Checked = true;
            radioSpecific.Tag = null;
            radioSpecific.Text =  @"none";
        }

        private void UpdateRadioButtonsInner()
        {
            foreach (MetroRadioButton button in _radioButtons)
            {
                button.Visible = false;
            }
            GetRadioButtons(_selectedItem);

        }
        
        private void UpdateRadioButtons()
        {
            string selectBackup = panelBackups.Controls.OfType<MetroRadioButton>().First(x => x.Checked).Tag as string;
            
            UpdateRadioButtonsInner();
            
            if (selectBackup == null)
            {
                SelectNoneBackup();
                return;
            }
            
            if (!Directory.Exists(selectBackup))
            {
                BackupPath old = BackupPath.FromPath(selectBackup);
                selectBackup = panelBackups.Controls.OfType<MetroRadioButton>().FirstOrDefault(x => x.Visible && x != radioSpecific && old.IsSameIgnoreLabel(BackupPath.FromPath((string)x.Tag)))?.Tag as string;
            }

            if (selectBackup == null)
            {
                SelectNoneBackup();
                return;
            }

            MetroRadioButton selectedRadio = panelBackups.Controls.OfType<MetroRadioButton>().FirstOrDefault(x => x.Tag as string == selectBackup);
            selectedRadio = radioSpecific.Checked ? radioSpecific : selectedRadio ?? radioSpecific;
            selectedRadio.Checked = true;
            selectedRadio.Tag = selectBackup;
            selectedRadio.Text = TrimStringForRadioButton(BackupFolders.GetLabelFromPath(selectBackup) ?? @"none");
            
            if (!radioSpecific.Checked && radioSpecific.Tag != null && BackupPath.FromPath(selectBackup).IsSameIgnoreLabel(BackupPath.FromPath((string)radioSpecific.Tag)))
            {
                radioSpecific.Text = selectedRadio.Text;
                radioSpecific.Tag = selectedRadio.Tag;
            }
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
                editGameProfile.InitialBackupFolder = currentProfile.BackupFolder;
                editGameProfile.ExistingProfileNames = _settings.Profiles.Select(x => x.ProfileName);
                editGameProfile.ExistingBackupFolders = _settings.Profiles.Select(x => x.BackupFolder);
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
            _logger = _selectedItem.WriteLog ? LoggerHelper.GetLoggerForFolder(_selectedItem.GetBackupsFolder()) : null;
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
                    _radioButtons[i].Text = TrimStringForRadioButton(label);
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

            FolderBrowserDialog cofd = new FolderBrowserDialog
            {
                SelectedPath = backup ?? backups
            };
            if (cofd.ShowDialog() == DialogResult.OK)
            {
                Log($"Selected {cofd.SelectedPath}");
                string label = BackupFolders.GetLabelFromPath(cofd.SelectedPath);
                if (label != null)
                {
                    Log($"Corresponds to {label}");
                    radioSpecific.Text = label;
                    radioSpecific.Tag = cofd.SelectedPath;
                    radioSpecific.Checked = true;
                    linkRestore.Enabled = radioSpecific.Tag != null;
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
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = _selectedItem.SavesFolder,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void linkOpenBackupsFolder_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = _selectedItem.GetBackupsFolder(),
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void linkRunGame_Click(object sender, EventArgs e)
        {
            runGame();
        }

        private void runGame()
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
                    if (_selectedItem.DeleteBeforeRestoring)
                    {
                        Log("Deleting old save before restoring");
                        _selectedItem.DeleteSavesFolder();
                    }

                    if (_selectedItem.BackupBeforeRestoring)
                    {
                        _selectedItem.MakeBackup(DateTime.Now);
                    }
                    _selectedItem.RestoreBackup(backupToRestore);
                })
                .ContinueWith((x) =>
                {
                    if (_selectedItem.KillBeforeRestore && !GameProcess.FindProcess(_selectedItem.GameExecutable).Any())
                    {
                        runGame();
                    }

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

        private void linkVersion_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://github.com/AndrewSav/Memento/releases",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MetroContextMenu strip = (MetroContextMenu)sender;
            MetroRadioButton button = (MetroRadioButton)strip.SourceControl;
            if (button.Tag == null)
            {
                e.Cancel = true;
            }
        }

        private void radio_KeyUp(object sender, KeyEventArgs e)
        {
            MetroRadioButton button = (MetroRadioButton)sender;
            if (e.KeyCode == Keys.F2 && button.Tag != null)
            {
                EditSaveName(button);
            }
        }

        private void textBoxSavenameEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                labelWarning.Visible = false;
                textBoxSavenameEdit.Visible = false;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSavenameEdit.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    labelWarning.Visible = true;
                    labelWarning.Text = @"Name cannot have illegal characters!";
                    return;
                }

                labelWarning.Visible = false;
                textBoxSavenameEdit.Visible = false;
                MetroRadioButton button = (MetroRadioButton)textBoxSavenameEdit.Tag;
                string path = (string)button.Tag;
                BackupPath backupPath = BackupPath.FromPath(path);
                                string newPath = backupPath.ApplyLabel(textBoxSavenameEdit.Text).ToString();
                if (string.Compare(
                    Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar), 
                    Path.GetFullPath(newPath).TrimEnd(Path.DirectorySeparatorChar), 
                    StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    Directory.Move(path, newPath);
                    button.Tag = newPath;
                }
                RestorePanel();
                UpdateRadioButtons();
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MetroContextMenu strip = (MetroContextMenu)item.Owner;
            MetroRadioButton button = (MetroRadioButton)strip.SourceControl;

            EditSaveName(button);               
        }

        private void EditSaveName(MetroRadioButton button)
        {
            BlockPanel();
            panelBackups.Enabled = true;
            textBoxSavenameEdit.Tag = button;
            textBoxSavenameEdit.Text = BackupFolders.GetLabelFromPath((string)button.Tag);
            textBoxSavenameEdit.Location = new Point(button.Location.X + 20, button.Location.Y);
            textBoxSavenameEdit.Visible = true;
            textBoxSavenameEdit.Select();
        }

        private void textBoxSaveEdit_Leave(object sender, EventArgs e)
        {
            labelWarning.Visible = false;
            textBoxSavenameEdit.Visible = false;
        }

        private string TrimStringForRadioButton(string s)
        {
            string elipsis = "...";
            Graphics g = radioSpecific.CreateGraphics();
            float limit = 138;
            float elipsisLenght = g.MeasureString(elipsis, radioSpecific.Font).Width;
            if (g.MeasureString(s, radioSpecific.Font).Width <= limit)
            {
                return s;
            }
            do
            {
                s = s.Substring(0, s.Length - 1);
            } while ((g.MeasureString(s, radioSpecific.Font).Width > limit - elipsisLenght));

            return s + elipsis;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlockPanel();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MetroContextMenu strip = (MetroContextMenu)item.Owner;
            MetroRadioButton button = (MetroRadioButton)strip.SourceControl;

            Directory.Delete((string)button.Tag,true);

            RestorePanel();
            UpdateRadioButtons();
        }
    }
}
