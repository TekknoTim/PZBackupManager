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
            SetFormBackgroundImage(Configuration.expFeaturesEnabled);
        }

        private void SetFormBackgroundImage(bool bDefault = true)
        {
            if (!bDefault)
            {
                MainPanel.BackgroundImage = Properties.Resources.SpiffoHighlightsWithBackground;
            }
            else
            {
                MainPanel.BackgroundImage = Properties.Resources.SpliffingSpliffoWithBackground;
            }
            MainPanel.Refresh();
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

        // config.ini
        private void JsonFileShortCutsDropDownItemA_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.GetConfigINIFilePath();
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - A] - [File not found = {path}]");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        // databaselist.json
        private void JsonFileShortCutsDropDownItemB_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.databaseDataListFile;
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - B] - [File not found = {path}]");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        // Readme.md
        private void JsonFileShortCutsDropDownItemC_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Application.StartupPath + @"Readme.md";
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - C] - [File not found = {path}]");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        // PZScriptHook.ini
        private void JsonFileShortCutsDropDownItemD_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.absoluteHookFilePATH;
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - D] - [File not found = {path}]");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        // Version.txt
        private void JsonFileShortCutsDropDownItemE_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.absoluteModVersionFilePATH;
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - E] - [File not found = {path}]");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            this.WindowState = FormWindowState.Minimized;
        }

        // Backup_History.csv
        private void JsonFileShortCutsDropDownItemF_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string path = Configuration.absoluteBackupHistoryFilePATH;
            if (!System.IO.File.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [File-ShortCutDropDownItem - F] - [File not found = {path}]");
                return;
            }
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

        private void FolderPathShortCutsDropDownItemD_Click(object sender, EventArgs e)
        {
            string? path = Path.GetDirectoryName(Configuration.absoluteHookFilePATH);
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [Folder-ShortCutDropDownItem - D] - [File not found = {path}]");
                return;
            }
            Process.Start("explorer.exe", path);
        }

        private void FolderPathShortCutsDropDownItemE_Click(object sender, EventArgs e)
        {
            string? path = Path.GetDirectoryName(Configuration.absoluteModVersionFilePATH);
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                PrintDebug($"[AboutInfoWindow.cs] - [Folder-ShortCutDropDownItem - E] - [File not found = {path}]");
                return;
            }
            Process.Start("explorer.exe", path);
        }

        private void ToggleExperimentalFeaturesPanel_DoubleClick(object sender, EventArgs e)
        {
            Configuration.expFeaturesEnabled = !Configuration.expFeaturesEnabled;
            SetFormBackgroundImage(Configuration.expFeaturesEnabled);
            Configuration.SaveConfig();
        }
    }
}
