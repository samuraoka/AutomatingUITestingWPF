using Northwind.Logic.Utils;
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
            Initer.Init();
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
