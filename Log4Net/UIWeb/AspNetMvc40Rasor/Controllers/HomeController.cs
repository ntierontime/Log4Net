using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40Rasor.Controllers
{
    public partial class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Framework.Resx.UIStringResource.Common_WelcomeToNTIERONTIME;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Framework.Resx.UIStringResource.Common_AboutPageTitle;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Framework.Resx.UIStringResource.Common_ContactPageTitle;

            return View();
        }
    }
}

