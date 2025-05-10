using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public partial class AutoDeleteSetupWindow : Form
    {
        public bool CheckBoxValue { get { return AutoDeleteEnabledCheckBox.Checked; } }
        public int TrackBarValue { get { return AutoDeleteCountTrackBar.Value; } }

        public AutoDeleteSetupWindow()
        {
            InitializeComponent();
            AutoDeleteEnabledCheckBox.Checked = autoDeleteEnabled;
            AutoDeleteCountValueLabel.Text = autoDelBackupCountUserSet.ToString();
            AutoDeleteCountTrackBar.Minimum = 1;
            AutoDeleteCountTrackBar.Maximum = autoDeleteKeepBackupsMax;
            AutoDeleteCountTrackBar.Value = autoDelBackupCountUserSet;
        }

        private void AutoDeleteSetupWindow_Shown(object sender, EventArgs e)
        {

        }

        private async void AutoDeleteEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoDeleteEnabled = AutoDeleteEnabledCheckBox.Checked;
            await Configuration.WriteCfgToJson();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutoDeleteCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int val = AutoDeleteCountTrackBar.Value;
            autoDeleteKeepBackupsCount = val;
            AutoDeleteCountValueLabel.Text = val.ToString();
        }
    }
}
