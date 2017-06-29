using ProgressQuest.Database;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var progressQuestDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProgressQuest");
            Directory.CreateDirectory(progressQuestDataDir); // Ensure directory exists
            Directory.SetCurrentDirectory(progressQuestDataDir);
            DbManager.Manage(ConfigurationManager.ConnectionStrings["ProgressQuestConnectionString"].ConnectionString);
        }
    }
}
