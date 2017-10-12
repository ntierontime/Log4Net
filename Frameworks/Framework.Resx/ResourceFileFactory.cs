using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Resx
{
    public static class ResourceFileFactory
    {
        public static Framework.Resx.UIStringResource GetUIStringResourceInstance()
        {
            return new Framework.Resx.UIStringResource();
        }
    }
}

