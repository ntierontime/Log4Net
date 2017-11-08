using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Framework.Mvc
{
    /// <summary>
    ///
    /// </summary>
    public class UISharedViewModel
    {
        public List<SelectListItem> SelectListOfPageSize { get; set; }
        public List<SelectListItem> SelectListOfQueryOrderBySettingCollecionInString { get; set; }
        public List<SelectListItem> SelectListOfDataExport { get; set; }
        public List<SelectListItem> PreDefinedDateTimeRangeList { get; private set; }
        public List<SelectListItem> PredefinedBooleanSelectionList { get; private set; }

        public static Framework.Mvc.UISharedViewModel GetUISharedViewModel(
            IList<Framework.NameValuePair> listOfQueryOrderBySettingCollecionInString
            , IList<Framework.NameValuePair> pageSizeSelectionList
            , IList<Framework.NameValuePair> listOfDataExport)
        {
            Framework.Mvc.UISharedViewModel retval = new Framework.Mvc.UISharedViewModel();
            retval.SelectListOfQueryOrderBySettingCollecionInString = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(listOfQueryOrderBySettingCollecionInString);
            retval.SelectListOfPageSize = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(pageSizeSelectionList);
            retval.SelectListOfDataExport = Framework.Mvc.MvcHelper.BuildListOfSelectListItem(listOfDataExport);

            retval.PreDefinedDateTimeRangeList = new List<SelectListItem>();
            var preDefinedDateTimeRangeList = Framework.EntityContracts.QuerySystemDateTimeRangeCriteria.GetList(null);
            foreach (var item in preDefinedDateTimeRangeList)
            {
                retval.PreDefinedDateTimeRangeList.Add(new SelectListItem { Text = item.Name, Value = item.Value });
            }

            retval.PredefinedBooleanSelectionList = new List<SelectListItem>();
            var predefinedBooleanSelectedValueList = Framework.EntityContracts.QuerySystemBooleanEqualsCriteria.GetList(null);
            foreach (var item in predefinedBooleanSelectedValueList)
            {
                retval.PredefinedBooleanSelectionList.Add(new SelectListItem { Text = item.Name, Value = item.Value });
            }
            return retval;
        }
    }
}

