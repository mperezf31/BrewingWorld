using System;
using System.Globalization;
using Xamarin.Forms;

namespace BrewingWorld.Converters
{
    public class EstablishedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = (string)value;

            if (!string.IsNullOrEmpty(text))
            {
                return "Established in " + text;
            }
            else
            {
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }


    }
}
