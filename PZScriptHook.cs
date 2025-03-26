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

namespace ZomboidBackupManager
{
    public partial class PZScriptHook : Form
    {
        private FileSystemWatcher fileWatcher;

        private string lastContent = "";

        private string emptyCommand = @"command=";

        public PZScriptHook()
        {
            InitializeComponent();

            SetSavegameInfoPanelValues();

            SetAlwaysOnTop();

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
        }

        private void SetSavegameInfoPanelValues()
        {
            string name = Configuration.currentLoadedSavegame;
            if (string.IsNullOrEmpty(name))
            {
                return;
            }
            SavegameNameValueLabel.Text = name;
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
            ResetHookCommandInFile();
            PrintStatusLog("[Tracking started]");
            StartStopButton.Text = "Stop";
        }

        private void StopTracking()
        {
            fileWatcher.EnableRaisingEvents = false;
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

        private void PZScriptHook_Shown(object sender, EventArgs e)
        {
            LoadSavegamesInSelectedGamemode();
            SavegameComboBox.SelectedIndex = currentLoadedSavegameIndex;
        }

        private void LoadSavegamesInSelectedGamemode()
        {
            var savegameList = GetSavegamesInSelectedGamemode();
            SavegameComboBox.Items.Clear();
            SavegameComboBox.Items.AddRange(savegameList);
            currentLoadedGamemodeIndex = GamemodesComboBox.SelectedIndex;
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

        private void SavegameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSavegame();
            SetSavegameInfoPanelValues();
        }

        private void GamemodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSavegamesInSelectedGamemode();
        }

        private void PZScriptHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileWatcher.EnableRaisingEvents)
            {
                StopTracking();
            }
        }
    }
}
