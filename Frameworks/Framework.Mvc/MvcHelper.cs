using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Framework.Mvc
{
    public static class MvcHelper
    {
	    public static List<SelectListItem> BuildListOfSelectListItem(IList<Framework.NameValuePair> input)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            if (input != null)
            {
                foreach (Framework.NameValuePair nvp in input)
                {
                    selectList.Add(new SelectListItem { Text = nvp.Name, Value = nvp.Value });
                }
            }
            return selectList;
        }

        public static SelectList GetSelectList(IList<Framework.NameValuePair> input, string selectedValue)
        {
            if (string.IsNullOrWhiteSpace(selectedValue))
            {
                return new SelectList(input, "Value", "Name", input[0].Value);
            }
            else
            {
                return new SelectList(input, "Value", "Name", selectedValue);
            }
        }
        public static SelectList GetSelectList(IList<Framework.PagingPageSizeOption> input, int currentPageSize)
        {
            if (currentPageSize != -1)
            {
                return new SelectList(input, "PageSize", "PageSizeName", currentPageSize);
            }
            else
            {
                return new SelectList(input, "PageSize", "PageSizeName", input[0].PageSize);
            }
        }
    }
}