namespace ZomboidBackupManager
{
    partial class ChangeDirectoryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDirectoryWindow));
            SaveButton = new Button();
            CancelButton = new Button();
            BackupFolderPathTextbox = new RichTextBox();
            ChangeDirLabel = new Label();
            ChangeDirectoryButton = new Button();
            OpenFolderButton = new Button();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.DialogResult = DialogResult.OK;
            SaveButton.Location = new Point(470, 124);
            SaveButton.Margin = new Padding(5);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(100, 30);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(14, 124);
            CancelButton.Margin = new Padding(5);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(100, 30);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // BackupFolderPathTextbox
            // 
            BackupFolderPathTextbox.BackColor = SystemColors.ControlLightLight;
            BackupFolderPathTextbox.DetectUrls = false;
            BackupFolderPathTextbox.EnableAutoDragDrop = true;
            BackupFolderPathTextbox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupFolderPathTextbox.Location = new Point(14, 31);
            BackupFolderPathTextbox.Margin = new Padding(30, 3, 30, 3);
            BackupFolderPathTextbox.Multiline = false;
            BackupFolderPathTextbox.Name = "BackupFolderPathTextbox";
            BackupFolderPathTextbox.ScrollBars = RichTextBoxScrollBars.Horizontal;
            BackupFolderPathTextbox.Size = new Size(556, 27);
            BackupFolderPathTextbox.TabIndex = 5;
            BackupFolderPathTextbox.TabStop = false;
            BackupFolderPathTextbox.Text = "";
            // 
            // ChangeDirLabel
            // 
            ChangeDirLabel.AutoSize = true;
            ChangeDirLabel.Location = new Point(12, 9);
            ChangeDirLabel.Name = "ChangeDirLabel";
            ChangeDirLabel.Size = new Size(193, 19);
            ChangeDirLabel.TabIndex = 6;
            ChangeDirLabel.Text = "Change Backup Directory";
            // 
            // ChangeDirectoryButton
            // 
            ChangeDirectoryButton.Location = new Point(470, 66);
            ChangeDirectoryButton.Margin = new Padding(5);
            ChangeDirectoryButton.Name = "ChangeDirectoryButton";
            ChangeDirectoryButton.Size = new Size(100, 30);
            ChangeDirectoryButton.TabIndex = 7;
            ChangeDirectoryButton.Text = "Change";
            ChangeDirectoryButton.UseVisualStyleBackColor = true;
            ChangeDirectoryButton.Click += ChangeDirectoryButton_Click;
            // 
            // OpenFolderButton
            // 
            OpenFolderButton.Location = new Point(14, 66);
            OpenFolderButton.Margin = new Padding(5);
            OpenFolderButton.Name = "OpenFolderButton";
            OpenFolderButton.Size = new Size(100, 30);
            OpenFolderButton.TabIndex = 8;
            OpenFolderButton.Text = "Open";
            OpenFolderButton.UseVisualStyleBackColor = true;
            OpenFolderButton.Click += OpenFolderButton_Click;
            // 
            // ChangeDirectoryWindow
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = CancelButton;
            ClientSize = new Size(584, 168);
            Controls.Add(OpenFolderButton);
            Controls.Add(ChangeDirectoryButton);
            Controls.Add(ChangeDirLabel);
            Controls.Add(BackupFolderPathTextbox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangeDirectoryWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Backup Directory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private RichTextBox BackupFolderPathTextbox;
        private Label ChangeDirLabel;
        private Button ChangeDirectoryButton;
        private Button OpenFolderButton;
    }
}