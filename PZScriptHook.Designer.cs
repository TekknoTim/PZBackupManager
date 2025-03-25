namespace ZomboidBackupManager
{
    partial class PZScriptHook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PZScriptHook));
            StartStopButton = new Button();
            txtLog = new ListBox();
            LoadedSavegameInfoPanel = new Panel();
            ChangeSelectionLabelText = new Label();
            SavegameComboBox = new ComboBox();
            GamemodesComboBox = new ComboBox();
            AlwaysOnTopCheckbox = new CheckBox();
            LoadedSavegameInfoLabel = new Label();
            SavegameNameTextLabel = new Label();
            SavegameNameValueLabel = new Label();
            LoadedSavegameInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // StartStopButton
            // 
            StartStopButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartStopButton.Location = new Point(12, 367);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(360, 50);
            StartStopButton.TabIndex = 0;
            StartStopButton.Text = "Listen to Project Zomboid";
            StartStopButton.UseVisualStyleBackColor = true;
            StartStopButton.Click += StartStopButton_Click;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.FormattingEnabled = true;
            txtLog.Items.AddRange(new object[] { " " });
            txtLog.Location = new Point(12, 213);
            txtLog.Name = "txtLog";
            txtLog.SelectionMode = SelectionMode.None;
            txtLog.Size = new Size(360, 148);
            txtLog.TabIndex = 1;
            // 
            // LoadedSavegameInfoPanel
            // 
            LoadedSavegameInfoPanel.BackColor = SystemColors.ControlDarkDark;
            LoadedSavegameInfoPanel.Controls.Add(ChangeSelectionLabelText);
            LoadedSavegameInfoPanel.Controls.Add(SavegameComboBox);
            LoadedSavegameInfoPanel.Controls.Add(GamemodesComboBox);
            LoadedSavegameInfoPanel.Controls.Add(AlwaysOnTopCheckbox);
            LoadedSavegameInfoPanel.Controls.Add(LoadedSavegameInfoLabel);
            LoadedSavegameInfoPanel.Controls.Add(SavegameNameTextLabel);
            LoadedSavegameInfoPanel.Controls.Add(SavegameNameValueLabel);
            LoadedSavegameInfoPanel.Location = new Point(12, 12);
            LoadedSavegameInfoPanel.Name = "LoadedSavegameInfoPanel";
            LoadedSavegameInfoPanel.Size = new Size(360, 184);
            LoadedSavegameInfoPanel.TabIndex = 13;
            // 
            // ChangeSelectionLabelText
            // 
            ChangeSelectionLabelText.AutoSize = true;
            ChangeSelectionLabelText.Font = new Font("Bahnschrift", 12F);
            ChangeSelectionLabelText.ForeColor = SystemColors.Control;
            ChangeSelectionLabelText.Location = new Point(5, 7);
            ChangeSelectionLabelText.Name = "ChangeSelectionLabelText";
            ChangeSelectionLabelText.Size = new Size(149, 19);
            ChangeSelectionLabelText.TabIndex = 16;
            ChangeSelectionLabelText.Text = "Change Savegame:";
            ChangeSelectionLabelText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SavegameComboBox
            // 
            SavegameComboBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavegameComboBox.FormattingEnabled = true;
            SavegameComboBox.Location = new Point(5, 62);
            SavegameComboBox.Name = "SavegameComboBox";
            SavegameComboBox.Size = new Size(352, 27);
            SavegameComboBox.TabIndex = 15;
            SavegameComboBox.SelectedIndexChanged += SavegameComboBox_SelectedIndexChanged;
            // 
            // GamemodesComboBox
            // 
            GamemodesComboBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GamemodesComboBox.FormattingEnabled = true;
            GamemodesComboBox.Location = new Point(5, 29);
            GamemodesComboBox.Name = "GamemodesComboBox";
            GamemodesComboBox.Size = new Size(352, 27);
            GamemodesComboBox.TabIndex = 14;
            GamemodesComboBox.SelectedIndexChanged += GamemodesComboBox_SelectedIndexChanged;
            // 
            // AlwaysOnTopCheckbox
            // 
            AlwaysOnTopCheckbox.AutoSize = true;
            AlwaysOnTopCheckbox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AlwaysOnTopCheckbox.ForeColor = SystemColors.Control;
            AlwaysOnTopCheckbox.Location = new Point(5, 156);
            AlwaysOnTopCheckbox.Margin = new Padding(5);
            AlwaysOnTopCheckbox.Name = "AlwaysOnTopCheckbox";
            AlwaysOnTopCheckbox.Size = new Size(129, 23);
            AlwaysOnTopCheckbox.TabIndex = 13;
            AlwaysOnTopCheckbox.Text = "Always on top";
            AlwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            AlwaysOnTopCheckbox.CheckedChanged += AlwaysOnTopCheckbox_CheckedChanged;
            // 
            // LoadedSavegameInfoLabel
            // 
            LoadedSavegameInfoLabel.AutoSize = true;
            LoadedSavegameInfoLabel.Font = new Font("Bahnschrift", 12F);
            LoadedSavegameInfoLabel.ForeColor = SystemColors.Control;
            LoadedSavegameInfoLabel.Location = new Point(5, 102);
            LoadedSavegameInfoLabel.Name = "LoadedSavegameInfoLabel";
            LoadedSavegameInfoLabel.Size = new Size(140, 19);
            LoadedSavegameInfoLabel.TabIndex = 12;
            LoadedSavegameInfoLabel.Text = "Currently Loaded:";
            LoadedSavegameInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SavegameNameTextLabel
            // 
            SavegameNameTextLabel.BackColor = SystemColors.Control;
            SavegameNameTextLabel.BorderStyle = BorderStyle.FixedSingle;
            SavegameNameTextLabel.Font = new Font("Bahnschrift", 10F);
            SavegameNameTextLabel.Location = new Point(5, 121);
            SavegameNameTextLabel.Name = "SavegameNameTextLabel";
            SavegameNameTextLabel.Size = new Size(86, 30);
            SavegameNameTextLabel.TabIndex = 10;
            SavegameNameTextLabel.Text = "Savegame:";
            SavegameNameTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavegameNameValueLabel
            // 
            SavegameNameValueLabel.BackColor = SystemColors.Control;
            SavegameNameValueLabel.BorderStyle = BorderStyle.FixedSingle;
            SavegameNameValueLabel.Font = new Font("Bahnschrift", 10F);
            SavegameNameValueLabel.Location = new Point(90, 121);
            SavegameNameValueLabel.Name = "SavegameNameValueLabel";
            SavegameNameValueLabel.Size = new Size(267, 30);
            SavegameNameValueLabel.TabIndex = 11;
            SavegameNameValueLabel.Text = "-";
            SavegameNameValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PZScriptHook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 429);
            Controls.Add(txtLog);
            Controls.Add(StartStopButton);
            Controls.Add(LoadedSavegameInfoPanel);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PZScriptHook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Project Zomboid Manager Script Hook";
            FormClosing += PZScriptHook_FormClosing;
            Shown += PZScriptHook_Shown;
            LoadedSavegameInfoPanel.ResumeLayout(false);
            LoadedSavegameInfoPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button StartStopButton;
        private ListBox txtLog;
        private Panel LoadedSavegameInfoPanel;
        private Label SavegameNameTextLabel;
        private Label SavegameNameValueLabel;
        private Label LoadedSavegameInfoLabel;
        private CheckBox AlwaysOnTopCheckbox;
        private ComboBox GamemodesComboBox;
        private ComboBox SavegameComboBox;
        private Label ChangeSelectionLabelText;
    }
}