using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace TestApp.Converters
{
    public class Base64ToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var image = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(value.ToString())));
                return image;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
