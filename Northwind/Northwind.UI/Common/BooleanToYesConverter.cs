﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Northwind.UI.Common
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BooleanToYesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //TODO
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}