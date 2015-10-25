using System;
namespace Framework.EntityContracts
{
    public interface IViewModelBase<TSearchCriteria>
     where TSearchCriteria : class, new()
    {
        TSearchCriteria Criteria { get; set; }
        Framework.NameValueCollection ListOfDataExport { get; set; }
        Framework.NameValueCollection ListOfQueryOrderBySettingCollecionInString { get; set; }
        string OriginalQueryOrderBySettingCollecionInString { get; set; }
        Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection { get; set; }
        Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }

        IViewModelBase<TSearchCriteria> GetPrimaryInformationEntity();
        void GetDefaultPerViewModel();
        void PopulateAllUIElements(IViewModelBase<TSearchCriteria> vmFromTempData, int currentPage);
        string QueryOrderBySettingCollecionInString { get; set; }
        Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString();
        Framework.EntityContracts.QueryPagingSetting GetDefaultQueryPagingSetting();
    }

    public interface IViewModelBase<TSearchCriteria, TSearchResult> : IViewModelBase<TSearchCriteria>
     where TSearchCriteria : class, new()
    {
        TSearchResult Result { get; set; }
		Framework.EntityContracts.SearchStatus SearchStatus { get; set; }
    }
}