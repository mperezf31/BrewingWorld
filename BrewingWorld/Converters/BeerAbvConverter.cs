﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace BrewingWorld.Converters
{
    public class BeerAbvConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = (string)value;

            if (string.IsNullOrEmpty(text))
            {
                return "N/D";
            }
            else
            {
                return text + "º";

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }


    }
}
