namespace Memento.Forms
{
    partial class Memento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.comboProfiles = new MetroFramework.Controls.MetroComboBox();
            this.radioSpecific = new MetroFramework.Controls.MetroRadioButton();
            this.radio02 = new MetroFramework.Controls.MetroRadioButton();
            this.radio01 = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.buttonStartStop = new MetroFramework.Controls.MetroButton();
            this.labelSelectGameProfile = new MetroFramework.Controls.MetroLabel();
            this.labelWarning = new MetroFramework.Controls.MetroLabel();
            this.panelBackups = new MetroFramework.Controls.MetroPanel();
            this.linkSelect = new MetroFramework.Controls.MetroLink();
            this.linkRestore = new MetroFramework.Controls.MetroLink();
            this.linkBackup = new MetroFramework.Controls.MetroLink();
            this.radio06 = new MetroFramework.Controls.MetroRadioButton();
            this.labelNoBackupsFound = new MetroFramework.Controls.MetroLabel();
            this.radio10 = new MetroFramework.Controls.MetroRadioButton();
            this.radio09 = new MetroFramework.Controls.MetroRadioButton();
            this.radio08 = new MetroFramework.Controls.MetroRadioButton();
            this.radio07 = new MetroFramework.Controls.MetroRadioButton();
            this.radio05 = new MetroFramework.Controls.MetroRadioButton();
            this.radio04 = new MetroFramework.Controls.MetroRadioButton();
            this.radio03 = new MetroFramework.Controls.MetroRadioButton();
            this.buttonEdit = new MetroFramework.Controls.MetroButton();
            this.linkOpenBackupsFolder = new MetroFramework.Controls.MetroLink();
            this.linkOpenSavesFolder = new MetroFramework.Controls.MetroLink();
            this.linkSettings = new MetroFramework.Controls.MetroLink();
            this.linkRunGame = new MetroFramework.Controls.MetroLink();
            this.linkKillGame = new MetroFramework.Controls.MetroLink();
            this.watcher = new System.IO.FileSystemWatcher();
            this.panelBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // comboProfiles
            // 
            this.comboProfiles.ItemHeight = 23;
            this.comboProfiles.Location = new System.Drawing.Point(23, 82);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(426, 29);
            this.comboProfiles.Sorted = true;
            this.comboProfiles.TabIndex = 0;
            this.comboProfiles.UseSelectable = true;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // radioSpecific
            // 
            this.radioSpecific.AutoSize = true;
            this.radioSpecific.Checked = true;
            this.radioSpecific.Location = new System.Drawing.Point(323, 31);
            this.radioSpecific.Name = "radioSpecific";
            this.radioSpecific.Size = new System.Drawing.Size(50, 15);
            this.radioSpecific.TabIndex = 10;
            this.radioSpecific.TabStop = true;
            this.radioSpecific.Text = "none";
            this.radioSpecific.UseSelectable = true;
            this.radioSpecific.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio02
            // 
            this.radio02.AutoSize = true;
            this.radio02.Location = new System.Drawing.Point(20, 52);
            this.radio02.Name = "radio02";
            this.radio02.Size = new System.Drawing.Size(62, 15);
            this.radio02.TabIndex = 1;
            this.radio02.Text = "radio02";
            this.radio02.UseSelectable = true;
            this.radio02.Visible = false;
            this.radio02.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio01
            // 
            this.radio01.AutoSize = true;
            this.radio01.Location = new System.Drawing.Point(20, 31);
            this.radio01.Name = "radio01";
            this.radio01.Size = new System.Drawing.Size(62, 15);
            this.radio01.TabIndex = 0;
            this.radio01.Text = "radio01";
            this.radio01.UseSelectable = true;
            this.radio01.Visible = false;
            this.radio01.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(312, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(102, 19);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Specific Backup:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(96, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Latest Backups:";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Enabled = false;
            this.buttonStartStop.Location = new System.Drawing.Point(23, 117);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(99, 29);
            this.buttonStartStop.TabIndex = 2;
            this.buttonStartStop.Text = "Start Watching";
            this.buttonStartStop.UseSelectable = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelSelectGameProfile
            // 
            this.labelSelectGameProfile.AutoSize = true;
            this.labelSelectGameProfile.Location = new System.Drawing.Point(23, 60);
            this.labelSelectGameProfile.Name = "labelSelectGameProfile";
            this.labelSelectGameProfile.Size = new System.Drawing.Size(127, 19);
            this.labelSelectGameProfile.TabIndex = 22;
            this.labelSelectGameProfile.Text = "Select Game Profile:";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(23, 342);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(58, 19);
            this.labelWarning.TabIndex = 23;
            this.labelWarning.Text = "Warning";
            this.labelWarning.UseCustomForeColor = true;
            this.labelWarning.Visible = false;
            // 
            // panelBackups
            // 
            this.panelBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackups.Controls.Add(this.linkSelect);
            this.panelBackups.Controls.Add(this.linkRestore);
            this.panelBackups.Controls.Add(this.linkBackup);
            this.panelBackups.Controls.Add(this.radio06);
            this.panelBackups.Controls.Add(this.labelNoBackupsFound);
            this.panelBackups.Controls.Add(this.radio10);
            this.panelBackups.Controls.Add(this.radio09);
            this.panelBackups.Controls.Add(this.radio08);
            this.panelBackups.Controls.Add(this.radio07);
            this.panelBackups.Controls.Add(this.metroLabel1);
            this.panelBackups.Controls.Add(this.metroLabel2);
            this.panelBackups.Controls.Add(this.radio01);
            this.panelBackups.Controls.Add(this.radio05);
            this.panelBackups.Controls.Add(this.radio04);
            this.panelBackups.Controls.Add(this.radio03);
            this.panelBackups.Controls.Add(this.radio02);
            this.panelBackups.Controls.Add(this.radioSpecific);
            this.panelBackups.HorizontalScrollbarBarColor = true;
            this.panelBackups.HorizontalScrollbarHighlightOnWheel = false;
            this.panelBackups.HorizontalScrollbarSize = 10;
            this.panelBackups.Location = new System.Drawing.Point(23, 152);
            this.panelBackups.Name = "panelBackups";
            this.panelBackups.Size = new System.Drawing.Size(468, 162);
            this.panelBackups.TabIndex = 4;
            this.panelBackups.VerticalScrollbarBarColor = true;
            this.panelBackups.VerticalScrollbarHighlightOnWheel = false;
            this.panelBackups.VerticalScrollbarSize = 10;
            // 
            // linkSelect
            // 
            this.linkSelect.Enabled = false;
            this.linkSelect.Location = new System.Drawing.Point(304, 52);
            this.linkSelect.Name = "linkSelect";
            this.linkSelect.Size = new System.Drawing.Size(110, 23);
            this.linkSelect.TabIndex = 24;
            this.linkSelect.Text = "Select specific";
            this.linkSelect.UseSelectable = true;
            this.linkSelect.Click += new System.EventHandler(this.linkSelect_Click);
            // 
            // linkRestore
            // 
            this.linkRestore.Enabled = false;
            this.linkRestore.Location = new System.Drawing.Point(92, 136);
            this.linkRestore.Name = "linkRestore";
            this.linkRestore.Size = new System.Drawing.Size(131, 19);
            this.linkRestore.TabIndex = 24;
            this.linkRestore.Text = "Restore";
            this.linkRestore.UseSelectable = true;
            this.linkRestore.Click += new System.EventHandler(this.linkRestore_Click);
            // 
            // linkBackup
            // 
            this.linkBackup.Enabled = false;
            this.linkBackup.Location = new System.Drawing.Point(3, 134);
            this.linkBackup.Name = "linkBackup";
            this.linkBackup.Size = new System.Drawing.Size(83, 23);
            this.linkBackup.TabIndex = 24;
            this.linkBackup.Text = "Backup";
            this.linkBackup.UseSelectable = true;
            this.linkBackup.Click += new System.EventHandler(this.linkBackup_Click);
            // 
            // radio06
            // 
            this.radio06.AutoSize = true;
            this.radio06.Location = new System.Drawing.Point(166, 31);
            this.radio06.Name = "radio06";
            this.radio06.Size = new System.Drawing.Size(62, 15);
            this.radio06.TabIndex = 5;
            this.radio06.Text = "radio06";
            this.radio06.UseSelectable = true;
            this.radio06.Visible = false;
            this.radio06.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // labelNoBackupsFound
            // 
            this.labelNoBackupsFound.AutoSize = true;
            this.labelNoBackupsFound.Location = new System.Drawing.Point(20, 31);
            this.labelNoBackupsFound.Name = "labelNoBackupsFound";
            this.labelNoBackupsFound.Size = new System.Drawing.Size(116, 19);
            this.labelNoBackupsFound.TabIndex = 23;
            this.labelNoBackupsFound.Text = "No backups found";
            // 
            // radio10
            // 
            this.radio10.AutoSize = true;
            this.radio10.Location = new System.Drawing.Point(166, 115);
            this.radio10.Name = "radio10";
            this.radio10.Size = new System.Drawing.Size(62, 15);
            this.radio10.TabIndex = 9;
            this.radio10.Text = "radio10";
            this.radio10.UseSelectable = true;
            this.radio10.Visible = false;
            this.radio10.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio09
            // 
            this.radio09.AutoSize = true;
            this.radio09.Location = new System.Drawing.Point(166, 94);
            this.radio09.Name = "radio09";
            this.radio09.Size = new System.Drawing.Size(62, 15);
            this.radio09.TabIndex = 8;
            this.radio09.Text = "radio09";
            this.radio09.UseSelectable = true;
            this.radio09.Visible = false;
            this.radio09.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio08
            // 
            this.radio08.AutoSize = true;
            this.radio08.Location = new System.Drawing.Point(166, 73);
            this.radio08.Name = "radio08";
            this.radio08.Size = new System.Drawing.Size(62, 15);
            this.radio08.TabIndex = 7;
            this.radio08.Text = "radio08";
            this.radio08.UseSelectable = true;
            this.radio08.Visible = false;
            this.radio08.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio07
            // 
            this.radio07.AutoSize = true;
            this.radio07.Location = new System.Drawing.Point(166, 52);
            this.radio07.Name = "radio07";
            this.radio07.Size = new System.Drawing.Size(62, 15);
            this.radio07.TabIndex = 6;
            this.radio07.Text = "radio07";
            this.radio07.UseSelectable = true;
            this.radio07.Visible = false;
            this.radio07.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio05
            // 
            this.radio05.AutoSize = true;
            this.radio05.Location = new System.Drawing.Point(20, 115);
            this.radio05.Name = "radio05";
            this.radio05.Size = new System.Drawing.Size(62, 15);
            this.radio05.TabIndex = 4;
            this.radio05.Text = "radio05";
            this.radio05.UseSelectable = true;
            this.radio05.Visible = false;
            this.radio05.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio04
            // 
            this.radio04.AutoSize = true;
            this.radio04.Location = new System.Drawing.Point(20, 94);
            this.radio04.Name = "radio04";
            this.radio04.Size = new System.Drawing.Size(62, 15);
            this.radio04.TabIndex = 3;
            this.radio04.Text = "radio04";
            this.radio04.UseSelectable = true;
            this.radio04.Visible = false;
            this.radio04.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // radio03
            // 
            this.radio03.AutoSize = true;
            this.radio03.Location = new System.Drawing.Point(20, 73);
            this.radio03.Name = "radio03";
            this.radio03.Size = new System.Drawing.Size(62, 15);
            this.radio03.TabIndex = 2;
            this.radio03.Text = "radio03";
            this.radio03.UseSelectable = true;
            this.radio03.Visible = false;
            this.radio03.Click += new System.EventHandler(this.radioLastest_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(466, 85);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(25, 29);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "...";
            this.buttonEdit.UseSelectable = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // linkOpenBackupsFolder
            // 
            this.linkOpenBackupsFolder.Location = new System.Drawing.Point(149, 316);
            this.linkOpenBackupsFolder.Name = "linkOpenBackupsFolder";
            this.linkOpenBackupsFolder.Size = new System.Drawing.Size(131, 23);
            this.linkOpenBackupsFolder.TabIndex = 24;
            this.linkOpenBackupsFolder.Text = "Open Backups Folder";
            this.linkOpenBackupsFolder.UseSelectable = true;
            this.linkOpenBackupsFolder.Click += new System.EventHandler(this.linkOpenBackupsFolder_Click);
            // 
            // linkOpenSavesFolder
            // 
            this.linkOpenSavesFolder.Location = new System.Drawing.Point(23, 316);
            this.linkOpenSavesFolder.Name = "linkOpenSavesFolder";
            this.linkOpenSavesFolder.Size = new System.Drawing.Size(131, 23);
            this.linkOpenSavesFolder.TabIndex = 24;
            this.linkOpenSavesFolder.Text = "Open Saves Folder";
            this.linkOpenSavesFolder.UseSelectable = true;
            this.linkOpenSavesFolder.Click += new System.EventHandler(this.linkOpenSavesFolder_Click);
            // 
            // linkSettings
            // 
            this.linkSettings.Location = new System.Drawing.Point(346, 56);
            this.linkSettings.Name = "linkSettings";
            this.linkSettings.Size = new System.Drawing.Size(131, 23);
            this.linkSettings.TabIndex = 24;
            this.linkSettings.Text = "Settings";
            this.linkSettings.UseSelectable = true;
            this.linkSettings.Click += new System.EventHandler(this.linkSettings_Click);
            // 
            // linkRunGame
            // 
            this.linkRunGame.Enabled = false;
            this.linkRunGame.Location = new System.Drawing.Point(286, 316);
            this.linkRunGame.Name = "linkRunGame";
            this.linkRunGame.Size = new System.Drawing.Size(81, 23);
            this.linkRunGame.TabIndex = 24;
            this.linkRunGame.Text = "Run Game";
            this.linkRunGame.UseSelectable = true;
            this.linkRunGame.Click += new System.EventHandler(this.linkRunGame_Click);
            // 
            // linkKillGame
            // 
            this.linkKillGame.Enabled = false;
            this.linkKillGame.Location = new System.Drawing.Point(357, 316);
            this.linkKillGame.Name = "linkKillGame";
            this.linkKillGame.Size = new System.Drawing.Size(81, 23);
            this.linkKillGame.TabIndex = 24;
            this.linkKillGame.Text = "Kill Game";
            this.linkKillGame.UseSelectable = true;
            this.linkKillGame.Click += new System.EventHandler(this.linkKillGame_Click);
            // 
            // watcher
            // 
            this.watcher.EnableRaisingEvents = true;
            this.watcher.SynchronizingObject = this;
            // 
            // Memento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(514, 373);
            this.Controls.Add(this.linkOpenSavesFolder);
            this.Controls.Add(this.linkSettings);
            this.Controls.Add(this.linkKillGame);
            this.Controls.Add(this.linkRunGame);
            this.Controls.Add(this.linkOpenBackupsFolder);
            this.Controls.Add(this.panelBackups);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.labelSelectGameProfile);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.comboProfiles);
            this.MaximizeBox = false;
            this.Name = "Memento";
            this.Resizable = false;
            this.Text = "Memento";
            this.Load += new System.EventHandler(this.Memento_Load);
            this.panelBackups.ResumeLayout(false);
            this.panelBackups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroComboBox comboProfiles;
        private MetroFramework.Controls.MetroRadioButton radioSpecific;
        private MetroFramework.Controls.MetroRadioButton radio02;
        private MetroFramework.Controls.MetroRadioButton radio01;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton buttonStartStop;
        private MetroFramework.Controls.MetroLabel labelSelectGameProfile;
        private MetroFramework.Controls.MetroLabel labelWarning;
        private MetroFramework.Controls.MetroPanel panelBackups;
        private MetroFramework.Controls.MetroRadioButton radio06;
        private MetroFramework.Controls.MetroRadioButton radio10;
        private MetroFramework.Controls.MetroRadioButton radio09;
        private MetroFramework.Controls.MetroRadioButton radio08;
        private MetroFramework.Controls.MetroRadioButton radio07;
        private MetroFramework.Controls.MetroRadioButton radio05;
        private MetroFramework.Controls.MetroRadioButton radio04;
        private MetroFramework.Controls.MetroRadioButton radio03;
        private MetroFramework.Controls.MetroLabel labelNoBackupsFound;
        private MetroFramework.Controls.MetroButton buttonEdit;
        private MetroFramework.Controls.MetroLink linkOpenBackupsFolder;
        private MetroFramework.Controls.MetroLink linkOpenSavesFolder;
        private MetroFramework.Controls.MetroLink linkSettings;
        private MetroFramework.Controls.MetroLink linkRunGame;
        private MetroFramework.Controls.MetroLink linkSelect;
        private MetroFramework.Controls.MetroLink linkRestore;
        private MetroFramework.Controls.MetroLink linkBackup;
        private MetroFramework.Controls.MetroLink linkKillGame;
        private System.IO.FileSystemWatcher watcher;
    }
}

