using System.Reflection;

namespace MyStopWatch
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Directory.CreateDirectory(SaveDir());
            Application.Run(new MainForm());
        }

        internal static string ProjectName()
        {
            var projectName = Assembly.GetCallingAssembly().GetName().Name;
            return string.IsNullOrWhiteSpace(projectName) ? throw new ArgumentNullException() : projectName;
        }
        internal static string SaveDir() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProjectName());
    }
}