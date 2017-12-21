using System.Web.Mvc;

namespace Log4Net.AspNetMvc40Rasor.Area.AreaName
{
    public class AreaNameAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaName";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaName_default",
                "AreaName/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = Log4Net.AspNetMvc40Rasor.Helpers.UrlStrings.AreaRouteConstraint },
                new[] { Log4Net.AspNetMvc40Rasor.Helpers.UrlStrings.AreaNamespace }
            );
        }
    }
}

