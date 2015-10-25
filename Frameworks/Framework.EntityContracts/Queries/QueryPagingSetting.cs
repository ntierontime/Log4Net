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

            this.PageSizeSelectionList.Add(10, "10");
            this.PageSizeSelectionList.Add(20, "20");
            this.PageSizeSelectionList.Add(50, "50");
            this.PageSizeSelectionList.Add(100, "100");

        }

        #endregion constructors

        #region properties

        public bool IsEmptyResult
        {
            get
            {
                return this.CountOfRecords == 0;
            }
        }

        public bool IsOnlyOnePage
        {
            get
            {
                return this.CountOfPages == 1;
            }
        }

        public bool IsMoreThanOnePage
        {
            get
            {
                return this.CountOfPages > 1;
            }
        }

        public bool IsCurrentPageIsFirstPage
        {
            get
            {
                return this.CurrentPage == 1;
            }
        }

        public bool IsCurrentPageIsLastPage
        {
            get
            {
                return this.CurrentPage == this.CountOfPages;
            }
        }

        public int m_CurrentPage;
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
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the current item index.
        /// </summary>
        /// <value>
        /// The index of the current page index.
        /// </value>
        public int CurrentIndex
        {
            get
            {
                return (this.CurrentPage - 1) * this.PageSize;
            }
        }

        public int EndIndex
        {
            get
            {
                return (this.CurrentPage - 1) * this.PageSize + this.RecordCountOfCurrentPage;
            }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the original page.
        /// </summary>
        /// <value>
        /// The size of the original page.
        /// </value>
        public int OriginalPageSize { get; set; }

        public bool PageSizeChanged
        {
            get
            {
                return this.PageSize != this.OriginalPageSize;
            }
        }

        /// <summary>
        /// Gets or sets the count of records.
        /// </summary>
        /// <value>
        /// The count of records.
        /// </value>
        public int CountOfRecords { get; set; }

        /// <summary>
        /// Gets or sets the count of pages.
        /// </summary>
        /// <value>
        /// The count of pages.
        /// </value>
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
                return string.Format("0 Record in Current Page");
            }
            else
            {
                return string.Format("Total Pages: {4}. {0} Record in Current Page: ({1} - {2}) / {3}", this.RecordCountOfCurrentPage, this.CurrentIndex + 1, this.EndIndex, this.CountOfRecords, this.CountOfPages);
            }
        }

        #endregion properties
    }
}