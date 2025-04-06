namespace ZomboidBackupManager
{
    partial class ZipArchiveSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipArchiveSetup));
            SaveButton = new Button();
            AbortButton = new Button();
            CheckboxPanel = new Panel();
            UseExternalArchiverCheckBox = new CheckBox();
            KeepLooseFilesCheckBox = new CheckBox();
            CreateZipArchivesCheckBox = new CheckBox();
            ExternalArchiverPanel = new Panel();
            Select7ZipRadioButton = new RadioButton();
            SelectWinRarRadioButton = new RadioButton();
            ArchiverExeTextBox = new RichTextBox();
            SelectExePanel = new Panel();
            SelectExeTextLabel = new Label();
            SelectExeButton = new Button();
            CheckboxPanel.SuspendLayout();
            ExternalArchiverPanel.SuspendLayout();
            SelectExePanel.SuspendLayout();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.DialogResult = DialogResult.OK;
            SaveButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.Location = new Point(214, 284);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(100, 30);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AbortButton
            // 
            AbortButton.DialogResult = DialogResult.Cancel;
            AbortButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AbortButton.Location = new Point(12, 284);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(100, 30);
            AbortButton.TabIndex = 1;
            AbortButton.Text = "Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += AbortButton_Click;
            // 
            // CheckboxPanel
            // 
            CheckboxPanel.BackColor = SystemColors.ControlLight;
            CheckboxPanel.BorderStyle = BorderStyle.Fixed3D;
            CheckboxPanel.Controls.Add(UseExternalArchiverCheckBox);
            CheckboxPanel.Controls.Add(KeepLooseFilesCheckBox);
            CheckboxPanel.Controls.Add(CreateZipArchivesCheckBox);
            CheckboxPanel.Location = new Point(12, 12);
            CheckboxPanel.Margin = new Padding(5);
            CheckboxPanel.Name = "CheckboxPanel";
            CheckboxPanel.Size = new Size(300, 75);
            CheckboxPanel.TabIndex = 2;
            // 
            // UseExternalArchiverCheckBox
            // 
            UseExternalArchiverCheckBox.BackColor = SystemColors.ControlLight;
            UseExternalArchiverCheckBox.Checked = true;
            UseExternalArchiverCheckBox.CheckState = CheckState.Checked;
            UseExternalArchiverCheckBox.Dock = DockStyle.Top;
            UseExternalArchiverCheckBox.Enabled = false;
            UseExternalArchiverCheckBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UseExternalArchiverCheckBox.Location = new Point(0, 50);
            UseExternalArchiverCheckBox.Margin = new Padding(15);
            UseExternalArchiverCheckBox.Name = "UseExternalArchiverCheckBox";
            UseExternalArchiverCheckBox.Size = new Size(296, 25);
            UseExternalArchiverCheckBox.TabIndex = 2;
            UseExternalArchiverCheckBox.Text = "Use External Archiver";
            UseExternalArchiverCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            UseExternalArchiverCheckBox.UseVisualStyleBackColor = false;
            UseExternalArchiverCheckBox.Click += UseExternalArchiverCheckBox_Click;
            // 
            // KeepLooseFilesCheckBox
            // 
            KeepLooseFilesCheckBox.BackColor = SystemColors.ControlLight;
            KeepLooseFilesCheckBox.Checked = true;
            KeepLooseFilesCheckBox.CheckState = CheckState.Checked;
            KeepLooseFilesCheckBox.Dock = DockStyle.Top;
            KeepLooseFilesCheckBox.Enabled = false;
            KeepLooseFilesCheckBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KeepLooseFilesCheckBox.Location = new Point(0, 25);
            KeepLooseFilesCheckBox.Margin = new Padding(15);
            KeepLooseFilesCheckBox.Name = "KeepLooseFilesCheckBox";
            KeepLooseFilesCheckBox.Size = new Size(296, 25);
            KeepLooseFilesCheckBox.TabIndex = 1;
            KeepLooseFilesCheckBox.Text = "Keep Loose Files";
            KeepLooseFilesCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            KeepLooseFilesCheckBox.UseVisualStyleBackColor = false;
            // 
            // CreateZipArchivesCheckBox
            // 
            CreateZipArchivesCheckBox.BackColor = SystemColors.ControlLight;
            CreateZipArchivesCheckBox.Dock = DockStyle.Top;
            CreateZipArchivesCheckBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateZipArchivesCheckBox.Location = new Point(0, 0);
            CreateZipArchivesCheckBox.Margin = new Padding(15);
            CreateZipArchivesCheckBox.Name = "CreateZipArchivesCheckBox";
            CreateZipArchivesCheckBox.Size = new Size(296, 25);
            CreateZipArchivesCheckBox.TabIndex = 0;
            CreateZipArchivesCheckBox.Text = "Create Zip Archives";
            CreateZipArchivesCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            CreateZipArchivesCheckBox.UseVisualStyleBackColor = false;
            CreateZipArchivesCheckBox.CheckedChanged += CreateZipArchivesCheckBox_CheckedChanged;
            CreateZipArchivesCheckBox.Click += CreateZipArchivesCheckBox_Click;
            // 
            // ExternalArchiverPanel
            // 
            ExternalArchiverPanel.BackColor = SystemColors.ControlLight;
            ExternalArchiverPanel.BorderStyle = BorderStyle.Fixed3D;
            ExternalArchiverPanel.Controls.Add(Select7ZipRadioButton);
            ExternalArchiverPanel.Controls.Add(SelectWinRarRadioButton);
            ExternalArchiverPanel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExternalArchiverPanel.Location = new Point(14, 107);
            ExternalArchiverPanel.Name = "ExternalArchiverPanel";
            ExternalArchiverPanel.Size = new Size(300, 50);
            ExternalArchiverPanel.TabIndex = 3;
            // 
            // Select7ZipRadioButton
            // 
            Select7ZipRadioButton.Appearance = Appearance.Button;
            Select7ZipRadioButton.Dock = DockStyle.Top;
            Select7ZipRadioButton.Location = new Point(0, 25);
            Select7ZipRadioButton.Margin = new Padding(15);
            Select7ZipRadioButton.Name = "Select7ZipRadioButton";
            Select7ZipRadioButton.Size = new Size(296, 25);
            Select7ZipRadioButton.TabIndex = 1;
            Select7ZipRadioButton.Text = "7Zip";
            Select7ZipRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            Select7ZipRadioButton.UseVisualStyleBackColor = true;
            Select7ZipRadioButton.CheckedChanged += RadioButtons_CheckedChanged;
            // 
            // SelectWinRarRadioButton
            // 
            SelectWinRarRadioButton.Appearance = Appearance.Button;
            SelectWinRarRadioButton.Checked = true;
            SelectWinRarRadioButton.Dock = DockStyle.Top;
            SelectWinRarRadioButton.FlatAppearance.CheckedBackColor = Color.FromArgb(128, 64, 64);
            SelectWinRarRadioButton.Location = new Point(0, 0);
            SelectWinRarRadioButton.Margin = new Padding(15);
            SelectWinRarRadioButton.Name = "SelectWinRarRadioButton";
            SelectWinRarRadioButton.Size = new Size(296, 25);
            SelectWinRarRadioButton.TabIndex = 0;
            SelectWinRarRadioButton.TabStop = true;
            SelectWinRarRadioButton.Text = "WinRar";
            SelectWinRarRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            SelectWinRarRadioButton.UseVisualStyleBackColor = true;
            SelectWinRarRadioButton.CheckedChanged += RadioButtons_CheckedChanged;
            SelectWinRarRadioButton.Click += SelectWinRarRadioButton_Click;
            // 
            // ArchiverExeTextBox
            // 
            ArchiverExeTextBox.Dock = DockStyle.Bottom;
            ArchiverExeTextBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ArchiverExeTextBox.Location = new Point(0, 41);
            ArchiverExeTextBox.MaxLength = 500;
            ArchiverExeTextBox.Multiline = false;
            ArchiverExeTextBox.Name = "ArchiverExeTextBox";
            ArchiverExeTextBox.ScrollBars = RichTextBoxScrollBars.None;
            ArchiverExeTextBox.Size = new Size(296, 30);
            ArchiverExeTextBox.TabIndex = 4;
            ArchiverExeTextBox.Text = "C:\\";
            ArchiverExeTextBox.Click += ArchiverExeTextBox_Click;
            // 
            // SelectExePanel
            // 
            SelectExePanel.BackColor = SystemColors.ControlLight;
            SelectExePanel.BorderStyle = BorderStyle.Fixed3D;
            SelectExePanel.Controls.Add(SelectExeTextLabel);
            SelectExePanel.Controls.Add(SelectExeButton);
            SelectExePanel.Controls.Add(ArchiverExeTextBox);
            SelectExePanel.Location = new Point(12, 177);
            SelectExePanel.Name = "SelectExePanel";
            SelectExePanel.Size = new Size(300, 75);
            SelectExePanel.TabIndex = 5;
            // 
            // SelectExeTextLabel
            // 
            SelectExeTextLabel.BackColor = SystemColors.Control;
            SelectExeTextLabel.BorderStyle = BorderStyle.Fixed3D;
            SelectExeTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectExeTextLabel.Location = new Point(5, 5);
            SelectExeTextLabel.Margin = new Padding(5, 0, 3, 0);
            SelectExeTextLabel.Name = "SelectExeTextLabel";
            SelectExeTextLabel.Size = new Size(159, 30);
            SelectExeTextLabel.TabIndex = 6;
            SelectExeTextLabel.Text = "Select WinRaR.exe";
            SelectExeTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectExeButton
            // 
            SelectExeButton.BackColor = SystemColors.Control;
            SelectExeButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectExeButton.Location = new Point(191, 5);
            SelectExeButton.Margin = new Padding(5);
            SelectExeButton.Name = "SelectExeButton";
            SelectExeButton.Size = new Size(100, 30);
            SelectExeButton.TabIndex = 5;
            SelectExeButton.Text = "Select";
            SelectExeButton.UseVisualStyleBackColor = false;
            SelectExeButton.Click += SelectExeButton_Click;
            // 
            // ZipArchiveSetup
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = AbortButton;
            ClientSize = new Size(333, 326);
            Controls.Add(SelectExePanel);
            Controls.Add(ExternalArchiverPanel);
            Controls.Add(CheckboxPanel);
            Controls.Add(AbortButton);
            Controls.Add(SaveButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ZipArchiveSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZipArchiveSetup";
            CheckboxPanel.ResumeLayout(false);
            ExternalArchiverPanel.ResumeLayout(false);
            SelectExePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button SaveButton;
        private Button AbortButton;
        private Panel CheckboxPanel;
        private CheckBox CreateZipArchivesCheckBox;
        private CheckBox KeepLooseFilesCheckBox;
        private CheckBox UseExternalArchiverCheckBox;
        private Panel ExternalArchiverPanel;
        private RadioButton Select7ZipRadioButton;
        private RadioButton SelectWinRarRadioButton;
        private RichTextBox ArchiverExeTextBox;
        private Panel SelectExePanel;
        private Label SelectExeTextLabel;
        private Button SelectExeButton;
    }
}