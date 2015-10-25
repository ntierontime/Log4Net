using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Log4Net.WcfClientBLL
{
    /// <summary>
    /// There are 5 classes/interfaces needed to consume a Wcf web service on client side:
    /// 1. Request Message class for each method, defined in CommonBusinessLogicLayerEntities project
    /// 2. Response Message class for each method, defined in CommonBusinessLogicLayerEntities project
    /// 3. Contract definition interface, defined in WcfServiceContracts project
    /// *4. Channel definition interface, defined in WcfClientBusinessLogicLayer(this) project
    /// 5. WcfClient class, defined in WcfClientBusinessLogicLayer(this) project
    /// </summary>
    public interface WcfClientEntityLogChannel : Log4Net.WcfContracts.ILogWcfService, System.ServiceModel.IClientChannel {
    }

    /// <summary>
    /// There are 5 classes/interfaces needed to consume a Wcf web service on client side:
    /// 1. Request Message class for each method, defined in CommonBusinessLogicLayerEntities project
    /// 2. Response Message class for each method, defined in CommonBusinessLogicLayerEntities project
    /// 3. Contract definition interface, defined in WcfServiceContracts project
    /// 4. Channel definition interface, defined in WcfClientBusinessLogicLayer(this) project
    /// *5. WcfClient class, defined in WcfClientBusinessLogicLayer(this) project
    /// </summary>
    public partial class WcfClientEntityLog : System.ServiceModel.ClientBase<Log4Net.WcfContracts.ILogWcfService>, Log4Net.WcfContracts.ILogWcfService {

		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfClientEntityLog"/> class.
        /// </summary>
        public WcfClientEntityLog() {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfClientEntityLog"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public WcfClientEntityLog(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfClientEntityLog"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public WcfClientEntityLog(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfClientEntityLog"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
		public WcfClientEntityLog(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfClientEntityLog"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public WcfClientEntityLog(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

		#endregion constructors
        
        #region Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

        /// <summary>
        /// Inserts the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog InsertEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.InsertEntity(request);
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog UpdateEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.UpdateEntity(request);
        }

        /// <summary>
        /// Deletes the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.DeleteEntity(request);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifierEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog id)
        {
            return base.Channel.DeleteByIdentifierEntity(id);
        }

        /// <summary>
        /// Batches the insert.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchInsert(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.BatchInsert(request);
        }

        /// <summary>
        /// Batches the delete.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchDelete(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.InsertEntity(request);
        }

        /// <summary>
        /// Batches the update.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchUpdate(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            return base.Channel.BatchUpdate(request);
        }		

        #endregion Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members





        #region Query Methods Of Entity of Common 

        /// <summary>
        /// Gets the count of entity of "Common".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the count</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            return base.Channel.GetCountOfEntityOfCommon(request);
        }

        /// <summary>
        /// Exists the of entity of "Common".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true if exists any, otherwise false</returns>		
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            return base.Channel.ExistsOfEntityOfCommon(request);
		}

        /// <summary>
        /// Gets the collection of entity of "Common".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            return base.Channel.GetCollectionOfEntityOfCommon(request);
        }

        /// <summary>
        /// Gets the single of entity of "Common".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            return base.Channel.GetSingleOfEntityOfCommon(request);
		}

        #endregion Query Methods Of Entity of Common 




        #region Query Methods Of Entity of All 

        /// <summary>
        /// Gets the count of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the count</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetCountOfEntityOfAll(request);
        }

        /// <summary>
        /// Exists the of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true if exists any, otherwise false</returns>		
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.ExistsOfEntityOfAll(request);
		}

        /// <summary>
        /// Gets the collection of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetCollectionOfEntityOfAll(request);
        }

        /// <summary>
        /// Gets the single of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetSingleOfEntityOfAll(request);
		}

        #endregion Query Methods Of Entity of All 




        #region Query Methods Of NameValuePair of All 

        /// <summary>
        /// Gets the count of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the count</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetCountOfNameValuePairOfAll(request);
        }

        /// <summary>
        /// Exists the of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true if exists any, otherwise false</returns>		
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.ExistsOfNameValuePairOfAll(request);
		}

        /// <summary>
        /// Gets the collection of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetCollectionOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetCollectionOfNameValuePairOfAll(request);
        }

        /// <summary>
        /// Gets the single of entity of "All".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetSingleOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            return base.Channel.GetSingleOfNameValuePairOfAll(request);
		}

        #endregion Query Methods Of NameValuePair of All 




        #region Query Methods Of Entity of ByIdentifier 

        /// <summary>
        /// Gets the count of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the count</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetCountOfEntityOfByIdentifier(request);
        }

        /// <summary>
        /// Exists the of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true if exists any, otherwise false</returns>		
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.ExistsOfEntityOfByIdentifier(request);
		}

        /// <summary>
        /// Gets the collection of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetCollectionOfEntityOfByIdentifier(request);
        }

        /// <summary>
        /// Gets the single of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetSingleOfEntityOfByIdentifier(request);
		}

        #endregion Query Methods Of Entity of ByIdentifier 




        #region Query Methods Of KeyInformation of ByIdentifier 

        /// <summary>
        /// Gets the count of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the count</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetCountOfKeyInformationOfByIdentifier(request);
        }

        /// <summary>
        /// Exists the of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true if exists any, otherwise false</returns>		
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.ExistsOfKeyInformationOfByIdentifier(request);
		}

        /// <summary>
        /// Gets the collection of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetCollectionOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetCollectionOfKeyInformationOfByIdentifier(request);
        }

        /// <summary>
        /// Gets the single of entity of "ByIdentifier".
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetSingleOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            return base.Channel.GetSingleOfKeyInformationOfByIdentifier(request);
		}

        #endregion Query Methods Of KeyInformation of ByIdentifier 







		
#if WINDOWS_PHONE
        protected override Log4Net.WcfContracts.ILogWcfService CreateChannel()
        {
            throw new NotImplementedException();
        }
#else
#endif
	}
}