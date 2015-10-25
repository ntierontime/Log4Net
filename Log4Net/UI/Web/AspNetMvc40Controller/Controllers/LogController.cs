using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Log4Net.AspNetMvc40ViewModel;

namespace Log4Net.AspNetMvc40Controller
{
    /// <summary>
	/// Cascading Dropdown: http://stackoverflow.com/questions/5497524/easiest-way-to-create-a-cascade-dropdown-in-asp-net-mvc-3-with-c-sharp
	/// Cascading Dropdown: http://code.msdn.microsoft.com/Cascading-DropDownList-in-833683f9
	/// Mvc Paging http://mvcpaging.apphb.com/
    /// Mvc Controller of  <see cref="Log4Net.DataSourceEntities.Log"/>
    /// </summary>
    public partial class LogController : Controller
    {
		#region log4net

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion log4net

		#region Workspace Controller Methods : there are 1 workspace(s)


		
		public const string TempDataKey_WPCommonOfLog = "TempDataKey_WPCommonOfLog";
		public ActionResult WPCommonOfLog(int currentPage = 1 ,string lowerBoundDateCommonOftOfCommon = null, string upperBoundDateCommonOftOfCommon = null, WPCommonOfLogVM viewModel = null)
        {
            log.Info(string.Format("{0}: WPCommonOfLog", Framework.LoggingOptions.UI_Process_Started.ToString()));

            Framework.EntityContracts.ViewModelBase<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten> vmFromTempData;
            if (TempData.ContainsKey(TempDataKey_WPCommonOfLog))
            {
                vmFromTempData = (Framework.EntityContracts.ViewModelBase<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten>)TempData[TempDataKey_WPCommonOfLog];
            }
            else
            {
                vmFromTempData = null;
            }

            viewModel.PopulateAllUIElements(vmFromTempData, currentPage);

			viewModel.Criteria.LowerBoundDateCommonOftOfCommon = string.IsNullOrWhiteSpace(lowerBoundDateCommonOftOfCommon) ? DateTime.MinValue : Framework.DateTimePeriodHelper.ParseDateTime(lowerBoundDateCommonOftOfCommon); viewModel.Criteria.UpperBoundDateCommonOftOfCommon = string.IsNullOrWhiteSpace(upperBoundDateCommonOftOfCommon) ? DateTime.MinValue : Framework.DateTimePeriodHelper.ParseDateTime(upperBoundDateCommonOftOfCommon);
            //viewModel.Criteria.LowerBoundCreatedDateTimeCommonOftOfCommon = string.IsNullOrWhiteSpace(lowerBoundCreatedDateTimeCommonOftOfCommon) ? DateTime.MinValue : Framework.DateTimePeriodHelper.ParseDateTime(lowerBoundCreatedDateTimeCommonOftOfCommon); viewModel.Criteria.UpperBoundCreatedDateTimeCommonOftOfCommon = string.IsNullOrWhiteSpace(upperBoundCreatedDateTimeCommonOftOfCommon) ? DateTime.MinValue : Framework.DateTimePeriodHelper.ParseDateTime(upperBoundCreatedDateTimeCommonOftOfCommon);

            var searchResult = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfCommon(
                new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(viewModel.Criteria)
                , viewModel.QueryPagingSetting
                , viewModel.QueryOrderBySettingCollection);


            viewModel.StatusOfResult = searchResult.BusinessLogicLayerResponseStatus;

            if (viewModel.StatusOfResult == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
				viewModel.Result = searchResult.Message;

				if (searchResult.QueryPagingResult != null)
				{
					viewModel.QueryPagingSetting.CountOfRecords = searchResult.QueryPagingResult.CountOfRecords;
					viewModel.QueryPagingSetting.RecordCountOfCurrentPage = searchResult.QueryPagingResult.RecordCountOfCurrentPage;
				}

				TempData[TempDataKey_WPCommonOfLog] = viewModel.GetPrimaryInformationEntity();
				TempData.Keep(TempDataKey_WPCommonOfLog); 
			}
            else
            {
                viewModel.StatusMessageOfResult = searchResult.GetStatusMessage();
#if DEBUG
                viewModel.StatusMessageOfResult = string.Format("{0} {1}", viewModel.StatusMessageOfResult, searchResult.ServerErrorMessage);
#endif
            }

            return View(viewModel);
        }

        public ActionResult WPCommonOfLog_Export(Framework.DataServiceTypes dataServiceType)
        {
            log.Info(string.Format("{0}: WPCommonOfLog_Export", Framework.LoggingOptions.UI_Process_Started.ToString()));

            Framework.EntityContracts.ViewModelBase<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten> vmFromTempData;
            if (TempData.ContainsKey(TempDataKey_WPCommonOfLog))
            {
                vmFromTempData = (Framework.EntityContracts.ViewModelBase<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten>)TempData[TempDataKey_WPCommonOfLog];

	            var searchResult = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfCommon(
		            new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(vmFromTempData.Criteria)
                    , new Framework.EntityContracts.QueryPagingSetting(-1, -1)
                    , new Framework.EntityContracts.QueryOrderBySettingCollection(vmFromTempData.QueryOrderBySettingCollecionInString)
					, dataServiceType);

                var result = searchResult.DataStreamServiceResult;

				TempData[TempDataKey_WPCommonOfLog] = vmFromTempData.GetPrimaryInformationEntity();
				TempData.Keep(TempDataKey_WPCommonOfLog); 

                return File(result.Result, result.MIMEType, string.Format("WPCommonOfLog_Export{0}{1}", result.DataServiceType, result.FileExtension));
            }

            return null;
        }





		#endregion Workspace Controller Methods : there are 1 workspace(s)
		

        public ActionResult WPEntityRelatedOfLog(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM vm = new Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM(new Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier));
            vm.LoadData();

            return View(vm);
        }





		#region Import()

        public ActionResult Import(HttpPostedFileBase file)
        {
			ViewBag.FileFormat = "Id,Date,Thread,Level,Logger,Message,Exception";
            if (file != null && file.ContentLength > 0 && !string.IsNullOrWhiteSpace(file.FileName))
            {
                log.Info(string.Format("{0}: Import", Framework.LoggingOptions.UI_Process_Started.ToString()));

                Framework.DataStreamServiceResult dataStreamServiceResult = new Framework.DataStreamServiceResult(file.FileName, file.ContentType, file.ContentLength, file.InputStream);
                dataStreamServiceResult.TempFilePath = Framework.Web.WebFormApplicationApplicationVariables.FileStorageRootFolder;
                Log4Net.CommonBLL.DataStreamServiceProviderLog dataStreamServiceProvider = new Log4Net.CommonBLL.DataStreamServiceProviderLog();
                Log4Net.DataSourceEntities.LogCollection collection = dataStreamServiceProvider.GetCollectionFromStream(dataStreamServiceResult);

                if (collection != null)
                {
					Log4Net.DataSourceEntities.LogCollection resultCollection = collection;
                    var result = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.BatchInsert(resultCollection);
					ViewBag.Message = Framework.Resources.UIStringResource.Data_Import_Success;
                }
                else
                {
                    ViewBag.Message = Framework.Resources.UIStringResource.Data_Import_NoRecordInSourceFile;
                }

                log.Info(string.Format("{0}: Import", Framework.LoggingOptions.UI_Process_Ended.ToString()));

                return View();
            }
            else
            {
                ViewBag.Message = "";
                return View();
            }
        }

		#endregion Import()

		#region Index()

        public ActionResult Index()
        {
            return RedirectToAction("WPCommonOfLog");
        }

		#endregion Index()

		#region ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)

        //
        // GET: /Log4Net.DataSourceEntities.Log/Details/5

        public ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            ViewBag.Message = "this is details";

            log.Info(string.Format("{0}: Details", Framework.LoggingOptions.UI_Process_Started.ToString()));

            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response =
                Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);

            if (_Response.Message != null && _Response.Message.Count > 0)
            {
                log.Info(string.Format("{0}: Details", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return View(_Response.Message[0]);
            }
            else
            {
                log.Error(string.Format("{0}: Details", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return View();
            }
        }

		#endregion ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)

		#region ActionResult AddNew()

        //
        // GET: /Log4Net.DataSourceEntities.Log/Create
        public ActionResult AddNew()
        {
            ViewBag.Message = "to AddNew a new Log4Net.DataSourceEntities.Log";



            Log4Net.DataSourceEntities.Log entity;
            if (TempData.ContainsKey(TempDataKey_LogController_Copy) && TempData[TempDataKey_LogController_Copy] != null)
            {
				try
				{
					entity = (Log4Net.DataSourceEntities.Log)TempData[TempDataKey_LogController_Copy];
					TempData.Keep(TempDataKey_LogController_Copy);
				}
				catch
				{
	                entity = new Log4Net.DataSourceEntities.Log();
				}
            }
            else
            {
                entity = new Log4Net.DataSourceEntities.Log();
            }

            return View(entity);
        } 

        //
        // POST: /Log4Net.DataSourceEntities.Log/AddNew
        [HttpPost]
        public ActionResult AddNew(Log4Net.DataSourceEntities.Log input)
        {
            try
            {
                log.Info(string.Format("{0}: AddNew", Framework.LoggingOptions.UI_Process_Started.ToString()));

				Log4Net.DataSourceEntities.Log entity = input;

                var _Response = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.InsertEntity(entity);



				TempData[TempDataKey_LogController_Copy] = null;
                TempData.Remove(TempDataKey_LogController_Copy);
                log.Info(string.Format("{0}: Insert", Framework.LoggingOptions.UI_Process_Ended.ToString()));

                return RedirectToAction("Index");
            }
            catch
            {
                return View(new Log4Net.DataSourceEntities.Log());
            }
        }
        
        public const string TempDataKey_LogController_Copy = "TempDataKey_LogController_Copy";
        public ActionResult Copy(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response =
                Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);

            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                TempData[TempDataKey_LogController_Copy] = _Response.Message[0];
                TempData.Keep(TempDataKey_LogController_Copy);
            }

            return RedirectToAction("AddNew");
        } 

		#endregion ActionResult AddNew()

		#region ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)

        //
        // GET: /Log4Net.DataSourceEntities.Log/Edit/5
 
        public ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Started.ToString()));



            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response =
                Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);
            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return View(_Response.Message[0]);
            }
            else
            {
                log.Error(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return View(new Log4Net.DataSourceEntities.Log());
            }
        }

        //
        // POST: /Log4Net.DataSourceEntities.Log/Edit/5

        [HttpPost]
        public ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier, Log4Net.DataSourceEntities.Log input)
        {
            try
            {
                log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Started.ToString()));
				Log4Net.DataSourceEntities.Log entity = input;

                entity.Id = valueToCompareIdByIdentifierOftOfByIdentifier;


                var _Response = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.UpdateEntity(entity);



                log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Ended.ToString()));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new Log4Net.DataSourceEntities.Log());
            }
        }

		#endregion ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)

		#region ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)

        //
        // GET: /Log4Net.DataSourceEntities.Log/Delete/5

        public ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
        {

            log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Started.ToString()));
            Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response =
                Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);

            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Succeeded.ToString()));
                return View(_Response.Message[0]);
            }
            else
            {
                log.Error(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Failed.ToString()));
                return View(new Log4Net.DataSourceEntities.Log());
            } 
        }
		
        //
        // POST: /Log4Net.DataSourceEntities.Log/Delete/5
		[HttpPost]
        public ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier, FormCollection collection)
        {
            try
            {
                log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Started.ToString()));
				Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Response =
					Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(true, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);
				if (_Response != null && _Response.Message != null && _Response.Message.Count == 1)
				{
					Log4Net.DataSourceEntities.Log input = _Response.Message[0];
					Log4Net.DataSourceEntities.Log entity = input;
                    Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.DeleteEntity(entity);
					log.Info(string.Format("{0}: DeleteByIdentifier", Framework.LoggingOptions.UI_Process_Ended.ToString()));
                }
				else
				{
					log.Warn(string.Format("{0}: DeleteByIdentifier, Entity not exists", Framework.LoggingOptions.UI_Process_Ended.ToString()));
				}

                return RedirectToAction("Index");
            }
            catch
            {
                return View(new Log4Net.DataSourceEntities.Log());
            } 
        }

		#endregion ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier)
		
		#region Binary Columns



        #endregion Binary Columns

		#region GoBackList()

        public ActionResult GoBackList()
        {
            return RedirectToAction("Index");
        }

		#endregion GoBackList()
    }
}

