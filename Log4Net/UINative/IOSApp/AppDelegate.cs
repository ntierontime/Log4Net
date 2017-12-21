using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using GalaSoft.MvvmLight.Threading;

namespace Log4Net.IOSApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Framework.Xaml.IDispatcherHelperWrapper, Log4Net.IOSApp.DispatcherHelperWrapper>();
            //DispatcherHelper.Initialize(app);

            global::Xamarin.Forms.Forms.Init();
            //PCLAppConfig.ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);
            LoadApplication(new Log4Net.XamarinForms.App());

            return base.FinishedLaunching(app, options);
        }
    }
}

