using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Web.UI;
using System.Reflection;
using System.Runtime;

namespace Log4Net.WcfWebApp
{
    public class Global : System.Web.HttpApplication
    {
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start(object sender, EventArgs e)
        {

			Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Clear();
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Log4Net.WcfContracts.IBusinessLogicLayerFactory, Log4Net.CommonBLL.BusinessLogicLayerFactory>();
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer, Framework.Web.WebFormApplicationSessionVariablesIoCContainer>();
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Log4Net.DALContracts.DataAccessLayerFactoryContract, Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactory>();

			log.Info(Framework.LoggingOptions.Application_Started.ToString());
			Framework.Web.WebFormApplicationApplicationVariables.GetDefault();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
			log.Info(Framework.LoggingOptions.Session_Started.ToString());


            Framework.CommonBLLEntities.BusinessLogicLayerMemberShip _BusinessLogicLayerMemberShip = new Framework.CommonBLLEntities.BusinessLogicLayerMemberShip();
            //Framework.Web.WebFormApplicationSessionVariables.BusinessLogicLayerContext = new Framework.CommonBLLEntities.BusinessLogicLayerContext(
            //    _BusinessLogicLayerMemberShip 
            //    , Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance);
            List<Framework.CommonBLLEntities.BusinessLogicLayerContextSetting> _BusinessLogicLayerContextSettingCollection = new List<Framework.CommonBLLEntities.BusinessLogicLayerContextSetting>();
            _BusinessLogicLayerContextSettingCollection.Add(new Framework.CommonBLLEntities.BusinessLogicLayerContextSetting(
				"Log4Net"
				, typeof(Framework.Web.WebFormApplicationSessionVariables)
				, typeof(Framework.CommonBLLEntities.BusinessLogicLayerContext)
				, typeof(Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactory)));
            foreach (Framework.CommonBLLEntities.BusinessLogicLayerContextSetting _BusinessLogicLayerContextSetting in _BusinessLogicLayerContextSettingCollection)
            {
                object[] _Params = new object[] {_BusinessLogicLayerMemberShip };
                object _BusinessLogicLayerContext = Activator.CreateInstance(_BusinessLogicLayerContextSetting.TypeOfBusinessLogicLayerContext, _Params);
                _BusinessLogicLayerContextSetting.TypeOfTargetUser.GetProperty("BusinessLogicLayerContext").SetValue(null, _BusinessLogicLayerContext, null);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Framework.Web.WebFormApplicationSessionVariables.BusinessLogicLayerContext = null;
            log.Info(Framework.LoggingOptions.Application_Ended.ToString());
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Framework.Web.WebFormApplicationApplicationVariables.MIMEContentTypeToFileExtensionMappingCollection = null;
            log.Info(Framework.LoggingOptions.Application_Ended.ToString());
        }
	}
}