using MVVMPractice.ViewModels;
using MVVMPractice.Views;
using System;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Threading;

namespace MVVMPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ShellViewModel context;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = new ShellView();
            context = new ShellViewModel();
            app.DataContext = context;
            app.Show();

            
        }
    }
}
