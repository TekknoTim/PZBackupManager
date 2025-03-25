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
            Configuration.Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}