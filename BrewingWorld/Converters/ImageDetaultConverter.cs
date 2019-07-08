using System;
using System.Globalization;
using BrewingWorld.Models;
using Xamarin.Forms;

namespace BrewingWorld.Converters
{
    public class ImageDefaultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageList images = (ImageList)value;

            if (images == null)
            {
                return "beer_default.jpg";
            }
            else
            {
                return images.Medium;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }


    }
}
