namespace ZomboidBackupManager
{
    partial class UpdateInfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInfoWindow));
            OkButton = new Button();
            ChangeLogTextBox = new RichTextBox();
            GeneralInfoLabel = new Label();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.Location = new Point(549, 717);
            OkButton.Margin = new Padding(540, 3, 540, 3);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(86, 32);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // ChangeLogTextBox
            // 
            ChangeLogTextBox.Location = new Point(34, 58);
            ChangeLogTextBox.Margin = new Padding(25);
            ChangeLogTextBox.Name = "ChangeLogTextBox";
            ChangeLogTextBox.Size = new Size(1116, 631);
            ChangeLogTextBox.TabIndex = 1;
            ChangeLogTextBox.Text = "";
            // 
            // GeneralInfoLabel
            // 
            GeneralInfoLabel.AutoSize = true;
            GeneralInfoLabel.Font = new Font("Bahnschrift", 18F);
            GeneralInfoLabel.Location = new Point(475, 14);
            GeneralInfoLabel.Margin = new Padding(480, 5, 480, 25);
            GeneralInfoLabel.Name = "GeneralInfoLabel";
            GeneralInfoLabel.Size = new Size(220, 29);
            GeneralInfoLabel.TabIndex = 2;
            GeneralInfoLabel.Text = "Update Information";
            // 
            // UpdateInfoWindow
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 761);
            Controls.Add(GeneralInfoLabel);
            Controls.Add(ChangeLogTextBox);
            Controls.Add(OkButton);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateInfoWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Information";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkButton;
        private RichTextBox ChangeLogTextBox;
        private Label GeneralInfoLabel;
    }
}