using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Xaml
{
    public class BooleanNegationConverter
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
            return !(value is bool && (bool)value);
        }

#if NETFX_CORE
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            return !(value is bool && (bool)value);
        }
    }
}