using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.DataSourceEntities
{
    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection of T.</typeparam>
    /// <typeparam name="T">entity type</typeparam>
	public class StatusChangeLinqQueryResultBase<TCollection, T>
    {
	
        #region result of IQueryable<T> properties

        /// <summary>
        /// Gets the collection for removed entries.
        /// </summary>
        public TCollection CollectionForRemovedEntries { get; set; } //0
        /// <summary>
        /// Gets the collection for new entries.
        /// </summary>
        public TCollection CollectionForNewEntries { get; set; }   // 1
        /// <summary>
        /// Gets the collection for refound entries.
        /// </summary>
        public TCollection CollectionForRefoundEntries { get; set; } // 2 not for raw
        /// <summary>
        /// Gets the collection for not updated entries.
        /// </summary>
        public TCollection CollectionForNotUpdatedEntries { get; set; } // 3
        /// <summary>
        /// Gets the collection for updated entries.
        /// </summary>
        public TCollection CollectionForUpdatedEntries { get; set; } // 4, 

        #endregion result of IQueryable<T> properties


        #region result of IQueryable<T> properties // to be removed

        //public int TotalCount { get; set; }
        //public int CountForNewEntries { get; set; }
        //public int CountForReFoundEntries { get; set; }
        //public int CountForUpdatedEntries { get; set; }
        //public int CountForNotUpdatedEntries { get; set; }
        //public int CountForRemovedEntries { get; set; }

        #endregion result of IQueryable<T> properties

    }


    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TCollection">The class of the collection of T.</typeparam>
    /// <typeparam name="T">entity class</typeparam>
    /// <typeparam name="TProcessStatus">The type of the process status.</typeparam>
	public class StatusChangeLinqQueryResultBase<TCollection, T, TProcessStatus>
		: StatusChangeLinqQueryResultBase<TCollection, T>
        where TProcessStatus : IProcessStatus, new()
    {
        /// <summary>
        /// Gets the process status.
        /// </summary>
        public TProcessStatus ProcessStatus { get; set; } // 4, 
    }


    /// <summary>
    /// ??
    /// </summary>
	public interface IProcessStatus
    {
		#region properties

        /// <summary>
        /// Gets or sets a value indicating whether [process success].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [process success]; otherwise, <c>false</c>.
        /// </value>
        bool ProcessSuccess { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        string Comments { get; set; }
        /// <summary>
        /// Gets or sets the type of the process.
        /// </summary>
        /// <value>
        /// The type of the process.
        /// </value>
        short ProcessType { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the count for new entries.
        /// </summary>
        /// <value>
        /// The count for new entries.
        /// </value>
        int CountForNewEntries { get; set; }
        /// <summary>
        /// Gets or sets the count for re found entries.
        /// </summary>
        /// <value>
        /// The count for re found entries.
        /// </value>
        int CountForReFoundEntries { get; set; }
        /// <summary>
        /// Gets or sets the count for updated entries.
        /// </summary>
        /// <value>
        /// The count for updated entries.
        /// </value>
        int CountForUpdatedEntries { get; set; }
        /// <summary>
        /// Gets or sets the count for not updated entries.
        /// </summary>
        /// <value>
        /// The count for not updated entries.
        /// </value>
        int CountForNotUpdatedEntries { get; set; }
        /// <summary>
        /// Gets or sets the count for removed entries.
        /// </summary>
        /// <value>
        /// The count for removed entries.
        /// </value>
        int CountForRemovedEntries { get; set; }

		#endregion properties

    }
}