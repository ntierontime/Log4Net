using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.ViewModelData
{
    public partial class LogItemVM : Framework.ViewModels.ViewModelItemBase<Log4Net.DataSourceEntities.LogIdentifier, Log4Net.DataSourceEntities.Log>
    {
        #region log4net

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion log4net

    }
}

