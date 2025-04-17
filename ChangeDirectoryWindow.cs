using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZomboidBackupManager
{
    public partial class ChangeDirectoryWindow : Form
    {
        private string currentPath;
        public string CurrentPath { get { return currentPath; } }

        public ChangeDirectoryWindow()
        {

            InitializeComponent();
            currentPath = Configuration.currentBaseBackupFolderPATH;
            SetBackupFolderPathTextbox();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", currentPath);
        }

        private void ChangeDirectoryButton_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog();
        }

        private void ShowFolderBrowserDialog()
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)  //check for OK...they might press cancel, so don't do anything if they did.
            {
                var path = dialog.SelectedPath;

                if (Directory.Exists(path))
                {
                    //Configuration.ChangeBackupFolderPath(path);
                    currentPath = path;
                }

                SetBackupFolderPathTextbox();
            }
        }

        private void SetBackupFolderPathTextbox()
        {
            BackupFolderPathTextbox.Text = currentPath;
        }

    }
}
