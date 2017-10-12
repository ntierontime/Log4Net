using System;
namespace Framework.ViewModels
{
    public interface IViewModelBase
    {
        Framework.EntityContracts.ContentData ContentData { get; set; }
        Framework.NameValueCollection ListOfDataExport { get; set; }
        Framework.NameValueCollection ListOfQueryOrderBySettingCollecionInString { get; set; }
        string OriginalQueryOrderBySettingCollecionInString { get; set; }
        Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection { get; set; }
        Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }

        void GetDefaultPerViewModel();
        string QueryOrderBySettingCollecionInString { get; set; }
        Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString();
        Framework.EntityContracts.QueryPagingSetting GetDefaultQueryPagingSetting();

        Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus StatusOfResult { get; set; }
        string StatusMessageOfResult { get; set; }    }

    public interface IViewModelBase<TSearchCriteria>: IViewModelBase
        where TSearchCriteria : class, new()
    {
        TSearchCriteria Criteria { get; set; }
        IViewModelBase<TSearchCriteria> GetPrimaryInformationEntity();
        void PopulateAllUIElements(IViewModelBase<TSearchCriteria> vmFromTempData, int currentPage);
    }

    public interface IViewModelBase<TSearchCriteria, TSearchResult> : IViewModelBase<TSearchCriteria>
     where TSearchCriteria : class, new()
    {
        TSearchResult Result { get; set; }
    }
}

