using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationContext = System.Web.Mvc.AuthorizationContext;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;

namespace Log4Net.AspNetMvc40Rasor.Helpers
{
    /// <summary>
    ///
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public partial class ClaimsAuthorizationAttribute : AuthorizeAttribute
    {
        private string[] _claimsArray = new string[0];

        private string _claimsString;

        public string Claims
        {
            get { return _claimsString ?? string.Empty; }
            set { SetClaims(value); }
        }

        private void SetClaims(string claimsString)
        {
            _claimsArray = SetStringCollection(claimsString, out _claimsString);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            if (httpContext.User.Identity.IsAuthenticated)
            {
                return _claimsArray.Length == 0 || _claimsArray.Any(claim => GetClaims(httpContext, claim).Any());
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string unauthorizedUrl = GetUnauthorizedUrl(filterContext.HttpContext);
            if (string.IsNullOrWhiteSpace(unauthorizedUrl))
            {
                filterContext.Result = new HttpUnauthorizedResult("Not Authorized To View This Page");
            }
            else
            {
                filterContext.Result = new RedirectResult(unauthorizedUrl);
            }
        }

        protected virtual string GetUnauthorizedUrl(HttpContextBase httpContext)
        {
            return null;
        }

        protected string[] SetStringCollection(string newValue, out string standardizedString)
        {
            standardizedString = null;
            string[] stringList = new string[0];

            if (string.IsNullOrWhiteSpace(newValue))
            {
                return stringList;
            }

            stringList = newValue.ToLower().Replace(" ", "").Split(',').Select(s => s.Trim()).ToArray();
            StringBuilder builder = new StringBuilder();
            foreach (string s in stringList)
            {
                builder.Append(s).Append(',');
            }
            standardizedString = builder.ToString().Substring(0, builder.Length - 1);
            return stringList;
        }

        protected IEnumerable<Claim> GetClaims(HttpContextBase httpContext, string claimType)
        {
            ClaimsPrincipal principal = httpContext.User as ClaimsPrincipal;
            if (principal == null)
            {
                throw new NullReferenceException("ClaimsPrincipal unavailable");
            }

            return principal.FindAll(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        }
    }
}

