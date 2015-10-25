using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    public class ViewModelBase<TSearchCriteria> : Framework.EntityContracts.IViewModelBase<TSearchCriteria>
        where TSearchCriteria : class, new()
    {
        public ViewModelBase()
        {
        }
        
        public TSearchCriteria Criteria { get; set; }

        public Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }
        public string QueryOrderBySettingCollecionInString { get; set; }
        public string OriginalQueryOrderBySettingCollecionInString { get; set; }
        public Framework.NameValueCollection ListOfQueryOrderBySettingCollecionInString { get; set; }
        public Framework.NameValueCollection ListOfDataExport { get; set; }
        public Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection { get; set; }

        public Framework.EntityContracts.IViewModelBase<TSearchCriteria> GetPrimaryInformationEntity()
        {
            ViewModelBase<TSearchCriteria> vm;
            vm = new ViewModelBase<TSearchCriteria>
            {
                Criteria = this.Criteria,
                ListOfQueryOrderBySettingCollecionInString = this.ListOfQueryOrderBySettingCollecionInString,
                QueryOrderBySettingCollecionInString = this.QueryOrderBySettingCollecionInString,
                OriginalQueryOrderBySettingCollecionInString = this.OriginalQueryOrderBySettingCollecionInString,
                QueryPagingSetting = this.QueryPagingSetting
            };

            return vm;
        }


        public virtual void PopulateAllUIElements(Framework.EntityContracts.IViewModelBase<TSearchCriteria> vmFromTempData, int currentPage)
        {
            // 1. Criteria
            if (this.Criteria == null)
            {
                if (vmFromTempData != null && vmFromTempData.Criteria != null)
                {
                    this.Criteria = vmFromTempData.Criteria;
                }
                else
                {
                    this.Criteria = new TSearchCriteria();
                }
            }

            // 2. ListOfQueryOrderBySettingCollecionInString
            if (this.ListOfQueryOrderBySettingCollecionInString == null)
            {
                if (vmFromTempData != null && vmFromTempData.ListOfQueryOrderBySettingCollecionInString != null)
                {
                    this.ListOfQueryOrderBySettingCollecionInString = vmFromTempData.ListOfQueryOrderBySettingCollecionInString;
                }
                else
                {
                    this.ListOfQueryOrderBySettingCollecionInString = GetDefaultListOfQueryOrderBySettingCollecionInString();
                }
            }

            // 3. QueryPagingSetting

            if (this.QueryPagingSetting == null)
            {
                if (vmFromTempData != null && vmFromTempData.QueryPagingSetting != null)
                // first time, pagination
                {
                    this.QueryPagingSetting = vmFromTempData.QueryPagingSetting;
                    this.QueryPagingSetting.CurrentPage = currentPage;
                }
                else
                {
                    this.QueryPagingSetting = GetDefaultQueryPagingSetting();
                }
            }
            else
            {
                if (this.QueryPagingSetting.PageSizeChanged)
                {
                    this.QueryPagingSetting.CurrentPage = 1;
                    this.QueryPagingSetting.OriginalPageSize = this.QueryPagingSetting.PageSize;
                }
                else if (this.OriginalQueryOrderBySettingCollecionInString != this.QueryOrderBySettingCollecionInString)
                {
                    this.OriginalQueryOrderBySettingCollecionInString = this.QueryOrderBySettingCollecionInString;
                    this.QueryPagingSetting.CurrentPage = 1;
                }
                else
                {
                    this.QueryPagingSetting.CurrentPage = 1;
                }
            }

            // 4. QueryOrderBySettingCollecionInString
            if (string.IsNullOrWhiteSpace(this.QueryOrderBySettingCollecionInString))
            {
                if (vmFromTempData != null && !string.IsNullOrWhiteSpace(vmFromTempData.QueryOrderBySettingCollecionInString))
                // first time, pagination
                {
                    this.QueryOrderBySettingCollecionInString = vmFromTempData.QueryOrderBySettingCollecionInString;
                }
            }

            // 4.1. QueryOrderBySettingCollecion
            if (!string.IsNullOrWhiteSpace(this.QueryOrderBySettingCollecionInString))
            {
                this.QueryOrderBySettingCollection = new Framework.EntityContracts.QueryOrderBySettingCollection(this.QueryOrderBySettingCollecionInString);
            }

            // 5. GetDefaultPerViewModel
            this.GetDefaultPerViewModel();

            if (this.ListOfDataExport == null)
            {
                if (vmFromTempData != null && vmFromTempData.ListOfDataExport != null)
                // first time, pagination
                {
                    this.ListOfDataExport = vmFromTempData.ListOfDataExport;
                }
                else
                {
                    this.ListOfDataExport = new Framework.NameValueCollection();
                    this.ListOfDataExport.Add("Csv", "Csv");
                    this.ListOfDataExport.Add("Excel2010", "Excel2010");
                }
            }
        }

        public virtual Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            return null;
        }

        public virtual Framework.EntityContracts.QueryPagingSetting GetDefaultQueryPagingSetting()
        {
            Framework.EntityContracts.QueryPagingSetting queryPagingSetting = new Framework.EntityContracts.QueryPagingSetting();
            return queryPagingSetting;
        }

        public virtual void GetDefaultPerViewModel()
        {
        }
    }
    
    public class ViewModelBase<TSearchCriteria, TSearchResult> : ViewModelBase<TSearchCriteria>, Framework.EntityContracts.IViewModelBase<TSearchCriteria, TSearchResult>
        where TSearchCriteria : class, new()
    {
		public ViewModelBase()
            : base()
        {
            this.SearchStatus = SearchStatus.Unknown;
        }
        public TSearchResult Result {get;set;}
		public Framework.EntityContracts.SearchStatus SearchStatus { get; set; }
    }
}