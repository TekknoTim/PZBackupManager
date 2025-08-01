﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public static class BackupHistoryUtil
    {
        public static string TrimGamehourString(string gameHourString, int lengthAfterDecimalPoint = 2)
        {
            string output = string.Empty;
            if (string.IsNullOrWhiteSpace(gameHourString))
            {
                output = "Initial";
            }
            else if (gameHourString.Contains('.'))
            {
                string[] parts = gameHourString.Split('.');
                if (parts.Length > 1)
                {
                    parts[1] = parts[1].Substring(0, lengthAfterDecimalPoint);
                    output = string.Join(".", parts);
                    //output = parts[0] + "." + parts[1];
                }
            }
            else
            {
                output = gameHourString + "." + new string('0', lengthAfterDecimalPoint);
            }
            return output;
        }

        public static double? StringToDouble(string input)
        {
            if (double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static string FormatWorldAge(string totalHoursString)
        {
            double? totalHours = StringToDouble(totalHoursString);
            if (totalHours == null)
                return "ERROR";

            int totalMinutes = (int)Math.Floor(totalHours.Value * 60);
            int days = totalMinutes / (24 * 60);
            int hours = (totalMinutes % (24 * 60)) / 60;
            int minutes = totalMinutes % 60;

            string result = "";

            // Format days
            if (days > 0)
            {
                result += (days < 10 ? "0" : "") + days + " day/s - ";
            }
            else
            {
                result += "00 day/s - ";
            }

            // Format hours
            if (hours > 0)
            {
                result += (hours < 10 ? "0" : "") + hours + "h - ";
            }
            else
            {
                result += "00h - ";
            }

            // Format minutes
            if (minutes > 0)
            {
                result += (minutes < 10 ? "0" : "") + minutes + "min ";
            }
            else
            {
                result += "00min ";
            }

            return result;
        }

        public static void SetupBackupHistoryGridView(List<BackupStatistics> statisticsList, DataGridView gridView)
        {
            gridView.Rows.Clear();
            foreach (BackupStatistics stat in statisticsList)
            {
                gridView.Rows.Add(stat.Index, stat.Folder, stat.Source, stat.Biom, stat.Gametime, stat.Gamehour + "h", stat.Delta);
                string id = stat.Id;
                if (string.IsNullOrEmpty(id) || id.Equals("[Deleted]"))
                {
                    Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [SetupBackupHistoryGridView] - [ID was null, empty or marked as deleted]");
                    gridView.Rows[gridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.MistyRose;
                    gridView.Rows[gridView.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    gridView.Rows[gridView.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        public static List<BackupStatistics> ImportAndBuildBackupStatisticsList(string savegame)
        {
            List<BackupStatistics> statsList = new List<BackupStatistics>();
            BackupHistoryImporter? importer = new BackupHistoryImporter(savegame);
            List<string> history = importer.Import();
            foreach (string line in history)
            {
                BackupStatistics backupStats = new BackupStatistics(line);
                statsList.Add(backupStats);
            }
            Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [ImportAndBuildBackupStatisticsList] - [statsList size = {statsList.Count}]");
            importer = null; // Clear the importer to free resources
            return statsList;
        }

        public static void RemoveBackupHistoryEntry(string savegame, string id, bool justMarkDeleted = false)
        {
            BackupHistoryImporter? importer = new BackupHistoryImporter(savegame);
            List<string> fileContent = importer.Import(true);
            List<string> updatedFileContent = new List<string>();
            foreach (string line in fileContent)
            {
                if (!line.Contains(id))
                {
                    updatedFileContent.Add(line);
                }
                else if (justMarkDeleted)
                {
                    string modifiedLine = line.Replace(id, @"[Deleted]");
                    updatedFileContent.Add(modifiedLine);
                    Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Marking Deleted] - [ID = {id}]");
                }
                else
                {
                    Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Removing entry with ID = {id}]");
                }
            }
            List<string> adjustedFileContent = AdjustIndexValueInFileForSavegame(savegame, updatedFileContent);


            if (importer.Export(adjustedFileContent))
            {
                Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Successfully removed entry with ID: {id}]", 1);
            }
            else
            {
                Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Failed to remove entry with ID: {id}]", 2);
            }
            importer = null; // Clear the importer to free resources
        }

        public static void DeleteBackupHistoryEntryAtIndex(string savegame, int index)
        {
            index++; // Increment index to match the 1-based index in the file
            BackupHistoryImporter? importer = new BackupHistoryImporter(savegame);
            List<string> fileContent = importer.Import(true);
            List<string> updatedFileContent = new List<string>();
            foreach (string line in fileContent)
            {
                if (line.Contains(savegame))
                {
                    string lastValue = line.Split(',').Last();
                    int idx = 0;
                    if (int.TryParse(lastValue, out idx) && idx == index)
                    {
                        Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [DeleteBackupHistoryEntry] - [Removing entry at index: {index}]");
                        continue; // Skip this line to remove it
                    }
                    else
                    {
                        updatedFileContent.Add(line);
                        Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [DeleteBackupHistoryEntry] - [Keeping entry at index: {index}]");
                    }
                }
                else
                {
                    updatedFileContent.Add(line);
                }
            }
            List<string> adjustedFileContent = AdjustIndexValueInFileForSavegame(savegame, updatedFileContent);


            if (importer.Export(adjustedFileContent))
            {
                Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Successfully removed entry with Index: {index}]");
            }
            else
            {
                Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [RemoveBackupHistoryEntry] - [Failed to remove entry with Index: {index}]", 2);
            }
            importer = null; // Clear the importer to free resources
        }

        private static List<string> AdjustIndexValueInFileForSavegame(string savegame, List<string> lines)
        {
            List<string> outputLines = new List<string>();
            int count = 1;                              //IN THIS CASE, THE INDEX ISN'T ZERO BASED! BEGINNING AT 1!
            foreach (string line in lines)
            {
                string tempLine = line;
                if (line.Split(',')[0].Equals(savegame))
                {
                    tempLine = line.Substring(0, line.Length - 1);
                    tempLine += count.ToString();
                    Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [AdjustIndexValueInFileForSavegame] - [count = {count}] - [lineEnding = {tempLine.Substring(tempLine.Length - 1)}]");
                    count++;
                }
                outputLines.Add(tempLine);
            }
            Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [AdjustIndexValueInFileForSavegame] - [DONE] - [Old Line Count = {lines.Count}]");
            Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [AdjustIndexValueInFileForSavegame] - [DONE] - [New Line Count = {outputLines.Count}]");
            return outputLines;
        }

        public static bool BackupHistoryDataExists(string savegame)
        {
            BackupHistoryImporter? importer = new BackupHistoryImporter(savegame);
            bool dataExists = importer.DataExists();
            importer = null; // Clear the importer to free resources
            return dataExists;
        }

        public static string GetIdAtIndex(List<BackupStatistics> statisticsList, int index)
        {
            if (index < 0 || index >= statisticsList.Count)
            {
                Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [GetIdAtIndex] - [Index out of range: {index}]", 2);
                return string.Empty;
            }
            return statisticsList[index].Id;
        }

        public static int GetGridViewRowIndexByID(List<BackupStatistics> statisticsList, string id)
        {
            for (int i = 0; i < statisticsList.Count; i++)
            {
                if (statisticsList[i].Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            Configuration.PrintDebug($"[BackupHistoryUtil.cs] - [GetGridViewIndexByID] - [ID {id} not found in statistics list]", 2);
            return -1; // Return -1 if ID is not found
        }
    }

    public class BackupStatistics
    {
        public string Savegame { get; set; }
        public string Id { get; set; }
        public string Index { get; set; }
        public string Folder { get; set; }
        public string Source { get; set; }
        public string Biom { get; set; }
        public string Gametime { get; set; }
        public string Gamehour { get; set; }
        public string Delta { get; set; }

        public BackupStatistics(string line)
        {
            List<string> rawValues = GetRawValues(line);
            int valueCount = rawValues.Count;

            Savegame = rawValues[0] ?? "Error";
            Id = GetIDFromLine(line) ?? string.Empty;
            Index = rawValues.Last() ?? "-1";
            Folder = rawValues[valueCount - 2].Split('|').First() ?? "Error";
            Source = TrimSourceString(rawValues[valueCount - 3]) ?? "Unknown";
            Biom = rawValues[1] ?? "Unknown";
            Gametime = FormatWorldAge(rawValues[2]) ?? "Error";
            Gamehour = TrimGamehourString(rawValues[2], 2) ?? "Error";
            if (!ContainsNumeric(rawValues[3]))
            {
                Delta = "Initial";
            }
            else
            {
                Delta = TrimGamehourString(rawValues[3], 1) ?? "Error";
            }
        }

        private static bool ContainsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value.Any(char.IsNumber);
        }

        private static string? TrimSourceString(string rawValue)
        {
            string output = rawValue;
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return null;
            }
            if (rawValue.Contains('_'))
            {
                output = rawValue.Replace('_', ' ');
            }
            return output.Trim();
        }

        private static double? StringToDouble(string input)
        {
            if (double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        private static string TrimGamehourString(string gameHourString, int lengthAfterDecimalPoint = 2)
        {
            string output = string.Empty;
            if (string.IsNullOrWhiteSpace(gameHourString))
            {
                output = "Initial";
            }
            else if (gameHourString.Contains('.'))
            {
                string[] parts = gameHourString.Split('.');
                if (parts.Length > 1)
                {
                    parts[1] = parts[1].Substring(0, lengthAfterDecimalPoint);
                    output = string.Join(".", parts);
                    //output = parts[0] + "." + parts[1];
                }
            }
            else
            {
                output = gameHourString + "." + new string('0', lengthAfterDecimalPoint);
            }
            return output;
        }

        private static string FormatWorldAge(string totalHoursString)
        {
            double? totalHours = StringToDouble(totalHoursString);
            if (totalHours == null)
                return "ERROR";

            int totalMinutes = (int)Math.Floor(totalHours.Value * 60);
            int days = totalMinutes / (24 * 60);
            int hours = (totalMinutes % (24 * 60)) / 60;
            int minutes = totalMinutes % 60;

            string result = "";

            // Format days
            if (days > 0)
            {
                result += (days < 10 ? "0" : "") + days + " day/s - ";
            }
            else
            {
                result += "00 day/s - ";
            }

            // Format hours
            if (hours > 0)
            {
                result += (hours < 10 ? "0" : "") + hours + "h - ";
            }
            else
            {
                result += "00h - ";
            }

            // Format minutes
            if (minutes > 0)
            {
                result += (minutes < 10 ? "0" : "") + minutes + "min ";
            }
            else
            {
                result += "00min ";
            }

            return result;
        }

        private string GetIDFromLine(string line)
        {
            string folderAndID = line.Split(new[] { ',' }, StringSplitOptions.None)[5];
            if (string.IsNullOrEmpty(folderAndID))
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetID] - [Folder and ID is empty for line: {line}]", 2);
                return string.Empty;
            }
            string? id = null;
            string[] splitted = folderAndID.Split('|');
            if (splitted.Length > 1)
            {
                id = splitted[1];
            }
            else
            {
                id = string.Empty;
            }
            return id;
        }

        private static List<string> GetRawValues(string line)
        {
            List<string> outputList = new List<string>();
            string[] values = line.Split(new[] { ',' }, StringSplitOptions.None);
            foreach (string value in values)
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetRawValues] - [Adding Value] - [Value = {value}]");
                outputList.Add(value);
            }
            return outputList;
        }
    }
}
