using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mvc
{
    public class ViewModelItemBase<TSearchCriteria, TItem> : Framework.ViewModels.ViewModelItemBase<TSearchCriteria, TItem>
        where TSearchCriteria : class, new()
        where TItem : class, new()
    {
        public ViewModelItemBase()
            : base()
        {
        }
    }
}

