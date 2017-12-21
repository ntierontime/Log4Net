using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Log4Net.UWPApp.Localize))]

namespace Log4Net.UWPApp
{
    public class Localize : Framework.Xamariner.ILocalize
    {
        public void SetLocale(CultureInfo ci) { }
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }
    }
}

