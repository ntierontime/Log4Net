using System.Web;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40Common
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}