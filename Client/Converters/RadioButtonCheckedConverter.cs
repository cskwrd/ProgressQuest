using System;
using System.Globalization;
using System.Windows.Data;

namespace Client.Converters
{
    // taken from https://www.codeproject.com/Tips/720497/Binding-Radio-Buttons-to-a-Single-Property
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
