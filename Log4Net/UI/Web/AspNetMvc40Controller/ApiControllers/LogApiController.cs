using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Framework.EntityContracts;

namespace Log4Net.AspNetMvc40Controller.ApiControllers
{
    /// <summary>
    /// Api Controller of  <see cref="CustomerInfo.DataSourceEntities.CustomerProduct"/>
	/// http://blogs.msdn.com/b/jmstall/archive/2012/04/16/how-webapi-does-parameter-binding.aspx
	/// http://blogs.msdn.com/b/jmstall/archive/2012/04/20/how-to-bind-to-custom-objects-in-action-signatures-in-mvc-webapi.aspx
	/// http://blogs.msdn.com/b/jmstall/archive/2012/04/18/mvc-style-parameter-binding-for-webapi.aspx
    /// </summary>
    public class LogApiController : ApiController
    {
		#region log4net

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion log4net

        #region Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

        #region insert, update and delete in an entity

        /// <summary>
        /// Inserts an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
		[HttpPost, ActionName("InsertEntity")]
        public void InsertEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.InsertEntity(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Updates an entity of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">input entity</param>
        [HttpPut, ActionName("UpdateEntity")]
        public void UpdateEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.UpdateEntity(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier.
        /// </summary>
        /// <param name="identifier">input identifier of an entity</param>
        [HttpDelete, ActionName("DeleteByIdentifierEntity")]
        public void DeleteByIdentifierEntity(
            Log4Net.DataSourceEntities.LogIdentifier identifier)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.DeleteByIdentifierEntity(identifier);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> using .net value types.
        /// </summary>
        /// <param name="input">input entity</param>
        [HttpDelete, ActionName("DeleteEntity")]
        public void DeleteEntity(
            Log4Net.DataSourceEntities.Log input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.DeleteEntity(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        #endregion insert, update and delete in an entity

        #region delete using .Net value types

		/// <summary>
        /// delete an entity of <see cref=" Log4Net.DataSourceEntities.Log"/> by identifier using .net value types.
        /// </summary>
        /// <param name="id">property value of System.Int64</param>
		[HttpDelete, ActionName("DeleteByIdentifier")]
        public void DeleteByIdentifier(
			System.Int64 id
			)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.DeleteByIdentifierEntity(new Log4Net.DataSourceEntities.LogIdentifier(
				id));

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        #endregion delete using .Net value types

        #region batch insert, update and delete in an entity collection

        /// <summary>
        /// batch update a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        [HttpPut, ActionName("BatchUpdate")]
        public void BatchUpdate(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.BatchUpdate(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

		/// <summary>
        /// batch insert a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
		[HttpPost, ActionName("BatchInsert")]
        public void BatchInsert(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.BatchInsert(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

		/// <summary>
        /// batch delete a collection of <see cref=" Log4Net.DataSourceEntities.Log"/>.
        /// </summary>
        /// <param name="input">The input collection.</param>
		[HttpDelete, ActionName("BatchDelete")]
        public void BatchDelete(Log4Net.DataSourceEntities.LogCollection input)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog responseMessage = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.BatchDelete(input);

            if (responseMessage.BusinessLogicLayerResponseStatus != Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        #endregion batch insert, update and delete in an entity collection

        #endregion



        #region Query Methods Of Entity of Common per critieria, queryPagingSetting and queryOrderBySettingCollection

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>an array with all available page numbers</returns>
		[HttpGet, ActionName("GetPageNumberListOfEntityOfCommonVM")]
        public int[] GetPageNumberListOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfEntityOfCommonVM")]
        public int GetPageCountOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
		[HttpGet, ActionName("GetCountOfEntityOfCommonVM")]
        public int GetCountOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfEntityOfCommonVM")]
        public bool ExistsOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfEntityOfCommonVM")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetMessageOfEntityOfCommonVM")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfEntityOfCommonVM")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfCommon(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfCommon(criteria, queryPagingSetting, queryOrderBySettingCollection);
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
		[HttpGet, ActionName("GetPageNumberListOfEntityOfCommon")]
        public int[] GetPageNumberListOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, pageSize);
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
		[HttpGet, ActionName("GetPageCountOfEntityOfCommon")]
        public int GetPageCountOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, pageSize);
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
		[HttpGet, ActionName("GetCountOfEntityOfCommon")]
        public int GetCountOfEntityOfCommon(
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
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("ExistsOfEntityOfCommon")]
        public bool ExistsOfEntityOfCommon(
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
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetCollectionOfEntityOfCommon")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfCommon(
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
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetMessageOfEntityOfCommon")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfCommon(
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
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetSingleOfEntityOfCommon")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
			, bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
			, bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
			, bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
			, bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
			, bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
			, string queryOrderByExpression
			)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfCommon(				isToCompareDateCommonOftOfCommon && lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue && upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, isToCompareLowerBoundDateCommonOftOfCommon & lowerBoundDateCommonOftOfCommon != System.DateTime.MinValue, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon & upperBoundDateCommonOftOfCommon != System.DateTime.MinValue, upperBoundDateCommonOftOfCommon
				, isToCompareThreadCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedThreadCommonOftOfCommon), valueToBeContainedThreadCommonOftOfCommon
				, isToCompareLevelCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLevelCommonOftOfCommon), valueToBeContainedLevelCommonOftOfCommon
				, isToCompareLoggerCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedLoggerCommonOftOfCommon), valueToBeContainedLoggerCommonOftOfCommon
				, isToCompareMessageCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedMessageCommonOftOfCommon), valueToBeContainedMessageCommonOftOfCommon
				, isToCompareExceptionCommonOftOfCommon && !string.IsNullOrWhiteSpace(valueToBeContainedExceptionCommonOftOfCommon), valueToBeContainedExceptionCommonOftOfCommon
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetPageNumberListOfEntityOfAllVM")]
        public int[] GetPageNumberListOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfEntityOfAllVM")]
        public int GetPageCountOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
		[HttpGet, ActionName("GetCountOfEntityOfAllVM")]
        public int GetCountOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfEntityOfAllVM")]
        public bool ExistsOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfEntityOfAllVM")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetMessageOfEntityOfAllVM")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfEntityOfAllVM")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        #endregion Query Methods Of Entity of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of Entity of All per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
		[HttpGet, ActionName("GetPageNumberListOfEntityOfAll")]
        public int[] GetPageNumberListOfEntityOfAll(
			int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfAll(				pageSize);
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfEntityOfAll")]
        public int GetPageCountOfEntityOfAll(
			int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfAll(				pageSize);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
		[HttpGet, ActionName("GetCountOfEntityOfAll")]
        public int GetCountOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfEntityOfAll")]
        public bool ExistsOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
		}

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfEntityOfAll")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
		}

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>business layer built-in message <see cref="Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog"/></returns>
		[HttpGet, ActionName("GetMessageOfEntityOfAll")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>

        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfEntityOfAll")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfAll(
			string queryOrderByExpression
			)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfAll(				queryOrderByExpression);
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
		[HttpGet, ActionName("GetPageNumberListOfNameValuePairOfAllVM")]
        public int[] GetPageNumberListOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfNameValuePairOfAllVM")]
        public int GetPageCountOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
		[HttpGet, ActionName("GetCountOfNameValuePairOfAllVM")]
        public int GetCountOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfNameValuePairOfAllVM")]
        public bool ExistsOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfNameValuePairOfAllVM")]
        public Framework.NameValueCollection GetCollectionOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Framework.NameValueCollection"/></returns>
		[HttpGet, ActionName("GetMessageOfNameValuePairOfAllVM")]
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetMessageOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfNameValuePairOfAllVM")]
        public Framework.NameValueCollection GetSingleOfNameValuePairOfAll(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogAll criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfNameValuePairOfAll(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        #endregion Query Methods Of NameValuePair of All per critieria, queryPagingSetting and queryOrderBySettingCollection

        #region Query Methods Of NameValuePair of All per value type

        /// <summary>
        /// Gets the page number list of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>an array with all available page numbers</returns>
		[HttpGet, ActionName("GetPageNumberListOfNameValuePairOfAll")]
        public int[] GetPageNumberListOfNameValuePairOfAll(
			int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfNameValuePairOfAll(				pageSize);
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>

        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfNameValuePairOfAll")]
        public int GetPageCountOfNameValuePairOfAll(
			int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfNameValuePairOfAll(				pageSize);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
		[HttpGet, ActionName("GetCountOfNameValuePairOfAll")]
        public int GetCountOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfNameValuePairOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
        }


        /// <summary>
        /// Exists the of entity of common.
        /// </summary>

        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfNameValuePairOfAll")]
        public bool ExistsOfNameValuePairOfAll(
			int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfNameValuePairOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
		}

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
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfNameValuePairOfAll(				currentIndex
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
			, string queryOrderByExpression		)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfNameValuePairOfAll(				currentIndex
				, pageSize
				, queryOrderByExpression);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>

        /// <returns>the collection of type <see cref="Framework.NameValueCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfNameValuePairOfAll")]
        public Framework.NameValueCollection GetSingleOfNameValuePairOfAll(
			string queryOrderByExpression
			)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfNameValuePairOfAll(				queryOrderByExpression);
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
		[HttpGet, ActionName("GetPageNumberListOfEntityOfByIdentifierVM")]
        public int[] GetPageNumberListOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfEntityOfByIdentifierVM")]
        public int GetPageCountOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
		[HttpGet, ActionName("GetCountOfEntityOfByIdentifierVM")]
        public int GetCountOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfEntityOfByIdentifierVM")]
        public bool ExistsOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfEntityOfByIdentifierVM")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetMessageOfEntityOfByIdentifierVM")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfEntityOfByIdentifierVM")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
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
		[HttpGet, ActionName("GetPageNumberListOfEntityOfByIdentifier")]
        public int[] GetPageNumberListOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, pageSize);
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfEntityOfByIdentifier")]
        public int GetPageCountOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, pageSize);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
		[HttpGet, ActionName("GetCountOfEntityOfByIdentifier")]
        public int GetCountOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("ExistsOfEntityOfByIdentifier")]
        public bool ExistsOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetCollectionOfEntityOfByIdentifier")]
        public Log4Net.DataSourceEntities.LogCollection GetCollectionOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetMessageOfEntityOfByIdentifier")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetMessageOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.LogCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfEntityOfByIdentifier")]
        public Log4Net.DataSourceEntities.LogCollection GetSingleOfEntityOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, string queryOrderByExpression
			)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfEntityOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetPageNumberListOfKeyInformationOfByIdentifierVM")]
        public int[] GetPageNumberListOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }
        
        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfKeyInformationOfByIdentifierVM")]
        public int GetPageCountOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns></returns>
		[HttpGet, ActionName("GetCountOfKeyInformationOfByIdentifierVM")]
        public int GetCountOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Exists the of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>true if meets criteria, otherwise false</returns>
		[HttpGet, ActionName("ExistsOfKeyInformationOfByIdentifierVM")]
        public bool ExistsOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
		[HttpGet, ActionName("GetCollectionOfKeyInformationOfByIdentifierVM")]
        public Log4Net.DataSourceEntities.Log.KeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets message of the collection of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>business layer built-in message <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
		[HttpGet, ActionName("GetMessageOfKeyInformationOfByIdentifierVM")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetMessageOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="queryPagingSetting"></param>
        /// <param name="queryOrderBySettingCollection"></param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfKeyInformationOfByIdentifierVM")]
        public Log4Net.DataSourceEntities.Log.KeyInformationCollection GetSingleOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteria
            , Framework.EntityContracts.QueryPagingSetting queryPagingSetting
            , Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfKeyInformationOfByIdentifier(criteria, queryPagingSetting, queryOrderBySettingCollection);
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
		[HttpGet, ActionName("GetPageNumberListOfKeyInformationOfByIdentifier")]
        public int[] GetPageNumberListOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageNumberListOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, pageSize);
        }

        /// <summary>
        /// Gets the page count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>total pages</returns>
		[HttpGet, ActionName("GetPageCountOfKeyInformationOfByIdentifier")]
        public int GetPageCountOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int pageSize
            )
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetPageCountOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, pageSize);
        }

        /// <summary>
        /// Gets the count of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
		[HttpGet, ActionName("GetCountOfKeyInformationOfByIdentifier")]
        public int GetCountOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCountOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("ExistsOfKeyInformationOfByIdentifier")]
        public bool ExistsOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.ExistsOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetCollectionOfKeyInformationOfByIdentifier")]
        public Log4Net.DataSourceEntities.Log.KeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression
			)
        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
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
		[HttpGet, ActionName("GetMessageOfKeyInformationOfByIdentifier")]
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetMessageOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, int currentIndex
			, int pageSize
			, string queryOrderByExpression		)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, currentIndex
				, pageSize
				, queryOrderByExpression);
        }

        /// <summary>
        /// Gets the single of entity of common.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        /// <returns>the collection of type <see cref="Log4Net.DataSourceEntities.Log.KeyInformationCollection"/></returns>
		[HttpGet, ActionName("GetSingleOfKeyInformationOfByIdentifier")]
        public Log4Net.DataSourceEntities.Log.KeyInformationCollection GetSingleOfKeyInformationOfByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
			, string queryOrderByExpression
			)

        {
			return Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetSingleOfKeyInformationOfByIdentifier(				isToCompareIdByIdentifierOftOfByIdentifier && valueToCompareIdByIdentifierOftOfByIdentifier != default(System.Int64), valueToCompareIdByIdentifierOftOfByIdentifier
				, queryOrderByExpression);
		}

        #endregion Query Methods Of KeyInformation of ByIdentifier per value type





    }
}

