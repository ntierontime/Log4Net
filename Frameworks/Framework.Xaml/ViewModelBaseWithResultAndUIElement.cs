using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace Framework.Xaml
{
    public abstract class ViewModelBaseWithResultAndUIElement<TSearchCriteria, TSearchResultEntityCollection, TSearchResultEntityItem>
        : GalaSoft.MvvmLight.ViewModelBase, Framework.EntityContracts.IViewModelBase<TSearchCriteria>
        where TSearchCriteria : class, new()
        where TSearchResultEntityCollection : List<TSearchResultEntityItem>, new()
        where TSearchResultEntityItem : class, new()
    {
        #region constructor

        public ViewModelBaseWithResultAndUIElement()
            : base()
        {
            this.SelectionChangedCommand = new RelayCommand(SelectionChanged);
            this.RefreshCurrentEditingItemCommand = new RelayCommand(this.RefreshCurrentEditingItem);
            this.ClearSearchResultCommand = new RelayCommand(ClearSearchResult, CanClearSearchResult);
            this.RefreshNewItemCommand = new RelayCommand(this.RefreshNewItem);
			
			this.LaunchCopyViewCommand = new RelayCommand(LaunchCopyView);
            
			this.LaunchViewDetailsViewCommand = new RelayCommand(LaunchViewDetailsView);
            this.CloseViewDetailsViewCommand = new RelayCommand(CloseViewDetailsView);

            this.LaunchEditViewCommand = new RelayCommand(LaunchEditView);
            this.CloseEditViewCommand = new RelayCommand(CloseEditView);
            this.SaveCommand = new RelayCommand(Save, CanSave);

            this.LaunchCreateViewCommand = new RelayCommand(LaunchCreateView);
            this.CloseCreateViewCommand = new RelayCommand(CloseCreateView);
            this.AddCommand = new RelayCommand(Add, CanAdd);

            this.LaunchDeleteViewCommand = new RelayCommand(LaunchDeleteView);
            this.CloseDeleteViewCommand = new RelayCommand(CloseDeleteView);
            this.DeleteCommand = new RelayCommand(Delete, CanDelete);

			this.Criteria = new TSearchCriteria();

			this.LaunchSearchViewCommand = new RelayCommand(this.LaunchSearchView);
			this.CloseSearchViewCommand = new RelayCommand(this.CloseSearchView);
			this.SearchCommand = new RelayCommand(this.Search, this.CanSearch);

#if WINDOWS_PHONE

            this.InfinityScrollingSearchCommand = new RelayCommand(this.InfinityScrollingSearch);

#endif
            PopulateAllUIElements(this, 1);

            this.PaginationFirstPageCommand = new RelayCommand(PaginationFirstPage, CanPaginationFirstPage);
            this.PaginationPreviousPageCommand = new RelayCommand(PaginationPreviousPage, CanPaginationPreviousPage);
            this.PaginationNextPageCommand = new RelayCommand(PaginationNextPage, CanPaginationNextPage);
            this.PaginationLastPageCommand = new RelayCommand(PaginationLastPage, CanPaginationLastPage);
        }

        #endregion constructor

        #region Business Entity Collection + Current Selected or editing Entity

        protected ObservableCollection<TSearchResultEntityItem> m_EntityCollection;

        /// <summary>
        /// Gets or sets the DataSourceEntities list.
        /// </summary>
        /// <value>The DataSourceEntities list.</value>
        public ObservableCollection<TSearchResultEntityItem> EntityCollection
        {
            get { return m_EntityCollection; }
            set
            {
                m_EntityCollection = value;
                RaisePropertyChanged("EntityCollection");
            }
        }

        protected TSearchResultEntityItem m_CurrentInEditing;
        public TSearchResultEntityItem CurrentInEditing
        {
            get { return m_CurrentInEditing; }
            set
            {
                if (m_CurrentInEditing != value)
                {
                    m_CurrentInEditing = value;
                    RaisePropertyChanged("CurrentInEditing");
                }
            }
        }

        protected TSearchResultEntityItem m_Current;
        public TSearchResultEntityItem Current
        {
            get { return m_Current; }
            set
            {
                if (m_Current != value)
                {
                    m_Current = value;
                    this.RefreshCurrentEditingItem();
                    RaisePropertyChanged("Current");
                }
            }
        }

        protected TSearchResultEntityItem m_NewItem;
        public TSearchResultEntityItem NewItem
        {
            get { return m_NewItem; }
            set
            {
                m_NewItem = value;
                RaisePropertyChanged("NewItem");
            }
        }

        #endregion Business Entity Collection + Current Selected or editing Entity

        #region SearchStatus

        public Framework.EntityContracts.SearchStatus m_SearchStatus;
        public Framework.EntityContracts.SearchStatus SearchStatus 
        { 
            get
            {
                return this.m_SearchStatus;
            } 
            set
            {
                if(this.m_SearchStatus != value)
                {
                    this.m_SearchStatus = value;
                    RaisePropertyChanged("SearchStatus");
                }
            }
        }

        #endregion SearchStatus

        #region string EntityName

        public abstract string EntityName { get; }

        #endregion string EntityName

        #region ViewNames

        public const string ViewName_Edit = "Edit";
        public const string ViewName_Create = "Create";
        public const string ViewName_Delete = "Delete";
        public const string ViewName_Details = "Details";
        public const string ViewName_SearchResult = "SearchResult";

        #endregion ViewNames

        #region QueryPagingSetting

        protected Framework.EntityContracts.QueryPagingSetting m_QueryPagingSetting;
        /// <summary>
        /// Gets or sets the query paging setting.
        /// </summary>
        /// <value>
        /// The query paging setting.
        /// </value>
        public Framework.EntityContracts.QueryPagingSetting QueryPagingSetting
        {
            get { return m_QueryPagingSetting; }
            set
            {
                m_QueryPagingSetting = value;
                RaisePropertyChanged("QueryPagingSetting");
            }
        }

        public virtual Framework.EntityContracts.QueryPagingSetting GetDefaultQueryPagingSetting()
        {
            Framework.EntityContracts.QueryPagingSetting queryPagingSetting = new Framework.EntityContracts.QueryPagingSetting();
            return queryPagingSetting;
        }

        protected Framework.EntityContracts.QueryPagingSetting GetQueryPagingSettingFromQueryPagingResult(Framework.EntityContracts.QueryPagingResult queryPagingResult)
        {
            Framework.EntityContracts.QueryPagingSetting queryPagingSetting = new Framework.EntityContracts.QueryPagingSetting
            {
                CountOfRecords = queryPagingResult.CountOfRecords,
                PageSize = queryPagingResult.PageSize,
                CurrentPage = queryPagingResult.CurrentIndexOfStartRecord / queryPagingResult.PageSize + 1,
                RecordCountOfCurrentPage = queryPagingResult.RecordCountOfCurrentPage,
            };
            return queryPagingSetting;
        }

        #endregion QueryPagingSetting

        #region Pagination Commands - First Page, Previous Page, Next Page, and Last Page, and Go Command

        public RelayCommand PaginationFirstPageCommand { get; protected set; }

        protected void PaginationFirstPage()
        {
            this.QueryPagingSetting.CurrentPage = 1;
            this.Search();
        }

        protected bool CanPaginationFirstPage()
        {
            return this.SearchStatus != Framework.EntityContracts.SearchStatus.Searching && this.QueryPagingSetting != null && this.QueryPagingSetting.IsMoreThanOnePage && !this.QueryPagingSetting.IsCurrentPageIsFirstPage;
        }

        public RelayCommand PaginationPreviousPageCommand { get; protected set; }

        protected void PaginationPreviousPage()
        {
            this.QueryPagingSetting.CurrentPage -= 1;
            this.Search();
        }

        protected bool CanPaginationPreviousPage()
        {
            return this.SearchStatus != Framework.EntityContracts.SearchStatus.Searching && this.QueryPagingSetting != null && this.QueryPagingSetting.IsMoreThanOnePage && !this.QueryPagingSetting.IsCurrentPageIsFirstPage;
        }

        public RelayCommand PaginationNextPageCommand { get; protected set; }

        protected void PaginationNextPage()
        {
            this.QueryPagingSetting.CurrentPage += 1;
            this.Search();
        }

        protected bool CanPaginationNextPage()
        {
            return this.SearchStatus != Framework.EntityContracts.SearchStatus.Searching && this.QueryPagingSetting != null && this.QueryPagingSetting.IsMoreThanOnePage && !this.QueryPagingSetting.IsCurrentPageIsLastPage;
        }

        public RelayCommand PaginationLastPageCommand { get; protected set; }

        protected void PaginationLastPage()
        {
            this.QueryPagingSetting.CurrentPage = this.QueryPagingSetting.CountOfPages;
            this.Search();
        }

        protected bool CanPaginationLastPage()
        {
            return this.SearchStatus != Framework.EntityContracts.SearchStatus.Searching && this.QueryPagingSetting != null && this.QueryPagingSetting.IsMoreThanOnePage && !this.QueryPagingSetting.IsCurrentPageIsLastPage;
        }

        #endregion Pagination Commands - First Page, Previous Page, Next Page, and Last Page

        #region QueryOrderBySettingCollection


        protected string m_QueryOrderBySettingCollecionInString;

        public string QueryOrderBySettingCollecionInString
        {
            get
            { return this.m_QueryOrderBySettingCollecionInString; }
            set
            {
                if (this.m_QueryOrderBySettingCollecionInString != value)
                {
                    m_QueryOrderBySettingCollecionInString = value;
                    RaisePropertyChanged("QueryOrderBySettingCollecionInString");
                    if (!string.IsNullOrWhiteSpace(this.m_QueryOrderBySettingCollecionInString))
                    {
                        this.m_QueryOrderBySettingCollection = new Framework.EntityContracts.QueryOrderBySettingCollection(this.m_QueryOrderBySettingCollecionInString);
                    }
                }
            }
        }

        protected string m_OriginalQueryOrderBySettingCollecionInString;
        public string OriginalQueryOrderBySettingCollecionInString
        {
            get
            { return this.m_OriginalQueryOrderBySettingCollecionInString; }
            set
            {
                if (this.m_OriginalQueryOrderBySettingCollecionInString != value)
                {
                    m_OriginalQueryOrderBySettingCollecionInString = value;
                    RaisePropertyChanged("OriginalQueryOrderBySettingCollecionInString");
                }
            }
        }

        public Framework.NameValueCollection ListOfQueryOrderBySettingCollecionInString { get; set; }

        protected Framework.EntityContracts.QueryOrderBySettingCollection m_QueryOrderBySettingCollection;
		/// <summary>
        /// Gets or sets the query order by setting collection.
        /// </summary>
        /// <value>
        /// The query order by setting collection.
        /// </value>
        public Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection
        {
            get { return m_QueryOrderBySettingCollection; }
            set
            {
                m_QueryOrderBySettingCollection = value;
                RaisePropertyChanged("QueryOrderBySettingCollection");
            }
        }

        public virtual Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            return null;
        }

        #endregion QueryOrderBySettingCollection

        #region Framework.NameValueCollection ListOfDataExport

        /// <summary>
        /// Gets or sets the list of data export: Csv/Excel2010 for now.
        /// </summary>
        /// <value>
        /// The list of data export.
        /// </value>
        public Framework.NameValueCollection ListOfDataExport { get; set; }

        #endregion Framework.NameValueCollection ListOfDataExport

        #region GetPrimaryInformationEntity()

        public Framework.EntityContracts.IViewModelBase<TSearchCriteria> GetPrimaryInformationEntity()
        {
            Framework.EntityContracts.ViewModelBase<TSearchCriteria> vm;
            vm = new Framework.EntityContracts.ViewModelBase<TSearchCriteria>
            {
                Criteria = this.Criteria,
                ListOfQueryOrderBySettingCollecionInString = this.ListOfQueryOrderBySettingCollecionInString,
                QueryOrderBySettingCollecionInString = this.QueryOrderBySettingCollecionInString,
                OriginalQueryOrderBySettingCollecionInString = this.OriginalQueryOrderBySettingCollecionInString,
                QueryPagingSetting = this.QueryPagingSetting
            };

            return vm;
        }

        #endregion GetPrimaryInformationEntity()

        #region PopulateAllUIElements(...)

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

        public virtual void GetDefaultPerViewModel()
        {
        }

        #endregion PopulateAllUIElements(...)

        #region SelectionChanged

        public RelayCommand SelectionChangedCommand { get; protected set; }

        protected void SelectionChanged()
        {
            string viewName = ViewName_SearchResult;
            Framework.UIAction uiAction = Framework.UIAction.SelectionChanged;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
        }

        #endregion SelectionChanged

        #region RefreshCurrentEditingItem

        public RelayCommand RefreshCurrentEditingItemCommand { get; protected set; }

        protected abstract void RefreshCurrentEditingItem();

        #endregion RefreshCurrentEditingItem

        #region RefreshNewItem

        public RelayCommand RefreshNewItemCommand { get; protected set; }

        protected abstract void RefreshNewItem();

        #endregion RefreshNewItem

        #region ClearSearchResult

        public RelayCommand ClearSearchResultCommand { get; protected set; }

        /// <summary>
        /// Clears the search result in this.EntityCollection.
        /// </summary>
        protected abstract void ClearSearchResult();

        /// <summary>
        /// Determines whether you can clear search result
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected bool CanClearSearchResult()
        {
            return true;
        }

        #endregion ClearSearchResult

        #region ViewDetails

        public RelayCommand LaunchViewDetailsViewCommand { get; protected set; }

        protected void LaunchViewDetailsView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.ViewDetails;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseViewDetailsViewCommand { get; protected set; }

        protected void CloseViewDetailsView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.ViewDetails;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        #endregion ViewDetails
		
        #region Copy

        public RelayCommand LaunchCopyViewCommand { get; protected set; }

        protected void LaunchCopyView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Copy;

            this.PrepareCopyView();

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        protected abstract void PrepareCopyView();

        #endregion Copy

        #region Save

        public RelayCommand LaunchEditViewCommand { get; protected set; }

        protected void LaunchEditView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Update;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseEditViewCommand { get; protected set; }

        protected void CloseEditView()
        {
            string viewName = ViewName_Edit;
            Framework.UIAction uiAction = Framework.UIAction.Update;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand SaveCommand { get; protected set; }

        /// <summary>
        /// update an Entity
        /// </summary>
        protected abstract void Save();

        /// <summary>
        /// Determines whether you can save Entity
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool CanSave();

        #endregion Save

        #region Add

        public RelayCommand LaunchCreateViewCommand { get; protected set; }

        protected void LaunchCreateView()
        {
            string viewName = ViewName_SearchResult;
            Framework.UIAction uiAction = Framework.UIAction.Create;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseCreateViewCommand { get; protected set; }

        protected void CloseCreateView()
        {
            string viewName = ViewName_Create;
            Framework.UIAction uiAction = Framework.UIAction.Create;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand AddCommand { get; protected set; }

        /// <summary>
        /// Adds a Entity to the list and repo.
        /// </summary>
        protected abstract void Add();

        /// <summary>
        /// Determines whether you can create a CustomerInformation.DataSourceEntities.CustomerProduct.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected bool CanAdd()
        {
            return true;
        }

        #endregion Add

        #region Delete

        public RelayCommand LaunchDeleteViewCommand { get; protected set; }

        protected void LaunchDeleteView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Delete;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseDeleteViewCommand { get; protected set; }

        protected void CloseDeleteView()
        {
            string viewName = ViewName_Delete;
            Framework.UIAction uiAction = Framework.UIAction.Delete;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand DeleteCommand { get; protected set; }

        /// <summary>,
        /// delete a CustomerInformation.DataSourceEntities.CustomerProduct.
        /// </summary>
        protected abstract void Delete();

        /// <summary>
        /// Determines whether you can delete an Entity
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool CanDelete();

        #endregion Delete


        #region Search

        protected TSearchCriteria m_Criteria;

        public TSearchCriteria Criteria
        {
            get { return m_Criteria; }
            set
            {
                m_Criteria = value;
                RaisePropertyChanged("Criteria");
            }
        }

        public RelayCommand LaunchSearchViewCommand { get; protected set; }

        protected void LaunchSearchView()
        {
            string viewName = ViewName_SearchResult;
            Framework.UIAction uiAction = Framework.UIAction.Search;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseSearchViewCommand { get; protected set; }

        protected void CloseSearchView()
        {
            string viewName = ViewName_SearchResult;
            Framework.UIAction uiAction = Framework.UIAction.Search;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand SearchCommand { get; protected set; }

        /// <summary>
        /// GetCollectionOfEntityOfCommon
        /// </summary>
        protected abstract void Search();

        protected bool CanSearch()
        {
            return this.QueryPagingSetting == null || !(this.SearchStatus == Framework.EntityContracts.SearchStatus.Searching);
        }

        #endregion Search

#if WINDOWS_PHONE

        #region InfinityScrollingSearch

        protected bool IsToClearExistingCollection { get; set; }

        public RelayCommand InfinityScrollingSearchCommand { get; protected set; }
        /// <summary>
        /// GetCollectionOfEntityOfCommon
        /// </summary>
        protected void InfinityScrollingSearch()
        {
            IsToClearExistingCollection = false;
            this.Search();
        }

        #endregion InfinityScrollingSearch

#endif
		
        #region Cleanup()

        public virtual void Cleanup()
        {
        }

        #endregion Cleanup()
    }

    public abstract class ViewModelBaseWithResultAndUIElement<TSearchCriteria, TSearchResultEntityCollection, TSearchResultEntityItem, TSearchResultDataViewCollection, TSearchResultDataViewItem>
        : ViewModelBaseWithResultAndUIElement<TSearchCriteria, TSearchResultDataViewCollection, TSearchResultDataViewItem>
        where TSearchCriteria : class, new()
        where TSearchResultDataViewCollection : List<TSearchResultDataViewItem>, new()
        where TSearchResultDataViewItem : class, new()
        where TSearchResultEntityCollection : List<TSearchResultEntityItem>, new()
        where TSearchResultEntityItem : class, new()
    {
        #region constructor

        public ViewModelBaseWithResultAndUIElement()
            : base()
        {
        }

        #endregion constructor


        #region DataView Collection + Current Selected or editing Entity for Current workspace and CURD

        protected ObservableCollection<TSearchResultDataViewItem> m_EntityCollectionDefault;

        /// <summary>
        /// Gets or sets the Default DataView Item list.
        /// </summary>
        /// <value>The Default DataView Item list.</value>
        public ObservableCollection<TSearchResultDataViewItem> EntityCollectionDefault
        {
            get { return m_EntityCollectionDefault; }
            set
            {
                m_EntityCollectionDefault = value;
                RaisePropertyChanged("EntityCollectionDefault");
            }
        }

        protected TSearchResultDataViewItem m_CurrentInEditingDefault;
        public TSearchResultDataViewItem CurrentInEditingDefault
        {
            get { return m_CurrentInEditingDefault; }
            set
            {
                if (m_CurrentInEditingDefault != value)
                {
                    m_CurrentInEditingDefault = value;
                    RaisePropertyChanged("CurrentInEditingDefault");
                }
            }
        }

        protected TSearchResultDataViewItem m_CurrentDefault;
        public TSearchResultDataViewItem CurrentDefault
        {
            get { return m_CurrentDefault; }
            set
            {
                if (m_CurrentDefault != value)
                {
                    m_CurrentDefault = value;
                    this.RefreshCurrentEditingItem();
                    RaisePropertyChanged("CurrentDefault");
                }
            }
        }

        protected TSearchResultDataViewItem m_NewItemDefault;
        public TSearchResultDataViewItem NewItemDefault
        {
            get { return m_NewItemDefault; }
            set
            {
                m_NewItemDefault = value;
                RaisePropertyChanged("NewItemDefault");
            }
        }

        #endregion Business Entity Collection + Current Selected or editing Entity
    }
}