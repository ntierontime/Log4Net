using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.DAL
{
    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection of T.</typeparam>
    /// <typeparam name="T">entity class</typeparam>
    public class StatusChangeLinqQuerySetBase<TCollection, T>
        where TCollection: List<T>, new()
        where T: new()
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="StatusChangeLinqQuerySetBase&lt;TCollection, T&gt;"/> class.
        /// </summary>
		public StatusChangeLinqQuerySetBase()
        {
        }

        //public StatusChangeLinqQuerySetBase(
        //    IQueryable<T> iQueryableForNewEntries
        //    , IQueryable<T> iQueryableForUpdatedEntries
        //    , IQueryable<T> iQueryableForNotUpdatedEntries
        //    , IQueryable<T> iQueryableForRemovedEntries)
        //{
        //    this.IQueryableForNewEntries = iQueryableForNewEntries;
        //    this.IQueryableForUpdatedEntries = iQueryableForUpdatedEntries;
        //    this.IQueryableForNotUpdatedEntries = iQueryableForNotUpdatedEntries;
        //    this.IQueryableForRemovedEntries = iQueryableForRemovedEntries;
        //}

        #endregion Constructors

        #region IQueryable<T> properties -- to be removed

        //public IQueryable<T> IQueryableForNewEntries { get; set; }
        //public IQueryable<T> IQueryableForUpdatedEntries { get; set; }
        //public IQueryable<T> IQueryableForNotUpdatedEntries { get; set; }
        //public IQueryable<T> IQueryableForRemovedEntries { get; set; }

        #endregion IQueryable<T> properties -- to be removed

        /// <summary>
        /// Key:
        /// 0 -- Removed
        /// 1 -- New
        /// 2 -- ReFound
        /// 3 -- Same
        /// 4+ -- Updated Combinations
        /// </summary>
        /// <value>
        /// The linq query set.
        /// </value>
        public Dictionary<short, IQueryable<T>> LinqQuerySet { get; set; }

    }

    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TCollection">The type of the collection of T.</typeparam>
    /// <typeparam name="T">entity class</typeparam>
    /// <typeparam name="TProcessStatus">The type of the process status.</typeparam>
    /// <typeparam name="TRawStatusChangeLinqQuerySet">The type of the raw status change linq query set.</typeparam>
    /// <typeparam name="TRawCollection">The type of the raw collection.</typeparam>
    /// <typeparam name="TRaw">The type of the raw.</typeparam>
    /// <typeparam name="TDataContext">The type of the data context.</typeparam>
    public abstract class StatusChangeLinqQuerySetBase<
            TResult, TCollection, T
			, TProcessStatus
            , TRawStatusChangeLinqQuerySet
            , TRawCollection, TRaw, TDataContext>
        : StatusChangeLinqQuerySetBase<TCollection, T>
        where TResult : Framework.DataSourceEntities.StatusChangeLinqQueryResultBase<TCollection, T, TProcessStatus>, new()
		where TProcessStatus : Framework.DataSourceEntities.IProcessStatus, new()
        where TCollection : List<T>, new()
        where T : new()
        where TRawStatusChangeLinqQuerySet : StatusChangeLinqQuerySetBase<TRawCollection, TRaw>, new()
        where TRawCollection : List<TRaw>, new()
        where TRaw : new()
        where TDataContext : System.Data.Linq.DataContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusChangeLinqQuerySetBase&lt;TResult, TCollection, T, TProcessStatus, TRawStatusChangeLinqQuerySet, TRawCollection, TRaw, TDataContext&gt;"/> class.
        /// </summary>
        public StatusChangeLinqQuerySetBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusChangeLinqQuerySetBase&lt;TResult, TCollection, T, TProcessStatus, TRawStatusChangeLinqQuerySet, TRawCollection, TRaw, TDataContext&gt;"/> class.
        /// </summary>
        /// <param name="rawStatusChangeLinqQuerySet">The raw status change linq query set.</param>
        /// <param name="dataContext">The linq data context.</param>
        public StatusChangeLinqQuerySetBase(TRawStatusChangeLinqQuerySet rawStatusChangeLinqQuerySet, TDataContext dataContext)
        {
            this.RawStatusChangeLinqQuerySet = rawStatusChangeLinqQuerySet;
            this.DataContext = dataContext;
        }

        #endregion Constructors
		
		#region properties

        /// <summary>
        /// Gets or sets the raw status change linq query set.
        /// </summary>
        /// <value>
        /// The raw status change linq query set.
        /// </value>
        public TRawStatusChangeLinqQuerySet RawStatusChangeLinqQuerySet { get; set; }
        /// <summary>
        /// Gets or sets the data context of Linq To Sql.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        public TDataContext DataContext { get; set; }

		#endregion properties

		#region abstract void BuildQuery();

        /// <summary>
        /// Builds the query.
        /// </summary>
        public abstract void BuildQuery();

		#endregion abstract void BuildQuery();

		#region TResult RunQuery()

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <returns>Result</returns>
		public TResult RunQuery()
        {
            TResult _TResult = new TResult();
			_TResult.ProcessStatus = new TProcessStatus();
            foreach (KeyValuePair<short, IQueryable<T>> _KVPair in this.LinqQuerySet)
            {
                if (_KVPair.Key == 0)
                {
                    _TResult.CollectionForRemovedEntries = new TCollection();
                    _TResult.CollectionForRemovedEntries.AddRange(_KVPair.Value.ToArray());
					_TResult.ProcessStatus.CountForRemovedEntries = _TResult.CollectionForRemovedEntries.Count();
                }
                else if (_KVPair.Key == 1)
                {
                    _TResult.CollectionForNewEntries = new TCollection();
                    _TResult.CollectionForNewEntries.AddRange(_KVPair.Value.ToArray());
					_TResult.ProcessStatus.CountForNewEntries = _TResult.CollectionForNewEntries.Count();
                }
                else if (_KVPair.Key == 2)
                {
                    _TResult.CollectionForRefoundEntries = new TCollection();
                    _TResult.CollectionForRefoundEntries.AddRange(_KVPair.Value.ToArray());
					_TResult.ProcessStatus.CountForReFoundEntries = _TResult.CollectionForRefoundEntries.Count();
                }
                else if (_KVPair.Key == 3)
                {
					_TResult.ProcessStatus.CountForNotUpdatedEntries = _KVPair.Value.Count();
                }
                else
                {
                    if(_TResult.CollectionForUpdatedEntries == null)
                    {
                        _TResult.CollectionForUpdatedEntries = new TCollection();
                    }
                    _TResult.CollectionForUpdatedEntries.AddRange(_KVPair.Value.ToArray());
					_TResult.ProcessStatus.CountForUpdatedEntries += _TResult.CollectionForUpdatedEntries.Count();
                }
				_TResult.ProcessStatus.TotalCount = 
					_TResult.ProcessStatus.CountForRemovedEntries +
					_TResult.ProcessStatus.CountForNewEntries +
					_TResult.ProcessStatus.CountForReFoundEntries +
					_TResult.ProcessStatus.CountForNotUpdatedEntries +
					_TResult.ProcessStatus.CountForUpdatedEntries;
            }

            return _TResult;
	    }

		#endregion TResult RunQuery()

    }
}