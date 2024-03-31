namespace Memento.Forms
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
            labelBackupBeforeRestoring = new MetroFramework.Controls.MetroLabel();
            labelDontWarnOnRestore = new MetroFramework.Controls.MetroLabel();
            labelKillBeforeRestore = new MetroFramework.Controls.MetroLabel();
            toggleBackupBeforeRestoring = new MetroFramework.Controls.MetroToggle();
            toggleDontWarnOnRestore = new MetroFramework.Controls.MetroToggle();
            toggleKillBeforeRestore = new MetroFramework.Controls.MetroToggle();
            labelGameExecutale = new MetroFramework.Controls.MetroLabel();
            buttonGameExecutable = new MetroFramework.Controls.MetroButton();
            buttonSavesFolder = new MetroFramework.Controls.MetroButton();
            textGameExecutable = new MetroFramework.Controls.MetroTextBox();
            textSavesFolder = new MetroFramework.Controls.MetroTextBox();
            labelSavesFolder = new MetroFramework.Controls.MetroLabel();
            textProfileName = new MetroFramework.Controls.MetroTextBox();
            labelProfileName = new MetroFramework.Controls.MetroLabel();
            buttonSave = new MetroFramework.Controls.MetroButton();
            buttonCancel = new MetroFramework.Controls.MetroButton();
            buttonDelete = new MetroFramework.Controls.MetroButton();
            labelWarning = new MetroFramework.Controls.MetroLabel();
            labelBackupOnStartWatching = new MetroFramework.Controls.MetroLabel();
            toggleBackupOnStartWatching = new MetroFramework.Controls.MetroToggle();
            labelWriteLog = new MetroFramework.Controls.MetroLabel();
            toggleWriteLog = new MetroFramework.Controls.MetroToggle();
            toggleDeleteBeforeRestoring = new MetroFramework.Controls.MetroToggle();
            labelDeleteBeforeRestoring = new MetroFramework.Controls.MetroLabel();
            linkAdvancedFiltering = new MetroFramework.Controls.MetroLink();
            labelShowNumberOfFiles = new MetroFramework.Controls.MetroLabel();
            toggleShowNumberOfFiles = new MetroFramework.Controls.MetroToggle();
            metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            labelDeleteWithoutConfirmation = new MetroFramework.Controls.MetroLabel();
            toggleDeleteWithoutConfirmation = new MetroFramework.Controls.MetroToggle();
            textMinimumInterval = new MetroFramework.Controls.MetroTextBox();
            labelMinimumInterval = new MetroFramework.Controls.MetroLabel();
            buttonClone = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // labelBackupBeforeRestoring
            // 
            labelBackupBeforeRestoring.AutoSize = true;
            labelBackupBeforeRestoring.Location = new System.Drawing.Point(27, 271);
            labelBackupBeforeRestoring.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBackupBeforeRestoring.Name = "labelBackupBeforeRestoring";
            labelBackupBeforeRestoring.Size = new System.Drawing.Size(150, 19);
            labelBackupBeforeRestoring.TabIndex = 23;
            labelBackupBeforeRestoring.Text = "Backup before restoring";
            // 
            // labelDontWarnOnRestore
            // 
            labelDontWarnOnRestore.AutoSize = true;
            labelDontWarnOnRestore.Location = new System.Drawing.Point(27, 217);
            labelDontWarnOnRestore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDontWarnOnRestore.Name = "labelDontWarnOnRestore";
            labelDontWarnOnRestore.Size = new System.Drawing.Size(171, 19);
            labelDontWarnOnRestore.TabIndex = 24;
            labelDontWarnOnRestore.Text = "Do not warn when restoring";
            // 
            // labelKillBeforeRestore
            // 
            labelKillBeforeRestore.AutoSize = true;
            labelKillBeforeRestore.Location = new System.Drawing.Point(27, 190);
            labelKillBeforeRestore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelKillBeforeRestore.Name = "labelKillBeforeRestore";
            labelKillBeforeRestore.Size = new System.Drawing.Size(193, 19);
            labelKillBeforeRestore.TabIndex = 25;
            labelKillBeforeRestore.Text = "Kill/restart game during restore";
            // 
            // toggleBackupBeforeRestoring
            // 
            toggleBackupBeforeRestoring.AutoSize = true;
            toggleBackupBeforeRestoring.Location = new System.Drawing.Point(260, 273);
            toggleBackupBeforeRestoring.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleBackupBeforeRestoring.Name = "toggleBackupBeforeRestoring";
            toggleBackupBeforeRestoring.Size = new System.Drawing.Size(80, 19);
            toggleBackupBeforeRestoring.TabIndex = 9;
            toggleBackupBeforeRestoring.Text = "Off";
            toggleBackupBeforeRestoring.UseSelectable = true;
            // 
            // toggleDontWarnOnRestore
            // 
            toggleDontWarnOnRestore.AutoSize = true;
            toggleDontWarnOnRestore.Location = new System.Drawing.Point(260, 219);
            toggleDontWarnOnRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleDontWarnOnRestore.Name = "toggleDontWarnOnRestore";
            toggleDontWarnOnRestore.Size = new System.Drawing.Size(80, 19);
            toggleDontWarnOnRestore.TabIndex = 7;
            toggleDontWarnOnRestore.Text = "Off";
            toggleDontWarnOnRestore.UseSelectable = true;
            // 
            // toggleKillBeforeRestore
            // 
            toggleKillBeforeRestore.AutoSize = true;
            toggleKillBeforeRestore.Location = new System.Drawing.Point(260, 192);
            toggleKillBeforeRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleKillBeforeRestore.Name = "toggleKillBeforeRestore";
            toggleKillBeforeRestore.Size = new System.Drawing.Size(80, 19);
            toggleKillBeforeRestore.TabIndex = 6;
            toggleKillBeforeRestore.Text = "Off";
            toggleKillBeforeRestore.UseSelectable = true;
            // 
            // labelGameExecutale
            // 
            labelGameExecutale.AutoSize = true;
            labelGameExecutale.Location = new System.Drawing.Point(27, 103);
            labelGameExecutale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGameExecutale.Name = "labelGameExecutale";
            labelGameExecutale.Size = new System.Drawing.Size(113, 19);
            labelGameExecutale.TabIndex = 17;
            labelGameExecutale.Text = "Game Executable:";
            // 
            // buttonGameExecutable
            // 
            buttonGameExecutable.Location = new System.Drawing.Point(403, 95);
            buttonGameExecutable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonGameExecutable.Name = "buttonGameExecutable";
            buttonGameExecutable.Size = new System.Drawing.Size(33, 27);
            buttonGameExecutable.TabIndex = 2;
            buttonGameExecutable.Text = "...";
            buttonGameExecutable.UseSelectable = true;
            buttonGameExecutable.Click += buttonGameExecutable_Click;
            // 
            // buttonSavesFolder
            // 
            buttonSavesFolder.Location = new System.Drawing.Point(403, 128);
            buttonSavesFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonSavesFolder.Name = "buttonSavesFolder";
            buttonSavesFolder.Size = new System.Drawing.Size(33, 27);
            buttonSavesFolder.TabIndex = 4;
            buttonSavesFolder.Text = "...";
            buttonSavesFolder.UseSelectable = true;
            buttonSavesFolder.Click += buttonSavesFolder_Click;
            // 
            // textGameExecutable
            // 
            // 
            // 
            // 
            textGameExecutable.CustomButton.Image = null;
            textGameExecutable.CustomButton.Location = new System.Drawing.Point(202, 1);
            textGameExecutable.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textGameExecutable.CustomButton.Name = "";
            textGameExecutable.CustomButton.Size = new System.Drawing.Size(25, 25);
            textGameExecutable.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textGameExecutable.CustomButton.TabIndex = 1;
            textGameExecutable.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textGameExecutable.CustomButton.UseSelectable = true;
            textGameExecutable.CustomButton.Visible = false;
            textGameExecutable.Location = new System.Drawing.Point(162, 98);
            textGameExecutable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textGameExecutable.MaxLength = 32767;
            textGameExecutable.Name = "textGameExecutable";
            textGameExecutable.PasswordChar = '\0';
            textGameExecutable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textGameExecutable.SelectedText = "";
            textGameExecutable.SelectionLength = 0;
            textGameExecutable.SelectionStart = 0;
            textGameExecutable.ShortcutsEnabled = true;
            textGameExecutable.Size = new System.Drawing.Size(228, 27);
            textGameExecutable.TabIndex = 1;
            textGameExecutable.UseSelectable = true;
            textGameExecutable.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textGameExecutable.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textSavesFolder
            // 
            // 
            // 
            // 
            textSavesFolder.CustomButton.Image = null;
            textSavesFolder.CustomButton.Location = new System.Drawing.Point(202, 1);
            textSavesFolder.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textSavesFolder.CustomButton.Name = "";
            textSavesFolder.CustomButton.Size = new System.Drawing.Size(25, 25);
            textSavesFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textSavesFolder.CustomButton.TabIndex = 1;
            textSavesFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textSavesFolder.CustomButton.UseSelectable = true;
            textSavesFolder.CustomButton.Visible = false;
            textSavesFolder.Location = new System.Drawing.Point(162, 131);
            textSavesFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textSavesFolder.MaxLength = 32767;
            textSavesFolder.Name = "textSavesFolder";
            textSavesFolder.PasswordChar = '\0';
            textSavesFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textSavesFolder.SelectedText = "";
            textSavesFolder.SelectionLength = 0;
            textSavesFolder.SelectionStart = 0;
            textSavesFolder.ShortcutsEnabled = true;
            textSavesFolder.Size = new System.Drawing.Size(228, 27);
            textSavesFolder.TabIndex = 3;
            textSavesFolder.UseSelectable = true;
            textSavesFolder.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textSavesFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelSavesFolder
            // 
            labelSavesFolder.AutoSize = true;
            labelSavesFolder.Location = new System.Drawing.Point(27, 136);
            labelSavesFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSavesFolder.Name = "labelSavesFolder";
            labelSavesFolder.Size = new System.Drawing.Size(87, 19);
            labelSavesFolder.TabIndex = 12;
            labelSavesFolder.Text = "Saves Folder:";
            // 
            // textProfileName
            // 
            // 
            // 
            // 
            textProfileName.CustomButton.Image = null;
            textProfileName.CustomButton.Location = new System.Drawing.Point(202, 1);
            textProfileName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textProfileName.CustomButton.Name = "";
            textProfileName.CustomButton.Size = new System.Drawing.Size(25, 25);
            textProfileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textProfileName.CustomButton.TabIndex = 1;
            textProfileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textProfileName.CustomButton.UseSelectable = true;
            textProfileName.CustomButton.Visible = false;
            textProfileName.Location = new System.Drawing.Point(162, 65);
            textProfileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textProfileName.MaxLength = 32767;
            textProfileName.Name = "textProfileName";
            textProfileName.PasswordChar = '\0';
            textProfileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textProfileName.SelectedText = "";
            textProfileName.SelectionLength = 0;
            textProfileName.SelectionStart = 0;
            textProfileName.ShortcutsEnabled = true;
            textProfileName.Size = new System.Drawing.Size(228, 27);
            textProfileName.TabIndex = 0;
            textProfileName.UseSelectable = true;
            textProfileName.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textProfileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelProfileName
            // 
            labelProfileName.AutoSize = true;
            labelProfileName.Location = new System.Drawing.Point(27, 69);
            labelProfileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelProfileName.Name = "labelProfileName";
            labelProfileName.Size = new System.Drawing.Size(90, 19);
            labelProfileName.TabIndex = 10;
            labelProfileName.Text = "Profile Name:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(348, 401);
            buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(88, 27);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save";
            buttonSave.UseSelectable = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(348, 302);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(88, 27);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseSelectable = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new System.Drawing.Point(348, 335);
            buttonDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(88, 27);
            buttonDelete.TabIndex = 14;
            buttonDelete.Text = "Delete";
            buttonDelete.UseSelectable = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelWarning
            // 
            labelWarning.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            labelWarning.AutoSize = true;
            labelWarning.BackColor = System.Drawing.Color.White;
            labelWarning.ForeColor = System.Drawing.Color.Red;
            labelWarning.Location = new System.Drawing.Point(27, 427);
            labelWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new System.Drawing.Size(58, 19);
            labelWarning.TabIndex = 26;
            labelWarning.Text = "Warning";
            labelWarning.UseCustomForeColor = true;
            labelWarning.Visible = false;
            // 
            // labelBackupOnStartWatching
            // 
            labelBackupOnStartWatching.AutoSize = true;
            labelBackupOnStartWatching.Location = new System.Drawing.Point(27, 298);
            labelBackupOnStartWatching.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBackupOnStartWatching.Name = "labelBackupOnStartWatching";
            labelBackupOnStartWatching.Size = new System.Drawing.Size(155, 19);
            labelBackupOnStartWatching.TabIndex = 28;
            labelBackupOnStartWatching.Text = "Backup on start watching";
            // 
            // toggleBackupOnStartWatching
            // 
            toggleBackupOnStartWatching.AutoSize = true;
            toggleBackupOnStartWatching.Location = new System.Drawing.Point(260, 300);
            toggleBackupOnStartWatching.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleBackupOnStartWatching.Name = "toggleBackupOnStartWatching";
            toggleBackupOnStartWatching.Size = new System.Drawing.Size(80, 19);
            toggleBackupOnStartWatching.TabIndex = 10;
            toggleBackupOnStartWatching.Text = "Off";
            toggleBackupOnStartWatching.UseSelectable = true;
            // 
            // labelWriteLog
            // 
            labelWriteLog.AutoSize = true;
            labelWriteLog.Location = new System.Drawing.Point(27, 325);
            labelWriteLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWriteLog.Name = "labelWriteLog";
            labelWriteLog.Size = new System.Drawing.Size(64, 19);
            labelWriteLog.TabIndex = 30;
            labelWriteLog.Text = "Write log";
            // 
            // toggleWriteLog
            // 
            toggleWriteLog.AutoSize = true;
            toggleWriteLog.Location = new System.Drawing.Point(260, 327);
            toggleWriteLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleWriteLog.Name = "toggleWriteLog";
            toggleWriteLog.Size = new System.Drawing.Size(80, 19);
            toggleWriteLog.TabIndex = 11;
            toggleWriteLog.Text = "Off";
            toggleWriteLog.UseSelectable = true;
            // 
            // toggleDeleteBeforeRestoring
            // 
            toggleDeleteBeforeRestoring.AutoSize = true;
            toggleDeleteBeforeRestoring.Location = new System.Drawing.Point(260, 246);
            toggleDeleteBeforeRestoring.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleDeleteBeforeRestoring.Name = "toggleDeleteBeforeRestoring";
            toggleDeleteBeforeRestoring.Size = new System.Drawing.Size(80, 19);
            toggleDeleteBeforeRestoring.TabIndex = 8;
            toggleDeleteBeforeRestoring.Text = "Off";
            toggleDeleteBeforeRestoring.UseSelectable = true;
            // 
            // labelDeleteBeforeRestoring
            // 
            labelDeleteBeforeRestoring.AutoSize = true;
            labelDeleteBeforeRestoring.Location = new System.Drawing.Point(27, 244);
            labelDeleteBeforeRestoring.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDeleteBeforeRestoring.Name = "labelDeleteBeforeRestoring";
            labelDeleteBeforeRestoring.Size = new System.Drawing.Size(228, 19);
            labelDeleteBeforeRestoring.TabIndex = 23;
            labelDeleteBeforeRestoring.Text = "Clean up save folder before restoring";
            // 
            // linkAdvancedFiltering
            // 
            linkAdvancedFiltering.Location = new System.Drawing.Point(159, 164);
            linkAdvancedFiltering.Name = "linkAdvancedFiltering";
            linkAdvancedFiltering.Size = new System.Drawing.Size(171, 23);
            linkAdvancedFiltering.TabIndex = 5;
            linkAdvancedFiltering.Text = "Configure advanced filtering";
            linkAdvancedFiltering.UseSelectable = true;
            linkAdvancedFiltering.UseVisualStyleBackColor = true;
            linkAdvancedFiltering.Click += linkAdvancedFiltering_Click;
            // 
            // labelShowNumberOfFiles
            // 
            labelShowNumberOfFiles.AutoSize = true;
            labelShowNumberOfFiles.Location = new System.Drawing.Point(27, 353);
            labelShowNumberOfFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelShowNumberOfFiles.Name = "labelShowNumberOfFiles";
            labelShowNumberOfFiles.Size = new System.Drawing.Size(197, 19);
            labelShowNumberOfFiles.TabIndex = 32;
            labelShowNumberOfFiles.Text = "Show number of files backed up";
            // 
            // toggleShowNumberOfFiles
            // 
            toggleShowNumberOfFiles.AutoSize = true;
            toggleShowNumberOfFiles.Location = new System.Drawing.Point(260, 355);
            toggleShowNumberOfFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleShowNumberOfFiles.Name = "toggleShowNumberOfFiles";
            toggleShowNumberOfFiles.Size = new System.Drawing.Size(80, 19);
            toggleShowNumberOfFiles.TabIndex = 12;
            toggleShowNumberOfFiles.Text = "Off";
            toggleShowNumberOfFiles.UseSelectable = true;
            // 
            // metroToolTip1
            // 
            metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            metroToolTip1.StyleManager = null;
            metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // labelDeleteWithoutConfirmation
            // 
            labelDeleteWithoutConfirmation.AutoSize = true;
            labelDeleteWithoutConfirmation.Location = new System.Drawing.Point(27, 379);
            labelDeleteWithoutConfirmation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDeleteWithoutConfirmation.Name = "labelDeleteWithoutConfirmation";
            labelDeleteWithoutConfirmation.Size = new System.Drawing.Size(170, 19);
            labelDeleteWithoutConfirmation.TabIndex = 34;
            labelDeleteWithoutConfirmation.Text = "Delete without confirmation";
            // 
            // toggleDeleteWithoutConfirmation
            // 
            toggleDeleteWithoutConfirmation.AutoSize = true;
            toggleDeleteWithoutConfirmation.Location = new System.Drawing.Point(260, 381);
            toggleDeleteWithoutConfirmation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toggleDeleteWithoutConfirmation.Name = "toggleDeleteWithoutConfirmation";
            toggleDeleteWithoutConfirmation.Size = new System.Drawing.Size(80, 19);
            toggleDeleteWithoutConfirmation.TabIndex = 33;
            toggleDeleteWithoutConfirmation.Text = "Off";
            toggleDeleteWithoutConfirmation.UseSelectable = true;
            // 
            // textMinimumInterval
            // 
            // 
            // 
            // 
            textMinimumInterval.CustomButton.Image = null;
            textMinimumInterval.CustomButton.Location = new System.Drawing.Point(53, 1);
            textMinimumInterval.CustomButton.Name = "";
            textMinimumInterval.CustomButton.Size = new System.Drawing.Size(21, 21);
            textMinimumInterval.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textMinimumInterval.CustomButton.TabIndex = 1;
            textMinimumInterval.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textMinimumInterval.CustomButton.UseSelectable = true;
            textMinimumInterval.CustomButton.Visible = false;
            textMinimumInterval.Lines = new string[]
    {
    "0"
    };
            textMinimumInterval.Location = new System.Drawing.Point(265, 405);
            textMinimumInterval.MaxLength = 32767;
            textMinimumInterval.Name = "textMinimumInterval";
            textMinimumInterval.PasswordChar = '\0';
            textMinimumInterval.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textMinimumInterval.SelectedText = "";
            textMinimumInterval.SelectionLength = 0;
            textMinimumInterval.SelectionStart = 0;
            textMinimumInterval.ShortcutsEnabled = true;
            textMinimumInterval.Size = new System.Drawing.Size(75, 23);
            textMinimumInterval.TabIndex = 35;
            textMinimumInterval.Text = "0";
            textMinimumInterval.UseSelectable = true;
            textMinimumInterval.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textMinimumInterval.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelMinimumInterval
            // 
            labelMinimumInterval.AutoSize = true;
            labelMinimumInterval.Location = new System.Drawing.Point(28, 405);
            labelMinimumInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelMinimumInterval.Name = "labelMinimumInterval";
            labelMinimumInterval.Size = new System.Drawing.Size(218, 19);
            labelMinimumInterval.TabIndex = 36;
            labelMinimumInterval.Text = "Minimum minutes between backups";
            // 
            // buttonClone
            // 
            buttonClone.Location = new System.Drawing.Point(348, 368);
            buttonClone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonClone.Name = "buttonClone";
            buttonClone.Size = new System.Drawing.Size(88, 27);
            buttonClone.TabIndex = 37;
            buttonClone.Text = "Clone";
            buttonClone.UseSelectable = true;
            buttonClone.Click += buttonClone_Click;
            // 
            // EditGameProfile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(469, 453);
            Controls.Add(buttonClone);
            Controls.Add(labelMinimumInterval);
            Controls.Add(textMinimumInterval);
            Controls.Add(labelDeleteWithoutConfirmation);
            Controls.Add(toggleDeleteWithoutConfirmation);
            Controls.Add(labelShowNumberOfFiles);
            Controls.Add(toggleShowNumberOfFiles);
            Controls.Add(linkAdvancedFiltering);
            Controls.Add(labelDeleteBeforeRestoring);
            Controls.Add(toggleDeleteBeforeRestoring);
            Controls.Add(labelWriteLog);
            Controls.Add(toggleWriteLog);
            Controls.Add(labelBackupOnStartWatching);
            Controls.Add(toggleBackupOnStartWatching);
            Controls.Add(labelWarning);
            Controls.Add(buttonDelete);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelBackupBeforeRestoring);
            Controls.Add(labelDontWarnOnRestore);
            Controls.Add(labelKillBeforeRestore);
            Controls.Add(toggleBackupBeforeRestoring);
            Controls.Add(toggleDontWarnOnRestore);
            Controls.Add(toggleKillBeforeRestore);
            Controls.Add(labelGameExecutale);
            Controls.Add(buttonGameExecutable);
            Controls.Add(buttonSavesFolder);
            Controls.Add(textGameExecutable);
            Controls.Add(textSavesFolder);
            Controls.Add(labelSavesFolder);
            Controls.Add(textProfileName);
            Controls.Add(labelProfileName);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "EditGameProfile";
            Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            Resizable = false;
            Text = "Edit Game Profile";
            ResumeLayout(false);
            PerformLayout();
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
        private MetroFramework.Controls.MetroLabel labelWarning;
        private MetroFramework.Controls.MetroLabel labelBackupOnStartWatching;
        private MetroFramework.Controls.MetroToggle toggleBackupOnStartWatching;
        private MetroFramework.Controls.MetroLabel labelWriteLog;
        private MetroFramework.Controls.MetroToggle toggleWriteLog;
        private MetroFramework.Controls.MetroToggle toggleDeleteBeforeRestoring;
        private MetroFramework.Controls.MetroLabel labelDeleteBeforeRestoring;
        private MetroFramework.Controls.MetroLink linkAdvancedFiltering;
        private MetroFramework.Controls.MetroLabel labelShowNumberOfFiles;
        private MetroFramework.Controls.MetroToggle toggleShowNumberOfFiles;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel labelDeleteWithoutConfirmation;
        private MetroFramework.Controls.MetroToggle toggleDeleteWithoutConfirmation;
        private MetroFramework.Controls.MetroTextBox textMinimumInterval;
        private MetroFramework.Controls.MetroLabel labelMinimumInterval;
        private MetroFramework.Controls.MetroButton buttonClone;
    }
}