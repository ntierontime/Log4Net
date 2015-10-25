using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Xaml
{
    public class BooleanToOnOffConverter
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
            bool val = (bool)value;

            return val ? Framework.Resources.UIStringResource.On_DescriptionText : Framework.Resources.UIStringResource.Off_DescriptionText;
        }

#if NETFX_CORE
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            return value == Framework.Resources.UIStringResource.On_DescriptionText;
        }
    }
}