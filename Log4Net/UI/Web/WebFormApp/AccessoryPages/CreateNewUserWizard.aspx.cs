using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4Net.WebFormApp.AccessoryPages
{
    public partial class CreateNewUserWizard : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_CheckUserNameAvailability_Click(object sender, EventArgs e)
        {
            TextBox _TextBoxOfUserName = (TextBox)this.CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
            if (_TextBoxOfUserName != null)
            {
                MembershipUser User = Membership.GetUser(_TextBoxOfUserName.Text);
                Label _Label = (Label)this.CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Label1");
                if (User != null)
                {
                    _Label.Visible = true;
                }
                else
                {
                    _Label.Visible = false;
                }
            }
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.CreateUser_Succeeded.ToString(), this.CreateUserWizard1.UserName));
        }

        protected void CreateUserWizard1_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.CreateUser_Failed.ToString(), this.CreateUserWizard1.UserName));
        }
    }
}