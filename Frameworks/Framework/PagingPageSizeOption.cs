using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// contains Paging PageSize informationm.
    /// </summary>
    public class PagingPageSizeOption
    {
		#region constructors

		/// <summary>
        /// Initializes a new instance of the <see cref="PagingPageSizeOption"/> class.
        /// </summary>
        public PagingPageSizeOption()
        {
        }

		/// <summary>
        /// Initializes a new instance of the <see cref="PagingPageSizeOption"/> class.
        /// </summary>
        /// <param name="pageSizeName">Name of the page size.</param>
        /// <param name="pageSize">Size of the page.</param>
		public PagingPageSizeOption(string pageSizeName, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageSizeName = pageSizeName;
        }

		#endregion constructors

		#region properties

        /// <summary>
        /// Gets or sets the name of the page size.
        /// </summary>
        /// <value>
        /// The name of the page size.
        /// </value>
        public string PageSizeName { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

		#endregion properties
    }

    /// <summary>
    /// collection class of <see cref="PagingPageSizeOption"/> class
    /// </summary>
    public class PagingPageSizeOptionCollection : List<PagingPageSizeOption>
    {
		#region constructors

		/// <summary>
        /// Initializes a new instance of the <see cref="PagingPageSizeOptionCollection"/> class.
        /// </summary>
        public PagingPageSizeOptionCollection()
        { 
        }

		#endregion constructors

		#region Add(...)

        /// <summary>
        /// Adds the specified page size name with page size.
        /// </summary>
        /// <param name="pageSizeName">Name of the page size.</param>
        /// <param name="pageSize">Size of the page.</param>
        public void Add(string pageSizeName, int pageSize)
        {
            PagingPageSizeOption _Item = new PagingPageSizeOption(pageSizeName, pageSize);
            this.Add(_Item);
        }

		#endregion Add(...)

		#region GetDefault()

        /// <summary>
        /// Gets the default PagingPageSizeOptionCollection.
        /// </summary>
        /// <returns>The default <see cref="PagingPageSizeOptionCollection"/></returns>
        public static PagingPageSizeOptionCollection GetDefault()
        {
            PagingPageSizeOptionCollection _retval = new PagingPageSizeOptionCollection();
            _retval.Add("10 Items", 10);
            _retval.Add("25 Items", 25);
            _retval.Add("50 Items", 50);
            _retval.Add("100 Items", 100);
            return _retval;
        }

		#endregion GetDefault()
    }
}