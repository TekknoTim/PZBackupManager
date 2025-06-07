using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public class DebugLog
    {
        public static string[] virtualLogStream = new string[5000];

        private static readonly string debugFilePath = Application.StartupPath + @"Debug";

        private static readonly string debugFileBaseName = "PZBackupManagerLog_";
        private static readonly string debugFileExtension = ".log";
        private static readonly string debugLogFileCacheFile = "logData.json";

        private static string currentLogFile = "";

        private static List<string>? logCache;



        public DebugLog()
        {
            currentLogFile = CreateLogFile();
            logCache = ReadLogCacheFile();
            logCache.Add(currentLogFile);
            CheckLogFileMax();
            WriteLogCacheFile();
        }

        public static void LogInfo(string msg)
        {
            string timeStampedMsg = $"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] - [INFO] - [{msg}]";
            try
            {
                File.AppendAllText(currentLogFile, timeStampedMsg + Environment.NewLine);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Error writing message to log: " + ex.Message);
            }
        }

        public static void LogError(string msg)
        {
            string timeStampedMsg = $"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] - [ERROR] - [{msg}]";
            try
            {
                File.AppendAllText(currentLogFile, timeStampedMsg + Environment.NewLine);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Error writing message to log: " + ex.Message);
            }
        }

        private static void CheckLogFileMax()
        {
            if (logCache?.Count > Configuration.logFileMax)
            {
                string path = logCache.First();
                logCache.RemoveAt(0);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        private static string CreateLogFile()
        {
            if (!Directory.Exists(debugFilePath))
            {
                Directory.CreateDirectory(debugFilePath);
            }

            string logFile = GetFullLogFilePath();
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
            File.Create(logFile).Close();
            return logFile;
        }

        private static void CreateLogCacheFile()
        {
            if (!Directory.Exists(debugFilePath))
            {
                Directory.CreateDirectory(debugFilePath);
            }
            string path = GetFullLogCacheFilePath();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static List<string> ReadLogCacheFile()
        {
            CreateLogCacheFile();
            string path = GetFullLogCacheFilePath();
            string? json = System.IO.File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<string>();
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json)!;

        }

        private static void WriteLogCacheFile()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(logCache, Newtonsoft.Json.Formatting.Indented);
            string path = GetFullLogCacheFilePath();
            System.IO.File.WriteAllText(path, json);
        }


        private static string GetFullLogFilePath()
        {
            return debugFilePath + @"\" + debugFileBaseName + DateTime.Now.ToString("ddMMyy_HHmmss") + debugFileExtension;
        }

        private static string GetFullLogCacheFilePath()
        {
            return debugFilePath + @"\" + debugLogFileCacheFile;
        }
    }
}
