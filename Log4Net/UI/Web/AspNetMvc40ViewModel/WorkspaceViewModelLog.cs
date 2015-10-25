using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40ViewModel
{

    public class WPCommonOfLogVM : Framework.Mvc.ViewModelBaseWithResultAndUIElement<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten, Log4Net.DataSourceEntities.LogCollection>
    {
        public WPCommonOfLogVM ()
            : base()
        {
        }

        public override Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            Framework.NameValueCollection list = new Framework.NameValueCollection();
            list.Add("Thread~ASC", "Thread A-Z");
				list.Add("Thread~DESC", "Thread Z-A");
            return list;
        }

        public override void GetDefaultPerViewModel()
        {

        }
    }




    public class WPEntityRelatedOfLogVM 
		: Framework.Mvc.ViewModelEntityRelatedBase<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier, Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus>
    {
        public WPEntityRelatedOfLogVM(Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier criteriaOfMasterEntity)
            : base(criteriaOfMasterEntity)
        {

        }



        public void LoadData()
        {
            // 1. master on accessory part - Aside UIWorkspaceItemSetting
			var masterEntityResult = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetMessageOfEntityOfByIdentifier(this.CriteriaOfMasterEntity, this.QueryPagingSettingOneRecord, null);

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

