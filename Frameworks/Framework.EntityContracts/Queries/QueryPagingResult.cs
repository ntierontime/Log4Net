using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// QueryPagingResult, includes:
    /// 1. the count of records.
    /// 2. the count of pages.
    /// 3. the current page.
    /// 4. the records count of current page.
    /// </summary>
    public class QueryPagingResult
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPagingResult"/> class.
        /// </summary>
        public QueryPagingResult()
        {
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the count of records.
        /// </summary>
        /// <value>
        /// The count of records.
        /// </value>
        public int CountOfRecords { get; set; }

        /// <summary>
        /// Gets or sets the records count of current page.
        /// </summary>
        /// <value>
        /// The count of current page.
        /// </value>
        public int RecordCountOfCurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public int CurrentIndexOfStartRecord { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public int PageSize { get; set; }

        #endregion properties

        #region Clone()

        public QueryPagingResult Clone()
        {
            return new QueryPagingResult
            {
                CountOfRecords = this.CountOfRecords
                , CurrentIndexOfStartRecord = this.CurrentIndexOfStartRecord
                , PageSize = this.PageSize
                , RecordCountOfCurrentPage = this.RecordCountOfCurrentPage
            };
        }

        #endregion Clone()
    }
}