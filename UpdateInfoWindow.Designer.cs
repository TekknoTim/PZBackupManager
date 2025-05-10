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
            OkButton.AutoSize = true;
            OkButton.Location = new Point(353, 540);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 29);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // ChangeLogTextBox
            // 
            ChangeLogTextBox.Location = new Point(34, 103);
            ChangeLogTextBox.Margin = new Padding(25);
            ChangeLogTextBox.Name = "ChangeLogTextBox";
            ChangeLogTextBox.Size = new Size(716, 409);
            ChangeLogTextBox.TabIndex = 1;
            ChangeLogTextBox.Text = "";
            // 
            // GeneralInfoLabel
            // 
            GeneralInfoLabel.AutoSize = true;
            GeneralInfoLabel.Location = new Point(317, 34);
            GeneralInfoLabel.Margin = new Padding(25);
            GeneralInfoLabel.Name = "GeneralInfoLabel";
            GeneralInfoLabel.Size = new Size(148, 19);
            GeneralInfoLabel.TabIndex = 2;
            GeneralInfoLabel.Text = "Update Information";
            // 
            // UpdateInfoWindow
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(784, 591);
            Controls.Add(GeneralInfoLabel);
            Controls.Add(ChangeLogTextBox);
            Controls.Add(OkButton);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateInfoWindow";
            Opacity = 0.9D;
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