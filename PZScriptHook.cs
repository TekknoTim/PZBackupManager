using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using System.Resources;
using System.ComponentModel;
using static System.Windows.Forms.DataFormats;
using System.Reflection.Metadata;

namespace ZomboidBackupManager
{
    public partial class PZScriptHook : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form? myParentForm { get; set; }

        private FileSystemWatcher fileWatcher;

        private string lastContent = "";

        private string emptyCommand = @"command=";

        private Image? OnToggleIcon;
        private Image? OffToggleIcon;

        private bool addToTaskbar = false;

        public PZScriptHook()
        {
            InitializeComponent();

            SetIndexChangeEventsSuspended(this, true);

            SetAlwaysOnTop();
            SetAddToTaskBar();
            LoadIconImages();

            GamemodesComboBox.Items.Clear();
            GamemodesComboBox.Items.AddRange(GetGamemodes().ToArray());

            //MessageBox.Show($"selGamemode = {selGameMode}");
            GamemodesComboBox.SelectedIndex = currentLoadedGamemodeIndex;

            string? path = Path.GetDirectoryName(Configuration.absoluteHookFilePATH);

            //MessageBox.Show($"[PZScriptHook] - [path = {path}]");
            PrintDebug($"[PZScriptHook] - [path = {path}]");
            if (string.IsNullOrEmpty(path))
            {
                PrintDebug("[PZScriptHook] - GetDirectoryName() returned null or empty.", 2);
                this.Close();
            }
            fileWatcher = new FileSystemWatcher
            {
                Path = path!,
                Filter = Path.GetFileName(Configuration.absoluteHookFilePATH),
                NotifyFilter = NotifyFilters.LastWrite
            };

            fileWatcher.Changed += OnFileChanged;
        }

        private void LoadIconImages()
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            Object? on = rm.GetObject("SwitchIconOn");
            Image? onTgl = (Bitmap?)on as Image;
            if (onTgl != null)
            {
                OnToggleIcon = onTgl;
            }
            Object? off = rm.GetObject("SwitchIconOff");
            Image? offTgl = (Bitmap?)off as Image;
            if (offTgl != null)
            {
                OffToggleIcon = offTgl;
            }
        }

        private void PZScriptHook_Load(object sender, EventArgs e)
        {

        }

        private void SelectSavegame()
        {
            var v1 = GamemodesComboBox.SelectedItem;
            if (v1 == null)
            {
                return;
            }
            var v2 = SavegameComboBox.SelectedItem;
            if (v2 == null)
            {
                return;
            }
            string? gamemodeName = v1.ToString();
            string? savegameName = v2.ToString();

            if (!string.IsNullOrEmpty(gamemodeName) && !string.IsNullOrEmpty(savegameName))
            {
                Configuration.LoadSavegame(savegameName, gamemodeName, SavegameComboBox.SelectedIndex, GamemodesComboBox.SelectedIndex);

                //MessageBox.Show($"Savegame [{savegameName}] successfully loaded!");
            }
            else
            {
                UnloadCurrentLoadedSavegame();
            }
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (fileWatcher.EnableRaisingEvents)
            {
                StopTracking();
            }
            else
            {
                StartTracking();
            }

        }

        private void StartTracking()
        {
            if (!File.Exists(Configuration.absoluteHookFilePATH))
            {
                FileStream file = File.Create(Configuration.absoluteHookFilePATH);
                file.Close();
            }
            if (!IsAnySavegameLoadedCurrently())
            {
                string msg = @"<Start Tracking> aborted! You need to select a savegame first!";

                MessageBox.Show(msg, @"Start Tracking aborted!");
                PrintStatusLog(msg);
                return;
            }
            GamemodesComboBox.Enabled = false;
            SavegameComboBox.Enabled = false;
            ResetHookCommandInFile();
            PrintDebug("[PZScriptHook] - [Tracking started]");
            PrintStatusLog("[Tracking started]");
            StartStopButton.Text = "Stop";
        }

        private void StopTracking()
        {
            fileWatcher.EnableRaisingEvents = false;
            GamemodesComboBox.Enabled = true;
            SavegameComboBox.Enabled = true;
            PrintDebug("[PZScriptHook] - [Tracking stopped]");
            PrintStatusLog("[Tracking stopped]");
            StartStopButton.Text = "Start";
        }

        private void ResetHookCommandInFile()
        {
            lastContent = emptyCommand;
            File.WriteAllText(Configuration.absoluteHookFilePATH, emptyCommand);
            fileWatcher.EnableRaisingEvents = true;
            PrintStatusLog("[Reset] --> Done! - Tracking Unsuspended!");

        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(100); // Warten, damit die Datei komplett geschrieben wird

            try
            {
                string newContent = File.ReadAllText(Configuration.absoluteHookFilePATH);
                if (newContent != lastContent && newContent != emptyCommand && newContent != emptyCommand + hookCommand_Done && newContent != emptyCommand + 50.ToString())
                {
                    Invoke(new Action(() =>
                    {
                        fileWatcher.EnableRaisingEvents = false;
                        PrintStatusLog("[Change Recognized]! - Tracking Suspended!");
                        PrintStatusLog($"File - [last = <{lastContent}>] --> [new = <{newContent}>]");
                        ExecuteHookCommand(newContent);
                    }));
                }
            }
            catch (IOException)
            {
                // Falls die Datei gerade von einem anderen Prozess verwendet wird
            }
        }

        private void ExecuteHookCommand(string str)
        {
            string command = str.Split('=')[1];
            PrintStatusLog($"Recieved cmd --> [{command}]");

            if (command == Configuration.hookCommand_Backup)
            {
                PrintStatusLog("[Backup] cmd detected! [b]");
                ExecuteBackupCommand();
            }
            else if (command == Configuration.hookCommand_Test)
            {
                PrintStatusLog("[Test] cmd detected! [t]");
                ExecuteTestCommand();
            }
            else
            {
                PrintStatusLog($"Unknown cmd detected! --> [{command}]");


            }
        }

        private async void ExecuteBackupCommand()
        {
            PrintStatusLog("Executing [backup] command...");
            SendConfirmCommand();
            System.Threading.Thread.Sleep(5000);
            Backup backup = new Backup();
            await backup.DoBackupFromRemote(txtLog, this);
            SendDoneCommand();
        }

        private void ExecuteTestCommand()
        {
            PrintStatusLog("Executing [test] command...");
            //MessageBox.Show("Test command recieved and executed!");
            TestCommandWindow testWindow = new TestCommandWindow();
            testWindow.TopMost = true;
            testWindow.ShowDialog();
            ResetHookCommandInFile();
        }

        private void SendConfirmCommand()
        {
            PrintStatusLog("Sending [Confirm] command...");
            File.WriteAllText(Configuration.absoluteHookFilePATH, emptyCommand + hookCommand_Confirm);
        }

        public void SendProcessCommand(int iProcess)
        {
            string sProcess = iProcess.ToString();
            PrintStatusLog("Sending [Process] command...");
            File.WriteAllText(Configuration.absoluteHookFilePATH, emptyCommand + sProcess);
        }

        public void SendDoneCommand()
        {
            PrintStatusLog("Executing [Done] command...");
            File.WriteAllText(Configuration.absoluteHookFilePATH, emptyCommand + hookCommand_Done);
            lastContent = emptyCommand + hookCommand_Done;
            fileWatcher.EnableRaisingEvents = true;
            PrintStatusLog("[Done] --> Done! - Tracking Unsuspended!");
        }

        private void PrintStatusLog(string txt = "")
        {
            int i = txtLog.Items.Count;
            if (i > 999)
            {
                txtLog.Items.Add("[1000] - [LogItemCount >= 1000] - [RESETTING LOG]");
                i = 1;
                txtLog.Items.Clear();
                txtLog.Items.Add($"[{i.ToString()}] - [LOG RESET] - [DONE!]");
                i++;
            }

            txtLog.Items.Add($"[{i.ToString()}] - " + txt);
            txtLog.SelectionMode = SelectionMode.One;
            txtLog.SetSelected(i, true);
        }

        private void SetAlwaysOnTop()
        {
            this.TopMost = AlwaysOnTopCheckbox.Checked;
        }

        private void AlwaysOnTopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetAlwaysOnTop();
        }

        private void SetAddToTaskBar()
        {
            this.addToTaskbar = AddToTaskBarCheckbox.Checked;
        }

        private void AddToTaskBarCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetAddToTaskBar();
        }

        private void PZScriptHook_Shown(object sender, EventArgs e)
        {
            LoadSavegamesInSelectedGamemode();
            if (IsAnySavegameLoadedCurrently())
            {
                SavegameComboBox.SelectedIndex = currentLoadedSavegameIndex;

            }
            SetSavegameInfoPanelValue();
            SetIndexChangeEventsSuspended(this, false);
        }

        private void SelectSavegameComboBoxItemAtIndex()
        {
            if (SavegameComboBox.Items.Count > 0)
            {

            }
            string name = Configuration.currentLoadedSavegame;
            SavegameNameValueLabel.Text = name;
        }

        private void LoadSavegamesInSelectedGamemode()
        {
            var savegameList = GetSavegamesInSelectedGamemode();
            SavegameComboBox.Items.Clear();
            SavegameComboBox.Items.AddRange(savegameList);
        }

        private string[] GetSavegamesInSelectedGamemode()
        {
            var cBoxItem = GamemodesComboBox.SelectedItem;
            if (cBoxItem == null)
            {
                return Array.Empty<string>();
            }
            string? gamemode = cBoxItem.ToString();
            if (string.IsNullOrEmpty(gamemode))
            {
                return Array.Empty<string>();
            }

            string fullSavegamePath = Configuration.GetFullSavegamesPath(gamemode);

            string[] savegameFolderList = Directory.GetDirectories(fullSavegamePath);

            List<string> outputList = new List<string>();

            foreach (var savegame in savegameFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullSavegamePath + savegame);
                outputList.Add(dirInfo.Name);
            }

            return outputList.ToArray();

        }

        private void GamemodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintDebug($"[PZScriptHook] - [{sender.ToString()}] - [SelectedIndexChanged] - Fired! --> [sender = {sender.ToString()}]");
            if (indexChangeEventsSuspended)
            {
                PrintDebug($"[PZScriptHook] - [{sender.ToString()}] - [SelectedIndexChanged] - Aborted --> Index change events suspended");
                return;
            }
            UnloadCurrentLoadedSavegame();
            LoadSavegamesInSelectedGamemode();
            ClearSavegameComboBoxSelection();
            SetSavegameInfoPanelValue();
        }

        private void SavegameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintDebug($"[PZScriptHook] - [{sender.ToString()}] - [SelectedIndexChanged] - Fired!");
            if (indexChangeEventsSuspended)
            {
                PrintDebug($"[PZScriptHook] - [{sender.ToString()}] - [SelectedIndexChanged] - Aborted --> Index change events suspended");
                return;
            }
            SelectSavegame();
            SetSavegameInfoPanelValue();
        }

        private void PZScriptHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileWatcher.EnableRaisingEvents)
            {
                StopTracking();
            }
        }

        private void SetSavegameInfoPanelValue()
        {
            if (!IsAnySavegameLoadedCurrently())
            {
                ClearSavegameInfoPanelValue();
                return;
            }
            string name = Configuration.currentLoadedSavegame;
            SavegameNameValueLabel.Text = name;
        }

        private void ClearSavegameInfoPanelValue()
        {
            SavegameNameValueLabel.Text = @" - ";
        }

        private void ClearSavegameComboBoxSelection()
        {
            SavegameComboBox.SelectedItem = null;
            SavegameComboBox.Text = @" - ";
        }

        private void MinimizedNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                MinimizedNotifyIcon.Visible = false;
            }
        }

        private void maximizeToolStripMenuItem_OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                MinimizedNotifyIcon.Visible = false;
            }
        }

        private void OnMinimizingWindow(object sender, EventArgs e)
        {
            if (addToTaskbar == true)
            {
                this.ShowInTaskbar = false;
                MinimizedNotifyIcon.Visible = true;
                if (!fileWatcher.EnableRaisingEvents)
                {
                    MinimizedNotifyIcon.ShowBalloonTip(10000);
                }
                SetNotifyIconMenuData();
            }
        }



        private void SetNotifyIconMenuData()
        {
            if (fileWatcher.EnableRaisingEvents)
            {
                ToggleTrackingMenuItem.Checked = true;
            }
            else
            {
                ToggleTrackingMenuItem.Checked = false;
            }

            ToolStripGamemodeTextBox.Text = "Gamemode: " + currentLoadedGamemode;
            ToolStripSavegameTextBox.Text = "Savegame: " + currentLoadedSavegame;
        }

        private void ToggleTrackingMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            string stateString = string.Empty;
            if (ToggleTrackingMenuItem.Checked)
            {
                if (!fileWatcher.EnableRaisingEvents)
                {
                    StartTracking();
                }
                ToggleTrackingMenuItem.Image = OnToggleIcon;
            }
            else
            {
                if (fileWatcher.EnableRaisingEvents)
                {
                    StopTracking();
                }
                ToggleTrackingMenuItem.Image = OffToggleIcon;
            }

            //NotifyIconTrackingInfoTextbox.Text = "Tracking: " + stateString;
        }

        private void NotifyIconMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myParentForm != null)
            {
                myParentForm.Close();
            }
        }
    }
}
