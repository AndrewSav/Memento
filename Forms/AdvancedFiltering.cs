using System;
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
    }
}
