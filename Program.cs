using System.Diagnostics;

namespace ZomboidBackupManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show("ThreadException: " + args.Exception.Message);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = (Exception)args.ExceptionObject;
                MessageBox.Show("UnhandledException: " + ex.Message);
            };
            */
            if (IsProcessOpen())
            {
                MessageBox.Show("The program is already running!");
                return;
            }
            bool bResult = GetArguments();
            if (bResult)
            {
                DummyFileCreatorUtility.CreateDummyFiles();
                return;
            }
            FontLoader.LoadDefaultCustomFonts();
            Configuration.Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
            
        }

        private static bool IsProcessOpen()
        {
            int count = 0;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains("ZomboidBackupManager"))
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return true;
            }
            return false;
        }

        private static bool GetArguments()
        {
            // Gets command line arguments
            string[] args = Environment.GetCommandLineArgs();

            for (int i = 1; i < args.Length; i++)
            {
                //MessageBox.Show($"Argument {i}: {args[i]}");
                if (args[i].Contains("-CreateDummy"))
                {
                    Console.WriteLine("[DEBUG] - Debug mode enabled.");
                    return true;
                }
            }
            return false;
        }
    }
}