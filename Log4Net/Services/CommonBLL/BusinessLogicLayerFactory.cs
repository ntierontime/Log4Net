using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLL
{
    /// <summary>
    /// is to factory class to create instances of business layer classes
    /// </summary>
    public class BusinessLogicLayerFactory : Log4Net.WcfContracts.IBusinessLogicLayerFactory
    {
        #region Entity related

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of LogService</returns>
        public Log4Net.WcfContracts.ILogService CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext)
        {
            return new LogService(businessLogicLayerContext);
        }

        #endregion Entity related
    }

    /// <summary>
    /// Singleton of <see cref="BusinessLogicLayerFactory"/>
    /// </summary>
    public class BusinessLogicLayerFactorySingleton
        : Framework.Singleton<BusinessLogicLayerFactory>
    {
    }
}

