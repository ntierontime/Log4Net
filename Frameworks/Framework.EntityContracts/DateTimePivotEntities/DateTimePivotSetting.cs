using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts.DateTimePivotEntities
{
    /// <summary>
    /// DateTimePivotSetting with following properties:
    ///     1. Criteria
    ///     2. DateTimeUnitOfInterval
    ///     3. Interval
    /// </summary>
    public class DateTimePivotSetting
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotSetting"/> class.
        /// </summary>
        public DateTimePivotSetting()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePivotSetting"/> class.
        /// </summary>
        /// <param name="dateTimeUnitOfInterval">The date time unit of interval.</param>
        /// <param name="interval">The interval.</param>
        public DateTimePivotSetting(
            Framework.EntityContracts.Queries.DateTimeUnit dateTimeUnitOfInterval,
            System.Int32 interval
            )
        {
            this.DateTimeUnitOfInterval = dateTimeUnitOfInterval;
            this.Interval = interval;
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the date time unit of interval.
        /// </summary>
        /// <value>
        /// The date time unit of interval.
        /// </value>
        public Framework.EntityContracts.Queries.DateTimeUnit DateTimeUnitOfInterval { get; private set; }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval { get; private set; }

        #endregion properties

        #region CalculateConsecutiveDistributionCriteria(...)

        /// <summary>
        /// Calculates the consecutive distribution criteria.
        /// </summary>
        /// <returns></returns>
        public Framework.EntityContracts.QuerySystemDateTimeRangeCriteria[] CalculateConsecutiveDistributionCriteria(Framework.EntityContracts.QuerySystemDateTimeRangeCriteria criteria)
        {
            return criteria.CalculateConsecutiveDistributionCriteria(this.DateTimeUnitOfInterval, this.Interval);
        }

        #endregion CalculateConsecutiveDistributionCriteria(...)

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("DateTimeUnitOfInterval:{0};Interval:{1};", this.DateTimeUnitOfInterval, this.Interval);
        }

        #endregion override string ToString()
    }
}