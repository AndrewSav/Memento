﻿namespace Memento.Forms
{
    partial class EditGameProfile
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
            this.labelBackupBeforeRestoring = new MetroFramework.Controls.MetroLabel();
            this.labelDontWarnOnRestore = new MetroFramework.Controls.MetroLabel();
            this.labelKillBeforeRestore = new MetroFramework.Controls.MetroLabel();
            this.toggleBackupBeforeRestoring = new MetroFramework.Controls.MetroToggle();
            this.toggleDontWarnOnRestore = new MetroFramework.Controls.MetroToggle();
            this.toggleKillBeforeRestore = new MetroFramework.Controls.MetroToggle();
            this.labelGameExecutale = new MetroFramework.Controls.MetroLabel();
            this.buttonGameExecutable = new MetroFramework.Controls.MetroButton();
            this.buttonSavesFolder = new MetroFramework.Controls.MetroButton();
            this.textGameExecutable = new MetroFramework.Controls.MetroTextBox();
            this.textSavesFolder = new MetroFramework.Controls.MetroTextBox();
            this.labelSavesFolder = new MetroFramework.Controls.MetroLabel();
            this.textProfileName = new MetroFramework.Controls.MetroTextBox();
            this.labelProfileName = new MetroFramework.Controls.MetroLabel();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.buttonCancel = new MetroFramework.Controls.MetroButton();
            this.buttonDelete = new MetroFramework.Controls.MetroButton();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.labelWarning = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toggleBackupOnStartWatching = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.toggleWriteLog = new MetroFramework.Controls.MetroToggle();
            this.SuspendLayout();
            // 
            // labelBackupBeforeRestoring
            // 
            this.labelBackupBeforeRestoring.AutoSize = true;
            this.labelBackupBeforeRestoring.Location = new System.Drawing.Point(23, 208);
            this.labelBackupBeforeRestoring.Name = "labelBackupBeforeRestoring";
            this.labelBackupBeforeRestoring.Size = new System.Drawing.Size(150, 19);
            this.labelBackupBeforeRestoring.TabIndex = 23;
            this.labelBackupBeforeRestoring.Text = "Backup before restoring";
            // 
            // labelDontWarnOnRestore
            // 
            this.labelDontWarnOnRestore.AutoSize = true;
            this.labelDontWarnOnRestore.Location = new System.Drawing.Point(23, 185);
            this.labelDontWarnOnRestore.Name = "labelDontWarnOnRestore";
            this.labelDontWarnOnRestore.Size = new System.Drawing.Size(171, 19);
            this.labelDontWarnOnRestore.TabIndex = 24;
            this.labelDontWarnOnRestore.Text = "Do not warn when restoring";
            // 
            // labelKillBeforeRestore
            // 
            this.labelKillBeforeRestore.AutoSize = true;
            this.labelKillBeforeRestore.Location = new System.Drawing.Point(23, 162);
            this.labelKillBeforeRestore.Name = "labelKillBeforeRestore";
            this.labelKillBeforeRestore.Size = new System.Drawing.Size(193, 19);
            this.labelKillBeforeRestore.TabIndex = 25;
            this.labelKillBeforeRestore.Text = "Kill/restart game during restore";
            // 
            // toggleBackupBeforeRestoring
            // 
            this.toggleBackupBeforeRestoring.AutoSize = true;
            this.toggleBackupBeforeRestoring.Location = new System.Drawing.Point(223, 210);
            this.toggleBackupBeforeRestoring.Name = "toggleBackupBeforeRestoring";
            this.toggleBackupBeforeRestoring.Size = new System.Drawing.Size(80, 17);
            this.toggleBackupBeforeRestoring.TabIndex = 7;
            this.toggleBackupBeforeRestoring.Text = "Off";
            this.toggleBackupBeforeRestoring.UseSelectable = true;
            // 
            // toggleDontWarnOnRestore
            // 
            this.toggleDontWarnOnRestore.AutoSize = true;
            this.toggleDontWarnOnRestore.Location = new System.Drawing.Point(223, 187);
            this.toggleDontWarnOnRestore.Name = "toggleDontWarnOnRestore";
            this.toggleDontWarnOnRestore.Size = new System.Drawing.Size(80, 17);
            this.toggleDontWarnOnRestore.TabIndex = 6;
            this.toggleDontWarnOnRestore.Text = "Off";
            this.toggleDontWarnOnRestore.UseSelectable = true;
            // 
            // toggleKillBeforeRestore
            // 
            this.toggleKillBeforeRestore.AutoSize = true;
            this.toggleKillBeforeRestore.Location = new System.Drawing.Point(223, 164);
            this.toggleKillBeforeRestore.Name = "toggleKillBeforeRestore";
            this.toggleKillBeforeRestore.Size = new System.Drawing.Size(80, 17);
            this.toggleKillBeforeRestore.TabIndex = 5;
            this.toggleKillBeforeRestore.Text = "Off";
            this.toggleKillBeforeRestore.UseSelectable = true;
            // 
            // labelGameExecutale
            // 
            this.labelGameExecutale.AutoSize = true;
            this.labelGameExecutale.Location = new System.Drawing.Point(23, 122);
            this.labelGameExecutale.Name = "labelGameExecutale";
            this.labelGameExecutale.Size = new System.Drawing.Size(113, 19);
            this.labelGameExecutale.TabIndex = 17;
            this.labelGameExecutale.Text = "Game Executable:";
            // 
            // buttonGameExecutable
            // 
            this.buttonGameExecutable.Location = new System.Drawing.Point(446, 118);
            this.buttonGameExecutable.Name = "buttonGameExecutable";
            this.buttonGameExecutable.Size = new System.Drawing.Size(28, 23);
            this.buttonGameExecutable.TabIndex = 4;
            this.buttonGameExecutable.Text = "...";
            this.buttonGameExecutable.UseSelectable = true;
            this.buttonGameExecutable.Click += new System.EventHandler(this.buttonGameExecutable_Click);
            // 
            // buttonSavesFolder
            // 
            this.buttonSavesFolder.Location = new System.Drawing.Point(446, 87);
            this.buttonSavesFolder.Name = "buttonSavesFolder";
            this.buttonSavesFolder.Size = new System.Drawing.Size(28, 23);
            this.buttonSavesFolder.TabIndex = 2;
            this.buttonSavesFolder.Text = "...";
            this.buttonSavesFolder.UseSelectable = true;
            this.buttonSavesFolder.Click += new System.EventHandler(this.buttonSavesFolder_Click);
            // 
            // textGameExecutable
            // 
            // 
            // 
            // 
            this.textGameExecutable.CustomButton.Image = null;
            this.textGameExecutable.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.textGameExecutable.CustomButton.Name = "";
            this.textGameExecutable.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textGameExecutable.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textGameExecutable.CustomButton.TabIndex = 1;
            this.textGameExecutable.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textGameExecutable.CustomButton.UseSelectable = true;
            this.textGameExecutable.CustomButton.Visible = false;
            this.textGameExecutable.Lines = new string[0];
            this.textGameExecutable.Location = new System.Drawing.Point(139, 118);
            this.textGameExecutable.MaxLength = 32767;
            this.textGameExecutable.Name = "textGameExecutable";
            this.textGameExecutable.PasswordChar = '\0';
            this.textGameExecutable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textGameExecutable.SelectedText = "";
            this.textGameExecutable.SelectionLength = 0;
            this.textGameExecutable.SelectionStart = 0;
            this.textGameExecutable.ShortcutsEnabled = true;
            this.textGameExecutable.Size = new System.Drawing.Size(298, 23);
            this.textGameExecutable.TabIndex = 3;
            this.textGameExecutable.UseSelectable = true;
            this.textGameExecutable.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textGameExecutable.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textSavesFolder
            // 
            // 
            // 
            // 
            this.textSavesFolder.CustomButton.Image = null;
            this.textSavesFolder.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.textSavesFolder.CustomButton.Name = "";
            this.textSavesFolder.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textSavesFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textSavesFolder.CustomButton.TabIndex = 1;
            this.textSavesFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textSavesFolder.CustomButton.UseSelectable = true;
            this.textSavesFolder.CustomButton.Visible = false;
            this.textSavesFolder.Lines = new string[0];
            this.textSavesFolder.Location = new System.Drawing.Point(139, 87);
            this.textSavesFolder.MaxLength = 32767;
            this.textSavesFolder.Name = "textSavesFolder";
            this.textSavesFolder.PasswordChar = '\0';
            this.textSavesFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textSavesFolder.SelectedText = "";
            this.textSavesFolder.SelectionLength = 0;
            this.textSavesFolder.SelectionStart = 0;
            this.textSavesFolder.ShortcutsEnabled = true;
            this.textSavesFolder.Size = new System.Drawing.Size(298, 23);
            this.textSavesFolder.TabIndex = 1;
            this.textSavesFolder.UseSelectable = true;
            this.textSavesFolder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textSavesFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelSavesFolder
            // 
            this.labelSavesFolder.AutoSize = true;
            this.labelSavesFolder.Location = new System.Drawing.Point(23, 91);
            this.labelSavesFolder.Name = "labelSavesFolder";
            this.labelSavesFolder.Size = new System.Drawing.Size(87, 19);
            this.labelSavesFolder.TabIndex = 12;
            this.labelSavesFolder.Text = "Saves Folder:";
            // 
            // textProfileName
            // 
            // 
            // 
            // 
            this.textProfileName.CustomButton.Image = null;
            this.textProfileName.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.textProfileName.CustomButton.Name = "";
            this.textProfileName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textProfileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textProfileName.CustomButton.TabIndex = 1;
            this.textProfileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textProfileName.CustomButton.UseSelectable = true;
            this.textProfileName.CustomButton.Visible = false;
            this.textProfileName.Lines = new string[0];
            this.textProfileName.Location = new System.Drawing.Point(139, 56);
            this.textProfileName.MaxLength = 32767;
            this.textProfileName.Name = "textProfileName";
            this.textProfileName.PasswordChar = '\0';
            this.textProfileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textProfileName.SelectedText = "";
            this.textProfileName.SelectionLength = 0;
            this.textProfileName.SelectionStart = 0;
            this.textProfileName.ShortcutsEnabled = true;
            this.textProfileName.Size = new System.Drawing.Size(298, 23);
            this.textProfileName.TabIndex = 0;
            this.textProfileName.UseSelectable = true;
            this.textProfileName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textProfileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelProfileName
            // 
            this.labelProfileName.AutoSize = true;
            this.labelProfileName.Location = new System.Drawing.Point(23, 60);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(90, 19);
            this.labelProfileName.TabIndex = 10;
            this.labelProfileName.Text = "Profile Name:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(318, 320);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(399, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseSelectable = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(237, 320);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseSelectable = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.BackColor = System.Drawing.Color.White;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(23, 276);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(58, 19);
            this.labelWarning.TabIndex = 26;
            this.labelWarning.Text = "Warning";
            this.labelWarning.UseCustomForeColor = true;
            this.labelWarning.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 231);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(155, 19);
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "Backup on start watching";
            // 
            // toggleBackupOnStartWatching
            // 
            this.toggleBackupOnStartWatching.AutoSize = true;
            this.toggleBackupOnStartWatching.Location = new System.Drawing.Point(223, 233);
            this.toggleBackupOnStartWatching.Name = "toggleBackupOnStartWatching";
            this.toggleBackupOnStartWatching.Size = new System.Drawing.Size(80, 17);
            this.toggleBackupOnStartWatching.TabIndex = 27;
            this.toggleBackupOnStartWatching.Text = "Off";
            this.toggleBackupOnStartWatching.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 254);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "Write log";
            // 
            // toggleWriteLog
            // 
            this.toggleWriteLog.AutoSize = true;
            this.toggleWriteLog.Location = new System.Drawing.Point(223, 256);
            this.toggleWriteLog.Name = "toggleWriteLog";
            this.toggleWriteLog.Size = new System.Drawing.Size(80, 17);
            this.toggleWriteLog.TabIndex = 29;
            this.toggleWriteLog.Text = "Off";
            this.toggleWriteLog.UseSelectable = true;
            // 
            // EditGameProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(499, 358);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.toggleWriteLog);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.toggleBackupOnStartWatching);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelBackupBeforeRestoring);
            this.Controls.Add(this.labelDontWarnOnRestore);
            this.Controls.Add(this.labelKillBeforeRestore);
            this.Controls.Add(this.toggleBackupBeforeRestoring);
            this.Controls.Add(this.toggleDontWarnOnRestore);
            this.Controls.Add(this.toggleKillBeforeRestore);
            this.Controls.Add(this.labelGameExecutale);
            this.Controls.Add(this.buttonGameExecutable);
            this.Controls.Add(this.buttonSavesFolder);
            this.Controls.Add(this.textGameExecutable);
            this.Controls.Add(this.textSavesFolder);
            this.Controls.Add(this.labelSavesFolder);
            this.Controls.Add(this.textProfileName);
            this.Controls.Add(this.labelProfileName);
            this.Name = "EditGameProfile";
            this.Resizable = false;
            this.Text = "Edit Game Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel labelBackupBeforeRestoring;
        private MetroFramework.Controls.MetroLabel labelDontWarnOnRestore;
        private MetroFramework.Controls.MetroLabel labelKillBeforeRestore;
        private MetroFramework.Controls.MetroToggle toggleBackupBeforeRestoring;
        private MetroFramework.Controls.MetroToggle toggleDontWarnOnRestore;
        private MetroFramework.Controls.MetroToggle toggleKillBeforeRestore;
        private MetroFramework.Controls.MetroLabel labelGameExecutale;
        private MetroFramework.Controls.MetroButton buttonGameExecutable;
        private MetroFramework.Controls.MetroButton buttonSavesFolder;
        private MetroFramework.Controls.MetroTextBox textGameExecutable;
        private MetroFramework.Controls.MetroTextBox textSavesFolder;
        private MetroFramework.Controls.MetroLabel labelSavesFolder;
        private MetroFramework.Controls.MetroTextBox textProfileName;
        private MetroFramework.Controls.MetroLabel labelProfileName;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroButton buttonCancel;
        private MetroFramework.Controls.MetroButton buttonDelete;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel labelWarning;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle toggleBackupOnStartWatching;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle toggleWriteLog;
    }
}