using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework
{
    public static class AssemblyHelper
    {
        const string fmtStd = "{0}.{1}.{2}.{3}";
#if NETFX_CORE
        public static string GetExecutingAssemblyVersionInString()
        {
            var version = Windows.ApplicationModel.Package.Current.Id.Version;
            return string.Format(fmtStd, version.Major, version.Minor, version.Build, version.Revision);
        }
#elif SILVERLIGHT
        public static string GetExecutingAssemblyVersionInString()
        {
            return GetAssemblyVersionInString(Assembly.GetExecutingAssembly());
        }

        public static string GetAssemblyVersionInString(Assembly assembly)
        {
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            Version version = assemblyName.Version;
            return string.Format(fmtStd, version.Major, version.Minor, version.Build, version.Revision);
        }
#elif XAMARIN
        //public static string GetExecutingAssemblyVersionInString()
        //{
        //    return GetAssemblyVersionInString(Assembly.GetCallingAssembly());
        //}

        public static string GetAssemblyVersionInString(Assembly assembly)
        {
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            Version version = assemblyName.Version;
            return string.Format(fmtStd, version.Major, version.Minor, version.Build, version.Revision);
        }
#else
        public static string GetExecutingAssemblyVersionInString()
        {
            return GetAssemblyVersionInString(Assembly.GetCallingAssembly());
        }

        public static string GetAssemblyVersionInString(Assembly assembly)
        {
            Version version = assembly.GetName().Version;
            return string.Format(fmtStd, version.Major, version.Minor, version.Build, version.Revision);
        }
#endif
    }
}

