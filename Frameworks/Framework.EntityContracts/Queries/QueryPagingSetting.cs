using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// pull data according Paging setting.
    /// </summary>
    public class QueryPagingSetting : Framework.PropertyChangedNotifier
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPagingSetting"/> class.
        /// </summary>
        public QueryPagingSetting()
            : this(1, 10)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPagingSetting"/> class.
        /// </summary>
        /// <param name="currentIndex">Index of the current page index.</param>
        /// <param name="pageSize">Size of the page.</param>
        public QueryPagingSetting(
            int currentPage
            , int pageSize)
        {
            this.CurrentPage = currentPage;
            this.PageSize = this.OriginalPageSize = pageSize;
            this.PageSizeSelectionList = new Framework.NameValueCollection();

            this.PageSizeSelectionList.Add("10", "10");
            this.PageSizeSelectionList.Add("20", "20");
            this.PageSizeSelectionList.Add("50", "50");
            this.PageSizeSelectionList.Add("100", "100");

        }

        #endregion constructors

        #region properties

        [Newtonsoft.Json.JsonIgnore]
        public bool IsEmptyResult
        {
            get
            {
                return this.CountOfRecords == 0;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsOnlyOnePage
        {
            get
            {
                return this.CountOfPages == 1;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool CanChangeCurrentPage
        {
            get
            {
                return !(this.IsEmptyResult || this.IsOnlyOnePage);
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsMoreThanOnePage
        {
            get
            {
                return this.CountOfPages > 1;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsCurrentPageIsFirstPage
        {
            get
            {
                return this.CurrentPage == 1;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsCurrentPageIsLastPage
        {
            get
            {
                return this.CurrentPage == this.CountOfPages;
            }
        }

        int m_CurrentPage;
        /// <summary>
        /// Gets or sets the index of the current page index.
        /// start from 1
        /// </summary>
        /// <value>
        /// The index of the current page index.
        /// </value>
        public int CurrentPage
        {
            get { return this.m_CurrentPage; }
            set
            {
                if (this.m_CurrentPage != value)
                {
                    this.m_CurrentPage = value;
                    RaisePropertyChanged("CurrentPage");
                    RaisePropertyChanged("IsEmptyResult");
                    RaisePropertyChanged("IsOnlyOnePage");
                    RaisePropertyChanged("CanChangeCurrentPage");
                    RaisePropertyChanged("IsMoreThanOnePage");
                    RaisePropertyChanged("IsCurrentPageIsFirstPage");
                    RaisePropertyChanged("IsCurrentPageIsLastPage");
                    RaisePropertyChanged("CurrentIndex");
                    RaisePropertyChanged("EndIndex");
                    RaisePropertyChanged("PageSizeChanged");
                    RaisePropertyChanged("CountOfPages");
                    RaisePropertyChanged("RecordCountOfCurrentPage");
                    RaisePropertyChanged("CanGoForeward");
                    RaisePropertyChanged("CanGoBackward");
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the current item index.
        /// </summary>
        /// <value>
        /// The index of the current page index.
        /// </value>
        [Newtonsoft.Json.JsonIgnore]
        public int CurrentIndex
        {
            get
            {
                return (this.CurrentPage - 1) * this.PageSize;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public int EndIndex
        {
            get
            {
                return (this.CurrentPage - 1) * this.PageSize + this.RecordCountOfCurrentPage;
            }
        }

        int m_PageSize;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize
        {
            get { return this.m_PageSize; }
            set
            {
                if (this.m_PageSize != value)
                {
                    this.m_PageSize = value;
                    RaisePropertyChanged("PageSize");
                }
            }
        }

        int m_OriginalPageSize;
        /// <summary>
        /// Gets or sets the size of the original page.
        /// </summary>
        /// <value>
        /// The size of the original page.
        /// </value>
        public int OriginalPageSize
        {
            get { return this.m_OriginalPageSize; }
            set
            {
                if (this.m_OriginalPageSize != value)
                {
                    this.m_OriginalPageSize = value;
                    RaisePropertyChanged("OriginalPageSize");
                }
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool PageSizeChanged
        {
            get
            {
                return this.PageSize != this.OriginalPageSize;
            }
        }

        int m_CountOfRecords;
        /// <summary>
        /// Gets or sets the count of records.
        /// </summary>
        /// <value>
        /// The count of records.
        /// </value>
        public int CountOfRecords
        {
            get { return this.m_CountOfRecords; }
            set
            {
                if (this.m_CountOfRecords != value)
                {
                    this.m_CountOfRecords = value;
                    RaisePropertyChanged("CountOfRecords");
                }
            }
        }

        /// <summary>
        /// Gets or sets the count of pages.
        /// </summary>
        /// <value>
        /// The count of pages.
        /// </value>
        [Newtonsoft.Json.JsonIgnore]
        public int CountOfPages
        {
            get
            {
                return (int)Math.Ceiling(this.CountOfRecords * 1.0 / this.PageSize);
            }
        }

        /// <summary>
        /// Gets or sets the records count of current page.
        /// </summary>
        /// <value>
        /// The count of current page.
        /// </value>
        public int RecordCountOfCurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the paging selection list.
        /// </summary>
        /// <value>
        /// The paging selection list.
        /// </value>
        public Framework.NameValueCollection  PageSizeSelectionList { get; set; }

        /// <summary>
        /// Gets or sets the page number selection list.
        /// </summary>
        /// <value>
        /// The page number selection list.
        /// </value>
        public Framework.NameValueCollection PageNumberSelectionList { get; set; }

        public string GetPagingInformationString()
        {
            if (this.RecordCountOfCurrentPage == 0)
            {
                return string.Format(Framework.Resx.UIStringResource.Pagination_NoData);
            }
            else
            {

                return string.Format(Framework.Resx.UIStringResource.Pagination_PagingInformation, this.RecordCountOfCurrentPage, this.CurrentIndex + 1, this.EndIndex, this.CountOfRecords, this.CountOfPages, this.CurrentPage);
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool CanGoForeward
        {
            get
            {
                return this.CountOfPages > 0 && !this.IsCurrentPageIsLastPage;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool CanGoBackward
        {
            get
            {
                return this.CountOfPages > 0 && !this.IsCurrentPageIsFirstPage;
            }
        }

        #endregion properties

        public override string ToString()
        {
            return GetPagingInformationString();
        }

        public static QueryPagingSetting GetDefault()
        {
            return new QueryPagingSetting(1, 10);
        }
    }
}

