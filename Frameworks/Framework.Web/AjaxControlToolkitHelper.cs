using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.Web
{
    public static class AjaxControlToolkitHelper
    {
        public static AjaxControlToolkit.CascadingDropDownNameValue[] BuildCascadingDropDownNameValues(Framework.NameValueCollection nameValueCollection)
        {
            if (nameValueCollection != null)
            {
                List<AjaxControlToolkit.CascadingDropDownNameValue> retval = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
                foreach (Framework.NameValuePair nameValuePair in nameValueCollection)
                {
                    retval.Add(new AjaxControlToolkit.CascadingDropDownNameValue(nameValuePair.Name, nameValuePair.Value));
                }
                return retval.ToArray();
            }
            else
            {
                return null;
            }
        }

    }
}