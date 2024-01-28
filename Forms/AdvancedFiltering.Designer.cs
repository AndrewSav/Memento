namespace Memento.Forms
{
    partial class AdvancedFiltering
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
            labelBackupFilter = new MetroFramework.Controls.MetroLabel();
            textBackupFilter = new MetroFramework.Controls.MetroTextBox();
            textWatchFilter = new MetroFramework.Controls.MetroTextBox();
            labelWatchFilter = new MetroFramework.Controls.MetroLabel();
            buttonOk = new MetroFramework.Controls.MetroButton();
            buttonCancel = new MetroFramework.Controls.MetroButton();
            buttonClear = new MetroFramework.Controls.MetroButton();
            metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            linkRegex = new MetroFramework.Controls.MetroLink();
            linkWatcher = new MetroFramework.Controls.MetroLink();
            toggleWatchSubfolders = new MetroFramework.Controls.MetroToggle();
            labelKillBeforeRestore = new MetroFramework.Controls.MetroLabel();
            SuspendLayout();
            // 
            // labelBackupFilter
            // 
            labelBackupFilter.AutoSize = true;
            labelBackupFilter.Location = new System.Drawing.Point(27, 69);
            labelBackupFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBackupFilter.Name = "labelBackupFilter";
            labelBackupFilter.Size = new System.Drawing.Size(88, 19);
            labelBackupFilter.TabIndex = 17;
            labelBackupFilter.Text = "Backup Filter:";
            // 
            // textBackupFilter
            // 
            // 
            // 
            // 
            textBackupFilter.CustomButton.Image = null;
            textBackupFilter.CustomButton.Location = new System.Drawing.Point(256, 1);
            textBackupFilter.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBackupFilter.CustomButton.Name = "";
            textBackupFilter.CustomButton.Size = new System.Drawing.Size(25, 25);
            textBackupFilter.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textBackupFilter.CustomButton.TabIndex = 1;
            textBackupFilter.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textBackupFilter.CustomButton.UseSelectable = true;
            textBackupFilter.CustomButton.Visible = false;
            textBackupFilter.Location = new System.Drawing.Point(119, 65);
            textBackupFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBackupFilter.MaxLength = 32767;
            textBackupFilter.Name = "textBackupFilter";
            textBackupFilter.PasswordChar = '\0';
            textBackupFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBackupFilter.SelectedText = "";
            textBackupFilter.SelectionLength = 0;
            textBackupFilter.SelectionStart = 0;
            textBackupFilter.ShortcutsEnabled = true;
            textBackupFilter.Size = new System.Drawing.Size(282, 27);
            textBackupFilter.TabIndex = 1;
            textBackupFilter.UseSelectable = true;
            textBackupFilter.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textBackupFilter.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textWatchFilter
            // 
            // 
            // 
            // 
            textWatchFilter.CustomButton.Image = null;
            textWatchFilter.CustomButton.Location = new System.Drawing.Point(256, 1);
            textWatchFilter.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textWatchFilter.CustomButton.Name = "";
            textWatchFilter.CustomButton.Size = new System.Drawing.Size(25, 25);
            textWatchFilter.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            textWatchFilter.CustomButton.TabIndex = 1;
            textWatchFilter.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            textWatchFilter.CustomButton.UseSelectable = true;
            textWatchFilter.CustomButton.Visible = false;
            textWatchFilter.Location = new System.Drawing.Point(119, 103);
            textWatchFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textWatchFilter.MaxLength = 32767;
            textWatchFilter.Name = "textWatchFilter";
            textWatchFilter.PasswordChar = '\0';
            textWatchFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textWatchFilter.SelectedText = "";
            textWatchFilter.SelectionLength = 0;
            textWatchFilter.SelectionStart = 0;
            textWatchFilter.ShortcutsEnabled = true;
            textWatchFilter.Size = new System.Drawing.Size(282, 27);
            textWatchFilter.TabIndex = 2;
            textWatchFilter.UseSelectable = true;
            textWatchFilter.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            textWatchFilter.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelWatchFilter
            // 
            labelWatchFilter.AutoSize = true;
            labelWatchFilter.Location = new System.Drawing.Point(27, 107);
            labelWatchFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWatchFilter.Name = "labelWatchFilter";
            labelWatchFilter.Size = new System.Drawing.Size(82, 19);
            labelWatchFilter.TabIndex = 10;
            labelWatchFilter.Text = "Watch Filter:";
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(217, 174);
            buttonOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(88, 27);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ok";
            buttonOk.UseSelectable = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(313, 174);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(88, 27);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseSelectable = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new System.Drawing.Point(121, 174);
            buttonClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new System.Drawing.Size(88, 27);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Reset";
            buttonClear.UseSelectable = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // metroToolTip1
            // 
            metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            metroToolTip1.StyleManager = null;
            metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // linkRegex
            // 
            linkRegex.Location = new System.Drawing.Point(26, 86);
            linkRegex.Name = "linkRegex";
            linkRegex.Size = new System.Drawing.Size(88, 16);
            linkRegex.TabIndex = 18;
            linkRegex.Text = "(regex syntax)";
            linkRegex.UseSelectable = true;
            linkRegex.UseVisualStyleBackColor = true;
            linkRegex.Click += linkRegex_Click;
            // 
            // linkWatcher
            // 
            linkWatcher.Location = new System.Drawing.Point(8, 124);
            linkWatcher.Name = "linkWatcher";
            linkWatcher.Size = new System.Drawing.Size(110, 15);
            linkWatcher.TabIndex = 18;
            linkWatcher.Text = "(watcher syntax)";
            linkWatcher.UseSelectable = true;
            linkWatcher.UseVisualStyleBackColor = true;
            linkWatcher.Click += linkWatcher_Click;
            // 
            // toggleWatchSubfolders
            // 
            toggleWatchSubfolders.AutoSize = true;
            toggleWatchSubfolders.Location = new System.Drawing.Point(119, 141);
            toggleWatchSubfolders.Name = "toggleWatchSubfolders";
            toggleWatchSubfolders.Size = new System.Drawing.Size(80, 19);
            toggleWatchSubfolders.TabIndex = 19;
            toggleWatchSubfolders.Text = "Off";
            toggleWatchSubfolders.UseSelectable = true;
            toggleWatchSubfolders.UseVisualStyleBackColor = true;
            // 
            // labelKillBeforeRestore
            // 
            labelKillBeforeRestore.AutoSize = true;
            labelKillBeforeRestore.Location = new System.Drawing.Point(6, 142);
            labelKillBeforeRestore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelKillBeforeRestore.Name = "labelKillBeforeRestore";
            labelKillBeforeRestore.Size = new System.Drawing.Size(109, 19);
            labelKillBeforeRestore.TabIndex = 26;
            labelKillBeforeRestore.Text = "Watch subfolders";
            // 
            // AdvancedFiltering
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(428, 219);
            Controls.Add(labelKillBeforeRestore);
            Controls.Add(toggleWatchSubfolders);
            Controls.Add(linkWatcher);
            Controls.Add(linkRegex);
            Controls.Add(buttonClear);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(labelBackupFilter);
            Controls.Add(textBackupFilter);
            Controls.Add(textWatchFilter);
            Controls.Add(labelWatchFilter);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "AdvancedFiltering";
            Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            Resizable = false;
            Text = "Advanced Filtering";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MetroFramework.Controls.MetroLabel labelBackupFilter;
        private MetroFramework.Controls.MetroTextBox textBackupFilter;
        private MetroFramework.Controls.MetroTextBox textWatchFilter;
        private MetroFramework.Controls.MetroLabel labelWatchFilter;
        private MetroFramework.Controls.MetroButton buttonOk;
        private MetroFramework.Controls.MetroButton buttonCancel;
        private MetroFramework.Controls.MetroButton buttonClear;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLink linkRegex;
        private MetroFramework.Controls.MetroLink linkWatcher;
        private MetroFramework.Controls.MetroToggle toggleWatchSubfolders;
        private MetroFramework.Controls.MetroLabel labelKillBeforeRestore;
    }
}