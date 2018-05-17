using System;
using System.Windows;
using System.Windows.Controls;

namespace Northwind.UI.Common
{
    public class MainDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(
            object item, DependencyObject container)
        {
            if (item == null || Application.Current == null)
            {
                return null;
            }

            string name = item.GetType().Name.Replace("ViewModel", "View");
            var template =
                Application.Current.TryFindResource(name) as DataTemplate;

            if (template == null)
            {
                throw new ArgumentException(name + " is not found");
            }

            return template;
        }
    }
}
