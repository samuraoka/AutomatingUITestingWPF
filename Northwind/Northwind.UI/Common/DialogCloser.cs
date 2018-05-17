using System;
using System.Windows;

namespace Northwind.UI.Common
{
    public static class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty
            = DependencyProperty.RegisterAttached("DialogResult",
                typeof(bool?), typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        public static void SetDialogResult(Window tartget, bool? value)
        {
            //TODO
            throw new NotImplementedException();
        }

        private static void DialogResultChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }
    }
}
