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
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public partial class ZipArchiveSetup : Form
    {
        public bool CreateZipCB { get { return CreateZipArchivesCheckBox.Checked; } }
        public bool KeepLooseCB { get { return KeepLooseFilesCheckBox.Checked; } }
        public bool UseExternalCB { get { return UseExternalArchiverCheckBox.Checked; } }

        private int archiverID = 0;
        public int ArchiverID { get { return archiverID; } }
        public string ArchiverPath { get { return ArchiverExeTextBox.Text; } }

        private readonly string winRarExeName = @"WinRAR.exe";
        private readonly string sevenZipExeName = @"7z.exe";


        public ZipArchiveSetup()
        {
            InitializeComponent();
            InitSetup();
        }

        private void InitSetup()
        {
            if (!saveBackupsAsZipFile)
            {
                CreateZipArchivesCheckBox.Checked = false;
                TogglePanels(false);
                return;
            }
            CreateZipArchivesCheckBox.Checked = true;
            KeepLooseFilesCheckBox.Enabled = true;
            UseExternalArchiverCheckBox.Enabled = true;
            if (!keepBackupFolderAfterZip)
            {
                KeepLooseFilesCheckBox.Checked = false;
                TogglePanels(false);
                return;
            }
            KeepLooseFilesCheckBox.Checked = true;
            archiverID = usedZipArchiver;
            if (archiverID == 2)
            {
                UseExternalArchiverCheckBox.Checked = true;
                Select7ZipRadioButton.Checked = true;
                SelectWinRarRadioButton.Checked = false;
                TogglePanels(true);
                SetBackupFolderPathTextbox();
            }
            else if (archiverID == 1)
            {
                UseExternalArchiverCheckBox.Checked = true;
                SelectWinRarRadioButton.Checked = true;
                Select7ZipRadioButton.Checked = false;
                TogglePanels(true);
                SetBackupFolderPathTextbox();
            }
            else
            {
                UseExternalArchiverCheckBox.Checked = false;
                TogglePanels(false);
            }
            
        }

        private void CreateZipArchivesCheckBox_Click(object sender, EventArgs e)
        {
            if (CreateZipArchivesCheckBox.Checked)
            {
                KeepLooseFilesCheckBox.Enabled = true;
                UseExternalArchiverCheckBox.Enabled = true;
            }
            else
            {
                KeepLooseFilesCheckBox.Enabled = false;
                UseExternalArchiverCheckBox.Enabled = false;
            }
        }
        private void UseExternalArchiverCheckBox_Click(object sender, EventArgs e)
        {
            SetArchiverID();
        }

        private void SetArchiverID()
        {
            if (UseExternalArchiverCheckBox.Checked)
            {
                if (SelectWinRarRadioButton.Checked)
                {
                    archiverID = 1;
                }
                else
                {
                    archiverID = 2;
                }
                TogglePanels(true);
            }
            else
            {

                archiverID = 0;
                TogglePanels(false);
            }
        }

        private void TogglePanels(bool val)
        {
            ExternalArchiverPanel.Enabled = val;
            SelectExePanel.Enabled = val;
        }

        private void SelectWinRarRadioButton_Click(object sender, EventArgs e)
        {
            SetArchiverID();
        }

        private void Select7ZipRadioButton_Click(object sender, EventArgs e)
        {
            SetArchiverID();
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectWinRarRadioButton.Checked)
            {
                SelectExeTextLabel.Text = $"Select [{winRarExeName}]";
            }
            else
            {
                SelectExeTextLabel.Text = $"Select [{sevenZipExeName}]";
            }
        }


        private void ToggleRadioButtons()
        {
            SelectWinRarRadioButton.Checked = !SelectWinRarRadioButton.Checked;
            Select7ZipRadioButton.Checked = !Select7ZipRadioButton.Checked;


        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task ShowFileBrowserDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.AddExtension = true;
            fileDialog.DefaultExt = ".exe";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                PrintDebug($"[ZipArchiverSetup] - [ShowFileBrowserDialog] - [ArchiverID = {ArchiverID}] - [path = {file}] - [SafeFileName = {fileDialog.SafeFileName}]");
                if (File.Exists(file))
                {
                    if (fileDialog.SafeFileName != GetExeFileName())
                    {
                        DialogResult res = MessageBox.Show($"The path you entered doesn't look as it should! \n\nExpected file name: [{GetExeFileName()}]\nSelected file name: [{fileDialog.SafeFileName}]\n\n Do you still want to use this executeable?","Warning!",MessageBoxButtons.YesNo);
                        if (res == DialogResult.No) { return; }
                    }
                    PrintDebug($"[ZipArchiveSetup.cs] - [ShowFileBrowserDialog] - [valid exe selected] - [file = {file}]");
                    zipArchiverExePath = file;
                    await WriteCfgToJson();

                }
                SetBackupFolderPathTextbox();
            }
        }

        private string GetExeFileName()
        {
            if (usedZipArchiver == 2)
            {
                return sevenZipExeName;
            }
            else if (usedZipArchiver == 1)
            {
                return winRarExeName;
            }
            else
            {
                return string.Empty;
            }
        }

        private void SetBackupFolderPathTextbox()
        {
            ArchiverExeTextBox.Text = zipArchiverExePath;

        }

        private void ArchiverExeTextBox_Click(object sender, EventArgs e)
        {
            ArchiverExeTextBox.Text = string.Empty;
        }

        private async void SelectExeButton_Click(object sender, EventArgs e)
        {
            await ShowFileBrowserDialog();
        }

        private void CreateZipArchivesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TogglePanels(CreateZipArchivesCheckBox.Checked);
        }
    }
}
