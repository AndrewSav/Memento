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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memento));
            this.comboProfiles = new MetroFramework.Controls.MetroComboBox();
            this.radioSpecific = new MetroFramework.Controls.MetroRadioButton();
            this.radio02 = new MetroFramework.Controls.MetroRadioButton();
            this.contextMenuStrip = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radio01 = new MetroFramework.Controls.MetroRadioButton();
            this.labelSpecificBackup = new MetroFramework.Controls.MetroLabel();
            this.labelLatestBackups = new MetroFramework.Controls.MetroLabel();
            this.buttonStartStop = new MetroFramework.Controls.MetroButton();
            this.labelSelectGameProfile = new MetroFramework.Controls.MetroLabel();
            this.labelWarning = new MetroFramework.Controls.MetroLabel();
            this.panelBackups = new MetroFramework.Controls.MetroPanel();
            this.textBoxSavenameEdit = new MetroFramework.Controls.MetroTextBox();
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
            this.linkRunGame = new MetroFramework.Controls.MetroLink();
            this.linkKillGame = new MetroFramework.Controls.MetroLink();
            this.watcher = new System.IO.FileSystemWatcher();
            this.linkVersion = new MetroFramework.Controls.MetroLink();
            this.labelBackup = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip.SuspendLayout();
            this.panelBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProfiles
            // 
            this.comboProfiles.ItemHeight = 23;
            this.comboProfiles.Location = new System.Drawing.Point(27, 95);
            this.comboProfiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(496, 29);
            this.comboProfiles.Sorted = true;
            this.comboProfiles.TabIndex = 0;
            this.comboProfiles.UseSelectable = true;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // radioSpecific
            // 
            this.radioSpecific.AutoSize = true;
            this.radioSpecific.Checked = true;
            this.radioSpecific.Location = new System.Drawing.Point(377, 36);
            this.radioSpecific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioSpecific.Name = "radioSpecific";
            this.radioSpecific.Size = new System.Drawing.Size(50, 15);
            this.radioSpecific.TabIndex = 10;
            this.radioSpecific.TabStop = true;
            this.radioSpecific.Text = "none";
            this.radioSpecific.UseSelectable = true;
            this.radioSpecific.Click += new System.EventHandler(this.radioLastest_Click);
            this.radioSpecific.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio02
            // 
            this.radio02.AutoSize = true;
            this.radio02.ContextMenuStrip = this.contextMenuStrip;
            this.radio02.Location = new System.Drawing.Point(23, 60);
            this.radio02.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio02.Name = "radio02";
            this.radio02.Size = new System.Drawing.Size(62, 15);
            this.radio02.TabIndex = 1;
            this.radio02.Text = "radio02";
            this.radio02.UseSelectable = true;
            this.radio02.Visible = false;
            this.radio02.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // radio01
            // 
            this.radio01.AutoSize = true;
            this.radio01.ContextMenuStrip = this.contextMenuStrip;
            this.radio01.Location = new System.Drawing.Point(23, 36);
            this.radio01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio01.Name = "radio01";
            this.radio01.Size = new System.Drawing.Size(62, 15);
            this.radio01.TabIndex = 0;
            this.radio01.Text = "radio01";
            this.radio01.UseSelectable = true;
            this.radio01.Visible = false;
            this.radio01.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // labelSpecificBackup
            // 
            this.labelSpecificBackup.AutoSize = true;
            this.labelSpecificBackup.Location = new System.Drawing.Point(364, 10);
            this.labelSpecificBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecificBackup.Name = "labelSpecificBackup";
            this.labelSpecificBackup.Size = new System.Drawing.Size(102, 19);
            this.labelSpecificBackup.TabIndex = 14;
            this.labelSpecificBackup.Text = "Specific Backup:";
            // 
            // labelLatestBackups
            // 
            this.labelLatestBackups.AutoSize = true;
            this.labelLatestBackups.Location = new System.Drawing.Point(4, 10);
            this.labelLatestBackups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLatestBackups.Name = "labelLatestBackups";
            this.labelLatestBackups.Size = new System.Drawing.Size(96, 19);
            this.labelLatestBackups.TabIndex = 15;
            this.labelLatestBackups.Text = "Latest Backups:";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Enabled = false;
            this.buttonStartStop.Location = new System.Drawing.Point(27, 135);
            this.buttonStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(115, 33);
            this.buttonStartStop.TabIndex = 2;
            this.buttonStartStop.Text = "Start Watching";
            this.buttonStartStop.UseSelectable = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelSelectGameProfile
            // 
            this.labelSelectGameProfile.AutoSize = true;
            this.labelSelectGameProfile.Location = new System.Drawing.Point(27, 69);
            this.labelSelectGameProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectGameProfile.Name = "labelSelectGameProfile";
            this.labelSelectGameProfile.Size = new System.Drawing.Size(127, 19);
            this.labelSelectGameProfile.TabIndex = 22;
            this.labelSelectGameProfile.Text = "Select Game Profile:";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(27, 395);
            this.labelWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.panelBackups.Controls.Add(this.textBoxSavenameEdit);
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
            this.panelBackups.HorizontalScrollbarSize = 12;
            this.panelBackups.Location = new System.Drawing.Point(27, 175);
            this.panelBackups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelBackups.Name = "panelBackups";
            this.panelBackups.Size = new System.Drawing.Size(546, 187);
            this.panelBackups.TabIndex = 4;
            this.panelBackups.VerticalScrollbarBarColor = true;
            this.panelBackups.VerticalScrollbarHighlightOnWheel = false;
            this.panelBackups.VerticalScrollbarSize = 12;
            // 
            // textBoxSavenameEdit
            // 
            // 
            // 
            // 
            this.textBoxSavenameEdit.CustomButton.Image = null;
            this.textBoxSavenameEdit.CustomButton.Location = new System.Drawing.Point(118, 1);
            this.textBoxSavenameEdit.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSavenameEdit.CustomButton.Name = "";
            this.textBoxSavenameEdit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxSavenameEdit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxSavenameEdit.CustomButton.TabIndex = 1;
            this.textBoxSavenameEdit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxSavenameEdit.CustomButton.UseSelectable = true;
            this.textBoxSavenameEdit.CustomButton.Visible = false;
            this.textBoxSavenameEdit.Lines = new string[0];
            this.textBoxSavenameEdit.Location = new System.Drawing.Point(388, 155);
            this.textBoxSavenameEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSavenameEdit.MaxLength = 32767;
            this.textBoxSavenameEdit.Name = "textBoxSavenameEdit";
            this.textBoxSavenameEdit.PasswordChar = '\0';
            this.textBoxSavenameEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxSavenameEdit.SelectedText = "";
            this.textBoxSavenameEdit.SelectionLength = 0;
            this.textBoxSavenameEdit.SelectionStart = 0;
            this.textBoxSavenameEdit.ShortcutsEnabled = true;
            this.textBoxSavenameEdit.Size = new System.Drawing.Size(140, 23);
            this.textBoxSavenameEdit.TabIndex = 2;
            this.textBoxSavenameEdit.UseSelectable = true;
            this.textBoxSavenameEdit.Visible = false;
            this.textBoxSavenameEdit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxSavenameEdit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxSavenameEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSavenameEdit_KeyUp);
            this.textBoxSavenameEdit.Leave += new System.EventHandler(this.textBoxSaveEdit_Leave);
            // 
            // linkSelect
            // 
            this.linkSelect.Enabled = false;
            this.linkSelect.Location = new System.Drawing.Point(355, 60);
            this.linkSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkSelect.Name = "linkSelect";
            this.linkSelect.Size = new System.Drawing.Size(128, 27);
            this.linkSelect.TabIndex = 24;
            this.linkSelect.Text = "Select specific";
            this.linkSelect.UseSelectable = true;
            this.linkSelect.Click += new System.EventHandler(this.linkSelect_Click);
            // 
            // linkRestore
            // 
            this.linkRestore.Enabled = false;
            this.linkRestore.Location = new System.Drawing.Point(107, 157);
            this.linkRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkRestore.Name = "linkRestore";
            this.linkRestore.Size = new System.Drawing.Size(153, 22);
            this.linkRestore.TabIndex = 24;
            this.linkRestore.Text = "Restore";
            this.linkRestore.UseSelectable = true;
            this.linkRestore.Click += new System.EventHandler(this.linkRestore_Click);
            // 
            // linkBackup
            // 
            this.linkBackup.Enabled = false;
            this.linkBackup.Location = new System.Drawing.Point(4, 155);
            this.linkBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkBackup.Name = "linkBackup";
            this.linkBackup.Size = new System.Drawing.Size(97, 27);
            this.linkBackup.TabIndex = 24;
            this.linkBackup.Text = "Backup";
            this.linkBackup.UseSelectable = true;
            this.linkBackup.Click += new System.EventHandler(this.linkBackup_Click);
            // 
            // radio06
            // 
            this.radio06.AutoSize = true;
            this.radio06.ContextMenuStrip = this.contextMenuStrip;
            this.radio06.Location = new System.Drawing.Point(194, 36);
            this.radio06.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio06.Name = "radio06";
            this.radio06.Size = new System.Drawing.Size(62, 15);
            this.radio06.TabIndex = 5;
            this.radio06.Text = "radio06";
            this.radio06.UseSelectable = true;
            this.radio06.Visible = false;
            this.radio06.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio06.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // labelNoBackupsFound
            // 
            this.labelNoBackupsFound.AutoSize = true;
            this.labelNoBackupsFound.Location = new System.Drawing.Point(23, 36);
            this.labelNoBackupsFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNoBackupsFound.Name = "labelNoBackupsFound";
            this.labelNoBackupsFound.Size = new System.Drawing.Size(116, 19);
            this.labelNoBackupsFound.TabIndex = 23;
            this.labelNoBackupsFound.Text = "No backups found";
            // 
            // radio10
            // 
            this.radio10.AutoSize = true;
            this.radio10.ContextMenuStrip = this.contextMenuStrip;
            this.radio10.Location = new System.Drawing.Point(194, 133);
            this.radio10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio10.Name = "radio10";
            this.radio10.Size = new System.Drawing.Size(62, 15);
            this.radio10.TabIndex = 9;
            this.radio10.Text = "radio10";
            this.radio10.UseSelectable = true;
            this.radio10.Visible = false;
            this.radio10.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio09
            // 
            this.radio09.AutoSize = true;
            this.radio09.ContextMenuStrip = this.contextMenuStrip;
            this.radio09.Location = new System.Drawing.Point(194, 108);
            this.radio09.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio09.Name = "radio09";
            this.radio09.Size = new System.Drawing.Size(62, 15);
            this.radio09.TabIndex = 8;
            this.radio09.Text = "radio09";
            this.radio09.UseSelectable = true;
            this.radio09.Visible = false;
            this.radio09.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio09.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio08
            // 
            this.radio08.AutoSize = true;
            this.radio08.ContextMenuStrip = this.contextMenuStrip;
            this.radio08.Location = new System.Drawing.Point(194, 84);
            this.radio08.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio08.Name = "radio08";
            this.radio08.Size = new System.Drawing.Size(62, 15);
            this.radio08.TabIndex = 7;
            this.radio08.Text = "radio08";
            this.radio08.UseSelectable = true;
            this.radio08.Visible = false;
            this.radio08.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio08.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio07
            // 
            this.radio07.AutoSize = true;
            this.radio07.ContextMenuStrip = this.contextMenuStrip;
            this.radio07.Location = new System.Drawing.Point(194, 60);
            this.radio07.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio07.Name = "radio07";
            this.radio07.Size = new System.Drawing.Size(62, 15);
            this.radio07.TabIndex = 6;
            this.radio07.Text = "radio07";
            this.radio07.UseSelectable = true;
            this.radio07.Visible = false;
            this.radio07.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio07.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio05
            // 
            this.radio05.AutoSize = true;
            this.radio05.ContextMenuStrip = this.contextMenuStrip;
            this.radio05.Location = new System.Drawing.Point(23, 133);
            this.radio05.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio05.Name = "radio05";
            this.radio05.Size = new System.Drawing.Size(62, 15);
            this.radio05.TabIndex = 4;
            this.radio05.Text = "radio05";
            this.radio05.UseSelectable = true;
            this.radio05.Visible = false;
            this.radio05.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio05.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio04
            // 
            this.radio04.AutoSize = true;
            this.radio04.ContextMenuStrip = this.contextMenuStrip;
            this.radio04.Location = new System.Drawing.Point(23, 108);
            this.radio04.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio04.Name = "radio04";
            this.radio04.Size = new System.Drawing.Size(62, 15);
            this.radio04.TabIndex = 3;
            this.radio04.Text = "radio04";
            this.radio04.UseSelectable = true;
            this.radio04.Visible = false;
            this.radio04.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio04.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // radio03
            // 
            this.radio03.AutoSize = true;
            this.radio03.ContextMenuStrip = this.contextMenuStrip;
            this.radio03.Location = new System.Drawing.Point(23, 84);
            this.radio03.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio03.Name = "radio03";
            this.radio03.Size = new System.Drawing.Size(62, 15);
            this.radio03.TabIndex = 2;
            this.radio03.Text = "radio03";
            this.radio03.UseSelectable = true;
            this.radio03.Visible = false;
            this.radio03.Click += new System.EventHandler(this.radioLastest_Click);
            this.radio03.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radio_KeyUp);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(544, 92);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(29, 33);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "...";
            this.buttonEdit.UseSelectable = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // linkOpenBackupsFolder
            // 
            this.linkOpenBackupsFolder.Location = new System.Drawing.Point(174, 365);
            this.linkOpenBackupsFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkOpenBackupsFolder.Name = "linkOpenBackupsFolder";
            this.linkOpenBackupsFolder.Size = new System.Drawing.Size(153, 27);
            this.linkOpenBackupsFolder.TabIndex = 24;
            this.linkOpenBackupsFolder.Text = "Open Backups Folder";
            this.linkOpenBackupsFolder.UseSelectable = true;
            this.linkOpenBackupsFolder.Click += new System.EventHandler(this.linkOpenBackupsFolder_Click);
            // 
            // linkOpenSavesFolder
            // 
            this.linkOpenSavesFolder.Location = new System.Drawing.Point(27, 365);
            this.linkOpenSavesFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkOpenSavesFolder.Name = "linkOpenSavesFolder";
            this.linkOpenSavesFolder.Size = new System.Drawing.Size(153, 27);
            this.linkOpenSavesFolder.TabIndex = 24;
            this.linkOpenSavesFolder.Text = "Open Saves Folder";
            this.linkOpenSavesFolder.UseSelectable = true;
            this.linkOpenSavesFolder.Click += new System.EventHandler(this.linkOpenSavesFolder_Click);
            // 
            // linkRunGame
            // 
            this.linkRunGame.Enabled = false;
            this.linkRunGame.Location = new System.Drawing.Point(334, 365);
            this.linkRunGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkRunGame.Name = "linkRunGame";
            this.linkRunGame.Size = new System.Drawing.Size(94, 27);
            this.linkRunGame.TabIndex = 24;
            this.linkRunGame.Text = "Run Game";
            this.linkRunGame.UseSelectable = true;
            this.linkRunGame.Click += new System.EventHandler(this.linkRunGame_Click);
            // 
            // linkKillGame
            // 
            this.linkKillGame.Enabled = false;
            this.linkKillGame.Location = new System.Drawing.Point(416, 365);
            this.linkKillGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkKillGame.Name = "linkKillGame";
            this.linkKillGame.Size = new System.Drawing.Size(94, 27);
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
            this.linkVersion.Location = new System.Drawing.Point(504, 398);
            this.linkVersion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.linkVersion.Name = "linkVersion";
            this.linkVersion.Size = new System.Drawing.Size(94, 27);
            this.linkVersion.TabIndex = 24;
            this.linkVersion.Text = "v00.00.00";
            this.linkVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.linkVersion.UseSelectable = true;
            this.linkVersion.Click += new System.EventHandler(this.linkVersion_Click);
            // 
            // labelBackup
            // 
            this.labelBackup.AutoSize = true;
            this.labelBackup.ForeColor = System.Drawing.Color.Black;
            this.labelBackup.Location = new System.Drawing.Point(160, 144);
            this.labelBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBackup.Name = "labelBackup";
            this.labelBackup.Size = new System.Drawing.Size(60, 19);
            this.labelBackup.TabIndex = 25;
            this.labelBackup.Text = "Message";
            this.labelBackup.UseCustomForeColor = true;
            this.labelBackup.Visible = false;
            // 
            // Memento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(600, 430);
            this.Controls.Add(this.labelBackup);
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
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Memento";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
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
        private MetroFramework.Controls.MetroTextBox textBoxSavenameEdit;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel labelBackup;
    }
}

