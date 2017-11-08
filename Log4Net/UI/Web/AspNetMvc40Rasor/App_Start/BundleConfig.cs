using System.Web;
using System.Web.Optimization;

namespace Log4Net.AspNetMvc40Rasor
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js"
                        , "~/Scripts/moment-with-locales.js"
                        , "~/Scripts/jquery.validate.js"
                        , "~/Scripts/jquery.validate.unobtrusive.js"
                        //, "~/Scripts/jquery.unobtrusive-ajax.js"
                        , "~/Scripts/bootstrap.js"
                        , "~/Scripts/bootstrap-datepicker.js"
                        , "~/Scripts/knockout-{version}.js"
                        , "~/Scripts/daterangepicker.js"
                        , "~/Scripts/app.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"
                , "~/Content/bootstrap-datepicker.css"
                , "~/Content/daterangepicker.css"
                , "~/Content/awesome-bootstrap-checkbox.mvcmodified.css"
                //, "~/Content/PagedList.css"
                , "~/Content/Site.css"
                ));
        }
    }
}

