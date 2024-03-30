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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memento));
            comboProfiles = new MetroFramework.Controls.MetroComboBox();
            radioSpecific = new MetroFramework.Controls.MetroRadioButton();
            radio02 = new MetroFramework.Controls.MetroRadioButton();
            contextMenuStrip = new MetroFramework.Controls.MetroContextMenu(components);
            renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            radio01 = new MetroFramework.Controls.MetroRadioButton();
            labelSpecificBackup = new MetroFramework.Controls.MetroLabel();
            labelLatestBackups = new MetroFramework.Controls.MetroLabel();
            buttonStartStop = new MetroFramework.Controls.MetroButton();
            labelSelectGameProfile = new MetroFramework.Controls.MetroLabel();
            labelWarning = new MetroFramework.Controls.MetroLabel();
            panelBackups = new MetroFramework.Controls.MetroPanel();
            textBoxSavenameEdit = new MetroFramework.Controls.MetroTextBox();
            linkSelect = new MetroFramework.Controls.MetroLink();
            linkRestore = new MetroFramework.Controls.MetroLink();
            linkBackup = new MetroFramework.Controls.MetroLink();
            radio06 = new MetroFramework.Controls.MetroRadioButton();
            labelNoBackupsFound = new MetroFramework.Controls.MetroLabel();
            radio10 = new MetroFramework.Controls.MetroRadioButton();
            radio09 = new MetroFramework.Controls.MetroRadioButton();
            radio08 = new MetroFramework.Controls.MetroRadioButton();
            radio07 = new MetroFramework.Controls.MetroRadioButton();
            radio05 = new MetroFramework.Controls.MetroRadioButton();
            radio04 = new MetroFramework.Controls.MetroRadioButton();
            radio03 = new MetroFramework.Controls.MetroRadioButton();
            buttonEdit = new MetroFramework.Controls.MetroButton();
            linkOpenBackupFolder = new MetroFramework.Controls.MetroLink();
            linkOpenSavesFolder = new MetroFramework.Controls.MetroLink();
            linkRunGame = new MetroFramework.Controls.MetroLink();
            linkKillGame = new MetroFramework.Controls.MetroLink();
            watcher = new System.IO.FileSystemWatcher();
            linkVersion = new MetroFramework.Controls.MetroLink();
            labelBackup = new MetroFramework.Controls.MetroLabel();
            metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            buttonClone = new MetroFramework.Controls.MetroButton();
            contextMenuStrip.SuspendLayout();
            panelBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)watcher).BeginInit();
            SuspendLayout();
            // 
            // comboProfiles
            // 
            comboProfiles.ItemHeight = 23;
            comboProfiles.Location = new System.Drawing.Point(27, 95);
            comboProfiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboProfiles.Name = "comboProfiles";
            comboProfiles.Size = new System.Drawing.Size(496, 29);
            comboProfiles.Sorted = true;
            comboProfiles.TabIndex = 0;
            comboProfiles.UseSelectable = true;
            comboProfiles.SelectedIndexChanged += comboProfiles_SelectedIndexChanged;
            // 
            // radioSpecific
            // 
            radioSpecific.AutoSize = true;
            radioSpecific.Checked = true;
            radioSpecific.Location = new System.Drawing.Point(377, 36);
            radioSpecific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioSpecific.Name = "radioSpecific";
            radioSpecific.Size = new System.Drawing.Size(50, 15);
            radioSpecific.TabIndex = 10;
            radioSpecific.TabStop = true;
            radioSpecific.Text = "none";
            radioSpecific.UseSelectable = true;
            radioSpecific.Click += radioLastest_Click;
            radioSpecific.KeyUp += radio_KeyUp;
            // 
            // radio02
            // 
            radio02.AutoSize = true;
            radio02.ContextMenuStrip = contextMenuStrip;
            radio02.Location = new System.Drawing.Point(23, 60);
            radio02.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio02.Name = "radio02";
            radio02.Size = new System.Drawing.Size(62, 15);
            radio02.TabIndex = 1;
            radio02.Text = "radio02";
            radio02.UseSelectable = true;
            radio02.Visible = false;
            radio02.Click += radioLastest_Click;
            radio02.KeyUp += radio_KeyUp;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { renameToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // radio01
            // 
            radio01.AutoSize = true;
            radio01.ContextMenuStrip = contextMenuStrip;
            radio01.Location = new System.Drawing.Point(23, 36);
            radio01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio01.Name = "radio01";
            radio01.Size = new System.Drawing.Size(62, 15);
            radio01.TabIndex = 0;
            radio01.Text = "radio01";
            radio01.UseSelectable = true;
            radio01.Visible = false;
            radio01.Click += radioLastest_Click;
            radio01.KeyUp += radio_KeyUp;
            // 
            // labelSpecificBackup
            // 
            labelSpecificBackup.AutoSize = true;
            labelSpecificBackup.Location = new System.Drawing.Point(364, 10);
            labelSpecificBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSpecificBackup.Name = "labelSpecificBackup";
            labelSpecificBackup.Size = new System.Drawing.Size(102, 19);
            labelSpecificBackup.TabIndex = 14;
            labelSpecificBackup.Text = "Specific Backup:";
            // 
            // labelLatestBackups
            // 
            labelLatestBackups.AutoSize = true;
            labelLatestBackups.Location = new System.Drawing.Point(4, 10);
            labelLatestBackups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelLatestBackups.Name = "labelLatestBackups";
            labelLatestBackups.Size = new System.Drawing.Size(96, 19);
            labelLatestBackups.TabIndex = 15;
            labelLatestBackups.Text = "Latest Backups:";
            // 
            // buttonStartStop
            // 
            buttonStartStop.Enabled = false;
            buttonStartStop.Location = new System.Drawing.Point(27, 135);
            buttonStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new System.Drawing.Size(115, 33);
            buttonStartStop.TabIndex = 2;
            buttonStartStop.Text = "Start Watching";
            buttonStartStop.UseSelectable = true;
            buttonStartStop.Click += buttonStartStop_Click;
            // 
            // labelSelectGameProfile
            // 
            labelSelectGameProfile.AutoSize = true;
            labelSelectGameProfile.Location = new System.Drawing.Point(27, 69);
            labelSelectGameProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSelectGameProfile.Name = "labelSelectGameProfile";
            labelSelectGameProfile.Size = new System.Drawing.Size(127, 19);
            labelSelectGameProfile.TabIndex = 22;
            labelSelectGameProfile.Text = "Select Game Profile:";
            // 
            // labelWarning
            // 
            labelWarning.AutoSize = true;
            labelWarning.ForeColor = System.Drawing.Color.Red;
            labelWarning.Location = new System.Drawing.Point(27, 395);
            labelWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new System.Drawing.Size(58, 19);
            labelWarning.TabIndex = 23;
            labelWarning.Text = "Warning";
            labelWarning.UseCustomForeColor = true;
            labelWarning.Visible = false;
            // 
            // panelBackups
            // 
            panelBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBackups.Controls.Add(textBoxSavenameEdit);
            panelBackups.Controls.Add(linkSelect);
            panelBackups.Controls.Add(linkRestore);
            panelBackups.Controls.Add(linkBackup);
            panelBackups.Controls.Add(radio06);
            panelBackups.Controls.Add(labelNoBackupsFound);
            panelBackups.Controls.Add(radio10);
            panelBackups.Controls.Add(radio09);
            panelBackups.Controls.Add(radio08);
            panelBackups.Controls.Add(radio07);
            panelBackups.Controls.Add(labelLatestBackups);
            panelBackups.Controls.Add(labelSpecificBackup);
            panelBackups.Controls.Add(radio01);
            panelBackups.Controls.Add(radio05);
            panelBackups.Controls.Add(radio04);
            panelBackups.Controls.Add(radio03);
            panelBackups.Controls.Add(radio02);
            panelBackups.Controls.Add(radioSpecific);
            panelBackups.HorizontalScrollbarBarColor = true;
            panelBackups.HorizontalScrollbarHighlightOnWheel = false;
            panelBackups.HorizontalScrollbarSize = 12;
            panelBackups.Location = new System.Drawing.Point(27, 175);
            panelBackups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBackups.Name = "panelBackups";
            panelBackups.Size = new System.Drawing.Size(546, 187);
            panelBackups.TabIndex = 4;
            panelBackups.VerticalScrollbarBarColor = true;
            panelBackups.VerticalScrollbarHighlightOnWheel = false;
            panelBackups.VerticalScrollbarSize = 12;
            // 
            // textBoxSavenameEdit
            // 
            // 
            // 
            // 
            textBoxSavenameEdit.CustomButton.Image = null;
            textBoxSavenameEdit.CustomButton.Location = new System.Drawing.Point(118, 1);
            textBoxSavenameEdit.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxSavenameEdit.CustomButton.Name = "";
            textBoxSavenameEdit.CustomButton.Size = new System.Drawing.Size(21, 21);
            textBoxSavenameEdit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textBoxSavenameEdit.CustomButton.TabIndex = 1;
            textBoxSavenameEdit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textBoxSavenameEdit.CustomButton.UseSelectable = true;
            textBoxSavenameEdit.CustomButton.Visible = false;
            textBoxSavenameEdit.Location = new System.Drawing.Point(388, 155);
            textBoxSavenameEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxSavenameEdit.MaxLength = 32767;
            textBoxSavenameEdit.Name = "textBoxSavenameEdit";
            textBoxSavenameEdit.PasswordChar = '\0';
            textBoxSavenameEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBoxSavenameEdit.SelectedText = "";
            textBoxSavenameEdit.SelectionLength = 0;
            textBoxSavenameEdit.SelectionStart = 0;
            textBoxSavenameEdit.ShortcutsEnabled = true;
            textBoxSavenameEdit.Size = new System.Drawing.Size(140, 23);
            textBoxSavenameEdit.TabIndex = 2;
            textBoxSavenameEdit.UseSelectable = true;
            textBoxSavenameEdit.Visible = false;
            textBoxSavenameEdit.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textBoxSavenameEdit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            textBoxSavenameEdit.KeyUp += textBoxSavenameEdit_KeyUp;
            textBoxSavenameEdit.Leave += textBoxSaveEdit_Leave;
            // 
            // linkSelect
            // 
            linkSelect.Enabled = false;
            linkSelect.Location = new System.Drawing.Point(355, 60);
            linkSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkSelect.Name = "linkSelect";
            linkSelect.Size = new System.Drawing.Size(128, 27);
            linkSelect.TabIndex = 24;
            linkSelect.Text = "Select specific";
            linkSelect.UseSelectable = true;
            linkSelect.Click += linkSelect_Click;
            // 
            // linkRestore
            // 
            linkRestore.Enabled = false;
            linkRestore.Location = new System.Drawing.Point(107, 157);
            linkRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkRestore.Name = "linkRestore";
            linkRestore.Size = new System.Drawing.Size(153, 22);
            linkRestore.TabIndex = 24;
            linkRestore.Text = "Restore";
            linkRestore.UseSelectable = true;
            linkRestore.Click += linkRestore_Click;
            // 
            // linkBackup
            // 
            linkBackup.Enabled = false;
            linkBackup.Location = new System.Drawing.Point(4, 155);
            linkBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkBackup.Name = "linkBackup";
            linkBackup.Size = new System.Drawing.Size(97, 27);
            linkBackup.TabIndex = 24;
            linkBackup.Text = "Backup";
            linkBackup.UseSelectable = true;
            linkBackup.Click += linkBackup_Click;
            // 
            // radio06
            // 
            radio06.AutoSize = true;
            radio06.ContextMenuStrip = contextMenuStrip;
            radio06.Location = new System.Drawing.Point(194, 36);
            radio06.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio06.Name = "radio06";
            radio06.Size = new System.Drawing.Size(62, 15);
            radio06.TabIndex = 5;
            radio06.Text = "radio06";
            radio06.UseSelectable = true;
            radio06.Visible = false;
            radio06.Click += radioLastest_Click;
            radio06.KeyUp += radio_KeyUp;
            // 
            // labelNoBackupsFound
            // 
            labelNoBackupsFound.AutoSize = true;
            labelNoBackupsFound.Location = new System.Drawing.Point(23, 36);
            labelNoBackupsFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelNoBackupsFound.Name = "labelNoBackupsFound";
            labelNoBackupsFound.Size = new System.Drawing.Size(116, 19);
            labelNoBackupsFound.TabIndex = 23;
            labelNoBackupsFound.Text = "No backups found";
            // 
            // radio10
            // 
            radio10.AutoSize = true;
            radio10.ContextMenuStrip = contextMenuStrip;
            radio10.Location = new System.Drawing.Point(194, 133);
            radio10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio10.Name = "radio10";
            radio10.Size = new System.Drawing.Size(62, 15);
            radio10.TabIndex = 9;
            radio10.Text = "radio10";
            radio10.UseSelectable = true;
            radio10.Visible = false;
            radio10.Click += radioLastest_Click;
            radio10.KeyUp += radio_KeyUp;
            // 
            // radio09
            // 
            radio09.AutoSize = true;
            radio09.ContextMenuStrip = contextMenuStrip;
            radio09.Location = new System.Drawing.Point(194, 108);
            radio09.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio09.Name = "radio09";
            radio09.Size = new System.Drawing.Size(62, 15);
            radio09.TabIndex = 8;
            radio09.Text = "radio09";
            radio09.UseSelectable = true;
            radio09.Visible = false;
            radio09.Click += radioLastest_Click;
            radio09.KeyUp += radio_KeyUp;
            // 
            // radio08
            // 
            radio08.AutoSize = true;
            radio08.ContextMenuStrip = contextMenuStrip;
            radio08.Location = new System.Drawing.Point(194, 84);
            radio08.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio08.Name = "radio08";
            radio08.Size = new System.Drawing.Size(62, 15);
            radio08.TabIndex = 7;
            radio08.Text = "radio08";
            radio08.UseSelectable = true;
            radio08.Visible = false;
            radio08.Click += radioLastest_Click;
            radio08.KeyUp += radio_KeyUp;
            // 
            // radio07
            // 
            radio07.AutoSize = true;
            radio07.ContextMenuStrip = contextMenuStrip;
            radio07.Location = new System.Drawing.Point(194, 60);
            radio07.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio07.Name = "radio07";
            radio07.Size = new System.Drawing.Size(62, 15);
            radio07.TabIndex = 6;
            radio07.Text = "radio07";
            radio07.UseSelectable = true;
            radio07.Visible = false;
            radio07.Click += radioLastest_Click;
            radio07.KeyUp += radio_KeyUp;
            // 
            // radio05
            // 
            radio05.AutoSize = true;
            radio05.ContextMenuStrip = contextMenuStrip;
            radio05.Location = new System.Drawing.Point(23, 133);
            radio05.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio05.Name = "radio05";
            radio05.Size = new System.Drawing.Size(62, 15);
            radio05.TabIndex = 4;
            radio05.Text = "radio05";
            radio05.UseSelectable = true;
            radio05.Visible = false;
            radio05.Click += radioLastest_Click;
            radio05.KeyUp += radio_KeyUp;
            // 
            // radio04
            // 
            radio04.AutoSize = true;
            radio04.ContextMenuStrip = contextMenuStrip;
            radio04.Location = new System.Drawing.Point(23, 108);
            radio04.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio04.Name = "radio04";
            radio04.Size = new System.Drawing.Size(62, 15);
            radio04.TabIndex = 3;
            radio04.Text = "radio04";
            radio04.UseSelectable = true;
            radio04.Visible = false;
            radio04.Click += radioLastest_Click;
            radio04.KeyUp += radio_KeyUp;
            // 
            // radio03
            // 
            radio03.AutoSize = true;
            radio03.ContextMenuStrip = contextMenuStrip;
            radio03.Location = new System.Drawing.Point(23, 84);
            radio03.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radio03.Name = "radio03";
            radio03.Size = new System.Drawing.Size(62, 15);
            radio03.TabIndex = 2;
            radio03.Text = "radio03";
            radio03.UseSelectable = true;
            radio03.Visible = false;
            radio03.Click += radioLastest_Click;
            radio03.KeyUp += radio_KeyUp;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new System.Drawing.Point(531, 91);
            buttonEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new System.Drawing.Size(29, 33);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "...";
            buttonEdit.UseSelectable = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // linkOpenBackupFolder
            // 
            linkOpenBackupFolder.Location = new System.Drawing.Point(174, 365);
            linkOpenBackupFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkOpenBackupFolder.Name = "linkOpenBackupFolder";
            linkOpenBackupFolder.Size = new System.Drawing.Size(153, 27);
            linkOpenBackupFolder.TabIndex = 24;
            linkOpenBackupFolder.Text = "Open Backup Folder";
            linkOpenBackupFolder.UseSelectable = true;
            linkOpenBackupFolder.Click += linkOpenBackupFolder_Click;
            // 
            // linkOpenSavesFolder
            // 
            linkOpenSavesFolder.Location = new System.Drawing.Point(27, 365);
            linkOpenSavesFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkOpenSavesFolder.Name = "linkOpenSavesFolder";
            linkOpenSavesFolder.Size = new System.Drawing.Size(153, 27);
            linkOpenSavesFolder.TabIndex = 24;
            linkOpenSavesFolder.Text = "Open Saves Folder";
            linkOpenSavesFolder.UseSelectable = true;
            linkOpenSavesFolder.Click += linkOpenSavesFolder_Click;
            // 
            // linkRunGame
            // 
            linkRunGame.Enabled = false;
            linkRunGame.Location = new System.Drawing.Point(334, 365);
            linkRunGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkRunGame.Name = "linkRunGame";
            linkRunGame.Size = new System.Drawing.Size(94, 27);
            linkRunGame.TabIndex = 24;
            linkRunGame.Text = "Run Game";
            linkRunGame.UseSelectable = true;
            linkRunGame.Click += linkRunGame_Click;
            // 
            // linkKillGame
            // 
            linkKillGame.Enabled = false;
            linkKillGame.Location = new System.Drawing.Point(416, 365);
            linkKillGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkKillGame.Name = "linkKillGame";
            linkKillGame.Size = new System.Drawing.Size(94, 27);
            linkKillGame.TabIndex = 24;
            linkKillGame.Text = "Kill Game";
            linkKillGame.UseSelectable = true;
            linkKillGame.Click += linkKillGame_Click;
            // 
            // watcher
            // 
            watcher.EnableRaisingEvents = true;
            watcher.SynchronizingObject = this;
            // 
            // linkVersion
            // 
            linkVersion.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            linkVersion.Location = new System.Drawing.Point(504, 398);
            linkVersion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            linkVersion.Name = "linkVersion";
            linkVersion.Size = new System.Drawing.Size(94, 27);
            linkVersion.TabIndex = 24;
            linkVersion.Text = "v00.00.00";
            linkVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            linkVersion.UseSelectable = true;
            linkVersion.Click += linkVersion_Click;
            // 
            // labelBackup
            // 
            labelBackup.AutoSize = true;
            labelBackup.ForeColor = System.Drawing.Color.Black;
            labelBackup.Location = new System.Drawing.Point(160, 144);
            labelBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBackup.Name = "labelBackup";
            labelBackup.Size = new System.Drawing.Size(60, 19);
            labelBackup.TabIndex = 25;
            labelBackup.Text = "Message";
            labelBackup.UseCustomForeColor = true;
            labelBackup.Visible = false;
            // 
            // metroToolTip1
            // 
            metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            metroToolTip1.StyleManager = null;
            metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // buttonClone
            // 
            buttonClone.Location = new System.Drawing.Point(568, 91);
            buttonClone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonClone.Name = "buttonClone";
            buttonClone.Size = new System.Drawing.Size(29, 33);
            buttonClone.TabIndex = 26;
            buttonClone.Text = "cln";
            metroToolTip1.SetToolTip(buttonClone, "Clone");
            buttonClone.UseSelectable = true;
            buttonClone.Click += buttonCloneProfile_Click;
            // 
            // Memento
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            ClientSize = new System.Drawing.Size(600, 430);
            Controls.Add(buttonClone);
            Controls.Add(labelBackup);
            Controls.Add(linkOpenSavesFolder);
            Controls.Add(linkVersion);
            Controls.Add(linkKillGame);
            Controls.Add(linkRunGame);
            Controls.Add(linkOpenBackupFolder);
            Controls.Add(panelBackups);
            Controls.Add(labelWarning);
            Controls.Add(labelSelectGameProfile);
            Controls.Add(buttonEdit);
            Controls.Add(buttonStartStop);
            Controls.Add(comboProfiles);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Memento";
            Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            Resizable = false;
            Text = "Memento";
            Load += Memento_Load;
            contextMenuStrip.ResumeLayout(false);
            panelBackups.ResumeLayout(false);
            panelBackups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)watcher).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private MetroFramework.Controls.MetroLink linkOpenBackupFolder;
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
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroButton buttonClone;
    }
}

