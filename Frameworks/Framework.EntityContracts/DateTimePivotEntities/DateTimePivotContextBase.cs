using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts.DateTimePivotEntities
{
    /// <summary>
    /// base class of DateTimePivotContenxt classes
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    /// <typeparam name="T">entity type</typeparam>
    /// <typeparam name="TCategoryCollection">The type of the category collection.</typeparam>
    /// <typeparam name="TCategory">The type of the category.</typeparam>
    /// <typeparam name="TSubSummary">The type of the sub summary.</typeparam>
    /// <typeparam name="TSummary">The type of the summary.</typeparam>
    public abstract class DateTimePivotContextBase<TCollection, T, TCategoryCollection, TCategory, TSubSummary, TSummary>
        where TCollection : List<T>, new()
        where T : new()
        where TCategoryCollection : List<TCategory>, new()
        where TCategory : class, new()
        where TSubSummary : class, new()
        where TSummary : class, new()
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotContextBase&lt;TCollection, T, TCategory, TSubSummary, TSummary&gt;"/> class.
        /// </summary>
        public DateTimePivotContextBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotContextBase&lt;TCollection, T, TCategoryCollection, TCategory, TSubSummary, TSummary&gt;"/> class.
        /// </summary>
        /// <param name="categoryCollection">The category collection.</param>
        /// <param name="entityCollection">The entity collection.</param>
        /// <param name="dateTimePivotSetting">The date time pivot setting.</param>
        /// <param name="func_GetEntityCollectionOfOneCategory">The func_ get entity collection of one category.</param>
        /// <param name="func_CalculateSummary">The func_ calculate summary.</param>
        /// <param name="func_GetEntityCollectionOfOneCriteria">The func_ get entity collection of one criteria.</param>
        /// <param name="func_CalculateSubSummary">The func_ calculate sub summary.</param>
        protected DateTimePivotContextBase(
            TCategoryCollection categoryCollection
            , TCollection entityCollection
            , Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteria
            , Func<TCategory, TCollection, TCollection> func_GetEntityCollectionOfOneCategory
            , Func<TCollection, TSummary> func_CalculateSummary
            , Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> func_GetEntityCollectionOfOneCriteria
            , Func<TCollection, TSubSummary> func_CalculateSubSummary
            )
        {
            this.CategoryCollection = categoryCollection;
            this.EntityCollection = entityCollection;
            this.Criteria = criteria;

            this.Func_CalculateSubSummary = func_CalculateSubSummary;
            this.Func_CalculateSummary = func_CalculateSummary;
            this.Func_GetEntityCollectionOfOneCategory = func_GetEntityCollectionOfOneCategory;
            this.Func_GetEntityCollectionOfOneCriteria = func_GetEntityCollectionOfOneCriteria;

            this.Summary = this.Func_CalculateSummary(this.EntityCollection);
        }

        #endregion constructors

        #region generic properties

        /// <summary>
        /// Gets the category collection.
        /// </summary>
        public TCategoryCollection CategoryCollection { get; private set; }

        /// <summary>
        /// Gets or sets the entity collection.
        /// </summary>
        /// <value>
        /// The entity collection.
        /// </value>
        public TCollection EntityCollection { get; private set; }

        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        public TSummary Summary { get; private set; }

        /// <summary>
        /// Gets the date time unit.
        /// </summary>
        public Framework.EntityContracts.QuerySystemDateTimeRangeCriteria Criteria { get; private set; }

        #endregion generic properties

        #region Functions

        /// <summary>
        /// Gets or sets the func_ get entity collection of one category.
        /// </summary>
        /// <value>
        /// The func_ get entity collection of one category.
        /// </value>
        Func<TCategory, TCollection, TCollection> Func_GetEntityCollectionOfOneCategory { get; set; }

        /// <summary>
        /// Gets or sets the func_ calculate summary.
        /// </summary>
        /// <value>
        /// The func_ calculate summary.
        /// </value>
        Func<TCollection, TSummary> Func_CalculateSummary { get; set; }

        /// <summary>
        /// Gets or sets the func_ get entity collection of one criteria.
        /// </summary>
        /// <value>
        /// The func_ get entity collection of one criteria.
        /// </value>
        Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> Func_GetEntityCollectionOfOneCriteria { get; set; }

        /// <summary>
        /// Gets or sets the func_ calculate sub summary.
        /// </summary>
        /// <value>
        /// The func_ calculate sub summary.
        /// </value>
        Func<TCollection, TSubSummary> Func_CalculateSubSummary { get; set; }

        #endregion Functions

        #region GetDateTimePerX...PivotBaseCollection(...)
        
        public Framework.EntityContracts.DateTimePivotEntities.DateTimePivotCollection<TCollection, T, TCategoryCollection, TCategory, TSubSummary> GetDateTimePerXIntervalTermPivotBaseCollection(
            Framework.EntityContracts.Queries.DateTimeUnit dateTimeUnit
            , int interval)
        {
            Framework.EntityContracts.DateTimePivotEntities.DateTimePivotCollection<TCollection, T, TCategoryCollection, TCategory, TSubSummary> _retval = new Framework.EntityContracts.DateTimePivotEntities.DateTimePivotCollection<TCollection, T, TCategoryCollection, TCategory, TSubSummary>(
                this.CategoryCollection
                , this.EntityCollection
                , this.Criteria
                , this.Func_GetEntityCollectionOfOneCategory
                , new DateTimePivotSetting(dateTimeUnit, interval)
                , this.Func_GetEntityCollectionOfOneCriteria
                , this.Func_CalculateSubSummary);
            return _retval;
        }

        #endregion GetDateTimePerX...PivotBaseCollection(...)
    }
}