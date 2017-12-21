using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Log4Net.DALContracts
{
    /// <summary>
    /// There is a DataAccessLayerEntityContract class for each entity, which inherits from <see cref="Framework.DAL.DataAccessLayerContractBase&lt;TCollection, T, TIdentifier&gt;"/> with 3 type arguments, entity class and its collection class, and identifier class.
    /// </summary>
    /// <typeparam name="TCollection">collection class of entity</typeparam>
    /// <typeparam name="T">the entity class</typeparam>
    /// <typeparam name="TIdentifier">identifier class of entity</typeparam>
    public interface ILogRepository<TCollection, T, TIdentifier, TCollectionMessage>
        : Framework.DAL.DataAccessLayerContractBase<TCollection, T, TIdentifier, TCollectionMessage>
        where TCollection : IList<T>, new()
        where T : Log4Net.EntityContracts.ILog, new()
        where TIdentifier : Log4Net.EntityContracts.ILogIdentifier, new()
    {

    }

    /// <summary>
    /// There is a DataAccessLayerEntityContract class for each entity, which inherits from <see cref="Framework.DAL.DataAccessLayerContractBase&lt;TCollection, T, TIdentifier&gt;"/> with 3 type arguments, entity class and its collection class, and identifier class.
    /// </summary>
    public interface ILogRepository: ILogRepository<Log4Net.DataSourceEntities.LogCollection, Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogIdentifier, Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog>
    {

        #region Binary Columns

        #endregion Binary Columns

        #region Query Methods Of Entity of Common

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfCommon(
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfCommon(
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfCommon(
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfCommon(
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
            ,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of Entity of Common

        #region Query Methods Of Entity of All

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfAll(
            Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of Entity of All

        #region Query Methods Of NameValuePair of All

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfNameValuePairOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfNameValuePairOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntity GetSingleOfNameValuePairOfAll(
            Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntityCollection GetCollectionOfNameValuePairOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of NameValuePair of All

        #region Query Methods Of RssItem of All

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfRssItemOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfRssItemOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageRssItem GetSingleOfRssItemOfAll(
            Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfRssItemCollection GetCollectionOfRssItemOfAll(
            int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of RssItem of All

        #region Query Methods Of Entity of ByIdentifier

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of Entity of ByIdentifier

        #region Query Methods Of KeyInformation of ByIdentifier

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>Result property will be the count of records in database, 0 if no record in database</returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfKeyInformationOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// *public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>an instance of <see cref="Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean"/></returns>
        Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfKeyInformationOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with single entity</returns>
        Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation GetSingleOfKeyInformationOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common.
        /// Common query set is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// *public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>result message with entity collection</returns>
        Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
            Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
            ,int currentIndex
            ,int pageSize
            ,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
            );

        #endregion Query Methods Of KeyInformation of ByIdentifier

    }
}

