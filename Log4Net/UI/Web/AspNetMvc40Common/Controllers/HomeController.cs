using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40Common.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Framework.Resources.UIStringResource.Common_WelcomeToNTIERONTIME;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Framework.Resources.UIStringResource.Common_AboutPageTitle;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Framework.Resources.UIStringResource.Common_ContactPageTitle;

            return View();
        }
    }
}