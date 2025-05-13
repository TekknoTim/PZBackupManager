using Newtonsoft.Json.Linq;
using SharpCompress.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.JsonData;

namespace ZomboidBackupManager
{
    public partial class BackupDataCleanerWindow : Form
    {

        StatusLogWriter logWriter;

        private System.Drawing.Font HeadlineFont;

        private event EventHandler<bool[]> OnAutoClean;
        private event EventHandler<int> OnScanUnlisted;
        private event EventHandler<int> OnScanBadJsonData;

        private List<string> cleanupCache = new List<string>();
        private List<string> cleanupBadJsonsCache = new List<string>();
        private List<string> cleanupUnlistedCache = new List<string>();

        public BackupDataCleanerWindow()
        {
            InitializeComponent();
            OnAutoClean += OnAutoCleanDone;
            OnScanUnlisted += OnScanDone;
            OnScanBadJsonData += OnJsonDataScanDone;
            

            HeadlineFont = FontLoader.GetStyleFont(40f);
            logWriter = new StatusLogWriter(StatusLog, LogToggleNumCMStrip.Checked, 11f, 999, 3, 1);
            logWriter.OnStatusChanged += LogWriter_OnStatusChanged;
            CleanUpDataHeadLabel.Font = HeadlineFont;
            PrintDebug($"HeadlineFont = [{HeadlineFont.Name}]");
        }

        private void LogWriter_OnStatusChanged(object? sender, Status s)
        {
            if (s == Status.READY)
            {
                PrintDebug($"[UnlistedBackupsWindow.cs] - [StatusLogWriter] - [OnStatusChanged] - [New Status = {s}]");
            }
            else if (s == Status.BUSY)
            {
                PrintDebug($"[UnlistedBackupsWindow.cs] - [StatusLogWriter] - [OnStatusChanged] - [New Status = {s}]");
            }
            else if (s == Status.DONE)
            {
                PrintDebug($"[UnlistedBackupsWindow.cs] - [StatusLogWriter] - [OnStatusChanged] - [New Status = {s}]");
            }
        }

        private List<string> SearchForBackupsWithoutJsonData()
        {
            List<string> outputList = new List<string>();
            List<string> paths = GetAllBackupFolderPathsContainingBackupFiles();
            foreach (string path in paths)
            {
                List<BackupData>? data = TryToGetBackupDataListFromJson(path);
                if (data == null || data.Count <= 0)
                {
                    PrintDebug($"[UnlistedBackupsWindow.cs] - [SearchForBackupsWithoutJsonData] - [Found missing Json data] - [path = {path}]");
                    outputList.Add(path);
                }
            }
            return outputList;
        }

        private async Task<bool> DeleteDirectoriesInList(List<string> list)
        {
            await Task.Delay(500);

            if (list == null || list.Count <= 0)
            {
                PrintDebug($"[UnlistedBackupWindow.cs] - [DeleteDirectoriesInList] - [Failed] - [list = null or contains no items]", 2);
                return false;
            }
            int idx = 0;
            int max = list.Count - 1;
            foreach (string path in list)
            {
                PrintDebug($"[UnlistedBackupsWindow.cs] - [DeleteDirectoriesInList] - [Deleting List Item No.{idx + 1} / {max}] - [path = {path}]");

                bool del = false;
                string dirName = Path.GetFileName(path);

                if (AskDeleteOnAutoCleanMenuItem.Checked)
                {
                    DialogResult result = MessageBox.Show($"Are you sure,\n you want to delete this folder\n and all of it's contents? \n\nName: [{dirName}] \nPath: {path}", "Confirm Deletion", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        del = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                else
                {
                    del = true;
                }

                if (del)
                {
                    try
                    {
                        await Task.Run(() => Directory.Delete(path, true));
                    }
                    catch (Exception ex)
                    {
                        PrintDebug($"[UnlistedBackupWindow.cs] - [DeleteUnlistedBackupDirectory failed!] - [Message = {ex.ToString()}]", 2);
                        return false;
                    }
                }
                idx++;

            }
            return true;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void AutoCleanToolStripButton_Click(object sender, EventArgs e)
        {
            PerformAutoCleanup();
        }

        private async void PerformAutoCleanup()
        {
            this.Enabled = false;
            await logWriter.WriteLabelToLog(" Starting... "," Auto Clean ");
            bool resultUnlisted = false;
            bool resultDeleteUnlisted = false;
            bool resultJson = false;
            bool resultDeleteJson = false;
            bool resultComplete = false;
            resultUnlisted = await FindAndCacheUnlistedSavegamePaths();
            if (resultUnlisted)
            {
                resultDeleteUnlisted = await DeleteDirectoriesInList(cleanupUnlistedCache);
                await Task.Delay(250);
            }
            resultJson = await FindAndCacheBackupsMissingJsonDataPaths();
            if (resultJson)
            {
                resultDeleteJson = await DeleteDirectoriesInList(cleanupBadJsonsCache);
                await Task.Delay(250);
            }
            await CreateCleanupCache(cleanupUnlistedCache, cleanupBadJsonsCache);
            await Task.Delay(100);
            resultComplete = await DeleteDirectoriesInList(cleanupCache);
            await Task.Delay(250);
            bool[] results = new bool[5];
            results[0] = resultUnlisted;
            results[1] = resultDeleteUnlisted;
            results[2] = resultJson;
            results[3] = resultDeleteJson;
            results[4] = resultComplete;
            OnAutoClean.Invoke(this, results);
        }


        private async Task<bool> FindAndCacheUnlistedSavegamePaths()
        {
            await Task.Delay(500);
            List<string> unlisted = GetUnlistedSavegamePaths();
            if (unlisted.Count <= 0 || unlisted == null)
            {
                PrintDebug($"[UnlistedBackupWindow.cs] - [FindAndCacheUnlistedSavegamePaths] - [Found 0 unlisted backup folders.]");
                cleanupUnlistedCache.Clear();
                await Task.Delay(250);
                return false;
            }
            cleanupUnlistedCache.Clear();
            cleanupUnlistedCache = unlisted;
            PrintDebug($"[UnlistedBackupWindow.cs] - [FindAndCacheUnlistedSavegamePaths] - [Found {cleanupUnlistedCache.Count} unlisted backup folders.]");
            await Task.Delay(250);
            return true;
        }


        private async Task<bool> FindAndCacheBackupsMissingJsonDataPaths()
        {
            await Task.Delay(500);
            List<string> paths = SearchForBackupsWithoutJsonData();
            if (paths.Count <= 0 || paths == null)
            {
                cleanupBadJsonsCache.Clear();
                await Task.Delay(250);
                return false;
            }
            cleanupBadJsonsCache.Clear();
            cleanupBadJsonsCache = paths;
            await Task.Delay(250);
            return true;
        }

        private async Task CreateCleanupCache(List<string>? list1, List<string>? list2)
        {
            cleanupCache.Clear();
            await Task.Delay(100);
            if (list1 != null && list1.Count > 0)
            {
                cleanupCache = list1;
            }
            else
            {
                if (list2 != null && list2.Count > 0)
                {
                    cleanupCache = list2;
                }
            }
            await Task.Delay(100);
            if (list2 == null || list2.Count <= 0)
            {
                return;
            }
            await Task.Delay(100);
            foreach (string path in list2)
            {
                bool cont = cleanupCache.Contains(path);
                if (!cont)
                {
                    cleanupCache.Add(path);
                }
            }
            await Task.Delay(100);
        }

        private async void OnAutoCleanDone(object? sender, bool[] results)
        {
            this.Enabled = true;
            List<string> res = new List<string>();
            res.Add("[ Auto Clean Done ]");
            res.Add(" [ Found Unlisted Folders ]");
            res.Add($" [ {results[0]} ] ");
            res.Add(" [ Found broken/missing Json Data ]");
            res.Add($" [ {results[1]} ] ");
            res.Add(" [ Successfully Deleted Folders ]");
            res.Add($" [ {results[2]} ] ");

            await logWriter.WriteEmptyLinesToLog(2);

            logWriter.WriteModularLabelToLog(res, 3, SeparatorType.Light, SeparatorType.Default);
            await logWriter.WriteEmptyLinesToLog(2);
            MessageBox.Show($"Auto Clean Done! \nResults: \n\n Found Unlisted = {results[0]} \nFound Bad Json Data = {results[1]} \nDeleted = {results[2]}");
        }

        private async void ScanToolStripButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await logWriter.WriteLabelToLog("Searching", "Unlisted Folders", "For");
            await Task.Delay(250);
            bool result = await FindAndCacheUnlistedSavegamePaths();
            if (!result)
            {
                OnScanUnlisted.Invoke(this, 0);
                return;
            }
            await Task.Delay(500);
            OnScanUnlisted.Invoke(this, cleanupUnlistedCache.Count);
        }

        private async void ScanJsonToolStripButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await logWriter.WriteLabelToLog("Searching For", " Json Files", "Broken / Missing");
            await Task.Delay(500);
            await Task.Delay(500);
            bool result = await FindAndCacheBackupsMissingJsonDataPaths();
            if (!result)
            {
                OnScanBadJsonData.Invoke(this, 0);
                return;
            }
            await Task.Delay(250);
            OnScanBadJsonData.Invoke(this, cleanupBadJsonsCache.Count);
        }

        private async void OnScanDone(object? sender, int found)
        {
            List<string> list = [found.ToString()];

            await logWriter.WriteLabelToLog("ScanDone", $"Unlisted Folders Found = {found}");
            if (ShowDetailesAfterScanMenuItem.Checked)
            {
                await logWriter.WriteEmptyLinesToLog(3);
                WriteUnlistedCacheToStatusLog();
            }
            this.Enabled = true;
        }

        private async void OnJsonDataScanDone(object? sender, int found)
        {
            List<string> list = [found.ToString()];
            await logWriter.WriteLabelToLog("Scan Json Done", $"Broken/Missing Json Files Found = {found}");
            if (ShowDetailesAfterScanMenuItem.Checked)
            {
                await logWriter.WriteEmptyLinesToLog(3);
                WriteBadJsonCacheToStatusLog();
            }
            this.Enabled = true;
        }

        private async void PrintStatusLog(string txt = "", string val = "", int sepBefore = 0, int sepAfter = 0, bool addSides = true, SeparatorType sepType = SeparatorType.WhiteSpace, SeparatorType sepTextType = SeparatorType.Default)
        {
            await logWriter.WriteLabelToLog(txt, val, " = ");
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            DataCleanupHelperWindow helpWindow = new DataCleanupHelperWindow();
            helpWindow.ShowDialog();
            helpWindow.Dispose();
        }

        private void WriteUnlistedCacheToStatusLog()
        {
            logWriter.WriteDualLabelToLog("Unlisted Folders Found:", cleanupUnlistedCache.Count.ToString(), SeparatorType.Light);
            int num = 1;
            List<string> list = new List<string>();
            foreach (string path in cleanupUnlistedCache)
            {
                string name = Path.GetFileName(path);
                list.Add("Folder No." + num.ToString());
                list.Add(name);
                list.Add(path);
                num++;
            }
            logWriter.WriteModularLabelToLog(list, 4, SeparatorType.WhiteSpace, SeparatorType.Light);
        }

        private void WriteBadJsonCacheToStatusLog()
        {
            logWriter.WriteDualLabelToLog("Broken/Missing Json Files Found:", cleanupBadJsonsCache.Count.ToString(), SeparatorType.Light);
            int num = 1;
            List<string> list = new List<string>();
            foreach (string path in cleanupBadJsonsCache)
            {
                string name = Path.GetFileName(path);
                list.Add("Folder No." + num.ToString());
                list.Add("Name: " + name);
                list.Add("Path: " + path);
                num++;
            }
            logWriter.WriteModularLabelToLog(list, 4, SeparatorType.WhiteSpace, SeparatorType.Light);
        }

        private void AskDeleteOnAutoCleanMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShowDetailesAfterScanMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenDirInExplorerButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Configuration.currentBaseBackupFolderPATH);
        }

        private void LogToggleNumCMStrip_CheckedChanged(object sender, EventArgs e)
        {
            logWriter.SetNumeration(LogToggleNumCMStrip.Checked);
        }

        private void ClearStatusLogTSButton_Click(object sender, EventArgs e)
        {
            logWriter.ClearStatusLog();
        }

        private void ChangeSep01_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void UnlistedBackupsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            logWriter.OnStatusChanged -= LogWriter_OnStatusChanged;
        }
    }
}
