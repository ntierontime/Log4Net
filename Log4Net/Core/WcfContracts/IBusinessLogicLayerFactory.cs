using System;
namespace Log4Net.WcfContracts
{
    public partial interface IBusinessLogicLayerFactory
    {

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of ILogService</returns>
        ILogService CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext);

    }

    public partial interface IBusinessLogicLayerFactoryAsyn
    {

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of ILogServiceAsyn</returns>
        ILogServiceAsyn CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext);

    }
}