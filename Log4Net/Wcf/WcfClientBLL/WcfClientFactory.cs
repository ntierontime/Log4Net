using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.WcfClientBLL
{
    /// <summary>
    /// is to factory class to create instances of business layer classes
    /// </summary>
    public class WcfClientFactory : Log4Net.WcfContracts.IBusinessLogicLayerFactory
    {
        #region Entity related

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of Log4Net.WcfContracts.ILogService</returns>
        public Log4Net.WcfContracts.ILogService CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext)
        {
            return new Log4Net.WcfClientBLL.WcfClientEntityLog();
        }

        #endregion Entity related
    }

    /// <summary>
    /// Singleton of <see cref="WcfClientFactory"/>
    /// </summary>
    public class WcfClientFactorySingleton
        : Framework.Singleton<WcfClientFactory>
    {
    }

    /// <summary>
    /// is to factory class to create instances of business layer classes
    /// </summary>
    public class WcfClientFactoryAsyn : Log4Net.WcfContracts.IBusinessLogicLayerFactoryAsyn
    {

#if NETFX_CORE && DEBUG
//  for WinRT/NETFX_CORE debug, because no app.config file

        public const string Url_Log4Net_WcfClientBLL_WcfClientEntityAsynLog = "http://localhost:11805/WcfMarkupLog.svc";

#elif NETFX_CORE
// for WinRT/NETFX_CORE release, because no app.config file

        public const string Url_Log4Net_WcfClientBLL_WcfClientEntityAsynLog = "http://localhost:11805/WcfMarkupLog.svc";

#endif

        #region Entity related

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of Log4Net.WcfContracts.ILogServiceAsyn</returns>
        public Log4Net.WcfContracts.ILogServiceAsyn CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext)
        {
#if NETFX_CORE
// for WinRT/NETFX_CORE release, because no app.config file, initialize WcfClient with Url
            return new Log4Net.WcfClientBLL.WcfClientEntityAsynLog(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress(Url_Log4Net_WcfClientBLL_WcfClientEntityAsynLog));
#else
            return new Log4Net.WcfClientBLL.WcfClientEntityAsynLog();
#endif
        }

        #endregion Entity related
    }

    /// <summary>
    /// Singleton of <see cref="WcfClientFactoryAsyn"/>
    /// </summary>
    public class WcfClientFactoryAsynSingleton
        : Framework.Singleton<WcfClientFactoryAsyn>
    {
    }
}

