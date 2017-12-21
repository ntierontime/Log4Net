using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Log4Net.AspNetMvc40ViewModel;
using Framework.EntityContracts;
using Framework.Mvc;
using UrlStringsAlias = Log4Net.AspNetMvc40Rasor.Helpers.UrlStrings;

namespace Log4Net.AspNetMvc40Rasor.Controllers
{
    /// <summary>
    /// Mvc Controller of  <see cref="Log4Net.DataSourceEntities.Log"/>
    /// </summary>
    public partial class LogController : Controller
    {
        #region log4net

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion log4net

        #region Workspace Controller Methods : there are 1 workspace(s)

        public const string TempDataKey_WPCommonOfLog = "TempDataKey_WPCommonOfLog";
        /// <summary>
        /// Controller Method of View WPCommonOfLog : Description Of Common of Log4Net.Log
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_WPCommonOfLog)]
        public ActionResult WPCommonOfLog(int currentPage = 1, WPCommonOfLogVM viewModel = null)
        {
            log.Info(string.Format("{0}: WPCommonOfLog", Framework.LoggingOptions.UI_Process_Started.ToString()));

            Framework.ViewModels.ViewModelBase<Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommon> vmFromTempData;
            if (TempData.ContainsKey(TempDataKey_WPCommonOfLog))
            {
                vmFromTempData = (Framework.ViewModels.ViewModelBase<Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommon>)TempData[TempDataKey_WPCommonOfLog];
            }
            else
            {
                vmFromTempData = null;
            }

            viewModel.PopulateAllUIElements(vmFromTempData, currentPage);

            viewModel.LoadData(true);

            if (viewModel.StatusOfResult == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                TempData[TempDataKey_WPCommonOfLog] = viewModel.GetPrimaryInformationEntity();
                TempData.Keep(TempDataKey_WPCommonOfLog);
            }
//            else
//            {
//                viewModel.StatusMessageOfResult = searchResult.GetStatusMessage();
//#if DEBUG
//                viewModel.StatusMessageOfResult = string.Format("{0} {1}", viewModel.StatusMessageOfResult, searchResult.ServerErrorMessage);
//#endif
//            }

            if (viewModel.Result != null)
            {
                ViewBag.StaticPagedResult = new PagedList.StaticPagedList<Log4Net.DataSourceEntities.Log>(viewModel.Result, viewModel.QueryPagingSetting.CurrentPage, viewModel.QueryPagingSetting.PageSize, viewModel.QueryPagingSetting.CountOfRecords);
            }

            viewModel.ContentData.Title = Log4Net.Resx.UIStringResourcePerEntityLog.Log;
            viewModel.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Description;

            return View(viewModel);
        }

        /// <summary>
        /// Export current search result.
        /// </summary>
        /// <param name="dataServiceType">Type of the data service.</param>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_WPCommonOfLog)]
        public ActionResult WPCommonOfLog_Export(Framework.DataServiceTypes dataServiceType)
        {
            log.Info(string.Format("{0}: WPCommonOfLog_Export", Framework.LoggingOptions.UI_Process_Started.ToString()));

            Framework.ViewModels.ViewModelBase<Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommon> vmFromTempData;
            if (TempData.ContainsKey(TempDataKey_WPCommonOfLog))
            {
                vmFromTempData = (Framework.ViewModels.ViewModelBase<Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommon>)TempData[TempDataKey_WPCommonOfLog];

                var searchResult = Log4Net.CommonBLLIoC.IoCLog.GetMessageOfEntityOfCommon(
                    vmFromTempData.Criteria
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

        /// <summary>
        /// Display one entity and all related entities if any, either single item or a list, based on foreign keys
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_WPEntityRelatedOfLog)]
        public ActionResult WPEntityRelatedOfLog(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM vm = new Log4Net.AspNetMvc40ViewModel.WPEntityRelatedOfLogVM(new Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier));
            vm.LoadData();

            return View(vm);
        }

        #region Import()

        /// <summary>
        /// Imports a list of entity from csv or excel file
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Import)]
        public ActionResult Import(HttpPostedFileBase file)
        {
            ViewBag.FileFormat = "Id,Date,Thread,Level,Logger,Message,Exception";
            if (file != null && file.ContentLength > 0 && !string.IsNullOrWhiteSpace(file.FileName))
            {
                log.Info(string.Format("{0}: Import", Framework.LoggingOptions.UI_Process_Started.ToString()));

                Framework.DataStreamServiceResult dataStreamServiceResult = new Framework.DataStreamServiceResult(file.FileName, file.ContentType, file.ContentLength, file.InputStream);
                dataStreamServiceResult.TempFilePath = Framework.Web.WebFormApplicationApplicationVariables.FileStorageRootFolder;
                Log4Net.CommonBLL.LogDataStreamService dataStreamServiceProvider = new Log4Net.CommonBLL.LogDataStreamService();
                Log4Net.DataSourceEntities.LogCollection collection = dataStreamServiceProvider.GetCollectionFromStream(dataStreamServiceResult);

                if (collection != null)
                {
                    Log4Net.DataSourceEntities.LogCollection resultCollection = collection;
                    var result = Log4Net.CommonBLLIoC.IoCLog.BatchInsert(resultCollection);
                    ViewBag.Message = Framework.Resx.UIStringResource.Data_Import_Success;
                }
                else
                {
                    ViewBag.Message = Framework.Resx.UIStringResource.Data_Import_NoRecordInSourceFile;
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

        /// <summary>
        /// default page, redirect to "WPCommonLog".
        /// </summary>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Index)]
        public ActionResult Index()
        {
            return RedirectToAction("WPCommonOfLog");
        }

        #endregion Index()

        #region ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        /// <summary>
        /// GET method of details page, based on identifier or unique constraint, this entity only, no related entities.
        /// GET: /Log/Details/5
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Details)]
        public ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Framework.UIAction uiAction = Framework.UIAction.ViewDetails;
            Log4Net.AspNetMvc40ViewModel.LogItemVM vm = new Log4Net.AspNetMvc40ViewModel.LogItemVM();
            vm.Load(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier, uiAction);
            vm.ContentData.Title = Framework.Resx.UIStringResource.Details;
            vm.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Details_Log;

            return View(vm);
        }

        #endregion ActionResult Details(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        #region ActionResult AddNew()

        /// <summary>
        /// GET method of Adds the new <see cref="Log4Net.Log"/>.
        /// GET: /Log/AddNew
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_AddNew)]
        public ActionResult AddNew()
        {
            var entity = CreateEmptyEntityOrGetFromTempData(TempDataKey_LogController_Copy);

            Framework.UIAction uiAction = Framework.UIAction.Create;
            Log4Net.AspNetMvc40ViewModel.LogItemVM vm = Log4Net.AspNetMvc40ViewModel.LogItemVM.CreateNewViewModel(entity);
            vm.LoadExtraData(uiAction);

            return View(vm);
        }

        /// <summary>
        /// Post method of Adds the new <see cref="Log4Net.Log"/>.
        /// POST: /Log/AddNew
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_AddNew)]
        public ActionResult AddNew(Log4Net.AspNetMvc40ViewModel.LogItemVM vm)
        {
            try
            {
                log.Info(string.Format("{0}: AddNew", Framework.LoggingOptions.UI_Process_Started.ToString()));

                Log4Net.DataSourceEntities.Log entity = vm.Item;

                var _Response = Log4Net.CommonBLLIoC.IoCLog.InsertEntity(entity);

                TempData[TempDataKey_LogController_Copy] = null;
                TempData.Remove(TempDataKey_LogController_Copy);
                log.Info(string.Format("{0}: Insert", Framework.LoggingOptions.UI_Process_Ended.ToString()));

                return RedirectToAction(UrlStringsAlias.ActionName_Log_Index);
            }
            catch(Exception ex)
            {
                Framework.UIAction uiAction = Framework.UIAction.Create;
                var entity = CreateEmptyEntityOrGetFromTempData(TempDataKey_LogController_Copy);
                vm = Log4Net.AspNetMvc40ViewModel.LogItemVM.CreateNewViewModel(entity);
                vm.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                vm.StatusMessageOfResult = ex.Message;
                vm.UIActionStatusMessage = new Framework.UIActionStatusMessage(typeof(Log4Net.AspNetMvc40ViewModel.LogItemVM).FullName, uiAction.ToString(), uiAction, Framework.UIActionStatus.Failed);
                log.Error(string.Format("{0}: AddNew: {1}", Framework.LoggingOptions.Business_Logic_Layer_Process_Failed.ToString(), ex.Message));
                return View(vm);
            }
        }

        public const string TempDataKey_LogController_Copy = "TempDataKey_LogController_Copy";
        /// <summary>
        /// Copies current <see cref="Log4Net.Log"/>, without identifier
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Copy)]
        public ActionResult Copy(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Log4Net.CommonBLLEntities.LogResponseMessageBuiltIn _Response =
                Log4Net.CommonBLLIoC.IoCLog.GetMessageOfEntityOfByIdentifier(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);

            if (_Response.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                TempData[TempDataKey_LogController_Copy] = _Response.Message[0];
                TempData.Keep(TempDataKey_LogController_Copy);
            }

            return RedirectToAction("AddNew");
        }

        #endregion ActionResult AddNew()

        #region ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        /// <summary>
        /// GET method of editing page of <see cref="Log4Net.Log"/>.
        /// GET: /Log/Edit/5
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Edit)]
        public ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Framework.UIAction uiAction = Framework.UIAction.Update;
            Log4Net.AspNetMvc40ViewModel.LogItemVM vm = new Log4Net.AspNetMvc40ViewModel.LogItemVM();
            vm.Load(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier, uiAction);
            vm.ContentData.Title = Framework.Resx.UIStringResource.Edit;
            vm.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Edit_Log;

            return View(vm);
        }

        /// <summary>
        /// POST method of editing page of <see cref="Log4Net.Log"/>.
        /// POST: /Log/Edit/5
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Edit)]
        public ActionResult Edit(Log4Net.AspNetMvc40ViewModel.LogItemVM vm)
        {
            try
            {
                log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Started.ToString()));

                Log4Net.DataSourceEntities.Log entity = vm.Item;
                var _Response = Log4Net.CommonBLLIoC.IoCLog.UpdateEntity(entity);

                log.Info(string.Format("{0}: Edit", Framework.LoggingOptions.UI_Process_Ended.ToString()));
                return RedirectToAction(UrlStringsAlias.ActionName_Log_Index);
            }
            catch(Exception ex)
            {
                Framework.UIAction uiAction = Framework.UIAction.Update;
                vm.ContentData.Title = Framework.Resx.UIStringResource.Edit;
                vm.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Edit_Log;
                vm.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                vm.StatusMessageOfResult = ex.Message;
                vm.UIActionStatusMessage = new Framework.UIActionStatusMessage(typeof(Log4Net.AspNetMvc40ViewModel.LogItemVM).FullName, uiAction.ToString(), uiAction, Framework.UIActionStatus.Failed);
                log.Error(string.Format("{0}: {1}, {2}, {3}", uiAction, Framework.LoggingOptions.UI_Process_Failed.ToString(), vm.StatusOfResult, vm.StatusMessageOfResult));

                return View(vm);
            }
        }

        #endregion ActionResult Edit(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        #region ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        /// <summary>
        /// GET method of delete page of <see cref="Log4Net.Log"/>
        /// GET: /Log/Delete/5
        /// </summary>
        /// <returns></returns>
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Delete)]
        public ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)
        {
            Framework.UIAction uiAction = Framework.UIAction.Delete;
            Log4Net.AspNetMvc40ViewModel.LogItemVM vm = new Log4Net.AspNetMvc40ViewModel.LogItemVM();
            vm.Load(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier, uiAction);
            vm.ContentData.Title = Framework.Resx.UIStringResource.Delete;
            vm.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Delete_Log;
            return View(vm);
        }

        /// <summary>
        /// POST method of delete page of <see cref="Log4Net.Log"/>
        /// POST: /Log/Delete/5
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Log4Net.AspNetMvc40Rasor.Helpers.WebAuthorizationAttribute(Permissions = Log4Net.AspNetMvc40Rasor.Helpers.PermissionVariables.PermissionName_Log_Delete)]
        public ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier, Log4Net.AspNetMvc40ViewModel.LogItemVM vm, FormCollection collection)
        {
            try
            {
                log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Started.ToString()));
                var _Response = Log4Net.CommonBLLIoC.IoCLog.ExistsOfEntityOfByIdentifier(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier, -1, -1, null);
                if (_Response)
                {
                    Log4Net.DataSourceEntities.Log entity = vm.Item;
                    Log4Net.CommonBLLIoC.IoCLog.DeleteEntity(entity);
                    log.Info(string.Format("{0}: Delete", Framework.LoggingOptions.UI_Process_Ended.ToString()));
                }
                else
                {
                    log.Warn(string.Format("{0}: Delete, Entity not exists",  Framework.LoggingOptions.UI_Process_Ended.ToString()));
                }

                return RedirectToAction("UrlStringsAlias.ActionName_Log_Index");
            }
            catch (Exception ex)
            {
                Framework.UIAction uiAction = Framework.UIAction.Delete;
                vm.ContentData.Title = Framework.Resx.UIStringResource.Delete;
                vm.ContentData.Summary = Log4Net.Resx.UIStringResourcePerEntityLog.Delete_Log;
                vm.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                vm.StatusMessageOfResult = ex.Message;
                vm.UIActionStatusMessage = new Framework.UIActionStatusMessage(typeof(Log4Net.AspNetMvc40ViewModel.LogItemVM).FullName, uiAction.ToString(), uiAction, Framework.UIActionStatus.Failed);
                log.Error(string.Format("{0}: {1}, {2}, {3}", uiAction, Framework.LoggingOptions.UI_Process_Failed.ToString(), vm.StatusOfResult, vm.StatusMessageOfResult));

                return View(vm);
            }
        }

        #endregion ActionResult Delete(bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier)

        #region Binary Columns

        #endregion Binary Columns

        #region GoBackList()

        public ActionResult GoBackList()
        {
            return RedirectToAction(UrlStringsAlias.ActionName_Log_Index);
        }

        #endregion GoBackList()

        private Log4Net.DataSourceEntities.Log CreateEmptyEntityOrGetFromTempData(string tempDataKey_LogController_Copy)
        {
            Log4Net.DataSourceEntities.Log entity;
            if (TempData.ContainsKey(tempDataKey_LogController_Copy) && TempData[tempDataKey_LogController_Copy] != null)
            {
                try
                {
                    entity = (Log4Net.DataSourceEntities.Log)TempData[tempDataKey_LogController_Copy];
                    TempData.Keep(tempDataKey_LogController_Copy);
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

            return entity;
        }
    }
}

