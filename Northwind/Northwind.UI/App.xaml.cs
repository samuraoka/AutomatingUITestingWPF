using Northwind.Logic.Utils;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Northwind.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                Initer.Init();
            }
            catch (Exception)
            {
                // How do I exit a WPF application programmatically?
                // https://stackoverflow.com/questions/2820357/how-do-i-exit-a-wpf-application-programmatically
                Current.Shutdown(-200);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            SetCulture();

            base.OnStartup(e);
        }

        private static void SetCulture()
        {
            var cul = new CultureInfo("en");
            CultureInfo.DefaultThreadCurrentCulture = cul;
            CultureInfo.DefaultThreadCurrentUICulture = cul;
            Thread.CurrentThread.CurrentCulture = cul;
            Thread.CurrentThread.CurrentUICulture = cul;
        }
    }
}
