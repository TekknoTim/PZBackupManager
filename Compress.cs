using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.JsonData;
using SharpCompress;
using Microsoft.VisualBasic;
using System.IO;
using SharpCompress.Common;
using SharpCompress.Archives.Zip;
using SharpCompress.Archives;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace ZomboidBackupManager
{
    public class Compress
    {
        public async Task SimpleCompress(ZipData data)
        {
            if (!expFeaturesEnabled) { return; }
            PrintDebug($"[DoCompress] - [SimpleCompress] - [Index = {data.Index}] - [BackupName = {data.BackupName}] - [SourcePath = {data.SourcePath}]");
            PrintDebug($"[DoCompress] - [SimpleCompress] - [DestPath = {data.DestPath}] - [ZipFilePath = {data.ZipFilePath}] - [ZipDestPath = {data.ZipDestPath}]");
            Thread.Sleep(1000);
            try
            {
                await Task.Delay(500);
                PrintDebug($"[Compress.cs] - [SimpleCompress] - [Creating Zip archive] - [Start]");
                await Task.Run(() => CreateZipFromDirectory(data.DestPath, data.ZipFilePath)); 
                PrintDebug($"[DoCompress.cs] - [SimpleCompress] - [Creating Zip archive] - [Done!]");
                await Task.Delay(500);
                await Task.Run(() => Directory.Move(data.ZipFilePath, data.ZipDestPath));
                await Task.Delay(500);
                await Task.Run(() => AddZipPathToBackupData(data.Index, data.ZipDestPath, true));
                PrintDebug($"[Compress.cs] - [SimpleCompress] - [Writing Json] - [Done!]");
                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                PrintDebug($"[DoCompress] - [Error] - [CreatingFromDirectory failed!] - [{ex.ToString()}]", 2);
                MessageBox.Show($"Failed to create  zip archive! \n [Message = {ex.ToString()}]");
            }
        }

        public async Task ExternCompress(ZipData data)
        {
            if (!expFeaturesEnabled) { return; }
            Process p = new Process();
            p.StartInfo.FileName = zipArchiverExePath;
            p.StartInfo.WorkingDirectory = data.SourcePath;
            p.StartInfo.Arguments = GetCommandArguments(data.ZipFilePath, data.DestPath);
            PrintDebug($"[ExternCompress] - [Starting Process] - [FileName = {p.StartInfo.FileName}] - [WorkingDirectory = {p.StartInfo.WorkingDirectory}] - [Arguments = {p.StartInfo.Arguments}]");
            PrintDebug($"[ExternCompress] - [Creating Zip archive] - [SourcePath = {data.SourcePath}] - [ZipFilePath = {data.ZipFilePath}] - [DestPath = {data.DestPath}]");
            Thread.Sleep(1000);
            try
            {
                await Task.Delay(500);
                await Task.Run(() => p.Start());
                await Task.Delay(500);
                PrintDebug($"[ExternCompress] - [Create Zip archive command sent!]");
            }
            catch (Exception ex)
            {
                PrintDebug($"[ExternCompress] - [ERROR] - [CreatingFromDirectory failed!] - [{ex.ToString()}]", 2);
                MessageBox.Show($"Failed to create  zip archive! \n [Message = {ex.ToString()}]");
            }
        }

        private string GetCommandArguments(string zip, string dest)
        {
            if (usedZipArchiver == 2)
            {
                return GetSevenZipCommandArgs(zip, dest);
            }
            else
            {
                return GetWinRARCommandArgs(zip, dest);
            }
        }

        string GetWinRARCommandArgs(string z, string d)
        {
            return $"a -s -ibck {z} {d}";
        }

        string GetSevenZipCommandArgs(string z, string d)
        {
            return $"a -tzip -bso0 - bsp0 {z} {d}";
        }

        private void CreateZipFromDirectory(string folderPath, string zip)
        {
            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(folderPath);
                archive.SaveTo(zip, CompressionType.Deflate);
            }
        }
    }
}
