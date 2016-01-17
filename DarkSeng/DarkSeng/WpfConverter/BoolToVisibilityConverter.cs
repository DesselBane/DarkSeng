using System;
using System.Windows;
using System.Windows.Data;

namespace DarkSeng.WpfConverter
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a Bool into a Visibility enum.
        /// </summary>
        /// <param name="value">
        ///                      true:  Visibility.Hidden
        ///                      false: Visibility.Visible
        /// </param>
        /// <param name="parameter">
        ///                      1:     Inverts Bool
        ///                      2:     Collapsed instead of Hidden
        /// </param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility hidOrCol = Visibility.Hidden;

            if (value == null)
                return Visibility.Collapsed;

            if (parameter != null)
            {
                if (parameter.ToString().Contains("1"))
                    value = !((bool)value);
                if (parameter.ToString().Contains("2"))
                    hidOrCol = Visibility.Collapsed;
            }

            if (value is bool)
            {
                if (((bool)value))
                    return hidOrCol;
                else
                    return Visibility.Visible;
            }

            return Visibility.Visible;
        }

        /// <summary>
        /// Not Supported !!!!
        /// </summary>
        /// <exception cref="NotImplementedException">Gets thrown ALWAYS!!!</exception>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //TODO: Add functionallity for Converting back
            throw new NotImplementedException();
        }
    }
}
