using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLL
{
    /// <summary>
    ///  inherit WcfService contract which will take advantage of .Net Wcf,
    ///  consume BusinessLogicLayerMemberShip
    ///  utilize LinqDataAccessLayer class 
    ///  provides Single/Batch Insert/Update/Delete
    ///  query methods based on BusinessLogicLayerRequestMessage, convert data access message to business logic layer response message
    ///  this BLL class targets at entity <see cref="Log4Net.Log"/>
    /// </summary>
    public class BusinessLogicLayerEntityLog
		: Log4Net.WcfContracts.ILogWcfService
    {
		#region logger of Log4Net

        /// <summary>
        /// logger of Log4Net
        /// </summary>
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion logger of Log4Net

		#region DALClassInstance && BusinessLogicLayerMemberShip

        /// <summary>
        /// Gets or sets the DAL class instance.
        /// </summary>
        /// <value>
        /// The DAL class instance.
        /// </value>
        Log4Net.DALContracts.DataAccessLayerEntityContractLog DALClassInstance { get; set; }

        /// <summary>
        /// Gets or sets the business logic layer member ship.
        /// </summary>
        /// <value>
        /// The business logic layer member ship.
        /// </value>
        public Framework.CommonBLLEntities.BusinessLogicLayerMemberShipContract BusinessLogicLayerMemberShip { get; set; }

		#endregion DALClassInstance && BusinessLogicLayerMemberShip

		#region constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerEntityLog"/> class.
        /// </summary>
        public BusinessLogicLayerEntityLog()
            : this(new Framework.CommonBLLEntities.BusinessLogicLayerMemberShip())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerEntityLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        public BusinessLogicLayerEntityLog(
			Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext)
            : this(businessLogicLayerContext.BusinessLogicLayerMemberShip)
        {
        }

		
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerEntityLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerMemberShip">The business logic layer member ship.</param>
        public BusinessLogicLayerEntityLog(
			Framework.CommonBLLEntities.BusinessLogicLayerMemberShipContract businessLogicLayerMemberShip)
        {
			Log4Net.DALContracts.DataAccessLayerFactoryContract _DataAccessLayerFactoryContract = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Log4Net.DALContracts.DataAccessLayerFactoryContract>();
            this.DALClassInstance = _DataAccessLayerFactoryContract.CreateDALInstanceOfLog();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerEntityLog"/> class.
        /// </summary>
        /// <param name="dalClassInstance">The dal class instance.</param>
        /// <param name="businessLogicLayerMemberShip">The business logic layer member ship.</param>
        public BusinessLogicLayerEntityLog(
            Log4Net.DALContracts.DataAccessLayerEntityContractLog dalClassInstance
            , Framework.CommonBLLEntities.BusinessLogicLayerMemberShipContract businessLogicLayerMemberShip)
        {
            this.DALClassInstance = dalClassInstance;
            this.BusinessLogicLayerMemberShip = businessLogicLayerMemberShip;
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
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
                _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                log.Info(string.Format("{0}: InsertEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Insert(request.Critieria[0]);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                log.Info(string.Format("{0}: InsertEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            return _retval;
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog UpdateEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                log.Info(string.Format("{0}: UpdateEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Update(request.Critieria[0]);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                log.Info(string.Format("{0}: UpdateEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            return _retval;
        }

        /// <summary>
        /// Deletes the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                log.Info(string.Format("{0}: DeleteEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Delete(request.Critieria[0]);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                log.Info(string.Format("{0}: DeleteEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            return _retval;
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog DeleteByIdentifierEntity(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog id)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = id.BusinessLogicLayerRequestID;

            if (id != null && id.Critieria != null)
            {
                log.Info(string.Format("{0}: DeleteByIdentifierEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.DeleteByIdentifier(id.Critieria);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                log.Info(string.Format("{0}: DeleteByIdentifierEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            return _retval;
        }

        /// <summary>
        /// Batches the insert.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchInsert(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            log.Info(string.Format("{0}: BatchInsert", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchInsert(request.Critieria);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            log.Info(string.Format("{0}: BatchInsert", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Batches the delete.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchDelete(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            log.Info(string.Format("{0}: BatchDelete", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchDelete(request.Critieria);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            log.Info(string.Format("{0}: BatchDelete", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Batches the update.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog BatchUpdate(Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog request)
        {
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchDelete(request.Critieria);

                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }		

        #endregion Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

		#region Binary Columns



        #endregion Binary Columns

		#region DataQueryPerQuerySettingCollection



        #region Query Methods Of Entity of Common 

        /// <summary>
        /// Gets the count of entity of Entity of Common .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfEntityOfCommon(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.DateCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ThreadCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LevelCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LoggerCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.MessageCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ExceptionCommonOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of Entity of Common .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfEntityOfCommon(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.DateCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ThreadCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LevelCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LoggerCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.MessageCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ExceptionCommonOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        /// <summary>
        /// Gets the collection of entity of Entity of Common .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
		public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfCommon(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.DateCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ThreadCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LevelCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LoggerCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.MessageCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ExceptionCommonOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

			//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of Common .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfCommon(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.DateCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ThreadCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LevelCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.LoggerCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.MessageCommonOft
				, request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogCommon.ExceptionCommonOft
				, request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        #endregion Query Methods Of Entity of Common 




        #region Query Methods Of Entity of All 

        /// <summary>
        /// Gets the count of entity of Entity of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfEntityOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of Entity of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfEntityOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        /// <summary>
        /// Gets the collection of entity of Entity of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
		public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

			//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfAll(
				request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        #endregion Query Methods Of Entity of All 




        #region Query Methods Of NameValuePair of All 

        /// <summary>
        /// Gets the count of entity of NameValuePair of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfNameValuePairOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of NameValuePair of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfNameValuePairOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        /// <summary>
        /// Gets the collection of entity of NameValuePair of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection if any</returns>
		public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetCollectionOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntityCollection _resultFromDAL = this.DALClassInstance.GetCollectionOfNameValuePairOfAll(
				request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection
				);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

			//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValueCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValueCollection>(_resultFromDAL, _retval);
            }
            else
            {
				//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValuePair, Framework.NameValueCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog.NameValuePair());
            }

            log.Info(string.Format("{0}: GetCollectionOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of NameValuePair of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection if any</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection GetSingleOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request)
        {
            log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfNameValuePairEntity _resultFromDAL = this.DALClassInstance.GetSingleOfNameValuePairOfAll(
				request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValuePair, Framework.NameValueCollection>(_resultFromDAL, _retval);
            }
            else
            {
				//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValuePair, Framework.NameValueCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog.NameValuePair());
            }

            log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        #endregion Query Methods Of NameValuePair of All 




        #region Query Methods Of Entity of ByIdentifier 

        /// <summary>
        /// Gets the count of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfEntityOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfEntityOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        /// <summary>
        /// Gets the collection of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
		public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetCollectionOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

			//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog if any</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog GetSingleOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog());
            }

            log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        #endregion Query Methods Of Entity of ByIdentifier 




        #region Query Methods Of KeyInformation of ByIdentifier 

        /// <summary>
        /// Gets the count of entity of KeyInformation of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfKeyInformationOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of KeyInformation of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfKeyInformationOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        /// <summary>
        /// Gets the collection of entity of KeyInformation of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation if any</returns>
		public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetCollectionOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection _resultFromDAL = this.DALClassInstance.GetCollectionOfKeyInformationOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryPagingSetting.CurrentIndex
				, request.QueryPagingSetting.PageSize
				, request.QueryOrderBySettingCollection
				);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

			//Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog.KeyInformation());
            }

            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of KeyInformation of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation if any</returns>
        public Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation GetSingleOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation _resultFromDAL = this.DALClassInstance.GetSingleOfKeyInformationOfByIdentifier(
				request.Critieria.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier.IdByIdentifierOft
				, request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _retval = new Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);
            }
            else
            {
				Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.DataStreamServiceProviderLog.KeyInformation());
            }

            log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
		}

        #endregion Query Methods Of KeyInformation of ByIdentifier 




		#endregion DataQueryPerQuerySettingCollection

		#region GetAscendantAndDescendant



		#endregion GetAscendantAndDescendant




	}
}