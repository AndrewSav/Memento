using System;
using System.Diagnostics;
using Memento.Models;

namespace Memento.Forms
{
    public partial class AdvancedFiltering : MetroFramework.Forms.MetroForm
    {
        public AdvancedFiltering()
        {
            InitializeComponent();
        }
                
        public GameProfile Profile
        {
            get
            {
                return new GameProfile
                {
                    WatchFilter = textWatchFilter.Text.Trim(),
                    BackupFilter = textBackupFilter.Text.Trim(),
                };
            }
            set
            {
                textWatchFilter.Text = value.WatchFilter;
                textBackupFilter.Text = value.BackupFilter;
            }
        }

        public bool Updated { get; private set; }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Updated = true;
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textWatchFilter.Text = string.Empty;
            textBackupFilter.Text = string.Empty;
        }

        private void linkWatcher_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher.filter#remarks",
                UseShellExecute = true
            };
            Process.Start(psi);

        }

        private void linkRegex_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference",
                UseShellExecute = true
            };
            Process.Start(psi);

        }
    }
}
