using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40ViewModel
{

    public partial class WPCommonOfLogVM : Log4Net.ViewModelData.WPCommonOfLogVM
    {
        public WPCommonOfLogVM ()
            : base()
        {
        }

        public Framework.Mvc.UISharedViewModel UISharedViewModel { get; set; }

        public override Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            return Log4Net.ViewModelData.OrderByLists.WPCommonOfLogVM_GetDefaultListOfQueryOrderBySettingCollecionInString();
        }

        public override void GetDefaultPerViewModel()
        {

            this.UISharedViewModel = Framework.Mvc.UISharedViewModel.GetUISharedViewModel(this.ListOfQueryOrderBySettingCollecionInString, this.QueryPagingSetting.PageSizeSelectionList, this.ListOfDataExport);
        }

        //public override void LoadData()
        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData(bool isToLoadDropDownlistContent)
        {
            if (isToLoadDropDownlistContent)
            {

            }

            var searchResult = Log4Net.CommonBLLIoC.IoCLog.GetMessageOfEntityOfCommon(
                this.Criteria
                , this.QueryPagingSetting
                , this.QueryOrderBySettingCollection);

            this.StatusOfResult = searchResult.BusinessLogicLayerResponseStatus;

            if (this.StatusOfResult == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                this.Result = searchResult.Message;

                if (searchResult.QueryPagingResult != null)
                {
                    this.QueryPagingSetting.CountOfRecords = searchResult.QueryPagingResult.CountOfRecords;
                    this.QueryPagingSetting.RecordCountOfCurrentPage = searchResult.QueryPagingResult.RecordCountOfCurrentPage;
                }
            }
            else
            {
                this.StatusMessageOfResult = searchResult.GetStatusMessage();
#if DEBUG
                this.StatusMessageOfResult = string.Format("{0} {1}", this.StatusMessageOfResult, searchResult.ServerErrorMessage);
#endif
            }
        }
    }

    public partial class WPEntityRelatedOfLogVM
        : Log4Net.ViewModelData.WPEntityRelatedOfLogVM
        //: Framework.ViewModels.ViewModelEntityRelatedBase<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier, Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus>
    {
        public WPEntityRelatedOfLogVM(Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier criteriaOfMasterEntity)
            : base(criteriaOfMasterEntity)
        {

        }

        public void LoadData(

            )
        {
            // 1. master on accessory part - Aside UIWorkspaceItemSetting
            var masterEntityResult = Log4Net.CommonBLLIoC.IoCLog.GetMessageOfEntityOfByIdentifier(this.CriteriaOfMasterEntity, this.QueryPagingSettingOneRecord, null);

            this.StatusOfMasterEntity = masterEntityResult.BusinessLogicLayerResponseStatus;

            if (masterEntityResult.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                this.MasterEntity = masterEntityResult.Message[0];

                // 2. accessory part - Aside UIWorkspaceItemSetting

                // 3. Major part - Article UIWorkspaceItemSetting - EntityReference/FK downtree

                // 4. Major part - Article UIWorkspaceItemSetting - EntityReference/FK CrossJoin

            }
            else
            {
                this.StatusMessageOfMasterEntity = masterEntityResult.GetStatusMessage();
#if DEBUG
                this.StatusMessageOfMasterEntity = string.Format("{0} {1}", this.StatusMessageOfMasterEntity, masterEntityResult.ServerErrorMessage);
#endif
            }
        }
    }

}

