using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Web
{

    public class WebFormApplicationSessionVariables
    {
        private const string SessionKey_BusinessLogicLayerContext = "Framework.CommonBLLEntities.BusinessLogicLayerContext";
        /// <summary>
        /// Gets or sets session of the business logic layer context.
        /// </summary>
        /// <value>
        /// The business logic layer context.
        /// </value>
		public static Framework.CommonBLLEntities.BusinessLogicLayerContext BusinessLogicLayerContext 
        {
            get
            {
                Framework.CommonBLLEntities.BusinessLogicLayerContext _BusinessLogicLayerContext
                     = (Framework.CommonBLLEntities.BusinessLogicLayerContext)HttpContext.Current.Session[SessionKey_BusinessLogicLayerContext];

                return _BusinessLogicLayerContext;
            }
            set
            {
                try
                {
                    if (HttpContext.Current.Session != null)
                    {
		                HttpContext.Current.Session[SessionKey_BusinessLogicLayerContext] = value;
                    }
                }
                catch { }
            }
        }
    }
    /// <summary>
    /// implements <see cref="Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer"/>
    /// </summary>
    public class WebFormApplicationSessionVariablesIoCContainer : Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer
    {
        /// <summary>
        /// Gets or sets the business logic layer context.
        /// </summary>
        /// <value>
        /// The business logic layer context.
        /// </value>
        public Framework.CommonBLLEntities.BusinessLogicLayerContext BusinessLogicLayerContext
        {
            get
            {
                return WebFormApplicationSessionVariables.BusinessLogicLayerContext ;
            }
            set
            {
                WebFormApplicationSessionVariables.BusinessLogicLayerContext  = value;
            }
        }
    }

}