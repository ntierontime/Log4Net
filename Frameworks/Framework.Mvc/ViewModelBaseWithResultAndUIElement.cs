using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Framework.Mvc
{
    public abstract class ViewModelBaseWithResultAndUIElement<TSearchCriteria, TSearchResult>
        : Framework.EntityContracts.ViewModelBase<TSearchCriteria>
        where TSearchCriteria : class, new()
        where TSearchResult : class, new()
    {
        public ViewModelBaseWithResultAndUIElement()
            : base()
        {
        }

        //public Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection { get; set; }
        public List<SelectListItem> SelectListOfPageSize { get; set; }
        public List<SelectListItem> SelectListOfQueryOrderBySettingCollecionInString { get; set; }
        public List<SelectListItem> SelectListOfDataExport { get; set; }
        public TSearchResult Result { get; set; }
		public Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus StatusOfResult { get; set; }
        public string StatusMessageOfResult { get; set; }

        public override void PopulateAllUIElements(Framework.EntityContracts.IViewModelBase<TSearchCriteria> vmFromTempData, int currentPage)
        {
			base.PopulateAllUIElements(vmFromTempData, currentPage);
            this.SelectListOfQueryOrderBySettingCollecionInString = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(this.ListOfQueryOrderBySettingCollecionInString);
            this.SelectListOfPageSize = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(this.QueryPagingSetting.PageSizeSelectionList);
            this.SelectListOfDataExport = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(this.ListOfDataExport);
        }
    }
}