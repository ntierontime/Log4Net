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
        : GalaSoft.MvvmLight.ViewModelBase, Framework.ViewModels.IViewModelBase<TSearchCriteria>
        where TSearchCriteria : class, new()
        where TSearchResultEntityCollection : List<TSearchResultEntityItem>, new()
        where TSearchResultEntityItem : class, new()
    {
        #region constructor

        public ViewModelBaseWithResultAndUIElement()
            : base()
        {
            //this.ContentData = new Framework.EntityContracts.ContentData();

            this.ClearSearchResultCommand = new RelayCommand(ClearSearchResult, CanClearSearchResult);

            this.Criteria = new TSearchCriteria();

            this.LaunchSearchViewCommand = new RelayCommand(this.LaunchSearchView);
            this.CloseSearchViewCommand = new RelayCommand(this.CloseSearchView);
            this.LaunchResultViewCommand = new RelayCommand(this.LaunchResultView);
            this.CloseResultViewCommand = new RelayCommand(this.CloseResultView);
            this.SearchCommand = new RelayCommand(this.Search, this.CanSearch);
            this.LoadMoreCommand = new RelayCommand(this.LoadMore, this.CanSearch);

            PopulateAllUIElements(this, 1);

            this.PaginationFirstPageCommand = new RelayCommand(PaginationFirstPage);
            this.PaginationPreviousPageCommand = new RelayCommand(PaginationPreviousPage);
            this.PaginationNextPageCommand = new RelayCommand(PaginationNextPage);
            this.PaginationLastPageCommand = new RelayCommand(PaginationLastPage);

            SuppressMVVMLightEventToCommandMessage = false;
        }

        #endregion constructor

        #region Suppress MVVMLight EventToCommand Message

        public bool SuppressMVVMLightEventToCommandMessage { get; set; }

        #endregion Suppress MVVMLight EventToCommand Message

        #region Business Entity Collection

        protected ObservableCollection<TSearchResultEntityItem> m_EntityCollection;

        /// <summary>
        /// Gets or sets the DataSourceEntities list.
        /// should investigate whether can remove RaisePropertyChanged
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

        #endregion Business Entity Collection

        #region SearchStatus

        public Framework.EntityContracts.SearchStatus m_SearchStatus;
        // should investigate whether can remove RaisePropertyChanged
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

        public abstract string ViewName { get; }

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
                if (m_QueryPagingSetting != value)
                {
                    m_QueryPagingSetting = value;
                    RaisePropertyChanged("QueryPagingSetting");
                }
            }
        }

        public virtual Framework.EntityContracts.QueryPagingSetting GetDefaultQueryPagingSetting()
        {
            Framework.EntityContracts.QueryPagingSetting queryPagingSetting = new Framework.EntityContracts.QueryPagingSetting();
            if (queryPagingSetting.CountOfPages == 0 || queryPagingSetting.CountOfRecords == 0)
            {
                queryPagingSetting.CurrentPage = 0;
            }
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
            this.DoSearch(true);
        }

        public RelayCommand PaginationPreviousPageCommand { get; protected set; }

        protected void PaginationPreviousPage()
        {
            this.QueryPagingSetting.CurrentPage -= 1;
            this.DoSearch(true);
        }

        public RelayCommand PaginationNextPageCommand { get; protected set; }

        protected void PaginationNextPage()
        {
            this.QueryPagingSetting.CurrentPage += 1;
            this.DoSearch(true);
        }

        public RelayCommand PaginationLastPageCommand { get; protected set; }

        protected void PaginationLastPage()
        {
            this.QueryPagingSetting.CurrentPage = this.QueryPagingSetting.CountOfPages;
            this.DoSearch(true);
        }

        #endregion Pagination Commands - First Page, Previous Page, Next Page, and Last Page

        #region QueryOrderBySettingCollection

        protected string m_QueryOrderBySettingCollecionInString;

        public string QueryOrderBySettingCollecionInString
        {
            get
            {
                if(string.IsNullOrWhiteSpace(this.m_QueryOrderBySettingCollecionInString) && this.ListOfQueryOrderBySettingCollecionInString != null && this.ListOfQueryOrderBySettingCollecionInString.Count > 0)
                    // select first order by.
                {
                    this.m_QueryOrderBySettingCollecionInString = this.ListOfQueryOrderBySettingCollecionInString[0].Value;
                }
                return this.m_QueryOrderBySettingCollecionInString;
            }
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

        public Framework.ViewModels.IViewModelBase<TSearchCriteria> GetPrimaryInformationEntity()
        {
            Framework.ViewModels.ViewModelBase<TSearchCriteria> vm;
            vm = new Framework.ViewModels.ViewModelBase<TSearchCriteria>
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

        public virtual void PopulateAllUIElements(Framework.ViewModels.IViewModelBase<TSearchCriteria> vmFromTempData, int currentPage)
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
        ///     <c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected bool CanClearSearchResult()
        {
            return true;
        }

        #endregion ClearSearchResult

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
            string viewName = ViewName;
            Framework.UIAction uiAction = Framework.UIAction.Search;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseSearchViewCommand { get; protected set; }

        protected void CloseSearchView()
        {
            string viewName = ViewName;
            Framework.UIAction uiAction = Framework.UIAction.Search;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand SearchCommand { get; protected set; }

        protected void Search()
        {
            if (this.QueryPagingSetting != null && this.QueryPagingSetting.CurrentPage == 0)
            {
                this.QueryPagingSetting.CurrentPage = 1;
            }

            this.DoSearch(true);
        }

        protected bool CanSearch()
        {
            return true; // !(this.SearchStatus == Framework.EntityContracts.SearchStatus.Searching);
        }

        public RelayCommand LoadMoreCommand { get; protected set; }

        protected void LoadMore()
        {
            if (this.QueryPagingSetting.CurrentPage == 0)
            {
                this.QueryPagingSetting.CurrentPage = 1;
                this.DoSearch(false);
            }
            else
            {
                this.QueryPagingSetting.CurrentPage += 1;
                this.DoSearch(false);
            }
        }

        protected abstract void DoSearch(bool isToClearExistingResult);

        #region Search Result

        public RelayCommand LaunchResultViewCommand { get; protected set; }

        protected void LaunchResultView()
        {
            this.QueryPagingSetting.CurrentPage = 0; // to re-do search when switch to ResultView Page
            string viewName = ViewName;
            Framework.UIAction uiAction = Framework.UIAction.Result;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseResultViewCommand { get; protected set; }

        protected void CloseResultView()
        {
            string viewName = ViewName;
            Framework.UIAction uiAction = Framework.UIAction.Result;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        #endregion Search Result

        public Framework.EntityContracts.ContentData ContentData { get; set; }

        #region Cleanup()

        public override void Cleanup()
        {
            base.Cleanup();
        }

        #endregion Cleanup()

        #region not implements and not used

        public Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus StatusOfResult { get; set; }

        public string StatusMessageOfResult { get; set; }

        #endregion not implements and not used
    }
}

