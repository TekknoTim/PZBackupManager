using System.Diagnostics;

namespace ZomboidBackupManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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
    }
}