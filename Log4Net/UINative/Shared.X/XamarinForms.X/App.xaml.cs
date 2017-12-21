using System.Reflection;
using Xamarin.Forms;

namespace Log4Net.XamarinForms {
    public partial class App : Application {

        public static NavigationPage NavigationPage { get; private set; }

        public App() {
            InitializeComponent();

            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            PCLAppConfig.ConfigurationManager.Initialise(assembly.GetManifestResourceStream("Log4Net.XamarinForms.ResourceApp.config"));

            if (Device.RuntimePlatform.ToLower() == Framework.Xamariner.Platforms.Android.ToString().ToLower())
            {
                Log4Net.MVVMLightViewModels.ViewModelLocator.WebApiRootUrl = PCLAppConfig.ConfigurationManager.AppSettings["Android" + Framework.ViewModels.ApiControllerHttpClientBase.WebApiRootUrlAppSettingName];
            }
            else if (Device.RuntimePlatform.ToLower() == Framework.Xamariner.Platforms.iOS.ToString().ToLower())
            {
                Log4Net.MVVMLightViewModels.ViewModelLocator.WebApiRootUrl = PCLAppConfig.ConfigurationManager.AppSettings["IOs" + Framework.ViewModels.ApiControllerHttpClientBase.WebApiRootUrlAppSettingName];
            }
            else
            {
                Log4Net.MVVMLightViewModels.ViewModelLocator.WebApiRootUrl = PCLAppConfig.ConfigurationManager.AppSettings[Framework.ViewModels.ApiControllerHttpClientBase.WebApiRootUrlAppSettingName];
            }

            MainPage = NavigationPage = new NavigationPage(new Log4Net.XamarinForms.Pages.HomePage());

            if (Device.RuntimePlatform.ToLower() == Framework.Xamariner.Platforms.iOS.ToString().ToLower() || Device.RuntimePlatform.ToLower() == Framework.Xamariner.Platforms.Android.ToString().ToLower())
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<Framework.Xamariner.ILocalize>().GetCurrentCultureInfo();
                Framework.Resx.UIStringResource.Culture = ci; // set the RESX for resource localization
                Log4Net.Resx.UIStringResourcePerApp.Culture = ci; // set the RESX for resource localization

                Log4Net.Resx.UIStringResourcePerEntityLog.Culture = ci; // set the RESX for resource localization

                DependencyService.Get<Framework.Xamariner.ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}

