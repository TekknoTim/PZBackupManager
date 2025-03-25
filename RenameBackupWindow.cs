namespace ZomboidBackupManager
{
    public partial class RenameBackupWindow : Form
    {
        public string InputText { get { return RenameBackupTextBox.Text; } }

        public RenameBackupWindow(string oldName)
        {
            InitializeComponent();
            EnterNameTextLabel.Text = $"Please enter a new name for = [{oldName}]";

        }

        private void RenameBackupTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelRenameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmRenameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
