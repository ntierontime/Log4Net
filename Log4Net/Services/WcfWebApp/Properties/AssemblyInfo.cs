using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Log4Net.WcfWebApp")]
[assembly: AssemblyDescription("Log4Net.WcfWebApp")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("NTIER ON TIME TECHNOLOGIES INC.")]
[assembly: AssemblyProduct("Log4Net")]
[assembly: AssemblyCopyright("Copyright © NTIER ON TIME TECHNOLOGIES INC. 2017")]
[assembly: AssemblyTrademark("Log4Net")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a8241eb4-f5f2-463c-84b8-4a54f64a310c")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile="Logging.config", Watch = true)]