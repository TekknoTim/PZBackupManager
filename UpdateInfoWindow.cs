using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZomboidBackupManager
{
    public partial class UpdateInfoWindow : Form
    {
        public UpdateInfoWindow()
        {
            InitializeComponent();
            string changeLogFile = Application.StartupPath + @"Changelog.md";
            if (File.Exists(changeLogFile) )
            {
                ChangeLogTextBox.Text = File.ReadAllText(changeLogFile);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
