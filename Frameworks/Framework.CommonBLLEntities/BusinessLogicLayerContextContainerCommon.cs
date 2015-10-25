using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessLogicLayerContextContainerCommon : Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerContextContainerCommon"/> class.
        /// </summary>
        public BusinessLogicLayerContextContainerCommon()
        {
            this.BusinessLogicLayerContext = new BusinessLogicLayerContext(new BusinessLogicLayerMemberShip());
        }

		#endregion constructors

        #region Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer Members

		/// <summary>
        /// Gets or sets the business logic layer context.
        /// </summary>
        /// <value>
        /// The business logic layer context.
        /// </value>
        public Framework.CommonBLLEntities.BusinessLogicLayerContext BusinessLogicLayerContext
        {
            get { return Framework.CommonBLLEntities.SessionVariablesCommon.BusinessLogicLayerContext; }
            set { Framework.CommonBLLEntities.SessionVariablesCommon.BusinessLogicLayerContext = value; }
        }

        #endregion Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer Members
    }
}