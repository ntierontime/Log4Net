using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Xaml
{
    public class BoolToVisibilityConverter
#if NETFX_CORE
        : Windows.UI.Xaml.Data.IValueConverter
#else
        : System.Windows.Data.IValueConverter
#endif
    {
#if NETFX_CORE
        public object Convert(object value, Type targetType, object parameter, string language)
#else
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
	    {
            bool param = bool.Parse(parameter as string);
            bool val = (bool)value;

#if SILVERLIGHT
            return val == param ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
#elif NETFX_CORE
            return val == param ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
#else
            return val == param ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
#endif
        }

#if NETFX_CORE
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
#if SILVERLIGHT
            return value is System.Windows.Visibility && (System.Windows.Visibility)value == System.Windows.Visibility.Visible;
#elif NETFX_CORE
            return value is Windows.UI.Xaml.Visibility && (Windows.UI.Xaml.Visibility)value == Windows.UI.Xaml.Visibility.Visible;
#else
            return value is System.Windows.Visibility && (System.Windows.Visibility)value == System.Windows.Visibility.Visible;
#endif
        }
    }
}