using Northwind.Logic.Utils;
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
    }
}
