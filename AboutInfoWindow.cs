using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static ZomboidBackupManager.Configuration;
using static System.Net.WebRequestMethods;

namespace ZomboidBackupManager
{
    public partial class AboutInfoWindow : Form
    {
        public AboutInfoWindow()
        {
            InitializeComponent();
            VersionLabel.Text = appVersion;
            this.DoubleBuffered(true);
            PZBackupManagerLogoPictureBox.DoubleBuffered(true);
            SteamLogoPictureBox.DoubleBuffered(true);
            GithubLogoPictureBox.DoubleBuffered(true);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }

        private void ChangelogButton_Click(object sender, EventArgs e)
        {

        }

        private void AuthorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://www.steamcommunity.com/id/mctimmey/";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void PZBackupManagerLogoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ShowCfgIniButton_Click(object sender, EventArgs e)
        {

        }

        private void ShowDatabaseJsonButton_Click(object sender, EventArgs e)
        {

        }

        private void AboutWindowButtonTS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TSChangeLogButton_Click(object sender, EventArgs e)
        {
            UpdateInfoWindow updateInfo = new UpdateInfoWindow();
            updateInfo.ShowDialog();
        }

        private void TSAcceptButton_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
        }

        private void TS_FolderPathShortCutsDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void TS_FileShortCutDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void SteamLogoPictureBox_Click(object? sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://steamcommunity.com/sharedfiles/filedetails/?id=3453009151";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void GitHubLogoPictureBox_Click(object? sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://www.github.com/TekknoTim/PZBackupManager";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void JsonFileShortCutsDropDownItemA_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.GetConfigINIFilePath();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        private void JsonFileShortCutsDropDownItemB_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.databaseDataListFile;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        private void JsonFileShortCutsDropDownItemC_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Application.StartupPath + @"Readme.md";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        private void FolderPathShortCutsDropDownItemA_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void FolderPathShortCutsDropDownItemB_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Configuration.currentBaseBackupFolderPATH);
        }

        private void FolderPathShortCutsDropDownItemC_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Configuration.absoluteSavegamePATH);
        }

        private void LogoPanelA_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
