using System.Windows.Forms;

namespace ZomboidBackupManager
{
    partial class RenameBackupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameBackupWindow));
            RenameBackupTextBox = new TextBox();
            EnterNameTextLabel = new Label();
            ConfirmRenameButton = new Button();
            CancelRenameButton = new Button();
            SuspendLayout();
            // 
            // RenameBackupTextBox
            // 
            RenameBackupTextBox.Location = new Point(19, 43);
            RenameBackupTextBox.Margin = new Padding(20, 20, 20, 50);
            RenameBackupTextBox.Name = "RenameBackupTextBox";
            RenameBackupTextBox.Size = new Size(496, 23);
            RenameBackupTextBox.TabIndex = 0;
            RenameBackupTextBox.TextChanged += RenameBackupTextBox_TextChanged;
            // 
            // EnterNameTextLabel
            // 
            EnterNameTextLabel.AutoSize = true;
            EnterNameTextLabel.BorderStyle = BorderStyle.FixedSingle;
            EnterNameTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterNameTextLabel.Location = new Point(19, 19);
            EnterNameTextLabel.Margin = new Padding(10);
            EnterNameTextLabel.Name = "EnterNameTextLabel";
            EnterNameTextLabel.Size = new Size(2, 21);
            EnterNameTextLabel.TabIndex = 1;
            EnterNameTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmRenameButton
            // 
            ConfirmRenameButton.DialogResult = DialogResult.OK;
            ConfirmRenameButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConfirmRenameButton.Location = new Point(387, 88);
            ConfirmRenameButton.Name = "ConfirmRenameButton";
            ConfirmRenameButton.Size = new Size(128, 36);
            ConfirmRenameButton.TabIndex = 2;
            ConfirmRenameButton.Text = "Rename";
            ConfirmRenameButton.UseVisualStyleBackColor = true;
            ConfirmRenameButton.Click += ConfirmRenameButton_Click;
            // 
            // CancelRenameButton
            // 
            CancelRenameButton.DialogResult = DialogResult.Cancel;
            CancelRenameButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelRenameButton.Location = new Point(19, 88);
            CancelRenameButton.Name = "CancelRenameButton";
            CancelRenameButton.Size = new Size(128, 36);
            CancelRenameButton.TabIndex = 3;
            CancelRenameButton.Text = "Cancel";
            CancelRenameButton.UseVisualStyleBackColor = true;
            CancelRenameButton.Click += CancelRenameButton_Click;
            // 
            // RenameBackupWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 136);
            Controls.Add(CancelRenameButton);
            Controls.Add(ConfirmRenameButton);
            Controls.Add(RenameBackupTextBox);
            Controls.Add(EnterNameTextLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RenameBackupWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rename Backup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox RenameBackupTextBox;
        private Label EnterNameTextLabel;
        private Button ConfirmRenameButton;
        private Button CancelRenameButton;
    }
}