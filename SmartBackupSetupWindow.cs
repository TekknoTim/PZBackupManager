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
    public partial class SmartBackupSetupWindow : Form
    {
        private bool wasSmartModeEnabled;

        public bool WasSmartModeEnabled { get { return wasSmartModeEnabled; } }

        public SmartBackupSetupWindow()
        {
            InitializeComponent();
            wasSmartModeEnabled = Configuration.smartBackupModeEnabled;
            SetRadioButtonsState(Configuration.smartBackupModeEnabled);
        }

        private void SetRadioButtonsState(bool bSet)
        {
            EnableSmartBackupRadioButton.Checked = bSet;
            DisableSmartBackupRadioButton.Checked = !bSet;
        }

        private bool ToggleSmartBackupMode()
        {
            bool smartModeEnabled = Configuration.smartBackupModeEnabled;
            smartModeEnabled = !smartModeEnabled;
            Configuration.SetSmartBackupMode(smartModeEnabled);
            SetRadioButtonsState(smartModeEnabled);
            return smartModeEnabled;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
