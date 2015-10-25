using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Framework.Mvc
{
    public static class PagerHelper
    {
        /// <summary>
        /// Generate the HTML for a pager.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="urlHelper">The current Url helper associated to the View. Used for generating the URLs in the page links.</param>
        /// <param name="pagerOptions">An object that defines the pager properties.</param>
        /// <returns></returns>
        public static MvcHtmlString PagedListPager(this HtmlHelper helper, UrlHelper urlHelper, Framework.Mvc.PagerHtmlRenderer pagerOptions)
        {
            return new MvcHtmlString(pagerOptions.GeneratePagerHtml(urlHelper));
        }
    }
}