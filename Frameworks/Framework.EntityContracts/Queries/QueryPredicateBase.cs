using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    [Obsolete("The original purpose is the utilize LinqKit predicate builder, retired.")]
    public abstract class QueryPredicateBase<TEntity>
    {
        /// <summary>
        /// Gets or sets the predicate types.
        /// </summary>
        /// <value>
        /// The predicate types.
        /// </value>
        protected QueryPredicateTypes PredicateTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity&gt;"/> class.
        /// </summary>
        public QueryPredicateBase()
        {
        }
    }

    /// <summary>
    ///  ??
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    /// <typeparam name="TQueryEqualCriteria">The type of the query equal criteria.</typeparam>
    [Obsolete("The original purpose is the utilize LinqKit predicate builder, retired.")]
	public abstract class QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria>
        : QueryPredicateBase<TEntity>
        where TEntity : class
        where TQueryEqualCriteria : QueryEqualsCriteriaBase<TValueType>, new()
    {
        #region Properties

        /// <summary>
        /// Gets or sets the query equal criteria.
        /// </summary>
        /// <value>
        /// The query equal criteria.
        /// </value>
        protected TQueryEqualCriteria QueryEqualCriteria { get; set; }

        #endregion Properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria&gt;"/> class.
        /// </summary>
        public QueryPredicateBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryEqualCriteria criteria)
            : base()
        {
            this.PredicateTypes = QueryPredicateTypes.Equals;
            this.QueryEqualCriteria = criteria;
        }

        #endregion constructors
    }

    /// <summary>
    /// ??
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    /// <typeparam name="TQueryEqualCriteria">The type of the query equal criteria.</typeparam>
    /// <typeparam name="TQueryInSelectedListCriteria">The type of the query in selected list criteria.</typeparam>
    public abstract class QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria>
        : QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria>
        where TEntity : class
        where TQueryEqualCriteria : QueryEqualsCriteriaBase<TValueType>, new()
        where TQueryInSelectedListCriteria : QueryInSelectedListCriteriaBase<TValueType>, new()
    {
        #region Properties

        /// <summary>
        /// Gets or sets the query in selected list criteria.
        /// </summary>
        /// <value>
        /// The query in selected list criteria.
        /// </value>
        protected TQueryInSelectedListCriteria QueryInSelectedListCriteria { get; set; }

        #endregion Properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria&gt;"/> class.
        /// </summary>
        public QueryPredicateBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryEqualCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryInSelectedListCriteria criteria)
            : base()
        {
            this.PredicateTypes = QueryPredicateTypes.InSelectedList;
            this.QueryInSelectedListCriteria = criteria;
        }

        #endregion constructors
    }

    /// <summary>
    /// ??
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    /// <typeparam name="TQueryEqualCriteria">The type of the query equal criteria.</typeparam>
    /// <typeparam name="TQueryInSelectedListCriteria">The type of the query in selected list criteria.</typeparam>
    /// <typeparam name="TQueryInRangeCriteria">The type of the query in range criteria.</typeparam>
    [Obsolete("The original purpose is the utilize LinqKit predicate builder, retired.")]
    public abstract class QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria>
        : QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria>
        where TEntity : class
        where TQueryEqualCriteria : QueryEqualsCriteriaBase<TValueType>, new()
        where TQueryInSelectedListCriteria : QueryInSelectedListCriteriaBase<TValueType>, new()
        where TQueryInRangeCriteria : QueryRangeCriteriaBase<TValueType>, new()
    {
        #region Properties

        /// <summary>
        /// Gets or sets the query in range criteria.
        /// </summary>
        /// <value>
        /// The query in range criteria.
        /// </value>
        protected TQueryInRangeCriteria QueryInRangeCriteria { get; set; }

        #endregion Properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria&gt;"/> class.
        /// </summary>
        public QueryPredicateBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryEqualCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryInSelectedListCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryInRangeCriteria criteria)
            : base()
        {
            this.PredicateTypes = QueryPredicateTypes.InRange;
            this.QueryInRangeCriteria = criteria;
        }

        #endregion constructors
    }

    /// <summary>
    /// ??
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    /// <typeparam name="TQueryEqualCriteria">The type of the query equal criteria.</typeparam>
    /// <typeparam name="TQueryInSelectedListCriteria">The type of the query in selected list criteria.</typeparam>
    /// <typeparam name="TQueryInRangeCriteria">The type of the query in range criteria.</typeparam>
    /// <typeparam name="TQueryContainsCriteria">The type of the query contains criteria.</typeparam>
    [Obsolete("The original purpose is the utilize LinqKit predicate builder, retired.")]
    public abstract class QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria>
        : QueryPredicateBase<TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria>
        where TEntity : class
        where TQueryEqualCriteria : QueryEqualsCriteriaBase<TValueType>, new()
        where TQueryInSelectedListCriteria : QueryInSelectedListCriteriaBase<TValueType>, new()
        where TQueryInRangeCriteria : QueryRangeCriteriaBase<TValueType>, new()
        where TQueryContainsCriteria : QueryContainsCriteriaBase<TValueType>, new()
    {
        #region Properties

        /// <summary>
        /// Gets or sets the query contains criteria.
        /// </summary>
        /// <value>
        /// The query contains criteria.
        /// </value>
        protected TQueryContainsCriteria QueryContainsCriteria { get; set; }

        #endregion Properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria&gt;"/> class.
        /// </summary>
        public QueryPredicateBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryEqualCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryInSelectedListCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryInRangeCriteria criteria)
            : base(criteria)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPredicateBase&lt;TEntity, TValueType, TQueryEqualCriteria, TQueryInSelectedListCriteria, TQueryInRangeCriteria, TQueryContainsCriteria&gt;"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public QueryPredicateBase(TQueryContainsCriteria criteria)
            : base()
        {
            this.PredicateTypes = QueryPredicateTypes.Contains;
            this.QueryContainsCriteria = criteria;
        }
        
        #endregion constructors
    }
}