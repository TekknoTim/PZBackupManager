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
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChangelogButton_Click(object sender, EventArgs e)
        {
            UpdateInfoWindow updateInfo = new UpdateInfoWindow();
            updateInfo.ShowDialog();
        }

        private void AuthorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://www.steamcommunity.com/id/mctimmey/";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://www.github.com/TekknoTim/PZBackupManager";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void WorkshopLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"https://steamcommunity.com/sharedfiles/filedetails/?id=3453009151";
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void PZBackupManagerLogoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
