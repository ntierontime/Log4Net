using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Log4Net.WPF4App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Framework.Xaml.IDispatcherHelperWrapper, Log4Net.WPF4App.DispatcherHelperWrapper>();
            Log4Net.MVVMLightViewModels.ViewModelLocator.WebApiRootUrl = System.Configuration.ConfigurationManager.AppSettings[Framework.ViewModels.ApiControllerHttpClientBase.WebApiRootUrlAppSettingName];
            DispatcherHelper.Initialize();

            #region for async wcf calls -- to-be-removed
            //Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer, Framework.CommonBLLEntities.BusinessLogicLayerContextContainerCommon>();
            //Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Log4Net.WcfContracts.IBusinessLogicLayerFactoryAsyn, Log4Net.WcfClientBLL.WcfClientFactoryAsyn>();
            //Framework.CommonBLLEntities.BusinessLogicLayerMemberShip _BusinessLogicLayerMemberShip = new Framework.CommonBLLEntities.BusinessLogicLayerMemberShip();
            //Framework.CommonBLLEntities.SessionVariablesCommon.BusinessLogicLayerContext = new Framework.CommonBLLEntities.BusinessLogicLayerContext(_BusinessLogicLayerMemberShip);
            #endregion for async wcf calls -- to-be-removed

            #region Syncronized wcf method call -- not in use/WPF only -- to-be-removed

            /*
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Log4Net.WcfContracts.IBusinessLogicLayerFactory, Log4Net.WcfClientBLL.WcfClientFactory>();
            */

            #endregion Syncronized wcf method call -- not in use/WPF only -- to-be-removed
        }
    }
}

