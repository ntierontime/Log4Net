using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.EntityContracts;
using Framework;

namespace Log4Net.CommonBLLEntities
{

    /// <summary>
    /// BusinessLogicLayerQueryCriteria, key=Common
    /// </summary>
    public class BusinessLogicLayerQueryCriteriaEntityLogCommon
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogCommon"/> class.
        /// </summary>
		public BusinessLogicLayerQueryCriteriaEntityLogCommon()
		{
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogCommon"/> class.
        /// </summary>
        /// <param name="QuerySystemDateTimeRangeCriteria">Initialize criteria of Date</param>
        /// <param name="QuerySystemStringContainsCriteria">Initialize criteria of Thread</param>
        /// <param name="QuerySystemStringContainsCriteria">Initialize criteria of Level</param>
        /// <param name="QuerySystemStringContainsCriteria">Initialize criteria of Logger</param>
        /// <param name="QuerySystemStringContainsCriteria">Initialize criteria of Message</param>
        /// <param name="QuerySystemStringContainsCriteria">Initialize criteria of Exception</param>
		public BusinessLogicLayerQueryCriteriaEntityLogCommon(
			QuerySystemDateTimeRangeCriteria dateCommonOft
			, QuerySystemStringContainsCriteria threadCommonOft
			, QuerySystemStringContainsCriteria levelCommonOft
			, QuerySystemStringContainsCriteria loggerCommonOft
			, QuerySystemStringContainsCriteria messageCommonOft
			, QuerySystemStringContainsCriteria exceptionCommonOft
			)
		{
			this.DateCommonOft = dateCommonOft;
			this.ThreadCommonOft = threadCommonOft;
			this.LevelCommonOft = levelCommonOft;
			this.LoggerCommonOft = loggerCommonOft;
			this.MessageCommonOft = messageCommonOft;
			this.ExceptionCommonOft = exceptionCommonOft;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogCommon"/> class.
        /// </summary>
        /// <param name="isToCompareDateCommonOft">will compare/filter DateCommonOft property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOft">will compare/filter to lower bound of DateCommonOft property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOft">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOft">will compare/filter to upper bound of DateCommonOft property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOft">upper bound</param>
        /// <param name="isToCompareThreadCommonOft">will compare/filter ThreadCommonOft property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOft">value to compare/filter with ThreadCommonOft property/field/column</param>
        /// <param name="isToCompareLevelCommonOft">will compare/filter LevelCommonOft property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOft">value to compare/filter with LevelCommonOft property/field/column</param>
        /// <param name="isToCompareLoggerCommonOft">will compare/filter LoggerCommonOft property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOft">value to compare/filter with LoggerCommonOft property/field/column</param>
        /// <param name="isToCompareMessageCommonOft">will compare/filter MessageCommonOft property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOft">value to compare/filter with MessageCommonOft property/field/column</param>
        /// <param name="isToCompareExceptionCommonOft">will compare/filter ExceptionCommonOft property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOft">value to compare/filter with ExceptionCommonOft property/field/column</param>
		public BusinessLogicLayerQueryCriteriaEntityLogCommon(
			bool isToCompareDateCommonOft, bool isToCompareLowerBoundDateCommonOft, System.DateTime lowerBoundDateCommonOft, bool isToCompareUpperBoundDateCommonOft, System.DateTime upperBoundDateCommonOft
			, bool isToCompareThreadCommonOft, System.String valueToBeContainedThreadCommonOft
			, bool isToCompareLevelCommonOft, System.String valueToBeContainedLevelCommonOft
			, bool isToCompareLoggerCommonOft, System.String valueToBeContainedLoggerCommonOft
			, bool isToCompareMessageCommonOft, System.String valueToBeContainedMessageCommonOft
			, bool isToCompareExceptionCommonOft, System.String valueToBeContainedExceptionCommonOft
			)
			: this(
				new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOft, isToCompareLowerBoundDateCommonOft, lowerBoundDateCommonOft, isToCompareUpperBoundDateCommonOft, upperBoundDateCommonOft)
				, new QuerySystemStringContainsCriteria(isToCompareThreadCommonOft, valueToBeContainedThreadCommonOft)
				, new QuerySystemStringContainsCriteria(isToCompareLevelCommonOft, valueToBeContainedLevelCommonOft)
				, new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOft, valueToBeContainedLoggerCommonOft)
				, new QuerySystemStringContainsCriteria(isToCompareMessageCommonOft, valueToBeContainedMessageCommonOft)
				, new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOft, valueToBeContainedExceptionCommonOft)
				)
		{
		}


		#endregion constructors

		#region Propertyies


        /// <summary>
        /// criteria of Date, filter type: Range
        /// </summary>
        public QuerySystemDateTimeRangeCriteria DateCommonOft { get; set; }

        /// <summary>
        /// criteria of Thread, filter type: Contains
        /// </summary>
        public QuerySystemStringContainsCriteria ThreadCommonOft { get; set; }

        /// <summary>
        /// criteria of Level, filter type: Contains
        /// </summary>
        public QuerySystemStringContainsCriteria LevelCommonOft { get; set; }

        /// <summary>
        /// criteria of Logger, filter type: Contains
        /// </summary>
        public QuerySystemStringContainsCriteria LoggerCommonOft { get; set; }

        /// <summary>
        /// criteria of Message, filter type: Contains
        /// </summary>
        public QuerySystemStringContainsCriteria MessageCommonOft { get; set; }

        /// <summary>
        /// criteria of Exception, filter type: Contains
        /// </summary>
        public QuerySystemStringContainsCriteria ExceptionCommonOft { get; set; }

		#endregion Propertyies
	}


    /// <summary>
    /// BusinessLogicLayerQueryCriteria, key=All
    /// </summary>
    public class BusinessLogicLayerQueryCriteriaEntityLogAll
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogAll"/> class.
        /// </summary>
		public BusinessLogicLayerQueryCriteriaEntityLogAll()
		{
		}


		#endregion constructors

		#region Propertyies



		#endregion Propertyies
	}


    /// <summary>
    /// BusinessLogicLayerQueryCriteria, key=ByIdentifier
    /// </summary>
    public class BusinessLogicLayerQueryCriteriaEntityLogByIdentifier
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>
		public BusinessLogicLayerQueryCriteriaEntityLogByIdentifier()
		{
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>
        /// <param name="QuerySystemInt64EqualsCriteria">Initialize criteria of Id</param>
		public BusinessLogicLayerQueryCriteriaEntityLogByIdentifier(
			QuerySystemInt64EqualsCriteria idByIdentifierOft
			)
		{
			this.IdByIdentifierOft = idByIdentifierOft;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOft">will compare/filter IdByIdentifierOft property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOft">value to compare/filter with IdByIdentifierOft property/field/column</param>
		public BusinessLogicLayerQueryCriteriaEntityLogByIdentifier(
			bool isToCompareIdByIdentifierOft, System.Int64 valueToCompareIdByIdentifierOft
			)
			: this(
				new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOft, valueToCompareIdByIdentifierOft)
				)
		{
		}


		#endregion constructors

		#region Propertyies


        /// <summary>
        /// criteria of Id, filter type: Equals
        /// </summary>
        public QuerySystemInt64EqualsCriteria IdByIdentifierOft { get; set; }

		#endregion Propertyies
	}


}