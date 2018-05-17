using System.Windows;
using System.Windows.Controls;

namespace Northwind.UI.Common
{
    public class MainDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item,
            DependencyObject container)
        {
            //TODO
            return base.SelectTemplate(item, container);
        }
    }
}
