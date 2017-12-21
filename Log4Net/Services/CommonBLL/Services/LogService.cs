using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLL
{
    /// <summary>
    ///  inherit WcfService contract which will take advantage of .Net Wcf,
    ///  consume BusinessLogicLayerMemberShip -- should be removed
    ///  provides Single/Batch Insert/Update/Delete
    ///  query methods based on BusinessLogicLayerRequestMessage, convert data access message to business logic layer response message
    ///  this BLL class targets at entity <see cref="Log4Net.Log"/>
    /// </summary>
    public partial class LogService
        : Log4Net.WcfContracts.ILogService
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
        Log4Net.DALContracts.ILogRepository DALClassInstance { get; set; }

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
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        public LogService()
            : this(new Framework.CommonBLLEntities.BusinessLogicLayerMemberShip())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="businessLogicLayerContext">The business logic layer context.</param>
        public LogService(
            Framework.CommonBLLEntities.BusinessLogicLayerContext businessLogicLayerContext)
            : this(businessLogicLayerContext.BusinessLogicLayerMemberShip)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="businessLogicLayerMemberShip">The business logic layer member ship.</param>
        public LogService(
            Framework.CommonBLLEntities.BusinessLogicLayerMemberShipContract businessLogicLayerMemberShip)
        {
            Log4Net.DALContracts.DataAccessLayerFactoryContract _DataAccessLayerFactoryContract = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Log4Net.DALContracts.DataAccessLayerFactoryContract>();
            this.DALClassInstance = _DataAccessLayerFactoryContract.CreateDALInstanceOfLog();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="dalClassInstance">The dal class instance.</param>
        /// <param name="businessLogicLayerMemberShip">The business logic layer member ship.</param>
        public LogService(
            Log4Net.DALContracts.ILogRepository dalClassInstance
            , Framework.CommonBLLEntities.BusinessLogicLayerMemberShipContract businessLogicLayerMemberShip)
        {
            this.DALClassInstance = dalClassInstance;
            this.BusinessLogicLayerMemberShip = businessLogicLayerMemberShip;
        }

        #endregion constructors

        #region InsertEntity/UpdateEntity/DeleteEntity/BatchInsert/BatchUpdate/BatchDelete Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

        /// <summary>
        /// Inserts the specified input.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>a message with action result</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn InsertEntity(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
                _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                try
                {
                    log.Info(string.Format("{0}: InsertEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Insert(request.Critieria[0]);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                    log.Info(string.Format("{0}: InsertEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn UpdateEntity(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                try
                {
                    log.Info(string.Format("{0}: UpdateEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Update(request.Critieria[0]);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                    log.Info(string.Format("{0}: UpdateEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn DeleteEntity(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null && request.Critieria.Count == 1)
            {
                try
                {
                    log.Info(string.Format("{0}: DeleteEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.Delete(request.Critieria[0]);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                    log.Info(string.Format("{0}: DeleteEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn DeleteByIdentifierEntity(Log4Net.CommonBLLEntities.LogRequestMessageBuiltInOfIdentifier id)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = id.BusinessLogicLayerRequestID;

            if (id != null && id.Critieria != null)
            {
                try
                {
                    log.Info(string.Format("{0}: DeleteByIdentifierEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.DeleteByIdentifier(id.Critieria);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                    log.Info(string.Format("{0}: DeleteByIdentifierEntity", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn BatchInsert(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            log.Info(string.Format("{0}: BatchInsert", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                try
                {
                    log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchInsert(request.Critieria);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                    log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn BatchDelete(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            log.Info(string.Format("{0}: BatchDelete", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                try
                {
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchDelete(request.Critieria);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
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
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn BatchUpdate(Log4Net.CommonBLLEntities.LogRequestMessageBuiltIn request)
        {
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request != null)
            {
                try
                {
                    Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.BatchDelete(request.Critieria);

                    Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
                }
                catch(Exception ex)
                {
                    _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    _retval.ServerErrorMessage = ex.Message;
                }
            }
            else
            {
                _retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.RequestError;
            }
            log.Info(string.Format("{0}: BatchUpdate", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        #endregion InsertEntity/UpdateEntity/DeleteEntity/BatchInsert/BatchUpdate/BatchDelete Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfCommon request)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfEntityOfCommon(
                request.Critieria.LogQueryCriteriaCommon.DateCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ThreadCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LevelCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LoggerCommonOft
                , request.Critieria.LogQueryCriteriaCommon.MessageCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ExceptionCommonOft
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfCommon request)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfEntityOfCommon(
                request.Critieria.LogQueryCriteriaCommon.DateCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ThreadCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LevelCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LoggerCommonOft
                , request.Critieria.LogQueryCriteriaCommon.MessageCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ExceptionCommonOft
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
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetCollectionOfEntityOfCommon(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfCommon request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfCommon(
                request.Critieria.LogQueryCriteriaCommon.DateCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ThreadCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LevelCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LoggerCommonOft
                , request.Critieria.LogQueryCriteriaCommon.MessageCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ExceptionCommonOft
                , request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection
                );
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of Common .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetSingleOfEntityOfCommon(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfCommon request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfCommon", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfCommon(
                request.Critieria.LogQueryCriteriaCommon.DateCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ThreadCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LevelCommonOft
                , request.Critieria.LogQueryCriteriaCommon.LoggerCommonOft
                , request.Critieria.LogQueryCriteriaCommon.MessageCommonOft
                , request.Critieria.LogQueryCriteriaCommon.ExceptionCommonOft
                , request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetCollectionOfEntityOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfAll(
                request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection
                );
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetSingleOfEntityOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfAll(
                request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
                //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValuePair, Framework.NameValueCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.NameValuePair());
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
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
                //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.NameValuePair, Framework.NameValueCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.NameValuePair());
            }

            log.Info(string.Format("{0}: GetSingleOfNameValuePairOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        #endregion Query Methods Of NameValuePair of All

        #region Query Methods Of RssItem of All

        /// <summary>
        /// Gets the count of entity of RssItem of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfRssItemOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: GetCountOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfRssItemOfAll(
                request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<int>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: GetCountOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Exists the of entity of RssItem of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns> Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean ExistsOfRssItemOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: ExistsOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfRssItemOfAll(
                request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean();

            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<bool>(_resultFromDAL, _retval);
            log.Info(string.Format("{0}: ExistsOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of RssItem of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection if any</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection GetCollectionOfRssItemOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: GetCollectionOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfRssItemCollection _resultFromDAL = this.DALClassInstance.GetCollectionOfRssItemOfAll(
                request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection
                );
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.RssItemCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.RssItemCollection>(_resultFromDAL, _retval);
            }
            else
            {
                //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.RssItem, Framework.RssItemCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.RssItem());
            }

            log.Info(string.Format("{0}: GetCollectionOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of RssItem of All .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection if any</returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection GetSingleOfRssItemOfAll(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll request)
        {
            log.Info(string.Format("{0}: GetSingleOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageRssItem _resultFromDAL = this.DALClassInstance.GetSingleOfRssItemOfAll(
                request.QueryOrderBySettingCollection);
            Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection _retval = new Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageRssItemCollection();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.RssItem, Framework.RssItemCollection>(_resultFromDAL, _retval);
            }
            else
            {
                //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Framework.RssItem, Framework.RssItemCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.RssItem());
            }

            log.Info(string.Format("{0}: GetSingleOfRssItemOfAll", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        #endregion Query Methods Of RssItem of All

        #region Query Methods Of Entity of ByIdentifier

        /// <summary>
        /// Gets the count of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of integer wrapper: <see cref="Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger"/></returns>
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger GetCountOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCountOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfEntityOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: ExistsOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfEntityOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
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
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetCollectionOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityCollectionLog _resultFromDAL = this.DALClassInstance.GetCollectionOfEntityOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
                , request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection
                );
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
            }

            log.Info(string.Format("{0}: GetCollectionOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of Entity of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn GetSingleOfEntityOfByIdentifier(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetSingleOfEntityOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.DataAccessLayerMessageOfEntityLog _resultFromDAL = this.DALClassInstance.GetSingleOfEntityOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
                , request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.LogCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService());
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCountOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfInteger _resultFromDAL = this.DALClassInstance.GetCountOfKeyInformationOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
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
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: ExistsOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Framework.DataSourceEntities.DataAccessLayerMessageOfBoolean _resultFromDAL = this.DALClassInstance.ExistsOfKeyInformationOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
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
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation GetCollectionOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformationCollection _resultFromDAL = this.DALClassInstance.GetCollectionOfKeyInformationOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
                , request.QueryPagingSetting.CurrentIndex
                , request.QueryPagingSetting.PageSize
                , request.QueryOrderBySettingCollection
                );
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            //Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.KeyInformation());
            }

            log.Info(string.Format("{0}: GetCollectionOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Ended.ToString()));
            return _retval;
        }

        /// <summary>
        /// Gets the collection of entity of KeyInformation of ByIdentifier .
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>an instance of Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation if any</returns>
        public Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation GetSingleOfKeyInformationOfByIdentifier(
            Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfByIdentifier request)
        {
            log.Info(string.Format("{0}: GetSingleOfKeyInformationOfByIdentifier", Framework.LoggingOptions.Business_Logic_Layer_Process_Started.ToString()));
            Log4Net.DataSourceEntities.Log.DataAccessLayerMessageOfKeyInformation _resultFromDAL = this.DALClassInstance.GetSingleOfKeyInformationOfByIdentifier(
                request.Critieria.LogQueryCriteriaByIdentifier.IdByIdentifierOft
                , request.QueryOrderBySettingCollection);
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation _retval = new Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn.KeyInformation();
            _retval.BusinessLogicLayerRequestID = request.BusinessLogicLayerRequestID;

            if (request.DataServiceType == Framework.DataServiceTypes.DataSourceResult)
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval);
            }
            else
            {
                Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBaseHelper.MapDataAccessLayerMessageToBusinessLogicLayerResponseMessage<Log4Net.DataSourceEntities.Log.KeyInformation, Log4Net.DataSourceEntities.Log.KeyInformationCollection>(_resultFromDAL, _retval, request.DataServiceType, new Log4Net.CommonBLL.LogDataStreamService.KeyInformation());
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

