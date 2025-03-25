using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public partial class MiniBackupWindow : Form
    {
        public MiniBackupWindow()
        {
            InitializeComponent();
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            await backup.DoBackup(currentLoadedSavegame, currentLoadedGamemode, GetFullLoadedSavegamePath(), currentLoadedBackupFolderPATH, GetLastBackupIndexFromJson(), ProgressLabel, ProgressBar);
        }

        private void MiniBackupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
