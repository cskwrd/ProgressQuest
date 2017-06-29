using DbUp;
using System.Reflection;

namespace ProgressQuest.Database
{
    public class DbManager
    {
        private const string MAINTENACE_SCHEMA = "Maintenance";
        public static void Manage(string connectionString)
        {
            DeployChanges.To
                .SQLiteDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build()
                .PerformUpgrade();
        }
    }
}
