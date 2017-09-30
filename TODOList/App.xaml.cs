using System.Windows;
using TODOList.Utilities;

namespace TODOList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            EmailManager mm = new EmailManager();
            mm.SendNotification();
        }
    }
}
