using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4Net.AspNetMvc40Rasor.Helpers
{
    /// <summary>
    ///
    /// </summary>
    public partial class WebAuthorizationAttribute: ClaimsAuthorizationAttribute
    {
        private string _permissionsString;

        private string[] _permissionsArray = new string[0];

        public string Permissions
        {
            get { return _permissionsString ?? string.Empty; }
            set { SetPermissions(value); }
        }

        private void SetPermissions(string permissionsString)
        {
            _permissionsArray = SetStringCollection(permissionsString, out _permissionsString);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (_permissionsArray.Length == 0)
                return true;
            httpContext.Session["UnauthorizedError"] = Permissions;
            return base.AuthorizeCore(httpContext) && AuthorizePermissions(httpContext);
        }

        private bool AuthorizePermissions(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            if (httpContext.User.Identity.IsAuthenticated)
            {
                return _permissionsArray.Length == 0 || _permissionsArray.Any(p => GetClaims(httpContext, CustomizedClaimTypes.Permission).Any(c => c.Value.Equals(p, StringComparison.OrdinalIgnoreCase)));
            }
            return false;
        }

        protected override string GetUnauthorizedUrl(System.Web.HttpContextBase httpContext)
        {
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            if (httpContext.User.Identity.IsAuthenticated)
                return url.RouteUrl(new { controller = "Home", action = "NoPermission", area = "" });
            else
                return url.RouteUrl(new { controller = "SignUp", action = "Login", area = "" });
        }
    }
}

