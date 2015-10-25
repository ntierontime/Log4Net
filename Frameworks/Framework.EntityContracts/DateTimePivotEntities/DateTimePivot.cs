using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts.DateTimePivotEntities
{

    /// <summary>
    /// base class of all datetime pivot entities
    /// </summary>
    /// <typeparam name="TCollection">The type of the entity collection.</typeparam>
    /// <typeparam name="T">The type of the entity</typeparam>
    /// <typeparam name="TCategory">The type of the category.</typeparam>
    /// <typeparam name="TSubSummary">The type of the sub summary.</typeparam>
    public class DateTimePivot<TCollection, T, TCategory, TSubSummary>
        where TCollection : List<T>, new()
        where T : new()
        where TCategory : class, new()
        where TSubSummary : class, new()

    {
        #region Constructors

        public DateTimePivot()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivot&lt;TCollection, T, TCategory, TSubSummary&gt;"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="entityCollection">The entity collection.</param>
        /// <param name="dateTimePivotSetting">The date time pivot setting.</param>
        public DateTimePivot(
            TCategory category
            , TCollection entityCollection
            , Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteria
            , Framework.EntityContracts.DateTimePivotEntities.DateTimePivotSetting dateTimePivotSetting)
            : this(category, entityCollection, dateTimePivotSetting.CalculateConsecutiveDistributionCriteria(criteria))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivot&lt;TCollection, T, TCategory, TSubSummary&gt;"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="entityCollection">The entity collection.</param>
        /// <param name="dateTimePivotSetting">The date time pivot setting.</param>
        /// <param name="consecutiveDistributionCriteria">The consecutive distribution criteria.</param>
        public DateTimePivot(
            TCategory category
            , TCollection entityCollection
            , Framework.EntityContracts.QuerySystemDateTimeRangeCriteria[] consecutiveDistributionCriteria)
        {
            this.Category = category;
            this.EntityCollection = entityCollection;
            this.DistributeEntityCollection(consecutiveDistributionCriteria);
        }

        #endregion Constructors

        #region properties

        #region query configuration

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public TCategory Category { get; set; }
        
        #endregion query configuration

        #region result raw data from data source

        /// <summary>
        /// Gets or sets the entity collection.
        /// </summary>
        /// <value>
        /// The entity collection.
        /// </value>
        public TCollection EntityCollection { get; set; }

        #endregion result raw data from data source

        #region distributed entity collection

        /// <summary>
        /// Gets or sets the distributed entity collection, according EntityCollection.
        /// </summary>
        /// <value>
        /// The distributed entity collection.
        /// </value>
        public TCollection[] DistributedEntityCollection { get; set; }

        #endregion distributed entity collection

        #region calculated sub summary data

        /// <summary>
        /// Gets or sets the sub summary, calculated from EntityCollection.
        /// </summary>
        /// <value>
        /// The sub summary.
        /// </value>
        public TSubSummary SubSummary { get; set; }

        #endregion calculated sub summary data
        
        #endregion properties
        
        #region void DistributeEntityCollection(...)

        /// <summary>
        /// Distributes the entity collection according to ConsecutiveDistributionCriteria.
        /// </summary>
        public void DistributeEntityCollection(Framework.EntityContracts.QuerySystemDateTimeRangeCriteria[] _ConsecutiveDistributionCriteria)
        {
            TCollection _EntityCollection = this.EntityCollection;
            Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> _Func_GetEntityCollectionOfOneCriteria = this.Func_GetEntityCollectionOfOneCriteria;
            List<TCollection> _DistributeEntityCollection = new List<TCollection>();
            this.DistributedEntityCollection = DistributeEntityCollection(_EntityCollection, _ConsecutiveDistributionCriteria, _Func_GetEntityCollectionOfOneCriteria);
        }

        /// <summary>
        /// Distributes the entity collection.
        /// </summary>
        /// <param name="_EntityCollection">The _ entity collection.</param>
        /// <param name="_ConsecutiveDistributionCriteria">The _ consecutive distribution criteria.</param>
        /// <param name="_Func_GetEntityCollectionOfOneCriteria">The _ func_ get entity collection of one criteria.</param>
        /// <returns>distributed  entity collection according to ConsecutiveDistributionCriteria.</returns>
        public static TCollection[] DistributeEntityCollection(TCollection _EntityCollection, Framework.EntityContracts.QuerySystemDateTimeRangeCriteria[] _ConsecutiveDistributionCriteria, Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> _Func_GetEntityCollectionOfOneCriteria)
        {
            List<TCollection> _DistributeEntityCollection = new List<TCollection>();
            if (_Func_GetEntityCollectionOfOneCriteria != null)
            {
                if (_EntityCollection != null && _EntityCollection.Count > 0 &&
                    _ConsecutiveDistributionCriteria != null && _ConsecutiveDistributionCriteria.Length > 0)
                {
                    foreach (Framework.EntityContracts.QuerySystemDateTimeRangeCriteria _OneCriteria in _ConsecutiveDistributionCriteria)
                    {
                        TCollection _OneCollection = _Func_GetEntityCollectionOfOneCriteria(_OneCriteria, _EntityCollection);
                        _DistributeEntityCollection.Add(_OneCollection);
                    }
                }
            }
            return _DistributeEntityCollection.ToArray();
        }

        #endregion void DistributeEntityCollection()

        #region GetEntityCollectionOfOneCriteria(...)

        Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> Func_GetEntityCollectionOfOneCriteria = null;

        /// <summary>
        /// Gets the entity collection of one criteria.
        /// </summary>
        /// <param name="oneCriteria">The one criteria.</param>
        /// <param name="func_GetEntityCollectionOfOneCriteria">The func_ get entity collection of one criteria.</param>
        /// <returns>entity Collection meets criteria</returns>
        public virtual TCollection GetEntityCollectionOfOneCriteria(
            Framework.EntityContracts.QuerySystemDateTimeRangeCriteria oneCriteria
            , Func<Framework.EntityContracts.QuerySystemDateTimeRangeCriteria, TCollection, TCollection> func_GetEntityCollectionOfOneCriteria)
        {
            this.Func_GetEntityCollectionOfOneCriteria = func_GetEntityCollectionOfOneCriteria;
            return this.GetEntityCollectionOfOneCriteria(oneCriteria);
        }

        /// <summary>
        /// Gets the entity collection of one criteria.
        /// </summary>
        /// <param name="oneCriteria">The one criteria.</param>
        /// <returns>entity Collection meets criteria</returns>
        public virtual TCollection GetEntityCollectionOfOneCriteria(Framework.EntityContracts.QuerySystemDateTimeRangeCriteria oneCriteria)
        {
            return this.Func_GetEntityCollectionOfOneCriteria(oneCriteria, this.EntityCollection);
        }

        #endregion GetEntityCollectionOfOneCriteria(...)

        #region CalculateSubSummary(...)

        Func<TCollection, TSubSummary> Func_CalculateSubSummary = null;

        /// <summary>
        /// Calculates the sub summary.
        /// </summary>
        /// <param name="func_CalculateSubSummary">The func_ calculate sub summary.</param>
        /// <returns>Sub Summary</returns>
        public virtual TSubSummary CalculateSubSummary(Func<TCollection, TSubSummary> func_CalculateSubSummary)
        {
            this.Func_CalculateSubSummary = func_CalculateSubSummary;
            return this.CalculateSubSummary();
        }

        /// <summary>
        /// Calculates the sub summary of EntityCollection.
        /// </summary>
        /// <returns>Sub Summary</returns>
        public virtual TSubSummary CalculateSubSummary()
        {
            return this.Func_CalculateSubSummary(this.EntityCollection);
        }

        #endregion CalculateSubSummary(...)

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Category={0}//SubSummary={1}", this.Category == null ? "(null)" : this.Category.ToString(), this.Category == null ? "(null)" : this.SubSummary.ToString());
        }

        #endregion override string ToString()
    }
}