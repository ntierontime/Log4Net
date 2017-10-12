namespace Framework.ViewModels
{
    public interface IViewModelItemBase
    {
        Framework.EntityContracts.ContentData ContentData { get; set; }
        Framework.EntityContracts.SearchStatus SearchStatus { get; set; }
        string StatusMessageOfResult { get; set; }
        Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus StatusOfResult { get; set; }
        Framework.UIActionStatusMessage UIActionStatusMessage { get; set; }
    }

    public interface IViewModelItemBase<TSearchCriteria, TItem> : IViewModelItemBase
        where TSearchCriteria : class, new()
        where TItem : class, new()
    {
        TSearchCriteria Criteria { get; set; }
        TItem Item { get; set; }
    }
}

