using Autofac;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Startup;
using FriendOrganizer.UI.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();

            //var mainWindow = new MainWindow(
            //    new MainViewModel(
            //        new FriendDataService()));
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Error..." + Environment.NewLine + e.Exception.Message, "Unexpected error");

            e.Handled = true;
        }
    }

}
