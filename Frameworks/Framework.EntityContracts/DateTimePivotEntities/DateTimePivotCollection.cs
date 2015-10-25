using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts.DateTimePivotEntities
{
    /// <summary>
    /// base class of datetime pivot collections
    /// </summary>
    /// <typeparam name="TDateTimePivot">The type of the date time pivot.</typeparam>
    /// <typeparam name="TCollection">The type of the entity collection.</typeparam>
    /// <typeparam name="T">the type of the entity</typeparam>
    /// <typeparam name="TCategory">The type of the category.</typeparam>
    public class DateTimePivotCollection<TCollection, T, TCategoryCollection, TCategory, TSubSummary>
        : List<Framework.EntityContracts.DateTimePivotEntities.DateTimePivot<TCollection, T, TCategory, TSubSummary>>
        where TCollection : List<T>, new()
        where T : new()
        where TCategoryCollection : List<TCategory>, new()
        where TCategory : class, new()
        where TSubSummary : class, new()
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotCollectionBase&lt;TCollection, T, TCategory&gt;"/> class.
        /// </summary>
        public DateTimePivotCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotCollectionBase&lt;TCollection, T, TCategory, TSubSummary&gt;"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public DateTimePivotCollection(IEnumerable<Framework.EntityContracts.DateTimePivotEntities.DateTimePivot<TCollection, T, TCategory, TSubSummary>> input)
            : base(input)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotCollection&lt;TCollection, T, TCategoryCollection, TCategory, TSubSummary&gt;"/> class.
        /// </summary>
        /// <param name="categoryCollection">The category collection.</param>
        /// <param name="entityCollection">The entity collection.</param>
        /// <param name="func_GetEntityCollectionOfOneCategory">The func_ get entity collection of one category.</param>
        /// <param name="dateTimePivotSetting">The date time pivot setting.</param>
        /// <param name="func_GetEntityCollectionOfOneCriteria">The func_ get entity collection of one criteria.</param>
        /// <param name="func_CalculateSubSummary">The func_ calculate sub summary.</param>
        public DateTimePivotCollection(
            TCategoryCollection categoryCollection
            , TCollection entityCollection
            , Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteria
            , Func<TCategory, TCollection, TCollection> func_GetEntityCollectionOfOneCategory
            , Framework.EntityContracts.DateTimePivotEntities.DateTimePivotSetting dateTimePivotSetting
            , Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> func_GetEntityCollectionOfOneCriteria
            , Func<TCollection, TSubSummary> func_CalculateSubSummary
            )
        {
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria[] _ConsecutiveDistributionCriteria = dateTimePivotSetting.CalculateConsecutiveDistributionCriteria(criteria);
            // some problems here.
            foreach (TCategory _Category in categoryCollection)
            {
                this.Add(_Category, func_GetEntityCollectionOfOneCategory(_Category, entityCollection), criteria, dateTimePivotSetting.DateTimeUnitOfInterval, dateTimePivotSetting.Interval);
            }

            foreach (var _OneItem in this)
            {
                List<TCollection> _Distributed = new List<TCollection>();
                foreach (var _OneCriteria in _ConsecutiveDistributionCriteria)
                {
                    _Distributed.Add(_OneItem.GetEntityCollectionOfOneCriteria(_OneCriteria, func_GetEntityCollectionOfOneCriteria));
                }
                _OneItem.DistributedEntityCollection = _Distributed.ToArray();
                _OneItem.SubSummary = _OneItem.CalculateSubSummary(func_CalculateSubSummary);
            }
        }

        #endregion constructors

        #region void Add(...)

        /// <summary>
        /// Adds the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="entityCollection">The entity collection.</param>
        /// <param name="criteria">The criteria.</param>
        protected void Add(
            TCategory category
            , TCollection entityCollection
            , Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteria
            , Framework.EntityContracts.Queries.DateTimeUnit dateTimeUnitOfInterval
            , int interval
            )
        {
            if (category != null && criteria != null)
            {
                Framework.EntityContracts.DateTimePivotEntities.DateTimePivot<TCollection, T, TCategory, TSubSummary> _One = new Framework.EntityContracts.DateTimePivotEntities.DateTimePivot<TCollection, T, TCategory, TSubSummary>(category, entityCollection, (new DateTimePivotSetting(dateTimeUnitOfInterval, interval)).CalculateConsecutiveDistributionCriteria(criteria));

                this.Add(_One);
            }
        }

        #endregion void Add(...)
    }
}