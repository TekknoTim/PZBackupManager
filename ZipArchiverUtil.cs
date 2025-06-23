using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomboidBackupManager
{
    internal class ZipArchiverUtil
    {
        // Events:
        /*
        private void OnZipFileReady(object? sender, string fullPath)
        {
            EndWatcher();
            this.Invoke((MethodInvoker)(() =>
            {
                PrintDebug($"[OnZipFileReady] - [ZIP - File is ready] - [fullPath = {fullPath}]");
                ProgressBarA.Value = 50;
                ProgressbarLabel.Text = "Zip file successfully created!";
                ZipData? data = ZipDataCache[0];
                if (data == null)
                {
                    return;
                }
                MoveZipArchive(data);
                string name = data.BackupName;
                bool result = AddZipPathToBackupData(data.Index, data.ZipDestPath, true);
                ProgressBarA.Value = 80;
                ProgressbarLabel.Text = "Zip Moved & Registered in jsonData";
                PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [result = {result}]");

                RefreshBackups(ZipDataCache[0].Index);
                ZipDataCache.RemoveAt(0);
                PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [ZipDataCache.Count = {ZipDataCache.Count}]");
                Watcher?.StopWatching();
                Thread.Sleep(500);
                ProgressBarA.Value = 100;
                ProgressbarLabel.Text = $"Backup [{name}] [successfull archived]";
                Thread.Sleep(500);
                if (ZipDataCache.Count > 0)
                {
                    CompressBackupToZipLoop();
                    return;
                }
                ToggleProgressBarPanel(false);

            }));
        }

        private void OnSkipCompressToZip(object? sender, string backup)
        {
            PrintDebug($"[MainWindow.cs] - [OnSkipCompressToZip] - [Skipping backup = {backup}]");
            ProgressBarA.Value = 50;
            ProgressbarLabel.Text = $"Skipping backup [{backup}] ! Zip archive already present!";
            ZipData? data = ZipDataCache[0];
            if (data == null)
            {
                return;
            }
            ProgressBarA.Value = 100;
            ProgressbarLabel.Text = "Zip Moved & Registered in jsonData";
            RefreshBackups(ZipDataCache[0].Index);
            ZipDataCache.RemoveAt(0);
            PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [ZipDataCache.Count = {ZipDataCache.Count}]");
            Watcher?.StopWatching();
            Thread.Sleep(500);
            if (ZipDataCache.Count > 0)
            {
                CompressBackupToZipLoop();
                return;
            }
            ToggleProgressBarPanel(false);
        }

                //=================================================================================================================
        //--------------------------------------[ Start Zip Archive Functions ]--------------------------------------------
        //=================================================================================================================
        // ZipWatcher:


        private void InitWatcher(string path)
        {
            Watcher = new ZipWatcher();
            Watcher.ZipFileReady += OnZipFileReady;
            Watcher.StartWatching(path);
        }

        private void EndWatcher()
        {
            Watcher?.StopWatching();
        }

        // Main:

        private void CreateZipEditBackupMenuOption_Click(object sender, EventArgs e)
        {
            if (IsValidBackupSelected())
            {
                ToggleProgressBarPanel(true);
                if (BackupListBox.SelectedItems.Count > 1)
                {
                    CompressMultiToZip();
                }
                else
                {
                    CompressBackupToZip(BackupListBox.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("No backup selected. Please select a backup first!");
            }
        }

        private async void CompressBackupToZip(int idx)
        {
            var result = MessageBox.Show($"Are you sure you want to create a zip archive for this backup? \n Name: {GetBackupDataNameFromJson(idx)} \n Index: {idx} ", "Please confirm action!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            if (usedZipArchiver == 0)
            {
                result = MessageBox.Show($"WARNING! This feature is currently WIP & can take up to minutes to complete even a single archive!\nAre you really sure, you want to continue?", "Please confirm again!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (IsBackupZipped(idx))
            {
                result = MessageBox.Show($"It looks like there is a zip for this file already!\n\nDo you want to overwrite it?", "Please confirm again!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                string? delPath = GetBackupZipPathFromJson(idx);
                if (!string.IsNullOrWhiteSpace(delPath))
                {
                    await Task.Run(() => File.Delete(delPath));
                }
            }
            Compress comp = new Compress();
            DirectoryInfo dirInfo = new DirectoryInfo(GetBackupFolderPathFromJson(idx));
            string backupName = dirInfo.Name;

            ZipData zipData = new ZipData(idx, backupName, currentLoadedBackupFolderPATH);
            ZipDataCache.Add(zipData);
            InitWatcher(currentLoadedBackupFolderPATH);
            if (usedZipArchiver == 0)
            {
                await comp.SimpleCompress(ZipDataCache[0]);
            }
            else
            {
                await comp.ExternCompress(ZipDataCache[0]);
            }

        }

        private async void CompressMultiToZip()
        {
            await CacheBackupZipData();

            var result = MessageBox.Show($"Are you sure you want to create a zip archive for those {ZipDataCache.Count} backups?", "Please confirm action!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                PrintDebug($"[MainWindow.cs] - [CompressMultiToZip] - [Aborted by user] - [clearing ZipData cache...]");
                ZipDataCache.Clear();
                return;
            }

            CompressBackupToZipLoop();
        }

        private async Task CacheBackupZipData()
        {
            ListBox.SelectedIndexCollection col = BackupListBox.SelectedIndices;
            List<ZipData> data = new List<ZipData>();
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [col.Count = {col.Count}] - [sourcePath = {currentLoadedBackupFolderPATH}] - [Caching started!]");
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [Caching started!]");
            foreach (int index in col)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(GetBackupFolderPathFromJson(index));
                string backupName = dirInfo.Name;
                ZipData zData = new ZipData(index, backupName, currentLoadedBackupFolderPATH);
                PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [index = {index}] - [backupName = {backupName}] - [name = {GetBackupDataNameFromJson(index)}]");
                await Task.Delay(50);
                data.Add(zData);
            }
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [Caching done!]");
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [data.Count = {data.Count}]");
            ZipDataCache.AddRange(data);
        }

        private async void CompressBackupToZipLoop()
        {
            ToggleProgressBarPanel(true);
            ZipData data = ZipDataCache[0];
            if (data == null)
            {
                PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [data = {data}] - [ZipDataCache.Count = {ZipDataCache.Count}]", 2);
                return;
            }
            if (IsBackupZipped(data.Index))
            {
                PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [Backup = {data.BackupName}] - [already has a zip archive] - [Skipping!]", 1);
                this.OnSkip.Invoke(this, data.BackupName);
            }
            Compress comp = new Compress();
            PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [ZipDataCache.Count = {ZipDataCache.Count}]");
            InitWatcher(currentLoadedBackupFolderPATH);
            if (usedZipArchiver == 0)
            {
                await comp.SimpleCompress(data);
            }
            else
            {
                await comp.ExternCompress(data);
            }
            await Task.Delay(500);
        }

        private async void MoveZipArchive(ZipData data)
        {
            try
            {
                string? path = Path.GetDirectoryName(data.ZipDestPath);
                if (string.IsNullOrWhiteSpace(path))
                {
                    throw new Exception();
                }
                await Task.Delay(1500);
                PrintDebug($"[DoCompress] - [Start moving Zip archive] - [ZipFilePath = {data.ZipFilePath}] - [ZipDestPath = {data.ZipDestPath}]");
                await Task.Run(() => Directory.Move(data.ZipFilePath, data.ZipDestPath));
                PrintDebug($"[DoCompress] - [Done moving Zip archive]");
                await Task.Delay(500);
            }
            catch (Exception e)
            {
                MessageBox.Show($"[ERROR] - [MoveArchive] - [ERROR] \n\n[Message: {e}]");
            }
        }
    public class ZipData
    {
        public int Index { get; set; }              // e.g. 5
        public string BackupName { get; set; }      // e.g. Backup_6
        public string SourcePath { get; set; }      // e.g. G:\ProjectZomboidBackups\Save01
        public string DestPath { get; set; }        // e.g. G:\ProjectZomboidBackups\Save01\Backup_6
        public string ZipFilePath { get; set; }     // e.g. G:\ProjectZomboidBackups\Save01\Backup_6.zip
        public string ZipDestPath { get; set; }     // e.g. G:\ProjectZomboidBackups\Save01\Backup_6\Backup_6.zip

        string fileExt = @".zip";

        public ZipData(int idx, string backupName, string sourcePath)
        {
            Index = idx;
            BackupName = backupName;
            SourcePath = sourcePath;
            DestPath = Path.Combine(sourcePath, backupName);
            ZipFilePath = DestPath + fileExt;
            ZipDestPath = Path.Combine(DestPath, backupName) + fileExt;
        }
    }
        */
    }
}
