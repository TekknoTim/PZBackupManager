namespace ZomboidBackupManager
{
    partial class SmartBackupSetupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartBackupSetupWindow));
            MainPanel = new Panel();
            BottomPanel = new Panel();
            DoneButton = new Button();
            ToggleSmartBackupPanel = new Panel();
            EnableSmartBackupRadioButton = new RadioButton();
            ToggleSmartBackupSpacerLabel = new Label();
            DisableSmartBackupRadioButton = new RadioButton();
            MainPanel.SuspendLayout();
            BottomPanel.SuspendLayout();
            ToggleSmartBackupPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ControlDarkDark;
            MainPanel.BorderStyle = BorderStyle.Fixed3D;
            MainPanel.Controls.Add(BottomPanel);
            MainPanel.Controls.Add(ToggleSmartBackupPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(2, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new Padding(5);
            MainPanel.Size = new Size(480, 307);
            MainPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            BottomPanel.AutoSize = true;
            BottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BottomPanel.BackColor = SystemColors.ControlDark;
            BottomPanel.Controls.Add(DoneButton);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Font = new Font("Bahnschrift", 11F);
            BottomPanel.Location = new Point(5, 258);
            BottomPanel.MaximumSize = new Size(465, 40);
            BottomPanel.MinimumSize = new Size(450, 40);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(465, 40);
            BottomPanel.TabIndex = 1;
            // 
            // DoneButton
            // 
            DoneButton.AutoSize = true;
            DoneButton.BackColor = SystemColors.Control;
            DoneButton.Dock = DockStyle.Fill;
            DoneButton.Location = new Point(0, 0);
            DoneButton.Margin = new Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(465, 40);
            DoneButton.TabIndex = 0;
            DoneButton.Text = "Done";
            DoneButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // ToggleSmartBackupPanel
            // 
            ToggleSmartBackupPanel.AutoSize = true;
            ToggleSmartBackupPanel.BackColor = SystemColors.Control;
            ToggleSmartBackupPanel.BorderStyle = BorderStyle.Fixed3D;
            ToggleSmartBackupPanel.Controls.Add(EnableSmartBackupRadioButton);
            ToggleSmartBackupPanel.Controls.Add(ToggleSmartBackupSpacerLabel);
            ToggleSmartBackupPanel.Controls.Add(DisableSmartBackupRadioButton);
            ToggleSmartBackupPanel.Dock = DockStyle.Top;
            ToggleSmartBackupPanel.Location = new Point(5, 5);
            ToggleSmartBackupPanel.MaximumSize = new Size(200, 75);
            ToggleSmartBackupPanel.MinimumSize = new Size(200, 75);
            ToggleSmartBackupPanel.Name = "ToggleSmartBackupPanel";
            ToggleSmartBackupPanel.Padding = new Padding(5);
            ToggleSmartBackupPanel.Size = new Size(200, 75);
            ToggleSmartBackupPanel.TabIndex = 0;
            // 
            // EnableSmartBackupRadioButton
            // 
            EnableSmartBackupRadioButton.AutoCheck = false;
            EnableSmartBackupRadioButton.AutoSize = true;
            EnableSmartBackupRadioButton.Dock = DockStyle.Top;
            EnableSmartBackupRadioButton.Font = new Font("Bahnschrift", 11F);
            EnableSmartBackupRadioButton.Location = new Point(5, 39);
            EnableSmartBackupRadioButton.Margin = new Padding(10);
            EnableSmartBackupRadioButton.Name = "EnableSmartBackupRadioButton";
            EnableSmartBackupRadioButton.Size = new Size(186, 22);
            EnableSmartBackupRadioButton.TabIndex = 0;
            EnableSmartBackupRadioButton.Text = "Enable Smart Backup";
            EnableSmartBackupRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            EnableSmartBackupRadioButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            EnableSmartBackupRadioButton.UseVisualStyleBackColor = true;
            EnableSmartBackupRadioButton.MouseClick += EnableSmartBackupRadioButton_MouseClick;
            // 
            // ToggleSmartBackupSpacerLabel
            // 
            ToggleSmartBackupSpacerLabel.AutoSize = true;
            ToggleSmartBackupSpacerLabel.Dock = DockStyle.Top;
            ToggleSmartBackupSpacerLabel.Font = new Font("Bahnschrift", 11F);
            ToggleSmartBackupSpacerLabel.Location = new Point(5, 27);
            ToggleSmartBackupSpacerLabel.MaximumSize = new Size(196, 12);
            ToggleSmartBackupSpacerLabel.MinimumSize = new Size(196, 12);
            ToggleSmartBackupSpacerLabel.Name = "ToggleSmartBackupSpacerLabel";
            ToggleSmartBackupSpacerLabel.Size = new Size(196, 12);
            ToggleSmartBackupSpacerLabel.TabIndex = 2;
            ToggleSmartBackupSpacerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DisableSmartBackupRadioButton
            // 
            DisableSmartBackupRadioButton.AutoCheck = false;
            DisableSmartBackupRadioButton.AutoSize = true;
            DisableSmartBackupRadioButton.Checked = true;
            DisableSmartBackupRadioButton.Dock = DockStyle.Top;
            DisableSmartBackupRadioButton.Font = new Font("Bahnschrift", 11F);
            DisableSmartBackupRadioButton.Location = new Point(5, 5);
            DisableSmartBackupRadioButton.Margin = new Padding(10);
            DisableSmartBackupRadioButton.Name = "DisableSmartBackupRadioButton";
            DisableSmartBackupRadioButton.Size = new Size(186, 22);
            DisableSmartBackupRadioButton.TabIndex = 1;
            DisableSmartBackupRadioButton.TabStop = true;
            DisableSmartBackupRadioButton.Text = "Disable Smart Backup";
            DisableSmartBackupRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            DisableSmartBackupRadioButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DisableSmartBackupRadioButton.UseVisualStyleBackColor = true;
            DisableSmartBackupRadioButton.MouseClick += DisableSmartBackupRadioButton_MouseClick;
            // 
            // SmartBackupSetupWindow
            // 
            AcceptButton = DoneButton;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 311);
            Controls.Add(MainPanel);
            DoubleBuffered = true;
            Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MaximumSize = new Size(750, 600);
            MinimizeBox = false;
            MinimumSize = new Size(500, 350);
            Name = "SmartBackupSetupWindow";
            Padding = new Padding(2);
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Smart Backup Setup";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            BottomPanel.ResumeLayout(false);
            BottomPanel.PerformLayout();
            ToggleSmartBackupPanel.ResumeLayout(false);
            ToggleSmartBackupPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Panel ToggleSmartBackupPanel;
        private RadioButton EnableSmartBackupRadioButton;
        private RadioButton DisableSmartBackupRadioButton;
        private Label ToggleSmartBackupSpacerLabel;
        private Panel BottomPanel;
        private Button DoneButton;
    }
}