namespace ZomboidBackupManager
{
    partial class DataCleanupHelperWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCleanupHelperWindow));
            MainPanel = new Panel();
            MainTextBox = new RichTextBox();
            ShowTextLabel = new Label();
            CloseButton = new Button();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = Color.Transparent;
            MainPanel.BorderStyle = BorderStyle.Fixed3D;
            MainPanel.Controls.Add(MainTextBox);
            MainPanel.Controls.Add(ShowTextLabel);
            MainPanel.Location = new Point(14, 19);
            MainPanel.Margin = new Padding(5, 10, 5, 35);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(756, 796);
            MainPanel.TabIndex = 0;
            // 
            // MainTextBox
            // 
            MainTextBox.BackColor = SystemColors.WindowFrame;
            MainTextBox.Dock = DockStyle.Fill;
            MainTextBox.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainTextBox.ForeColor = Color.Yellow;
            MainTextBox.Location = new Point(0, 0);
            MainTextBox.Name = "MainTextBox";
            MainTextBox.Size = new Size(752, 792);
            MainTextBox.TabIndex = 0;
            MainTextBox.Text = "";
            MainTextBox.Click += MainTextBox_Click;
            // 
            // ShowTextLabel
            // 
            ShowTextLabel.AutoSize = true;
            ShowTextLabel.BackColor = Color.IndianRed;
            ShowTextLabel.Font = new Font("Impact", 27F);
            ShowTextLabel.Location = new Point(255, 81);
            ShowTextLabel.Name = "ShowTextLabel";
            ShowTextLabel.Size = new Size(242, 44);
            ShowTextLabel.TabIndex = 2;
            ShowTextLabel.Text = "SHOW TEXT BOX";
            ShowTextLabel.Visible = false;
            ShowTextLabel.Click += ShowTextLabel_Click;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(300, 818);
            CloseButton.Margin = new Padding(300, 2, 300, 2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(175, 38);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // DataCleanupHelperWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(784, 861);
            Controls.Add(CloseButton);
            Controls.Add(MainPanel);
            Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 900);
            MinimizeBox = false;
            MinimumSize = new Size(400, 450);
            Name = "DataCleanupHelperWindow";
            RightToLeft = RightToLeft.No;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Help";
            TopMost = true;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private RichTextBox MainTextBox;
        private Button CloseButton;
        private Label ShowTextLabel;
    }
}