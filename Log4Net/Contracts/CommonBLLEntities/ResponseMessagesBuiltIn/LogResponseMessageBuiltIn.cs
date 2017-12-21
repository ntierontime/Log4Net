using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLLEntities
{
    /// <summary>
    /// BusinessLogicLayerResponseMessage of entity Log4Net.Log
    /// </summary>
    public partial class LogResponseMessageBuiltIn
        : Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBase<Log4Net.DataSourceEntities.LogCollection>
    {

        #region Nested Views classes and their collection classes 1

        /// <summary>
        /// BusinessLogicLayerResponseMessage of of view KeyInformation of entity Log4Net.Log
        /// </summary>
        public partial class KeyInformation
            : Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBase<Log4Net.DataSourceEntities.Log.KeyInformationCollection>
        {
        }

        #endregion Nested Views classes and their collection classes 1
    }
}

