namespace ZomboidBackupManager
{
    partial class TestCommandWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestCommandWindow));
            OKButton = new Button();
            InfoLabelText = new Label();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OKButton.Location = new Point(103, 135);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(115, 42);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // InfoLabelText
            // 
            InfoLabelText.AutoSize = true;
            InfoLabelText.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InfoLabelText.Location = new Point(85, 61);
            InfoLabelText.Name = "InfoLabelText";
            InfoLabelText.Size = new Size(156, 19);
            InfoLabelText.TabIndex = 1;
            InfoLabelText.Text = "Test was successful!";
            // 
            // TestCommandWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 189);
            Controls.Add(InfoLabelText);
            Controls.Add(OKButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TestCommandWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup Manager Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OKButton;
        private Label InfoLabelText;
    }
}