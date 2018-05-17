namespace Northwind.UI.Common
{
    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            var window = new CustomWindow(viewModel)
            {
                ShowInTaskbar = false,
            };

            return window.ShowDialog();
        }
    }
}
