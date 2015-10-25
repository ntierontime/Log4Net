using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Framework.EntityContracts;
using Framework;

namespace Log4Net.CommonBLLIoC
{
    /// <summary>
    /// provides static method wrappers of Business logic layer using IoC
    /// </summary>
	//[System.ComponentModel.DataObject], because of Silverlight and Windows Phone 7.1
    public static class BusinessLogicLayerEntityStaticLog
    {
        public static Framework.EntityContracts.QueryOrderBySettingCollection DefaultQueryOrderBySettingCollection;

        static BusinessLogicLayerEntityStaticLog()
        {
            DefaultQueryOrderBySettingCollection = new Framework.EntityContracts.QueryOrderBySettingCollection();
            DefaultQueryOrderBySettingCollection.Add("Id", System.ComponentModel.ListSortDirection.Ascending);
        }

        #region insert, update and delete in request message

        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> in a request message.
        /// </summary>
        /// <param name="_Request">the request message</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog InsertRequest(
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            return _BusinessLogicLayerInstance.InsertEntity(_Request);
        }

        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> in a request message.
        /// </summary>
        /// <param name="_Request">the request message</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog UpdateRequest(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            return _BusinessLogicLayerInstance.UpdateEntity(_Request);
        }

        /// <summary>
        /// Deletes By Identifier an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> in a request message.
        /// </summary>
        /// <param name="_Request">the request message</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifierRequest(
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog _Request)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            return _BusinessLogicLayerInstance.DeleteByIdentifierEntity(_Request);
        }

        /// <summary>
        /// Deletes an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> in a request message.
        /// </summary>
        /// <param name="_Request">the request message</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteRequest(
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            return _BusinessLogicLayerInstance.DeleteEntity(_Request);
        }

        #endregion insert, update and delete in request message
		
        #region insert, update and delete in an entity

        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog InsertEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request =new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Create, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Create.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.Add(input);
            return InsertRequest(_Request);
        }

        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog UpdateEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Update, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Update.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.Add(input);
            return UpdateRequest(_Request);
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier.
        /// </summary>
        /// <param name="identifier">input identifier of an entity</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifierEntity(
            Log4Net.DataSourceEntities.LogIdentifier identifier)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = identifier;
            return DeleteByIdentifierRequest(_Request);
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="input">input entity</param>
        /// <returns>a message with action result</returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.Add(input);
            return DeleteRequest(_Request);
        }

        #endregion insert, update and delete in an entity

        #region insert, update and delete using .Net value types

        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        /// <param name="date">property value of System.DateTime</param>
        /// <param name="thread">property value of System.String</param>
        /// <param name="level">property value of System.String</param>
        /// <param name="logger">property value of System.String</param>
        /// <param name="message">property value of System.String</param>
        /// <param name="exception">property value of System.String</param>
        public static void Insert(
			System.Int64 id
			, System.DateTime date
			, System.String thread
			, System.String level
			, System.String logger
			, System.String message
			, System.String exception
			)
        {
            InsertEntity(new Log4Net.DataSourceEntities.Log(
				id
				, date
				, thread
				, level
				, logger
				, message
				, exception));
        }

        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        /// <param name="date">property value of System.DateTime</param>
        /// <param name="thread">property value of System.String</param>
        /// <param name="level">property value of System.String</param>
        /// <param name="logger">property value of System.String</param>
        /// <param name="message">property value of System.String</param>
        /// <param name="exception">property value of System.String</param>
        public static void Update(
			System.Int64 id
			, System.DateTime date
			, System.String thread
			, System.String level
			, System.String logger
			, System.String message
			, System.String exception			)
        {
            UpdateEntity(new Log4Net.DataSourceEntities.Log(
				id
				, date
				, thread
				, level
				, logger
				, message
				, exception));
        }


		/// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        /// <param name="date">property value of System.DateTime</param>
        /// <param name="thread">property value of System.String</param>
        /// <param name="level">property value of System.String</param>
        /// <param name="logger">property value of System.String</param>
        /// <param name="message">property value of System.String</param>
        /// <param name="exception">property value of System.String</param>
        public static void Delete(
			System.Int64 id
			, System.DateTime date
			, System.String thread
			, System.String level
			, System.String logger
			, System.String message
			, System.String exception
			)
        {
            DeleteEntity(new Log4Net.DataSourceEntities.Log(
				id
				, date
				, thread
				, level
				, logger
				, message
				, exception));
        }

		/// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifier(
			System.Int64 id
			)
        {
            return DeleteByIdentifierEntity(new Log4Net.DataSourceEntities.LogIdentifier(
				id));
        }

        #endregion insert, update and delete using .Net value types

        #region batch insert, update and delete in an entity collection

        /// <summary>
        /// batch update a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchUpdate(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Update, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Update.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.AddRange(input);
            return _BusinessLogicLayerInstance.BatchUpdate(_Request);
        }

		/// <summary>
        /// batch insert a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchInsert(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Create, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Create.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.AddRange(input);
            return _BusinessLogicLayerInstance.BatchInsert(_Request);
        }

		/// <summary>
        /// batch delete a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchDelete(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog(Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete, Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete.ToString(), Guid.NewGuid().ToString());
            _Request.Critieria = new Log4Net.DataSourceEntities.LogCollection();
            _Request.Critieria.AddRange(input);
            return _BusinessLogicLayerInstance.BatchDelete(_Request);
        }

        #endregion batch insert, update and delete in an entity collection
		


        #region Query Methods Of Entity of Common per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfCommon for GetPageNumberListOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetCountOfEntityOfCommon for GetPageCountOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
        public static int GetCountOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "ExistsOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return GetMessageOfEntityOfCommon(
				criteria
				, queryPagingSetting
				, queryOrderBySettingCollection
				, Framework.DataServiceTypes.DataSourceResult);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			, Framework.DataServiceTypes dataServiceType)
        {
            //log.Info(string.Format("{0}: GetMessageOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetMessageOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			_Request.DataServiceType = dataServiceType;

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfCommon(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetSingleOfEntityOfCommon"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        #endregion Query Methods Of Entity of Common per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of Entity of Common per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfCommon for GetPageNumberListOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfCommon for GetPageCountOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public static int GetCountOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, currentIndex				  
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "ExistsOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon));

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfCommon(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, string queryOrderByExpression
			)

        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetSingleOfEntityOfCommon"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, queryOrderByExpression
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon)
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfCommon(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfCommon", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        #endregion Query Methods Of Entity of Common per value type




        #region Query Methods Of Entity of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfAll for GetPageNumberListOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetCountOfEntityOfAll for GetPageCountOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
        public static int GetCountOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "ExistsOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return GetMessageOfEntityOfAll(
				criteria
				, queryPagingSetting
				, queryOrderBySettingCollection
				, Framework.DataServiceTypes.DataSourceResult);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			, Framework.DataServiceTypes dataServiceType)
        {
            //log.Info(string.Format("{0}: GetMessageOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetMessageOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			_Request.DataServiceType = dataServiceType;

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfAll(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetSingleOfEntityOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        #endregion Query Methods Of Entity of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of Entity of All per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfAll(
			int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfAll for GetPageNumberListOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfAll(
			int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfAll for GetPageCountOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public static int GetCountOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex				  
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "ExistsOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfAll(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>

        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfAll(
			string queryOrderByExpression
			)

        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetSingleOfEntityOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, queryOrderByExpression
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(

				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        #endregion Query Methods Of Entity of All per value type




        #region Query Methods Of NameValuePair of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfNameValuePairOfAll for GetPageNumberListOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetCountOfNameValuePairOfAll for GetPageCountOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
        public static int GetCountOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "ExistsOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.NameValueCollection GetCollectionOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetCollectionOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetMessageOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return GetMessageOfNameValuePairOfAll(
				criteria
				, queryPagingSetting
				, queryOrderBySettingCollection
				, Framework.DataServiceTypes.DataSourceResult);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetMessageOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			, Framework.DataServiceTypes dataServiceType)
        {
            //log.Info(string.Format("{0}: GetMessageOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetMessageOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			_Request.DataServiceType = dataServiceType;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetCollectionOfNameValuePairOfAll(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.NameValueCollection GetSingleOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetSingleOfNameValuePairOfAll"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetSingleOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        #endregion Query Methods Of NameValuePair of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of NameValuePair of All per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfNameValuePairOfAll(
			int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfNameValuePairOfAll for GetPageNumberListOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfNameValuePairOfAll(
			int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfNameValuePairOfAll for GetPageCountOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public static int GetCountOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex				  
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "ExistsOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.NameValueCollection GetCollectionOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetCollectionOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection"/></returns>
        public static Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetMessageOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
);

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetCollectionOfNameValuePairOfAll(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>

        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        public static Framework.NameValueCollection GetSingleOfNameValuePairOfAll(
			string queryOrderByExpression
			)

        {
            //log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetSingleOfNameValuePairOfAll"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, queryOrderByExpression
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll(

				);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Response = _BusinessLogicLayerInstance.GetSingleOfNameValuePairOfAll(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfNameValuePairOfAll", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        #endregion Query Methods Of NameValuePair of All per value type




        #region Query Methods Of Entity of ByIdentifier per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfByIdentifier for GetPageNumberListOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetCountOfEntityOfByIdentifier for GetPageCountOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
        public static int GetCountOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "ExistsOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return GetMessageOfEntityOfByIdentifier(
				criteria
				, queryPagingSetting
				, queryOrderBySettingCollection
				, Framework.DataServiceTypes.DataSourceResult);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			, Framework.DataServiceTypes dataServiceType)
        {
            //log.Info(string.Format("{0}: GetMessageOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetMessageOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			_Request.DataServiceType = dataServiceType;

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfByIdentifier(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetSingleOfEntityOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        #endregion Query Methods Of Entity of ByIdentifier per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of Entity of ByIdentifier per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfByIdentifier for GetPageNumberListOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfByIdentifier for GetPageCountOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public static int GetCountOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex				  
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "ExistsOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetCollectionOfEntityOfByIdentifier(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
        public static Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, string queryOrderByExpression
			)

        {
            //log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetSingleOfEntityOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, queryOrderByExpression
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier)
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response = _BusinessLogicLayerInstance.GetSingleOfEntityOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfEntityOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        #endregion Query Methods Of Entity of ByIdentifier per value type




        #region Query Methods Of KeyInformation of ByIdentifier per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfKeyInformationOfByIdentifier for GetPageNumberListOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetCountOfKeyInformationOfByIdentifier for GetPageCountOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			int pageSize = queryPagingSetting == null ? 0 : queryPagingSetting.PageSize;

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
        public static int GetCountOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "ExistsOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.DataSourceEntities.Log.KeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetCollectionOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetMessageOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return GetMessageOfKeyInformationOfByIdentifier(
				criteria
				, queryPagingSetting
				, queryOrderBySettingCollection
				, Framework.DataServiceTypes.DataSourceResult);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetMessageOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			, Framework.DataServiceTypes dataServiceType)
        {
            //log.Info(string.Format("{0}: GetMessageOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetMessageOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }
			_Request.DataServiceType = dataServiceType;

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetCollectionOfKeyInformationOfByIdentifier(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.DataSourceEntities.Log.KeyInformationCollection GetSingleOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
            //log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
                Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
                , "GetSingleOfKeyInformationOfByIdentifier"
                , Guid.NewGuid().ToString()
                );
            _Request.Critieria = criteria;
            _Request.QueryPagingSetting = queryPagingSetting;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _Request.QueryOrderBySettingCollection = DefaultQueryOrderBySettingCollection;
            }
            else
            {
                _Request.QueryOrderBySettingCollection = queryOrderBySettingCollection;
            }

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetSingleOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        #endregion Query Methods Of KeyInformation of ByIdentifier per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of KeyInformation of ByIdentifier per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
        public static int[] GetPageNumberListOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfKeyInformationOfByIdentifier for GetPageNumberListOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
				if (_PageCount > 0)
				{
					List<int> _retval = new List<int>();
					for (int i = 1; i <= _PageCount; i++)
					{
						_retval.Add(i);
					}
		            //log.Info(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
					return _retval.ToArray();
				}
				else
				{
		            //log.Error(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
					return null;
				}
			}
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
		            //log.Error(string.Format("{0}: GetPageNumberListOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
        public static int GetPageCountOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
            //log.Info(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfKeyInformationOfByIdentifier for GetPageCountOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, null
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				int _RecordCount = _Response.Message;

				int _PageCount;
				if (pageSize > 0)
				{
					_PageCount = _RecordCount / pageSize + _RecordCount % pageSize > 0 ? 1 : 0;
				}
				else
				{
					_PageCount = 0;
				}
	            //log.Info(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
				return _PageCount;
			}
            else
            {
                //log.Error(string.Format("{0}: GetPageCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
	            //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public static int GetCountOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCountOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex				  
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Response = _BusinessLogicLayerInstance.GetCountOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
	            return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCountOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
                //log.Error(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return 0;
            }
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public static bool ExistsOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "ExistsOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Response = _BusinessLogicLayerInstance.ExistsOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "ExistsOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return false;
            }
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.DataSourceEntities.Log.KeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
            //log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetCollectionOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetCollectionOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation"/></returns>
        public static Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetMessageOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetCollectionOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, currentIndex
				, pageSize
				, queryOrderByExpression				
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetCollectionOfKeyInformationOfByIdentifier(_Request);
            return _Response;
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
        public static Log4Net.DataSourceEntities.Log.KeyInformationCollection GetSingleOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, string queryOrderByExpression
			)

        {
            //log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Started.ToString()));
			Log4Net.WcfContracts.ILogWcfService _BusinessLogicLayerInstance = Log4Net.WcfContracts.WcfServiceResolver.ResolveWcfServiceLog();
            Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier(
				Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search
				, "GetSingleOfKeyInformationOfByIdentifier"
				, Guid.NewGuid().ToString()
				, -1
				, -1
				, queryOrderByExpression
				);
            _Request.Critieria = new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier)
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Response = _BusinessLogicLayerInstance.GetSingleOfKeyInformationOfByIdentifier(_Request);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
	            //log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return _Response.Message;
            }
            else
            {
                //Framework.Web.WebFormApplicationExceptionHandler.Process("BusinessLogicLayerEntityStaticLog", "GetSingleOfKeyInformationOfByIdentifier", _Response.BusinessLogicLayerResponseStatus.ToString(), _Response.ServerErrorMessage);
	            //log.Error(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return null;
            }
		}

        #endregion Query Methods Of KeyInformation of ByIdentifier per value type





    }
}

