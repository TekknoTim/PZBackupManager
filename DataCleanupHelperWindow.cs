using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public partial class DataCleanupHelperWindow : Form
    {
        public DataCleanupHelperWindow()
        {
            InitializeComponent();
            ReadTextFromFileAndShowInTextBox();
        }

        private void ReadTextFromFileAndShowInTextBox()
        {
            if (!File.Exists(Configuration.cleanUpHelperFile))
            {
                FileStream stream = File.Create(Configuration.cleanUpHelperFile);
                stream.Close();
            }
            string content = File.ReadAllText(Configuration.cleanUpHelperFile);
            if (string.IsNullOrEmpty(content))
            {
                content = "ERROR! The file wasn't existing or it was empty!";
            }
            MainTextBox.Text = content;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTextLabel_Click(object sender, EventArgs e)
        {
            if (ShowTextLabel.Visible)
            {
                MainTextBox.Visible = true;
                ShowTextLabel.Visible = false;
            }
        }

        private void MainTextBox_Click(object sender, EventArgs e)
        {
            if (MainTextBox.Visible)
            {
                MainTextBox.Visible = false;
                ShowTextLabel.Visible = true;
            }
        }
    }
}
