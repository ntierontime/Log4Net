using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Framework.EntityContracts;
using Framework.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;

namespace Log4Net.WebApiClient
{
    /// <summary>

    /// </summary>
    public partial class LogApiControllerClient : Framework.ViewModels.ApiControllerHttpClientBase
    {
        #region fields and properties

        public const string ControllerNameString = "LogApi";
        public override string ControllerName
        {
            get
            {
                return ControllerNameString;
            }
        }

        #endregion fields and properties

        #region contructors

        public LogApiControllerClient(string rootPath) : base(rootPath)
        {
        }

        #endregion contructors

        #region insert, update and delete in an entity

        public const string ActionName_InsertEntity = "InsertEntity";
        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// http://[host]/api/LogApi/InsertEntity
        /// </summary>
        /// <param name="input">input entity</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> InsertEntityAsync(
            Log4Net.DataSourceEntities.Log input)
        {
            string url = GetHttpRequestUrl(ActionName_InsertEntity);

            return await Post<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        public const string ActionName_UpdateEntity = "UpdateEntity";
        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// http://[host]/api/LogApi/UpdateEntity
        /// </summary>
        /// <param name="input">input entity</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> UpdateEntityAsync(
            Log4Net.DataSourceEntities.Log input)
        {
            string url = GetHttpRequestUrl(ActionName_UpdateEntity);

            return await Put<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        public const string ActionName_DeleteByIdentifierEntity = "DeleteByIdentifierEntity";
        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier.
        /// http://[host]/api/LogApi/DeleteByIdentifierEntity
        /// </summary>
        /// <param name="identifier">input identifier of an entity</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> DeleteByIdentifierEntityAsync(
            Log4Net.DataSourceEntities.LogIdentifier identifier)
        {
            string url = GetHttpRequestUrl(ActionName_DeleteByIdentifierEntity);

            return await Post<Log4Net.DataSourceEntities.LogIdentifier, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, identifier);
        }

        public const string ActionName_DeleteEntity = "DeleteEntity";
        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// http://[host]/api/LogApi/DeleteEntity
        /// </summary>
        /// <param name="input">input entity</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> DeleteEntityAsync(
            Log4Net.DataSourceEntities.Log input)
        {
            string url = GetHttpRequestUrl(ActionName_InsertEntity);

            return await Post<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        #endregion insert, update and delete in an entity

        #region delete using .Net value types

        public const string ActionName_DeleteByIdentifier = "DeleteByIdentifier";
        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier using .net value types.
        /// http://[host]/api/LogApi/DeleteByIdentifier
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> DeleteByIdentifierAsync(
            System.Int64 id
            )
        {
            string url = GetHttpRequestUrl(ActionName_InsertEntity);

            return await Delete<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url);
        }

        #endregion delete using .Net value types

        #region batch insert, update and delete in an entity collection

        public const string ActionName_BatchInsert = "BatchInsert";
        /// <summary>
        /// batch insert a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// http://[host]/api/LogApi/BatchInsert
        /// </summary>
        /// <param name="input">The input collection.</param>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchInsertAsync(Log4Net.DataSourceEntities.LogCollection input)
        {
            string url = GetHttpRequestUrl(ActionName_BatchInsert);

            return await Post<Log4Net.DataSourceEntities.LogCollection, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        public const string ActionName_BatchUpdate = "BatchUpdate";
        /// <summary>
        /// batch update a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// http://[host]/api/LogApi/BatchUpdate
        /// </summary>
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchUpdateAsync(Log4Net.DataSourceEntities.LogCollection input)
        {
            string url = GetHttpRequestUrl(ActionName_BatchUpdate);

            return await Put<Log4Net.DataSourceEntities.LogCollection, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        public const string ActionName_BatchDelete = "BatchDelete";
        /// <summary>
        /// batch delete a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// http://[host]/api/LogApi/BatchDelete
        /// </summary>
        /// <param name="input">The input collection.</param>
        // [HttpDelete, ActionName("BatchDelete")] //although JSON allowed in Http Delete request body, but not allowed in HttpClient
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchDeleteAsync(Log4Net.DataSourceEntities.LogCollection input)
        {
            string url = GetHttpRequestUrl(ActionName_BatchDelete);

            return await Post<Log4Net.DataSourceEntities.LogCollection, Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(url, input);
        }

        #endregion batch insert, update and delete in an entity collection

        #region Query Methods Of NameValuePair of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        public const string ActionName_GetCollectionOfNameValuePairOfAll = "GetCollectionOfNameValuePairOfAll";
        /// <summary>
        /// Gets the collection of entity of common.
        /// http://[host]/api/LogApi/GetCollectionOfNameValuePairOfAll
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        public async Task<Framework.NameValueCollection> GetCollectionOfNameValuePairOfAllAsync(
            int currentIndex
            , int pageSize
            , string queryOrderByExpression
            )
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("currentIndex", currentIndex.ToString());
            parameters.Add("pageSize", pageSize.ToString());
            parameters.Add("queryOrderByExpression", queryOrderByExpression);

            string url = GetHttpRequestUrl(ActionName_GetCollectionOfNameValuePairOfAll, parameters);
            return await Get<Framework.NameValueCollection>(url);
        }

        #endregion Query Methods Of NameValuePair of All per value type

        public const string ActionName_GetLogItemVM = "GetLogItemVM";
        /// <summary>
        /// Gets the build log item.
        /// http://[host]/api/LogApi/GetLogItemVM?id=1
        /// </summary>
        /// <returns></returns>
        public async Task<Log4Net.ViewModelData.LogItemVM> GetLogItemVMAsync(
            System.Int64 id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            string url = GetHttpRequestUrl(ActionName_GetLogItemVM, parameters);

            return await GetItemViewModel<Log4Net.ViewModelData.LogItemVM>(url);
        }

            public const string ActionName_GetWPCommonOfLogVM = "GetWPCommonOfLogVM";
        /// <summary>
        /// Gets the wp common of build log vm.
        /// http://[host]/api/LogApi/GetWPCommonOfLogVM
        /// Content-Type: application/json; charset=utf-8
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        public async Task<Log4Net.ViewModelData.WPCommonOfLogVM> GetWPCommonOfLogVMAsync(
            Log4Net.ViewModelData.WPCommonOfLogVM vm)
        {
            string url = GetHttpRequestUrl(ActionName_GetWPCommonOfLogVM);

            return await Post<Log4Net.ViewModelData.WPCommonOfLogVM>(url, vm);
        }

        public const string ActionName_GetWPEntityRelatedOfLogVM = "GetWPEntityRelatedOfLogVM";
        /// <summary>
        /// Gets the wp entity related of build log.
        /// http://[host]/api/LogApi/GetWPEntityRelatedOfLogVM?id=1
        /// </summary>
        /// <returns></returns>
        public async Task<Log4Net.ViewModelData.WPEntityRelatedOfLogVM> GetWPEntityRelatedOfLogVMAsync(
            System.Int64 id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            string url = GetHttpRequestUrl(ActionName_GetWPEntityRelatedOfLogVM, parameters);

            return await GetEntityRelated<Log4Net.ViewModelData.WPEntityRelatedOfLogVM>(url);
        }

        public const string ActionName_HeartBeat = "HeartBeat";
        /// <summary>
        /// Hearts the beat asynchronous.
        /// http://[host]/api/LogApi/HeartBeat
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> HeartBeatAsync()
        {
            string url = GetHttpRequestUrl(ActionName_HeartBeat);
            var response = await Client.GetAsync(url);

            return response;
        }
    }
}

