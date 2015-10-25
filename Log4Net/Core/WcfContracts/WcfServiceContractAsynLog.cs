using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Log4Net.WcfContracts
{
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Log4Net.WcfContracts.WcfServiceContractAsynLog")]
    public interface WcfServiceContractAsynLog
    {

        #region Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteEntityResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteByIdentifierEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteByIdentifierEntityResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifierEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/InsertEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/InsertEntityResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog InsertEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/UpdateEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/UpdateEntityResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog UpdateEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchInsert", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchInsertResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchInsert(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchDelete", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchDeleteResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchDelete(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchUpdate", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchUpdateResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchUpdate(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteEntityResponse")]
        System.IAsyncResult BeginDeleteEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndDeleteEntity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteByIdentifierEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/DeleteByIdentifierEntityResponse")]
        System.IAsyncResult BeginDeleteByIdentifierEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog id, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndDeleteByIdentifierEntity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/InsertEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/InsertEntityResponse")]
        System.IAsyncResult BeginInsertEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndInsertEntity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/UpdateEntity",
            ReplyAction = "http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/UpdateEntityResponse")]
        System.IAsyncResult BeginUpdateEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndUpdateEntity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchInsert", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchInsertResponse")]
        System.IAsyncResult BeginBatchInsert(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndBatchInsert(System.IAsyncResult result);

        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchDelete", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchDeleteResponse")]
        System.IAsyncResult BeginBatchDelete(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog inpu, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndBatchDelete(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchUpdate", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/BatchUpdateResponse")]
        System.IAsyncResult BeginBatchUpdate(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog input, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndBatchUpdate(System.IAsyncResult result);

        #endregion





        #region Query Methods Of Entity of Common 

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfCommonResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request);
		
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfCommonResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfCommonResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfCommonResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfCommonResponse")]
        System.IAsyncResult BeginGetCountOfEntityOfCommon(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger EndGetCountOfEntityOfCommon(System.IAsyncResult result);
		
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfCommonResponse")]
        System.IAsyncResult BeginExistsOfEntityOfCommon(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean EndExistsOfEntityOfCommon(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfCommonResponse")]
        System.IAsyncResult BeginGetCollectionOfEntityOfCommon(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetCollectionOfEntityOfCommon(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfCommon", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfCommonResponse")]
        System.IAsyncResult BeginGetSingleOfEntityOfCommon(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetSingleOfEntityOfCommon(System.IAsyncResult result);

        #endregion Query Methods Of Entity of Common 




        #region Query Methods Of Entity of All 

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);
		
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfAllResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfAllResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfAllResponse")]
        System.IAsyncResult BeginGetCountOfEntityOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger EndGetCountOfEntityOfAll(System.IAsyncResult result);
		
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfAllResponse")]
        System.IAsyncResult BeginExistsOfEntityOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean EndExistsOfEntityOfAll(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfAllResponse")]
        System.IAsyncResult BeginGetCollectionOfEntityOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetCollectionOfEntityOfAll(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfAllResponse")]
        System.IAsyncResult BeginGetSingleOfEntityOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetSingleOfEntityOfAll(System.IAsyncResult result);

        #endregion Query Methods Of Entity of All 




        #region Query Methods Of NameValuePair of All 

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfNameValuePairOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);
		
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfNameValuePairOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfNameValuePairOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetCollectionOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfNameValuePairOfAllResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetSingleOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfNameValuePairOfAllResponse")]
        System.IAsyncResult BeginGetCountOfNameValuePairOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger EndGetCountOfNameValuePairOfAll(System.IAsyncResult result);
		
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfNameValuePairOfAllResponse")]
        System.IAsyncResult BeginExistsOfNameValuePairOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean EndExistsOfNameValuePairOfAll(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfNameValuePairOfAllResponse")]
        System.IAsyncResult BeginGetCollectionOfNameValuePairOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection EndGetCollectionOfNameValuePairOfAll(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfNameValuePairOfAll", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfNameValuePairOfAllResponse")]
        System.IAsyncResult BeginGetSingleOfNameValuePairOfAll(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection EndGetSingleOfNameValuePairOfAll(System.IAsyncResult result);

        #endregion Query Methods Of NameValuePair of All 




        #region Query Methods Of Entity of ByIdentifier 

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfByIdentifierResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);
		
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfByIdentifierResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfByIdentifierResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfByIdentifierResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfEntityOfByIdentifierResponse")]
        System.IAsyncResult BeginGetCountOfEntityOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger EndGetCountOfEntityOfByIdentifier(System.IAsyncResult result);
		
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfEntityOfByIdentifierResponse")]
        System.IAsyncResult BeginExistsOfEntityOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean EndExistsOfEntityOfByIdentifier(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfEntityOfByIdentifierResponse")]
        System.IAsyncResult BeginGetCollectionOfEntityOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetCollectionOfEntityOfByIdentifier(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfEntityOfByIdentifierResponse")]
        System.IAsyncResult BeginGetSingleOfEntityOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog EndGetSingleOfEntityOfByIdentifier(System.IAsyncResult result);

        #endregion Query Methods Of Entity of ByIdentifier 




        #region Query Methods Of KeyInformation of ByIdentifier 

#if SILVERLIGHT
#else

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfKeyInformationOfByIdentifierResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);
		
        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfKeyInformationOfByIdentifierResponse")]
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfKeyInformationOfByIdentifierResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetCollectionOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

        [System.ServiceModel.OperationContractAttribute(Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfKeyInformationOfByIdentifierResponse")]
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetSingleOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request);

#endif

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCountOfKeyInformationOfByIdentifierResponse")]
        System.IAsyncResult BeginGetCountOfKeyInformationOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger EndGetCountOfKeyInformationOfByIdentifier(System.IAsyncResult result);
		
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/ExistsOfKeyInformationOfByIdentifierResponse")]
        System.IAsyncResult BeginExistsOfKeyInformationOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean EndExistsOfKeyInformationOfByIdentifier(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetCollectionOfKeyInformationOfByIdentifierResponse")]
        System.IAsyncResult BeginGetCollectionOfKeyInformationOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation EndGetCollectionOfKeyInformationOfByIdentifier(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfKeyInformationOfByIdentifier", 
			ReplyAction="http://www.nTierSketchUp.com/Log4Net/WcfContracts/ILogWcfService/GetSingleOfKeyInformationOfByIdentifierResponse")]
        System.IAsyncResult BeginGetSingleOfKeyInformationOfByIdentifier(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request, System.AsyncCallback callback, object asyncState);
        Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation EndGetSingleOfKeyInformationOfByIdentifier(System.IAsyncResult result);

        #endregion Query Methods Of KeyInformation of ByIdentifier 







	}
}