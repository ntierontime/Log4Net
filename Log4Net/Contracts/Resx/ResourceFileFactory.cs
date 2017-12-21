using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.Resx
{
    public static class ResourceFileFactory
    {
        public static Log4Net.Resx.UIStringResourcePerApp GetUIStringResourcePerAppInstance()
        {
            return new Log4Net.Resx.UIStringResourcePerApp();
        }

        public static Log4Net.Resx.UIStringResourcePerEntityLog GetUIStringResourcePerEntityLog()
        {
            return new Log4Net.Resx.UIStringResourcePerEntityLog();
        }

    }
}

