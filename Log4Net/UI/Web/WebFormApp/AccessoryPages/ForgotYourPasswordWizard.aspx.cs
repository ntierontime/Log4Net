using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4Net.WebFormApp.AccessoryPages
{
    public partial class ForgotYourPasswordWizard : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		        protected void Page_Load(object sender, EventArgs e)
        {

        }
	
        protected void PasswordRecovery1_AnswerLookupError(object sender, EventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.PasswordRecovery_AnswerLookupError.ToString(), this.PasswordRecovery1.Question));
        }

        protected void PasswordRecovery1_SendMailError(object sender, SendMailErrorEventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.PasswordRecovery_SendMailError.ToString(), this.PasswordRecovery1.UserName));
        }

        protected void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.PasswordRecovery_UserLookupError.ToString(), this.PasswordRecovery1.UserName));
        }
    }
}