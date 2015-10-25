using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

namespace Framework.Xaml
{
    /// <summary>
    /// This is a temporary solution for Windows Phone ListPicker SelectedItem Binding, but now it is oneway binding: from UI to ViewModel
    /// Some possible solutions:
    /// http://www.codeproject.com/Articles/459958/Bindable-Converter-Converter-Parameter-and-StringF
    /// http://marlongrech.wordpress.com/2008/08/03/my-wish-came-true-i-can-now-use-databinding-in-a-converterparameter/
    /// http://stackoverflow.com/questions/15309008/binding-converterparameter
    /// http://www.codeproject.com/Articles/456589/Bindable-Converter-Parameter
    /// </summary>
    public class NameValuePairToIntegerConverter
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
            return null;//throw new NotImplementedException();
        }

#if NETFX_CORE
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            Framework.NameValuePair val = (Framework.NameValuePair)value;

            int intValue;
            if (!int.TryParse(val.Value, out intValue))
            {
                intValue = 0;
            }
            return intValue;
        }
    }
}