using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class BackupHistoryImporter
    {
        public string FilePath { get { return Configuration.absoluteBackupHistoryFilePATH; } }
        public string Savegame { get; set; }

        private Dictionary<int, int> _posToNewPos = new Dictionary<int, int>(); // Value position mapping
        private const int maxValues = 6; // Maximum number of values expected in a line
           


        public BackupHistoryImporter(string savegame)
        {
            Savegame = savegame;
            _posToNewPos.Add(5, 0);
            _posToNewPos.Add(3, 1);
            _posToNewPos.Add(0, 2);
            _posToNewPos.Add(4, 3);
            _posToNewPos.Add(1, 4);
            _posToNewPos.Add(2, 5);
        }

        public List<string> Import()
        {
            List<string> history = new List<string>();
            try
            {
                if (File.Exists(FilePath))
                {
                    string[] lines = File.ReadAllLines(FilePath);
                    foreach (string line in lines)
                    {
                        if (line.Split(',')[0].Equals(Savegame))
                        {
                            Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Adding Line] - [Line = {line}]");
                            history.Add(line);
                        }
                    }
                }
                else
                {
                    Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Backup_History.csv not found!]", 1);
                    throw new FileNotFoundException($"Backup history file not found at {FilePath}");
                }
            }
            catch (Exception ex)
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Message: {ex}]", 2);
            }
            return history;
        }

        public List<string> GetRawValues(string line)
        {
            List<string> outputList = new List<string>();
            try
            {
                string[] values = line.Split(new[] { ',' }, StringSplitOptions.None);
                foreach (string value in values)
                {
                    if (value.Contains(Savegame))
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetRawValues] - [Skipping Value] - [Value = {value}]");
                    }
                    else
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetRawValues] - [Adding Value] - [Value = {value}]");
                        outputList.Add(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetRawValues] - [Message: {ex}]",2);
            }
            return outputList;
        }

        public string[] ReorderValues(List<string> values)
        {
            int count = 0;
            string[] outputList = new string[maxValues];
            foreach (string value in values)
            {
                int pos = _posToNewPos[count];
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [ReorderValues] - [Adding Value = {value} - From Index = {count} - To Positon {pos}]");
                outputList[pos] = value;
                count++;
            }
            return outputList;
        }
    }

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

        public static void SetupBackupHistoryGridView(string savegame, DataGridView gridView)
        {
            BackupHistoryImporter importer = new BackupHistoryImporter(savegame);
            List<string> history = importer.Import();
            gridView.Rows.Clear();
            foreach (string line in history)
            {
                List<string> rawValues = importer.GetRawValues(line);
                string[] reorderedValues = importer.ReorderValues(rawValues).ToArray();
                gridView.Rows.Add(reorderedValues[0], reorderedValues[1].Replace('_', ' ').Trim(), reorderedValues[2], reorderedValues[3], FormatWorldAge(reorderedValues[4]), TrimGamehourString(reorderedValues[4], 2), TrimGamehourString(reorderedValues[5], 1));
            }
        }


    }
}
