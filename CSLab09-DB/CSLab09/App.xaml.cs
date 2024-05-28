using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace CSLab08.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.Resources["connString"] = GetConnectionString();
        }
        private string GetConnectionString()
        {
            // pobranie connection stringa
            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var dataDir = $@"{di.Parent?.Parent?.Parent?.FullName}\Database";
            var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            return connString.Replace(@"C:\USERS\VBOXUSER\SOURCE\REPOS\DAMAZI1\CSHARP-STUDIA\CSLAB09-DB\CSLAB09\DATABASE", dataDir);
        }
    }
}

