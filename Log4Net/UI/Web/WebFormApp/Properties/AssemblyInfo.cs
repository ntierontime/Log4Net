
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Log4Net.WebFormApp")]
[assembly: AssemblyDescription("Log4Net.WebFormApp")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("nTierSketchUp")]
[assembly: AssemblyProduct("Log4Net")]
[assembly: AssemblyCopyright("Copyright © nTierSketchUp 2015")]
[assembly: AssemblyTrademark("Log4Net")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e0475575-a372-42de-b8e9-2657363a45d1")]

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

[assembly: log4net.Config.XmlConfigurator(ConfigFile="Logging.config", Watch = true)]