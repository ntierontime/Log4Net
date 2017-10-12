using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.ViewModelData
{

    public partial class WPCommonOfLogVM : Framework.ViewModels.ViewModelBase<Log4Net.CommonBLLEntities.LogChainedQueryCriteriaCommonFlatten, Log4Net.DataSourceEntities.LogCollection>
    {
        public WPCommonOfLogVM()
            : base()
        {
        }

        public override Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            return Log4Net.ViewModelData.OrderByLists.WPCommonOfLogVM_GetDefaultListOfQueryOrderBySettingCollecionInString();
        }
    }

    public partial class WPEntityRelatedOfLogVM
        : Framework.ViewModels.ViewModelEntityRelatedBase<Log4Net.DataSourceEntities.Log, Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier>
    {
        public WPEntityRelatedOfLogVM()
            : base(null)
        { }

        public WPEntityRelatedOfLogVM(Log4Net.CommonBLLEntities.LogChainedQueryCriteriaByIdentifier criteriaOfMasterEntity)
            : base(criteriaOfMasterEntity)
        {

        }

    }

}

