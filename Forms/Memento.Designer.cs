using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memento));
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.comboProfiles = new MetroFramework.Controls.MetroComboBox();
            this.radioSpecific = new MetroFramework.Controls.MetroRadioButton();
            this.radio02 = new MetroFramework.Controls.MetroRadioButton();
            this.radio01 = new MetroFramework.Controls.MetroRadioButton();
            this.labelSpecificBackup = new MetroFramework.Controls.MetroLabel();
            this.labelLatestBackups = new MetroFramework.Controls.MetroLabel();
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
            this.contextMenuStrip = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonEdit = new MetroFramework.Controls.MetroButton();
            this.linkOpenBackupsFolder = new MetroFramework.Controls.MetroLink();
            this.linkOpenSavesFolder = new MetroFramework.Controls.MetroLink();
            this.linkRunGame = new MetroFramework.Controls.MetroLink();
            this.linkKillGame = new MetroFramework.Controls.MetroLink();
            this.watcher = new System.IO.FileSystemWatcher();
            this.linkVersion = new MetroFramework.Controls.MetroLink();
            this.textBoxSaveEdit = new MetroFramework.Controls.MetroTextBox();
            this.contextMenuStrip.SuspendLayout();
            this.panelBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem, 
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.radioSpecific.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radioSpecific.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio02.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio01.ContextMenuStrip = this.contextMenuStrip;
            // 
            // labelSpecificBackup
            // 
            this.labelSpecificBackup.AutoSize = true;
            this.labelSpecificBackup.Location = new System.Drawing.Point(312, 9);
            this.labelSpecificBackup.Name = "labelSpecificBackup";
            this.labelSpecificBackup.Size = new System.Drawing.Size(102, 19);
            this.labelSpecificBackup.TabIndex = 14;
            this.labelSpecificBackup.Text = "Specific Backup:";
            // 
            // labelLatestBackups
            // 
            this.labelLatestBackups.AutoSize = true;
            this.labelLatestBackups.Location = new System.Drawing.Point(3, 9);
            this.labelLatestBackups.Name = "labelLatestBackups";
            this.labelLatestBackups.Size = new System.Drawing.Size(96, 19);
            this.labelLatestBackups.TabIndex = 15;
            this.labelLatestBackups.Text = "Latest Backups:";
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
            this.panelBackups.Controls.Add(this.textBoxSaveEdit);
            this.panelBackups.Controls.Add(this.linkSelect);
            this.panelBackups.Controls.Add(this.linkRestore);
            this.panelBackups.Controls.Add(this.linkBackup);
            this.panelBackups.Controls.Add(this.radio06);
            this.panelBackups.Controls.Add(this.labelNoBackupsFound);
            this.panelBackups.Controls.Add(this.radio10);
            this.panelBackups.Controls.Add(this.radio09);
            this.panelBackups.Controls.Add(this.radio08);
            this.panelBackups.Controls.Add(this.radio07);
            this.panelBackups.Controls.Add(this.labelLatestBackups);
            this.panelBackups.Controls.Add(this.labelSpecificBackup);
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
            this.radio06.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio06.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio10.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio09.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio09.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio09.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio08.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio07.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio07.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio05.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio05.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio04.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio04.ContextMenuStrip = this.contextMenuStrip;
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
            this.radio03.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radioLastest_KeyUp);
            this.radio03.ContextMenuStrip = this.contextMenuStrip;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(466, 80);
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
            // linkVersion
            // 
            this.linkVersion.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.linkVersion.Location = new System.Drawing.Point(432, 345);
            this.linkVersion.Name = "linkVersion";
            this.linkVersion.Size = new System.Drawing.Size(81, 23);
            this.linkVersion.TabIndex = 24;
            this.linkVersion.Text = "v00.00.00";
            this.linkVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.linkVersion.UseSelectable = true;
            this.linkVersion.Click += new System.EventHandler(this.linkVersion_Click);
            // 
            // textBoxSaveEdit
            // 
            this.textBoxSaveEdit.Location = new System.Drawing.Point(100, 100);
            this.textBoxSaveEdit.Name = "textBoxSaveEdit";
            this.textBoxSaveEdit.Size = new System.Drawing.Size(120, 20);
            this.textBoxSaveEdit.Visible = false;
            this.textBoxSaveEdit.Leave += new System.EventHandler(this.textBoxSaveEdit_Leave);
            this.textBoxSaveEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSaveEdit_KeyUp);
            // 
            // Memento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(514, 373);
            this.Controls.Add(this.linkOpenSavesFolder);
            this.Controls.Add(this.linkVersion);
            this.Controls.Add(this.linkKillGame);
            this.Controls.Add(this.linkRunGame);
            this.Controls.Add(this.linkOpenBackupsFolder);
            this.Controls.Add(this.panelBackups);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.labelSelectGameProfile);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.comboProfiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Memento";
            this.Resizable = false;
            this.Text = "Memento";
            this.Load += new System.EventHandler(this.Memento_Load);
            this.contextMenuStrip.ResumeLayout(false);
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
        private MetroFramework.Controls.MetroLabel labelSpecificBackup;
        private MetroFramework.Controls.MetroLabel labelLatestBackups;
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
        private MetroFramework.Controls.MetroLink linkRunGame;
        private MetroFramework.Controls.MetroLink linkSelect;
        private MetroFramework.Controls.MetroLink linkRestore;
        private MetroFramework.Controls.MetroLink linkBackup;
        private MetroFramework.Controls.MetroLink linkKillGame;
        private System.IO.FileSystemWatcher watcher;
        private MetroFramework.Controls.MetroLink linkVersion;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MetroFramework.Controls.MetroTextBox textBoxSaveEdit;
    }
}

