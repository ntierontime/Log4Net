using System;
namespace Log4Net.WcfContracts
{
    public interface IBusinessLogicLayerFactory
    {


        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of ILogWcfService</returns>
        ILogWcfService CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext);



    }

    public interface IBusinessLogicLayerFactoryAsyn
    {

        /// <summary>
        /// Creates the BLL instance of entity <see cref="Log4Net.Log"/> tables for change notification.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        /// <returns>Instance of WcfServiceContractAsynLog</returns>
        WcfServiceContractAsynLog CreateBLLInstanceOfEntityLog(Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext);



    }
}