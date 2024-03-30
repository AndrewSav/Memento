using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
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
        private const string tagRunning = "Running";

        private Settings _settings;
        private readonly string _configPath = Path.Combine(BackupFolders.GetBaseFolder(), "settings.json");
        private List<MetroRadioButton> _radioButtons;
        private IDisposable _watcherObservableDisposable;
        private GameProfile _selectedItem;
        private Logger _logger;

        public Memento()
        {
            InitializeComponent();

            LoadSettings();
        }
        private void LoadSettings()
        {
            if (!File.Exists(_configPath))
            {
                var defaultSettings = new Settings
                {
                    LogFileName = "log.txt",
                    LogRetainedCountLimit = "9",
                    LogSizeLimitBytes = "1000000",
                    StabilizationTimeSeconds = 5,
                    DefaultProfile = "<New>",
                    Profiles = new List<GameProfile>()
                };
                defaultSettings.Save(_configPath);
            }
            _settings = Settings.Load(_configPath);
        }

        private void Memento_Load(object sender, EventArgs e)
        {
            DisplayVersion();
            PopulateProfilesDropdown();
            SelectDefaultProfile();
            InitializeRadioButtons();
        }
        private void DisplayVersion()
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Environment.ProcessPath);
            linkVersion.Text = $"v{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}";
        }

        private void PopulateProfilesDropdown()
        {
            comboProfiles.Items.Add(new GameProfile { ProfileName = "<New>" });
            foreach (GameProfile gameProfile in _settings.Profiles)
            {
                comboProfiles.Items.Add(gameProfile);
            }
        }

        private void SelectDefaultProfile()
        {
            GameProfile selected = _settings.Profiles.FirstOrDefault(x => x.ProfileName == _settings.DefaultProfile) ?? comboProfiles.Items[0] as GameProfile;
            comboProfiles.SelectedItem = selected;
        }

        private void InitializeRadioButtons()
        {
            _radioButtons = panelBackups.Controls.OfType<MetroRadioButton>().Where(x => x.Name != "radioSpecific").ToList();
            _radioButtons.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            comboProfiles_SelectedIndexChanged(comboProfiles, EventArgs.Empty);
        }

        private void StopWatching()
        {
            Log("Stopping watching");
            CleanUpWatcher();
            UpdateUIForWatchingState(false);
        }

        private void UpdateUIForWatchingState(bool isWatching)
        {
            buttonStartStop.Text = isWatching ? @"Stop watching" : @"Start watching";
            buttonStartStop.Tag = isWatching ? tagRunning : null;
            ToggleUIEnabled(!isWatching);
        }

        private void ToggleUIEnabled(bool enabled)
        {
            linkBackup.Enabled = enabled;
            comboProfiles.Enabled = enabled;
            buttonEdit.Enabled = enabled;
        }

        private void StartWatching()
        {
            Log("Starting watching");
            if (_selectedItem.BackupOnStartWatching)
            {
                DoBackup();
            }

            SetupFileSystemWatcher();
            SetUpObservables();
            UpdateUIForWatchingState(true);
        }

        private void SetUpObservables()
        {
            var observables = new List<IObservable<EventPattern<FileSystemEventArgs>>>
            {
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                    handler => watcher.Changed += handler,
                    handler => watcher.Changed -= handler),
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                    handler => watcher.Created += handler,
                    handler => watcher.Created -= handler),
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                    handler => watcher.Deleted += handler,
                    handler => watcher.Deleted -= handler),
                Observable.FromEventPattern<RenamedEventHandler, RenamedEventArgs>(
                    handler => watcher.Renamed += handler,
                    handler => watcher.Renamed -= handler).Select(pattern => new EventPattern<FileSystemEventArgs>(pattern.Sender, pattern.EventArgs))
            };

            _watcherObservableDisposable = Observable.Merge(observables)
                .Where(evt =>
                {
                    var fileName = evt.EventArgs.Name;
                    if (string.IsNullOrEmpty(_selectedItem.BackupFilter) || string.IsNullOrEmpty(fileName)) return true;
                    bool ok = Regex.IsMatch(fileName, _selectedItem.BackupFilter);
                    if (!ok)
                    {
                        Log($"Suppressing change not matching backup filter: {evt.EventArgs.ChangeType} {fileName}");
                    }
                    return ok;
                })
                .Throttle(TimeSpan.FromSeconds(_settings.StabilizationTimeSeconds))
                .Subscribe(evt =>
                {
                    DateTime now = DateTime.Now;
                    Log($"Save change detected. {now:HH:mm:ss} {evt.EventArgs.ChangeType} {evt.EventArgs.Name}");
                    if (_selectedItem.MinimumBackupInterval > 0)
                    {
                        DateTime? z = Invoke(GetLastSaveTime);
                        if (z != null)
                        {
                            TimeSpan interval = DateTime.Now - z.Value;
                            if (_selectedItem.MinimumBackupInterval != 0 &&
                                interval.TotalMinutes < _selectedItem.MinimumBackupInterval)
                            {
                                Log($"Skipping backup. Last one was {(int)interval.TotalMinutes} minutes ago, which is less than {_selectedItem.MinimumBackupInterval} minutes");
                                return;
                            }
                        }
                    }
                    RunMakeBackup(_selectedItem, now);
                    Invoke(UpdateRadioButtons);
                    Log("Finished automated backup");
                });
        }

        private void SetupFileSystemWatcher()
        {
            watcher = new FileSystemWatcher(_selectedItem.GetSavesFolder())
            {
                IncludeSubdirectories = _selectedItem.WatchSubdirectories,
                Filter = string.IsNullOrEmpty(_selectedItem.WatchFilter) ? "*" : _selectedItem.WatchFilter,
                EnableRaisingEvents = true
            };
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {            
            CleanUpWatcher();
            if (buttonStartStop.Tag as string == tagRunning)
            {
                StopWatching();
            }
            else
            {
                StartWatching();
            }
        }

        private void RunMakeBackup(GameProfile profile, DateTime x)
        {
            int n = profile.MakeBackup(x);
            Invoke(SetBackupLabel, n, x);
        }

        private void SetBackupLabel(int n, DateTime x)
        {
            if (n >= 0 && _selectedItem.ShowNumberOfFiles)
            {
                labelBackup.Text = $"{n} files backed up {BackupPath.LabelFromTimestamp(x)}";
                labelBackup.Visible = true;
            }
            else
            {
                labelBackup.Visible = false;
            }
        }

        private void SelectNoneBackup()
        {
            radioSpecific.Checked = true;
            radioSpecific.Tag = null;
            radioSpecific.Text = @"none";
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
            object tag = panelBackups.Controls.OfType<MetroRadioButton>().First(x => x.Checked).Tag;

            UpdateRadioButtonsInner();

            if (tag is not string selectBackup)
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
            EditGameProfile editGameProfile = new();
            if (comboProfiles.SelectedItem is GameProfile currentProfile)
            {
                editGameProfile.Profile = currentProfile;
                editGameProfile.InitialProfileName = currentProfile.ProfileName;
                editGameProfile.InitialBackupFolder = currentProfile.BackupFolder;
                editGameProfile.ExistingProfileNames = _settings.Profiles.Select(x => x.ProfileName);
                editGameProfile.ExistingBackupFolders = _settings.Profiles.Select(x => x.BackupFolder);
            }

            editGameProfile.ShowDialog(this);

            if (editGameProfile.Deleted && ((GameProfile)comboProfiles.SelectedItem).ProfileName != "<New>")
            {
                _settings.Profiles = _settings.Profiles.Where(x => x != comboProfiles.SelectedItem).ToList();
                comboProfiles.Items.Remove(comboProfiles.SelectedItem);
                _settings.Save(_configPath);
                comboProfiles.SelectedIndex = comboProfiles.Items.Count > 1 ? 1 : 0;
            }

            if (editGameProfile.Updated)
            {
                GameProfile newProfile = editGameProfile.Profile;
                GameProfile selectedItem = (GameProfile)comboProfiles.SelectedItem;
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
                    _settings.Profiles = _settings.Profiles.Union(new[] { newProfile }).ToList();
                    comboProfiles.SelectedItem = newProfile;
                }
                _settings.DefaultProfile = newProfile.ProfileName;
                _settings.Save(_configPath);
            }
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = false;
            labelBackup.Visible = false;
            _selectedItem = (GameProfile)comboProfiles.SelectedItem;
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
            labelBackup.Visible = false;

            linkRunGame.Enabled = false;
            linkKillGame.Enabled = false;
            linkOpenBackupFolder.Enabled = false;
            linkOpenSavesFolder.Enabled = false;
        }

        private void LoadProfile(GameProfile profile)
        {
            if (!Directory.Exists(profile.GetSavesFolder()))
            {
                labelWarning.Visible = true;
                labelWarning.Text = @"Saves Folder not found!";
                return;
            }

            if (!File.Exists(profile.GetGameExecutable()))
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
            linkOpenBackupFolder.Enabled = true;
            linkOpenSavesFolder.Enabled = true;

            _logger?.Dispose();
            _logger = _selectedItem.WriteLog ? LoggerHelper.GetLoggerForFolder(_selectedItem.GetBackupFolder()) : null;
            Log($"Profile selected {_selectedItem.ProfileName}");
        }

        private DateTime? GetLastSaveTime()
        {
            if (_radioButtons[0].Tag is not string tag) return null;
            MatchCollection matches = DateTimeFromBackupPath().Matches(tag);
            if (matches.Count == 0) return null;
            Match match = matches[^1];
            return new DateTime(
                int.Parse(match.Groups["year"].Value),
                int.Parse(match.Groups["month"].Value),
                int.Parse(match.Groups["day"].Value),
                int.Parse(match.Groups["hour"].Value),
                int.Parse(match.Groups["minute"].Value),
                int.Parse(match.Groups["second"].Value)
            );
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
            MetroRadioButton button = (MetroRadioButton)sender;
            if (!button.Checked)
            {
                return;
            }
            linkRestore.Enabled = button.Tag != null;
        }

        private void linkSelect_Click(object sender, EventArgs e)
        {
            Log("Selecting specific backup");
            string backups = _selectedItem.GetBackupFolder();
            string backup = _selectedItem.GetBackupsDescending().FirstOrDefault();

            FolderBrowserDialog cofd = new()
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
            ProcessStartInfo psi = new()
            {
                FileName = _selectedItem.GetSavesFolder(),
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void linkOpenBackupFolder_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new()
            {
                FileName = _selectedItem.GetBackupFolder(),
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void linkRunGame_Click(object sender, EventArgs e)
        {
            RunGame();
        }

        private void RunGame()
        {
            ProcessStartInfo si = new()
            {
                FileName = _selectedItem.GetGameExecutable(),
                // ReSharper disable once AssignNullToNotNullAttribute
                WorkingDirectory = Path.GetDirectoryName(_selectedItem.GetGameExecutable())
            };
            Process.Start(si);
        }

        private void linkKillGame_Click(object sender, EventArgs e)
        {
            GameProcess.KillProcess(_selectedItem.GetGameExecutable());
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
                GameProcess.KillProcess(_selectedItem.GetGameExecutable());
            }

            if (!_selectedItem.DontWarnOnRestore && GameProcess.FindProcess(_selectedItem.GetGameExecutable()).Any())
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
                        Log("Backing up before restoring");
                        RunMakeBackup(_selectedItem, DateTime.Now);
                    }
                    _selectedItem.RestoreBackup(backupToRestore);
                })
                .ContinueWith((x) =>
                {
                    if (_selectedItem.KillBeforeRestore && !GameProcess.FindProcess(_selectedItem.GetGameExecutable()).Any())
                    {
                        RunGame();
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
            Task.Factory.StartNew(() => { RunMakeBackup(_selectedItem, DateTime.Now); })
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
            ProcessStartInfo psi = new()
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
                s = s[..^1];
            } while ((g.MeasureString(s, radioSpecific.Font).Width > limit - elipsisLenght));

            return s + elipsis;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_selectedItem.DeleteWithoutConfirmation)
            {
                DialogResult dr = MessageBox.Show(this, "Confirm deletion, please!", "Deleting Backup", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
            BlockPanel();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MetroContextMenu strip = (MetroContextMenu)item.Owner;
            MetroRadioButton button = (MetroRadioButton)strip.SourceControl;

            string timeFolder = (string)button.Tag;
            SetAttributesNormal(new DirectoryInfo(timeFolder));
            Directory.Delete(timeFolder, true);
            string dayFolder = Path.GetDirectoryName(timeFolder);
            if (Directory.GetDirectories(dayFolder).Length == 0)
            {
                SetAttributesNormal(new DirectoryInfo(dayFolder));
                Directory.Delete(dayFolder, true);
            }
            string monthFolder = Path.GetDirectoryName(dayFolder);
            if (Directory.GetDirectories(monthFolder).Length == 0)
            {
                SetAttributesNormal(new DirectoryInfo(monthFolder));
                Directory.Delete(monthFolder, true);
            }

            RestorePanel();
            UpdateRadioButtons();
        }
        private static void SetAttributesNormal(DirectoryInfo path)
        {
            Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>();
            dirs.Enqueue(path);
            while (dirs.Count > 0)
            {
                var dir = dirs.Dequeue();
                dir.Attributes = FileAttributes.Normal;
                Parallel.ForEach(dir.EnumerateFiles(), e => e.Attributes = FileAttributes.Normal);
                foreach (var subDir in dir.GetDirectories())
                    dirs.Enqueue(subDir);
            }
        }

        [GeneratedRegex(@"(?<year>\d{4})-(?<month>\d{2})\\(?<day>\d{2})\\(?<hour>\d{2})\.(?<minute>\d{2})\.(?<second>\d{2})(?:$|[^\d])")]
        private static partial Regex DateTimeFromBackupPath();

        private void buttonCloneProfile_Click(object sender, EventArgs e)
        {
            if (comboProfiles.SelectedItem is GameProfile currentProfile)
            {
                var clonedProfile = currentProfile.Clone();

                EditGameProfile editGameProfileForm = new EditGameProfile
                {
                    Profile = clonedProfile,
                    IsCloning = true,
                    ExistingProfileNames = _settings.Profiles.Select(x => x.ProfileName).ToList(),
                    ExistingBackupFolders = _settings.Profiles.Select(x => x.BackupFolder).ToList()
                };

                
                var dialogResult = editGameProfileForm.ShowDialog(this);

                
                if (editGameProfileForm.Updated)
                {
                    _settings.Profiles.Add(editGameProfileForm.Profile);
                    
                    comboProfiles.Items.Add(editGameProfileForm.Profile);
                    comboProfiles.SelectedItem = editGameProfileForm.Profile;
                    
                    _settings.Save(_configPath);
                }
            }
            else
            {
                MessageBox.Show("Please select a profile to clone.", "No Profile Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
