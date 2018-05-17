using System.Windows;
using System.Windows.Controls;

namespace Northwind.UI.Common
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void leftPane_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            var viewModel = leftPane.SelectedItem as ViewModel;
            viewModel?.RefreshAll();
        }
    }
}
