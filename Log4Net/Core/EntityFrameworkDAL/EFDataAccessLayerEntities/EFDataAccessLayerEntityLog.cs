using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using MathNet.Numerics.LinqExtensions;
using System.Data.SqlClient;
using System.Data;

namespace Log4Net.EntityFrameworkDAL
{
    /// <summary>
    /// Linq data access layer of entity <see cref="Log4Net.DataSourceEntities.Log"/>, with following methods:
    /// 1. Insert, Update and Delete
    /// 2. Batch Insert, Update and Delete
    /// 3. Queries
    /// </summary>
    public class EFDataAccessLayerEntityLog
        : Log4Net.DALContracts.DataAccessLayerEntityContractLog//<Log4Net.DataSourceEntities.LogCollection, Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogIdentifier>
    {
		#region for log4net

        /// <summary>
        /// for log4net
        /// </summary>
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion for log4net

		#region LinqContext

        /// <summary>
        /// DataContext for EF Linq
        /// </summary>
        public Log4Net.EntityFrameworkContext.Log4NetEntities LinqContext { get; set; }
        
		#endregion LinqContext

		#region constructors

        /// <summary>
        /// default constructor, developer should assign LinqConext after.
        /// </summary>
        public EFDataAccessLayerEntityLog()
        {
        }

        /// <summary>
        /// constructor with Linq DataContext parameter
        /// </summary>
        /// <param name="linqContext">see<see cref="Log4Net.EntityFrameworkContext.Log4NetEntities"/></param>
        public EFDataAccessLayerEntityLog(Log4Net.EntityFrameworkContext.Log4NetEntities linqContext)
        {
            this.LinqContext = linqContext;
        }

		#endregion constructors

        #region IDataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

        /// <summary>
        /// single item insert with entity input
        /// </summary>
        /// <param name="input">to-be-inserted instance of entity class</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog Insert(Log4Net.DataSourceEntities.Log input)
        {
            log.Info(string.Format("{0}: Insert", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = new Log4Net.DataSourceEntities.LogCollection();
            _retval.OriginalValue.Add(input);

            if (input != null)
            {
                Log4Net.EntityFrameworkContext.Log _LinqItem = Log4Net.EntityContracts.ILogHelper.Clone<Log4Net.DataSourceEntities.Log, Log4Net.EntityFrameworkContext.Log>(input);
                this.LinqContext.Log.Add(_LinqItem);
                this.LinqContext.SaveChanges();
                Log4Net.DataSourceEntities.Log _Result = new Log4Net.DataSourceEntities.Log();
                Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.EntityFrameworkContext.Log, Log4Net.DataSourceEntities.Log>(_LinqItem, _Result);
                _retval.Result = new Log4Net.DataSourceEntities.LogCollection();
                _retval.Result.Add(_Result);
            }

            log.Info(string.Format("{0}: Insert", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// single item update with entity input
        /// </summary>
        /// <param name="input">to-be-updated instance of entity class</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog Update(Log4Net.DataSourceEntities.Log input)
        {
            log.Info(string.Format("{0}: Update", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = new Log4Net.DataSourceEntities.LogCollection();
            _retval.OriginalValue.Add(input);

            if (input != null)
            {
                Log4Net.EntityFrameworkContext.Log _LinqItem = GetLinqObjectByIdentifier(input);
                if (_LinqItem != null)
                {
                    Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.DataSourceEntities.Log, Log4Net.EntityFrameworkContext.Log>(input, _LinqItem);
                    this.LinqContext.SaveChanges();
					Log4Net.DataSourceEntities.Log _Result = new Log4Net.DataSourceEntities.Log();
					Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.EntityFrameworkContext.Log, Log4Net.DataSourceEntities.Log>(_LinqItem, _Result);
					_retval.Result = new Log4Net.DataSourceEntities.LogCollection();
					_retval.Result.Add(_Result);
                }
            }
            log.Info(string.Format("{0}: Update", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
			return _retval;
        }

        /// <summary>
        /// single item deletion with entity input
        /// </summary>
        /// <param name="input">item to be deleted</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog Delete(Log4Net.DataSourceEntities.Log input)
        {
            log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = new Log4Net.DataSourceEntities.LogCollection();
            _retval.OriginalValue.Add(input);

            if (input != null)
            {
                Log4Net.EntityFrameworkContext.Log _LinqItem = GetLinqObjectByIdentifier(input);
                if (_LinqItem != null)
                {
                    this.LinqContext.Log.Remove(_LinqItem);
                    this.LinqContext.SaveChanges();
                }
            }
            log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
			return _retval;
        }

        /// <summary>
        /// single item delete by identifier with entity identifier input
        /// </summary>
        /// <param name="id">delete the item if its identifier equals to this parameter</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog DeleteByIdentifier(Log4Net.DataSourceEntities.LogIdentifier id)
        {
            log.Info(string.Format("{0}: DeleteByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            
			Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();

            if (id != null)
            {
                Log4Net.EntityFrameworkContext.Log _LinqItem = GetLinqObjectByIdentifier(id);
                if (_LinqItem != null)
                {
					Log4Net.DataSourceEntities.Log _Original = new Log4Net.DataSourceEntities.Log();
					Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.EntityFrameworkContext.Log, Log4Net.DataSourceEntities.Log>(_LinqItem, _Original);

					_retval.OriginalValue = new Log4Net.DataSourceEntities.LogCollection();
					_retval.OriginalValue.Add(_Original);

                    this.LinqContext.Log.Remove(_LinqItem);
                    this.LinqContext.SaveChanges();
                }
            }
            log.Info(string.Format("{0}: DeleteByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
			return _retval;
        }

        /// <summary>
        /// Batches insert with entity collection input.
        /// </summary>
        /// <param name="input">The input.</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog BatchInsert(Log4Net.DataSourceEntities.LogCollection input)
        {
            log.Info(string.Format("{0}: BatchInsert", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

			Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = input;

            if (input != null && input.Count > 0)
            {
                try
                {
                    DataTable _DataTable = new DataTable();
				_DataTable.Columns.Add("Id", typeof(System.Int64));
				_DataTable.Columns.Add("Date", typeof(System.DateTime));
				_DataTable.Columns.Add("Thread", typeof(System.String));
				_DataTable.Columns.Add("Level", typeof(System.String));
				_DataTable.Columns.Add("Logger", typeof(System.String));
				_DataTable.Columns.Add("Message", typeof(System.String));
				_DataTable.Columns.Add("Exception", typeof(System.String));

                    foreach (Log4Net.DataSourceEntities.Log _Item in input)
                    {
                        _DataTable.Rows.Add(new object[] { _Item.Id, _Item.Date, _Item.Thread, _Item.Level, _Item.Logger, _Item.Message, _Item.Exception });
                    }

                    using (SqlBulkCopy s = new SqlBulkCopy(this.LinqContext.Database.Connection.ConnectionString))
                    {
                        s.DestinationTableName = "dbo.Log";

					s.ColumnMappings.Add("Id", "Id");
					s.ColumnMappings.Add("Date", "Date");
					s.ColumnMappings.Add("Thread", "Thread");
					s.ColumnMappings.Add("Level", "Level");
					s.ColumnMappings.Add("Logger", "Logger");
					s.ColumnMappings.Add("Message", "Message");
					s.ColumnMappings.Add("Exception", "Exception");

                        s.NotifyAfter = 10000;
                        s.WriteToServer(_DataTable);
                        s.Close();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("{0}: Insert", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()), ex);
                }
            }
            log.Info(string.Format("{0}: BatchInsert", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
			return _retval;
        }

        /// <summary>
        /// Batches the delete with entity collection input.
        /// </summary>
        /// <param name="input">The input.</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog BatchDelete(Log4Net.DataSourceEntities.LogCollection input)
        {
            log.Info(string.Format("{0}: BatchDelete", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

			Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = input;

            if (input != null)
            {
                List<Log4Net.EntityFrameworkContext.Log> _ListOfLinq = new List<Log4Net.EntityFrameworkContext.Log>();
                foreach (Log4Net.DataSourceEntities.Log _ItemOfInput in input)
                {
                    Log4Net.EntityFrameworkContext.Log _LinqItem = GetLinqObjectByIdentifier(_ItemOfInput);	
					this.LinqContext.Log.Remove(_LinqItem);
                }
                this.LinqContext.SaveChanges();
            }
            log.Info(string.Format("{0}: BatchDelete", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
			return _retval;
        }

        /// <summary>
        /// Batches the update with entity collection input.
        /// </summary>
        /// <param name="input">The input.</param>
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog BatchUpdate(Log4Net.DataSourceEntities.LogCollection input)
        {
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

			Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog  _retval = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            _retval.OriginalValue = input;

            if (input != null)
            {
                List<Log4Net.EntityFrameworkContext.Log> _ListOfLinq = new List<Log4Net.EntityFrameworkContext.Log>();
                foreach (Log4Net.DataSourceEntities.Log _ItemOfInput in input)
                {
                    Log4Net.EntityFrameworkContext.Log _LinqItem = GetLinqObjectByIdentifier(_ItemOfInput);
                    Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.DataSourceEntities.Log, Log4Net.EntityFrameworkContext.Log>(_ItemOfInput, _LinqItem);
                    _ListOfLinq.Add(_LinqItem);
                }
                this.LinqContext.SaveChanges();

                for (int i = 0; i < input.Count; i++)
                {
                    Log4Net.EntityContracts.ILogHelper.Copy
                        <
                            Log4Net.EntityFrameworkContext.Log, Log4Net.DataSourceEntities.Log
                        >(_ListOfLinq[i], input[i]);
                }
            }
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
			return _retval;
        }

        /// <summary>
        /// Gets an entity instance by input identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>an instance of <see cref="Log4Net.DataSourceEntities.LogIdentifier"/> class, with same identifier.</returns>
        public Log4Net.DataSourceEntities.Log GetByIdentifier(Log4Net.DataSourceEntities.LogIdentifier id)
        {
            Log4Net.EntityFrameworkContext.Log _Only = GetLinqObjectByIdentifier(id);
            if (_Only != null)
            {
                return new Log4Net.DataSourceEntities.Log(_Only);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the linq object by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>an instance of <see cref="Log4Net.EntityFrameworkContext.Log"/> class, with same identifier, which is a IQueryable.</returns>
        private Log4Net.EntityFrameworkContext.Log GetLinqObjectByIdentifier(Log4Net.EntityContracts.ILogIdentifier id)
        {
            Func<Log4Net.EntityFrameworkContext.Log, bool> m_Predicate = (Log4Net.EntityFrameworkContext.Log t) =>
            {
                return Log4Net.EntityContracts.ILogIdentifierHelper.Equals<Log4Net.EntityContracts.ILogIdentifier, Log4Net.EntityFrameworkContext.Log>(id, t);
            };

            return this.LinqContext.Log.SingleOrDefault<Log4Net.EntityFrameworkContext.Log>(m_Predicate);
        }

        #endregion

		#region Binary Columns



        #endregion Binary Columns



        #region Query Methods Of Entity of Common 

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// *internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>IQueryable&lt;...&gt; of Common</returns>
        internal IQueryable<Log4Net.DataSourceEntities.Log> _GetQueryOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
			var _ResultFromDataSource = 
				(
					from t in this.LinqContext.Log
					where
						(
							(
							(criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompare && (criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompareLowerBound == false || criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompareLowerBound && t.Date > criteriaOfDateOftOfCommonOfCommonOfCommon.LowerBound) && (criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompareUpperBound == false || criteriaOfDateOftOfCommonOfCommonOfCommon.IsToCompareUpperBound && t.Date <= criteriaOfDateOftOfCommonOfCommonOfCommon.UpperBound))
							 &&
							(criteriaOfThreadOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfThreadOftOfCommonOfCommonOfCommon.IsToCompare && t.Thread.Contains(criteriaOfThreadOftOfCommonOfCommonOfCommon.ValueToBeContained))
							 &&
							(criteriaOfLevelOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfLevelOftOfCommonOfCommonOfCommon.IsToCompare && t.Level.Contains(criteriaOfLevelOftOfCommonOfCommonOfCommon.ValueToBeContained))
							 &&
							(criteriaOfLoggerOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfLoggerOftOfCommonOfCommonOfCommon.IsToCompare && t.Logger.Contains(criteriaOfLoggerOftOfCommonOfCommonOfCommon.ValueToBeContained))
							 &&
							(criteriaOfMessageOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfMessageOftOfCommonOfCommonOfCommon.IsToCompare && t.Message.Contains(criteriaOfMessageOftOfCommonOfCommonOfCommon.ValueToBeContained))
							 &&
							(criteriaOfExceptionOftOfCommonOfCommonOfCommon.IsToCompare == false || criteriaOfExceptionOftOfCommonOfCommonOfCommon.IsToCompare && t.Exception.Contains(criteriaOfExceptionOftOfCommonOfCommonOfCommon.ValueToBeContained))
							)
						)
					select new Log4Net.DataSourceEntities.Log { Id = t.Id, Date = t.Date, Thread = t.Thread, Level = t.Level, Logger = t.Logger, Message = t.Message, Exception = t.Exception } into x
					select x
				);
			var _retval = _ResultFromDataSource.Distinct();
            IQueryable<Log4Net.DataSourceEntities.Log> _retval1;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _retval1 = _retval;
            }
            else
            {
                _retval1 = _retval.AsQueryable().OrderBy(queryOrderBySettingCollection.GetOrderByExpression());
            }
            return _retval1;
		}

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// *private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>true if any in database, otherwise false</returns>
        private bool _ExistsOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            int _Count = _GetCountOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);
            return _Count > 0;
        }

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>count of this query criteria</returns>
        private int _GetCountOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)

        {
            IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,queryOrderBySettingCollection
			);
            int _Count;
            if (currentIndex == -1 || pageSize == -1)
            {
                _Count = _Query.Count();
            }
            else
            {
                _Count = _Query.Skip(currentIndex).Take(pageSize).Count();
            }
			return _Count;
        }
		
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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfInteger();
            try
            {
                int _retval = _GetCountOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch(Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = 0;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean();
            try
            {
                bool _retval = _ExistsOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = false;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,-1
				,-1
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,queryOrderBySettingCollection
			);

                    Log4Net.DataSourceEntities.Log _retval = _Query.SingleOrDefault();

                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = _retval;
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfCommon(
			Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteriaOfDateOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfThreadOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLevelOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfLoggerOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfMessageOftOfCommonOfCommonOfCommon
			,Framework.EntityContracts.QuerySystemStringContainsCriteria criteriaOfExceptionOftOfCommonOfCommonOfCommon
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfCommon(
				criteriaOfDateOftOfCommonOfCommonOfCommon
				,criteriaOfThreadOftOfCommonOfCommonOfCommon
				,criteriaOfLevelOftOfCommonOfCommonOfCommon
				,criteriaOfLoggerOftOfCommonOfCommonOfCommon
				,criteriaOfMessageOftOfCommonOfCommonOfCommon
				,criteriaOfExceptionOftOfCommonOfCommonOfCommon
				,queryOrderBySettingCollection
			);

                    IEnumerable<Log4Net.DataSourceEntities.Log> _retval;
					
					if (currentIndex == -1 || pageSize == -1)
					{
						_retval = _Query;
					}
					else
					{
						_retval = _Query.Skip(currentIndex).Take(pageSize);
					}
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = new Log4Net.DataSourceEntities.LogCollection();
					_retMessage.Result.AddRange(_retval);
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }
        #endregion Query Methods Of Entity of Common 



        #region Query Methods Of Entity of All 

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// *internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>IQueryable&lt;...&gt; of Common</returns>
        internal IQueryable<Log4Net.DataSourceEntities.Log> _GetQueryOfEntityOfAll(
			Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
			var _ResultFromDataSource = 
				(
					from t in this.LinqContext.Log
					select new Log4Net.DataSourceEntities.Log { Id = t.Id, Date = t.Date, Thread = t.Thread, Level = t.Level, Logger = t.Logger, Message = t.Message, Exception = t.Exception } into x
					select x
				);
			var _retval = _ResultFromDataSource.Distinct();
            IQueryable<Log4Net.DataSourceEntities.Log> _retval1;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _retval1 = _retval;
            }
            else
            {
                _retval1 = _retval.AsQueryable().OrderBy(queryOrderBySettingCollection.GetOrderByExpression());
            }
            return _retval1;
		}

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// *private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>true if any in database, otherwise false</returns>
        private bool _ExistsOfEntityOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            int _Count = _GetCountOfEntityOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);
            return _Count > 0;
        }

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>count of this query criteria</returns>
        private int _GetCountOfEntityOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)

        {
            IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfAll(
				queryOrderBySettingCollection
			);
            int _Count;
            if (currentIndex == -1 || pageSize == -1)
            {
                _Count = _Query.Count();
            }
            else
            {
                _Count = _Query.Skip(currentIndex).Take(pageSize).Count();
            }
			return _Count;
        }
		
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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfInteger();
            try
            {
                int _retval = _GetCountOfEntityOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch(Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = 0;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean();
            try
            {
                bool _retval = _ExistsOfEntityOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = false;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfAll(
			Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfAll(
				-1
				,-1
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfAll(
				queryOrderBySettingCollection
			);

                    Log4Net.DataSourceEntities.Log _retval = _Query.SingleOrDefault();

                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = _retval;
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfAll(
				queryOrderBySettingCollection
			);

                    IEnumerable<Log4Net.DataSourceEntities.Log> _retval;
					
					if (currentIndex == -1 || pageSize == -1)
					{
						_retval = _Query;
					}
					else
					{
						_retval = _Query.Skip(currentIndex).Take(pageSize);
					}
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = new Log4Net.DataSourceEntities.LogCollection();
					_retMessage.Result.AddRange(_retval);
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }
        #endregion Query Methods Of Entity of All 



        #region Query Methods Of NameValuePair of All 

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// *internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>IQueryable&lt;...&gt; of Common</returns>
        internal IQueryable<Framework.NameValuePair> _GetQueryOfNameValuePairOfAll(
			Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
			var _ResultFromDataSource = 
				(
					from t in this.LinqContext.Log
					let _Value = t.Id.ToString()
					select new Framework.NameValuePair { Name = t.Thread, Value = _Value } into vD0
					select vD0
				);
			var _retval = _ResultFromDataSource;
            IQueryable<Framework.NameValuePair> _retval1;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _retval1 = _retval;
            }
            else
            {
                _retval1 = _retval.AsQueryable().OrderBy(queryOrderBySettingCollection.GetOrderByExpression());
            }
            return _retval1;
		}

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// *private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>true if any in database, otherwise false</returns>
        private bool _ExistsOfNameValuePairOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            int _Count = _GetCountOfNameValuePairOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);
            return _Count > 0;
        }

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>count of this query criteria</returns>
        private int _GetCountOfNameValuePairOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)

        {
            IQueryable<Framework.NameValuePair> _Query = _GetQueryOfNameValuePairOfAll(
				queryOrderBySettingCollection
			);
            int _Count;
            if (currentIndex == -1 || pageSize == -1)
            {
                _Count = _Query.Count();
            }
            else
            {
                _Count = _Query.Skip(currentIndex).Take(pageSize).Count();
            }
			return _Count;
        }
		
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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfNameValuePairOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfInteger();
            try
            {
                int _retval = _GetCountOfNameValuePairOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch(Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = 0;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfNameValuePairOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean();
            try
            {
                bool _retval = _ExistsOfNameValuePairOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = false;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntity GetSingleOfNameValuePairOfAll(
			Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntity _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntity();
            try
            {
                bool _Exists = _ExistsOfNameValuePairOfAll(
				-1
				,-1
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Framework.NameValuePair> _Query = _GetQueryOfNameValuePairOfAll(
				queryOrderBySettingCollection
			);

                    Framework.NameValuePair _retval = _Query.SingleOrDefault();

                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = _retval;
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntityCollection GetCollectionOfNameValuePairOfAll(
			int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntityCollection _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntityCollection();
            try
            {
                bool _Exists = _ExistsOfNameValuePairOfAll(
				currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Framework.NameValuePair> _Query = _GetQueryOfNameValuePairOfAll(
				queryOrderBySettingCollection
			);

                    IEnumerable<Framework.NameValuePair> _retval;
					
					if (currentIndex == -1 || pageSize == -1)
					{
						_retval = _Query;
					}
					else
					{
						_retval = _Query.Skip(currentIndex).Take(pageSize);
					}
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = new Framework.NameValueCollection();
					_retMessage.Result.AddRange(_retval);
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }
        #endregion Query Methods Of NameValuePair of All 



        #region Query Methods Of Entity of ByIdentifier 

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// *internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>IQueryable&lt;...&gt; of Common</returns>
        internal IQueryable<Log4Net.DataSourceEntities.Log> _GetQueryOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
			var _ResultFromDataSource = 
				(
					from t in this.LinqContext.Log
					where
						(
							(
							(criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.IsToCompare == false || criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.IsToCompare && t.Id == criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.ValueToCompare)
							)
						)
					select new Log4Net.DataSourceEntities.Log { Id = t.Id, Date = t.Date, Thread = t.Thread, Level = t.Level, Logger = t.Logger, Message = t.Message, Exception = t.Exception } into x
					select x
				);
			var _retval = _ResultFromDataSource.Distinct();
            IQueryable<Log4Net.DataSourceEntities.Log> _retval1;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _retval1 = _retval;
            }
            else
            {
                _retval1 = _retval.AsQueryable().OrderBy(queryOrderBySettingCollection.GetOrderByExpression());
            }
            return _retval1;
		}

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// *private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>true if any in database, otherwise false</returns>
        private bool _ExistsOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            int _Count = _GetCountOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);
            return _Count > 0;
        }

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>count of this query criteria</returns>
        private int _GetCountOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)

        {
            IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);
            int _Count;
            if (currentIndex == -1 || pageSize == -1)
            {
                _Count = _Query.Count();
            }
            else
            {
                _Count = _Query.Skip(currentIndex).Take(pageSize).Count();
            }
			return _Count;
        }
		
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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfInteger();
            try
            {
                int _retval = _GetCountOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch(Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = 0;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean();
            try
            {
                bool _retval = _ExistsOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = false;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog GetSingleOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,-1
				,-1
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);

                    Log4Net.DataSourceEntities.Log _retval = _Query.SingleOrDefault();

                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = _retval;
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog GetCollectionOfEntityOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _retMessage = new Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog();
            try
            {
                bool _Exists = _ExistsOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log> _Query = _GetQueryOfEntityOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);

                    IEnumerable<Log4Net.DataSourceEntities.Log> _retval;
					
					if (currentIndex == -1 || pageSize == -1)
					{
						_retval = _Query;
					}
					else
					{
						_retval = _Query.Skip(currentIndex).Take(pageSize);
					}
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = new Log4Net.DataSourceEntities.LogCollection();
					_retMessage.Result.AddRange(_retval);
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }
        #endregion Query Methods Of Entity of ByIdentifier 



        #region Query Methods Of KeyInformation of ByIdentifier 

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// *internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>IQueryable&lt;...&gt; of Common</returns>
        internal IQueryable<Log4Net.DataSourceEntities.Log.KeyInformation> _GetQueryOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
			var _ResultFromDataSource = 
				(
					from t in this.LinqContext.Log
					where
						(
							(
							(criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.IsToCompare == false || criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.IsToCompare && t.Id == criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier.ValueToCompare)
							)
						)
					select new Log4Net.DataSourceEntities.Log.KeyInformation { Id = t.Id } into vD1
					select vD1
				);
			var _retval = _ResultFromDataSource;
            IQueryable<Log4Net.DataSourceEntities.Log.KeyInformation> _retval1;
            if (queryOrderBySettingCollection == null || queryOrderBySettingCollection.Count == 0)
            {
                _retval1 = _retval;
            }
            else
            {
                _retval1 = _retval.AsQueryable().OrderBy(queryOrderBySettingCollection.GetOrderByExpression());
            }
            return _retval1;
		}

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// *private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>true if any in database, otherwise false</returns>
        private bool _ExistsOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            int _Count = _GetCountOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);
            return _Count > 0;
        }

        /// <summary>
        /// The return value of this set of query is: <see cref="ASPNETDB_CACHE.DataSourceEntities.AspNet_SqlCacheTablesForChangeNotification"/>
        /// The key query criteria of this set of query is: Common. 
        /// Common is a built-in set of query criteria, which will query all foreign keys, string/text value, and range of datatime
        /// There are 7 methods, 1 internal, 2 private and 4 public, for one set of return value and query criteria:
        /// internal _GetQueryOfEntityOf...(...) gives the Linq Query 
        /// private _ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// *private _GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public GetCountOfEntityOf...(...) returns count if there is any records meets Query Criteria, otherwise 0
        /// public ExistsOfEntityOf...(...) returns true if there is any records meets Query Criteria, otherwise false
        /// public GetSingleOfEntityOf...(...) returns the first record if there is any records meets Query Criteria, otherwise null
        /// public GetCollectionOfEntityOf...(...) returns all records if there is any records meets Query Criteria, otherwise null
        /// </summary>
        /// <param name="currentIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <param name="queryOrderBySettingCollection">query OrderBy setting</param>
        /// <returns>count of this query criteria</returns>
        private int _GetCountOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)

        {
            IQueryable<Log4Net.DataSourceEntities.Log.KeyInformation> _Query = _GetQueryOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);
            int _Count;
            if (currentIndex == -1 || pageSize == -1)
            {
                _Count = _Query.Count();
            }
            else
            {
                _Count = _Query.Skip(currentIndex).Take(pageSize).Count();
            }
			return _Count;
        }
		
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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfInteger GetCountOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfInteger();
            try
            {
                int _retval = _GetCountOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch(Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = 0;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean ExistsOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _retMessage = new Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean();
            try
            {
                bool _retval = _ExistsOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
					);
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                _retMessage.Result = _retval;
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = false;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation GetSingleOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation _retMessage = new Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation();
            try
            {
                bool _Exists = _ExistsOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,-1
				,-1
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log.KeyInformation> _Query = _GetQueryOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);

                    Log4Net.DataSourceEntities.Log.KeyInformation _retval = _Query.SingleOrDefault();

                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = _retval;
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }

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
        public Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection GetCollectionOfKeyInformationOfByIdentifier(
			Framework.EntityContracts.QuerySystemInt64EqualsCriteria criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
			,int currentIndex
			,int pageSize
			,Framework.EntityContracts.QueryOrderBySettingCollection queryOrderBySettingCollection
			)
        {
            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Started.ToString()));

            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection _retMessage = new Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection();
            try
            {
                bool _Exists = _ExistsOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,currentIndex
				,pageSize
				,queryOrderBySettingCollection
			);

                if (_Exists)
                {
                    IQueryable<Log4Net.DataSourceEntities.Log.KeyInformation> _Query = _GetQueryOfKeyInformationOfByIdentifier(
				criteriaOfIdOftOfByIdentifierOfByIdentifierOfByIdentifier
				,queryOrderBySettingCollection
			);

                    IEnumerable<Log4Net.DataSourceEntities.Log.KeyInformation> _retval;
					
					if (currentIndex == -1 || pageSize == -1)
					{
						_retval = _Query;
					}
					else
					{
						_retval = _Query.Skip(currentIndex).Take(pageSize);
					}
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Success;
                    _retMessage.Result = new Log4Net.DataSourceEntities.Log.KeyInformationCollection();
					_retMessage.Result.AddRange(_retval);
                }
                else
                {
                    _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.SuccessButNoResult;
                    _retMessage.Result = null;
                }
            }
            catch (Exception ex)
            {
                _retMessage.DataAccessLayerMessageStatus = Framework.DataSourceEntities.DataAccessLayerMessageStatus.Fail;
                _retMessage.Result = null;
                _retMessage.Message = ex.Message;
                log.Error(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Failed.ToString()), ex);
            }
            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Data_Access_Layer_Process_Ended.ToString()));
            return _retMessage;
        }
        #endregion Query Methods Of KeyInformation of ByIdentifier 







	}





	
}

