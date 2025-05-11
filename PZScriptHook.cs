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
using System.Diagnostics;

namespace ZomboidBackupManager
{
    public partial class PZScriptHook : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form? myParentForm { get; set; }

        private FileSystemWatcher fileWatcher;

        private StatusLogWriter logWriter;

        private System.Windows.Forms.Timer checkTimer;

        private bool wasRunning = true;

        private string[] lastContent = Array.Empty<string>();

        private string emptyCommand = @"command=";

        private Image? OnToggleIcon;
        private Image? OffToggleIcon;

        private bool addToTaskbar = false;

        public PZScriptHook()
        {
            InitializeComponent();


            logWriter = new StatusLogWriter(txtLog, false, 9f);
            logWriter.OnStatusChanged += StatusLogWriter_OnStatusChanged;

            SetIndexChangeEventsSuspended(this, true);

            SetAlwaysOnTop();
            SetAddToTaskBar();
            AutoDeleteCheckbox.Checked = autoDeleteEnabled;
            LoadIconImages();

            GamemodesComboBox.Items.Clear();
            GamemodesComboBox.Items.AddRange(GetGamemodes().ToArray());

            //MessageBox.Show($"selGamemode = {selGameMode}");
            GamemodesComboBox.SelectedIndex = currentLoadedGamemodeIndex;

            // Init polling timer:
            checkTimer = new System.Windows.Forms.Timer();
            checkTimer.Interval = 2000;
            checkTimer.Tick += CheckTimer_Tick;

            string? path = Path.GetDirectoryName(Configuration.absoluteHookFilePATH);

            //MessageBox.Show($"[PZScriptHook] - [path = {path}]");
            PrintDebug($"[PZScriptHook] - [path = {path}]");
            if (string.IsNullOrEmpty(path))
            {
                PrintDebug("[PZScriptHook] - GetDirectoryName() returned null or empty.", 2);
                this.Close();
            }
            CheckHookFileExists();
            fileWatcher = new FileSystemWatcher
            {
                Path = path!,
                Filter = Path.GetFileName(Configuration.absoluteHookFilePATH),
                NotifyFilter = NotifyFilters.LastWrite
            };

            fileWatcher.Changed += OnFileChanged;
            lastContent = File.ReadAllLines(Configuration.absoluteHookFilePATH);

        }

        private void StatusLogWriter_OnStatusChanged(object? sender, Status s)
        {
            if (s == Status.READY)
            {
                logWriter.WriteInitLabelToLog();
            }
        }

        private void CheckHookFileExists()
        {
            if (!File.Exists(Configuration.absoluteHookFilePATH))
            {
                List<string> data = new List<string>();
                data.Add(@"command=");
                data.Add(@"savegame=");
                FileStream stream = System.IO.File.Create(Configuration.absoluteHookFilePATH);
                stream.Close();
                File.WriteAllLines(Configuration.absoluteHookFilePATH, data.ToArray());
            }
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
            BeginPolling();
            PrintDebug("[PZScriptHook.cs] - [Tracking started]");
            PrintStatusLog("[Tracking started]");
            StartStopButton.Text = "Stop Tracking";
        }

        private void StopTracking()
        {
            fileWatcher.EnableRaisingEvents = false;
            GamemodesComboBox.Enabled = true;
            SavegameComboBox.Enabled = true;
            if (checkTimer.Enabled)
            {
                EndPolling();
            }
            PrintDebug("[PZScriptHook.cs] - [Tracking stopped]");
            PrintStatusLog("[Tracking stopped]");
            StartStopButton.Text = "Start Tracking";
        }

        private void ResetHookCommandInFile()
        {
            lastContent[0] = emptyCommand;
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
            fileWatcher.EnableRaisingEvents = true;
            PrintStatusLog("[Reset] --> Done! - Tracking Unsuspended!");

        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(100); // Warten, damit die Datei komplett geschrieben wird

            try
            {
                string[] newContent = File.ReadAllLines(Configuration.absoluteHookFilePATH);
                if (newContent[0] != lastContent[0] && newContent[0] != emptyCommand && newContent[0] != emptyCommand + hookCommand_Done && newContent[0] != emptyCommand + 50.ToString())
                {
                    Invoke(new Action(() =>
                    {
                        fileWatcher.EnableRaisingEvents = false;
                        PrintStatusLog($"----------------------------------------");
                        PrintStatusLog("[Change Recognized]! - Tracking Suspended!");
                        PrintStatusLog($"File - [last = <{lastContent[0]}>]");
                        PrintStatusLog($"File - [new = <{newContent[0]}>]");
                        PrintStatusLog($"----------------------------------------");
                        ExecuteHookCommand(newContent[0]);
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
                PrintStatusLog($"[Backup] cmd detected! [{command}]");
                ExecuteBackupCommand();
            }
            else if (command == Configuration.hookCommand_Test)
            {
                PrintStatusLog($"[Test] cmd detected! [{command}]");
                ExecuteTestCommand();
            }
            else if (command == @"v")
            {
                PrintStatusLog($"[Validate] cmd detected! [{command}]");
                bool result = PreCheckBackup();
                if (result)
                {
                    SendConfirmCommand();
                    fileWatcher.EnableRaisingEvents = true;
                }
                else
                {
                    ExecuteMismatchCommand();
                }
            }
            else if (command == @"s")
            {
                SwitchSavegame();
            }
            else
            {
                PrintStatusLog($"Unknown cmd detected! --> [{command}]");


            }
        }

        private bool PreCheckBackup()
        {
            string name = GetSavegameNameFromFile();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (name != Configuration.currentLoadedSavegame)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void ExecuteMismatchCommand()
        {
            PrintStatusLog("Sending [Mismatch] command...");
            lastContent[0] = emptyCommand + @"m";
            lastContent[1] = @"savegame=" + Configuration.currentLoadedSavegame;
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
            fileWatcher.EnableRaisingEvents = true;
        }

        private void SendAbortCommand()
        {
            PrintStatusLog("Sending [Abort] command...");
            lastContent[0] = emptyCommand + @"a";
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
            fileWatcher.EnableRaisingEvents = true;
        }

        private async void ExecuteBackupCommand()
        {
            SendConfirmCommand();
            System.Threading.Thread.Sleep(5000);
            Backup backup = new Backup();
            await backup.DoBackupFromRemote(txtLog, this);
            if (autoDeleteEnabled)
            {
                if (GetBackupCountFromJson() > autoDeleteKeepBackupsCount)
                {
                    Delete delete = new Delete();
                    await delete.DoDeleteFromRemote(txtLog, 0);
                }
            }
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
            lastContent[0] = emptyCommand + hookCommand_Confirm;
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
        }

        public void SendProcessCommand(int iProcess)
        {
            string sProcess = iProcess.ToString();
            PrintStatusLog("Sending [Process] command...");
            lastContent[0] = emptyCommand + sProcess;
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
        }

        private string GetSavegameNameFromFile()
        {
            string[] lines = File.ReadAllLines(Configuration.absoluteHookFilePATH);
            return lines[1].Split('=')[1];
        }

        public void SendDoneCommand()
        {
            PrintStatusLog("Executing [Done] command...");
            lastContent[0] = emptyCommand + hookCommand_Done;
            File.WriteAllLines(Configuration.absoluteHookFilePATH, lastContent);
            fileWatcher.EnableRaisingEvents = true;
            PrintStatusLog("[Done] --> Done! - Tracking Unsuspended!");
        }

        private void SwitchSavegame()
        {
            string savegameName = GetSavegameNameFromFile();
            PrintStatusLog($"Switching Savegame from [{Configuration.currentLoadedSavegame}] to [{savegameName}]");
            List<string> savegames = GetSavegamesInLoadedGamemode();
            int index = 0;
            PrintStatusLog($"Does Savegame exist = [{savegameName}] ");
            foreach (string savegame in savegames)
            {
                if (savegame == savegameName)
                {
                    PrintStatusLog($"Savegame exists! Loading Savegame = [{savegameName}] ");
                    Configuration.LoadSavegame(savegameName, Configuration.currentLoadedGamemode, index, Configuration.currentLoadedGamemodeIndex);
                    LoadSavegamesInSelectedGamemode();
                    SendConfirmCommand();
                    SavegameComboBox.SelectedIndex = currentLoadedSavegameIndex;
                    SetSavegameInfoPanelValue();
                    fileWatcher.EnableRaisingEvents = true;
                    return;
                }
                index++;
            }
            SendAbortCommand();
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

        private void SetAutoDelete()
        {
            autoDeleteEnabled = AutoDeleteCheckbox.Checked;
        }

        private void AutoDeleteCheckbox_Click(object sender, EventArgs e)
        {
            SetAutoDelete();
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

        private List<string> GetSavegamesInLoadedGamemode()
        {
            string gamemode = Configuration.currentLoadedGamemode;

            string fullSavegamePath = Configuration.GetFullSavegamesPath(gamemode);

            string[] savegameFolderList = Directory.GetDirectories(fullSavegamePath);

            List<string> outputList = new List<string>();

            foreach (var savegame in savegameFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullSavegamePath + savegame);
                outputList.Add(dirInfo.Name);
            }

            return outputList;

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
                UnMinimize();
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

        private void UnMinimize()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            MinimizedNotifyIcon.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myParentForm != null)
            {
                myParentForm.Close();
            }
        }

        //===============================================================================================
        //=======--------------------[ ProjectZomboid64 Process Tracking ]--------------------===========
        //===============================================================================================

        private void OnPZExeClosed()
        {
            UnMinimize();
        }

        private void CheckTimer_Tick(object? sender, EventArgs e)
        {
            var isRunning = Process.GetProcessesByName("ProjectZomboid64").Length > 0;

            if (wasRunning && !isRunning)
            {
                checkTimer.Stop();
                StopTracking();
                PrintDebug("[PZScriptHook.cs] - [InitPollingTimer] - [ProjectZomboid64.exe was closed!] ");
                OnPZExeClosed();
            }

            wasRunning = isRunning;
        }

        private void BeginPolling()
        {
            wasRunning = Process.GetProcessesByName("ProjectZomboid64").Length > 0;
            checkTimer.Start();
        }

        private void EndPolling()
        {
            wasRunning = true;
            checkTimer.Stop();
        }

        private void CloseScriptHookButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
