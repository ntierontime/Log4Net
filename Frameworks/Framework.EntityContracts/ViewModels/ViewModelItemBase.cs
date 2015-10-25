using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    public class ViewModelItemBase<TSearchCriteria, TItem>
        where TSearchCriteria : class, new()
    {
        public ViewModelItemBase()
            : base()
        {
            this.SearchStatus = SearchStatus.Unknown;
        }
        public TSearchCriteria Criteria { get; set; }
        public TItem Item { get; set; }
        public Framework.EntityContracts.SearchStatus SearchStatus { get; set; }
    }
}


