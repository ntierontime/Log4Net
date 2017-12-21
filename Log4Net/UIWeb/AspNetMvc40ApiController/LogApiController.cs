using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Framework.EntityContracts;

namespace Log4Net.AspNetMvc40ApiController.ApiControllers
{
    /// <summary>

    /// </summary>
    public partial class LogApiController : ApiController
    {
        #region log4net

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion log4net

        #region insert, update and delete in an entity

        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
        [HttpPost, ActionName("InsertEntity")]
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn InsertEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.InsertEntity(input);

            return responseMessage;
        }

        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
        [HttpPut, ActionName("UpdateEntity")]
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn UpdateEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.UpdateEntity(input);

            return responseMessage;
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier.
        /// </summary>
        /// <param name="identifier">input identifier of an entity</param>
        [HttpPut, ActionName("DeleteByIdentifierEntity")]
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn DeleteByIdentifierEntity(
            Log4Net.DataSourceEntities.LogIdentifier identifier)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.DeleteByIdentifierEntity(identifier);

            return responseMessage;
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="input">input entity</param>
        [HttpPut, ActionName("DeleteEntity")]
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn DeleteEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.DeleteEntity(input);

            return responseMessage;
        }

        #endregion insert, update and delete in an entity

        #region delete using .Net value types

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
        [HttpDelete, ActionName("DeleteByIdentifier")]
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn DeleteByIdentifier(
            System.Int64 id
            )
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.DeleteByIdentifierEntity(new Log4Net.DataSourceEntities.LogIdentifier(
                id));

            return responseMessage;
        }

        #endregion delete using .Net value types

        #region batch insert, update and delete in an entity collection

        /// <summary>
        /// batch update a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        [HttpPut, ActionName("BatchUpdate")]
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchUpdate(Log4Net.DataSourceEntities.LogCollection input)
        {
            Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> resultTask = Task.Factory.StartNew<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(() =>
            {
                Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.BatchUpdate(input);

                return responseMessage;
            });
            return await resultTask;
        }

        /// <summary>
        /// batch insert a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
        [HttpPost, ActionName("BatchInsert")]
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchInsert(Log4Net.DataSourceEntities.LogCollection input)
        {
            Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> resultTask = Task.Factory.StartNew<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(() =>
            {
                Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.BatchInsert(input);

                return responseMessage;
            });
            return await resultTask;
        }

        /// <summary>
        /// batch delete a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
        [HttpDelete, ActionName("BatchDelete")]
        public async Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> BatchDelete(Log4Net.DataSourceEntities.LogCollection input)
        {
            Task<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn> resultTask = Task.Factory.StartNew<Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn>(() =>
            {
                Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn responseMessage = Log4Net.CommonBLLIoC.IoCLog.BatchDelete(input);

                return responseMessage;
            });
            return await resultTask;
        }

        #endregion batch insert, update and delete in an entity collection

        #region Query Methods Of NameValuePair of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
        [HttpGet, ActionName("GetCollectionOfNameValuePairOfAll")]
        public Framework.NameValueCollection GetCollectionOfNameValuePairOfAll(
            int currentIndex
            , int pageSize
            , string queryOrderByExpression
            )
        {
            return Log4Net.CommonBLLIoC.IoCLog.GetCollectionOfNameValuePairOfAll(                currentIndex
                , pageSize
                , queryOrderByExpression);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection"/></returns>
        [HttpGet, ActionName("GetMessageOfNameValuePairOfAll")]
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetMessageOfNameValuePairOfAll(
            int currentIndex
            , int pageSize
            , string queryOrderByExpression        )

        {
            return Log4Net.CommonBLLIoC.IoCLog.GetMessageOfNameValuePairOfAll(                currentIndex
                , pageSize
                , queryOrderByExpression);
        }

        #endregion Query Methods Of NameValuePair of All per value type

        /// <summary>
        /// Gets the Item View Model of Log4Net.Log.
        /// http://[host]/api/LogApi/GetLogItemVM?
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Log4Net.ViewModelData.LogItemVM GetLogItemVM(
            System.Int64 id)
        {
            Log4Net.AspNetMvc40ViewModel.LogItemVM retval = new Log4Net.AspNetMvc40ViewModel.LogItemVM();
            retval.Load(true, id, Framework.UIAction.ViewDetails);
            return retval;
        }

        /// <summary>
        /// Gets the Wrapper View Model of Log4Net.Log: WPCommonOfLogVM.
        /// http://[host]/api/LogApi/GetWPCommonOfLogVM
        /// Content-Type: application/json; charset=utf-8
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        // [HttpGet, ActionName("GetWPCommonOfLogVM")] //although JSON allowed in Http Delete request body, but not allowed in HttpClient
        [HttpPost, ActionName("GetWPCommonOfLogVM")]
        public Log4Net.ViewModelData.WPCommonOfLogVM GetWPCommonOfLogVM(
            [FromBody]Log4Net.ViewModelData.WPCommonOfLogVM vm)
        {
            Log4Net.AspNetMvc40ViewModel.WPCommonOfLogVM retval = new Log4Net.AspNetMvc40ViewModel.WPCommonOfLogVM();
            if (vm != null)
            {
                retval.Criteria = vm.Criteria;
                retval.QueryPagingSetting = vm.QueryPagingSetting;
                retval.QueryOrderBySettingCollecionInString = vm.QueryOrderBySettingCollecionInString;
            }
            else
            {
                retval.Criteria = new Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommon();
                retval.QueryPagingSetting = Framework.EntityContracts.QueryPagingSetting.GetDefault();
                //retval.QueryOrderBySettingCollecionInString = Log4Net.ViewModelData.OrderByLists.WPCommonOfLogVM_GetDefaultListOfQueryOrderBySettingCollecionInString();
            }
            retval.LoadData(true);
            return retval;
        }

        /// <summary>
        /// Gets entity related view model of Log4Net.Log: WPEntityRelatedOfLogVM.
        /// http://[host]/api/LogApi/GetWPEntityRelatedOfLogVM?
        /// </summary>
        /// <returns></returns>
        [HttpGet, ActionName("GetWPEntityRelatedOfLogVM")]
        public Log4Net.ViewModelData.WPEntityRelatedOfLogVM GetWPEntityRelatedOfLogVM(
            System.Int64 id)
        {
            Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM retval = new Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM(new Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier(true, id));
            retval.LoadData();
            return retval;
        }

        /// <summary>
        /// HearBeat.
        /// http://[host]/api/LogApi/HearBeat
        /// </summary>
        /// <returns></returns>
        [HttpGet, ActionName("HeartBeat")]
        public bool HeartBeat()
        {
            return true;
        }

    }
}

