using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    /// Session variables
    /// </summary>
	public class SessionVariablesCommon 
	{
        /// <summary>
        /// Gets or sets the business logic layer context.
        /// </summary>
        /// <value>
        /// The business logic layer context.
        /// </value>
        public static Framework.CommonBLLEntities.BusinessLogicLayerContext BusinessLogicLayerContext
        {
            get;
            set;
        }
    }
}