using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4Net.WebFormApp.AccessoryPages
{
    public partial class LogIn : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login2_LoggedIn(object sender, EventArgs e)
        {
            MembershipUser _UserInfo = Membership.GetUser(((Login)sender).UserName);
            Framework.Web.WebFormApplicationSessionVariables.BusinessLogicLayerContext.BusinessLogicLayerMemberShip.CurrentUserGuid =
                 (Guid)_UserInfo.ProviderUserKey;
            Framework.Web.WebFormApplicationSessionVariables.BusinessLogicLayerContext.BusinessLogicLayerMemberShip.RolesOfCurrentUser =
                 Roles.GetRolesForUser(_UserInfo.UserName);
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.LogIn_Success.ToString(), this.Login2.UserName));
        }
		
        protected void Login2_LoginError(object sender, EventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.LogIn_Failed.ToString(), this.Login2.UserName));
        }
    }
}