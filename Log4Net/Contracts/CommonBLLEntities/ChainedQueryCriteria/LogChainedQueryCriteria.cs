using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.EntityContracts;
using Framework;

namespace Log4Net.CommonBLLEntities
{

    /// <summary>
    /// BusinessLogicLayerChainedQueryCriteria, key=Common
    /// </summary>
    public class LogChainedQueryCriteriaCommon
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommon"/> class.
        /// </summary>
        public LogChainedQueryCriteriaCommon()
            : this(new LogChainedQueryCriteriaCommonFlatten())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommon"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public LogChainedQueryCriteriaCommon(LogChainedQueryCriteriaCommonFlatten input)
            : this(
                input.IsToCompareDateCommonOftOfCommon, input.IsToCompareLowerBoundDateCommonOftOfCommon, input.LowerBoundDateCommonOftOfCommon.HasValue ? input.LowerBoundDateCommonOftOfCommon.Value : DateTime.Now, input.IsToCompareUpperBoundDateCommonOftOfCommon, input.UpperBoundDateCommonOftOfCommon.HasValue ? input.UpperBoundDateCommonOftOfCommon.Value : DateTime.Now
                , input.IsToCompareThreadCommonOftOfCommon, input.ValueToBeContainedThreadCommonOftOfCommon
                , input.IsToCompareLevelCommonOftOfCommon, input.ValueToBeContainedLevelCommonOftOfCommon
                , input.IsToCompareLoggerCommonOftOfCommon, input.ValueToBeContainedLoggerCommonOftOfCommon
                , input.IsToCompareMessageCommonOftOfCommon, input.ValueToBeContainedMessageCommonOftOfCommon
                , input.IsToCompareExceptionCommonOftOfCommon, input.ValueToBeContainedExceptionCommonOftOfCommon
            )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommon"/> class.
        /// </summary>

        public LogChainedQueryCriteriaCommon(
            LogQueryCriteriaCommon logQueryCriteriaCommon
            )
        {
            this.LogQueryCriteriaCommon = logQueryCriteriaCommon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommon"/> class.
        /// </summary>
        /// <param name="dateCommonOftOfCommon">Initialize criteria of DateCommonOftOfCommon</param>
        /// <param name="threadCommonOftOfCommon">Initialize criteria of ThreadCommonOftOfCommon</param>
        /// <param name="levelCommonOftOfCommon">Initialize criteria of LevelCommonOftOfCommon</param>
        /// <param name="loggerCommonOftOfCommon">Initialize criteria of LoggerCommonOftOfCommon</param>
        /// <param name="messageCommonOftOfCommon">Initialize criteria of MessageCommonOftOfCommon</param>
        /// <param name="exceptionCommonOftOfCommon">Initialize criteria of ExceptionCommonOftOfCommon</param>
        public LogChainedQueryCriteriaCommon(
            QuerySystemDateTimeRangeCriteria dateCommonOftOfCommon
            , QuerySystemStringContainsCriteria threadCommonOftOfCommon
            , QuerySystemStringContainsCriteria levelCommonOftOfCommon
            , QuerySystemStringContainsCriteria loggerCommonOftOfCommon
            , QuerySystemStringContainsCriteria messageCommonOftOfCommon
            , QuerySystemStringContainsCriteria exceptionCommonOftOfCommon
            )
            : this(
            new LogQueryCriteriaCommon(dateCommonOftOfCommon,threadCommonOftOfCommon,levelCommonOftOfCommon,loggerCommonOftOfCommon,messageCommonOftOfCommon,exceptionCommonOftOfCommon)
                )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommon"/> class.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        public LogChainedQueryCriteriaCommon(
            bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime? lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime? upperBoundDateCommonOftOfCommon
            , bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
            , bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
            , bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
            , bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
            , bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
            )
            : this(
            new QuerySystemDateTimeRangeCriteria(isToCompareDateCommonOftOfCommon, isToCompareLowerBoundDateCommonOftOfCommon, lowerBoundDateCommonOftOfCommon, isToCompareUpperBoundDateCommonOftOfCommon, upperBoundDateCommonOftOfCommon)
            , new QuerySystemStringContainsCriteria(isToCompareThreadCommonOftOfCommon, valueToBeContainedThreadCommonOftOfCommon)
            , new QuerySystemStringContainsCriteria(isToCompareLevelCommonOftOfCommon, valueToBeContainedLevelCommonOftOfCommon)
            , new QuerySystemStringContainsCriteria(isToCompareLoggerCommonOftOfCommon, valueToBeContainedLoggerCommonOftOfCommon)
            , new QuerySystemStringContainsCriteria(isToCompareMessageCommonOftOfCommon, valueToBeContainedMessageCommonOftOfCommon)
            , new QuerySystemStringContainsCriteria(isToCompareExceptionCommonOftOfCommon, valueToBeContainedExceptionCommonOftOfCommon)
                )
        {
        }

        #endregion constructors

        #region Propertyies

        /// <summary>
        /// DataQueryPerQuerySetting, key is Common
        /// </summary>
        public LogQueryCriteriaCommon LogQueryCriteriaCommon { get; set; }
        #endregion Propertyies
    }

    public class LogChainedQueryCriteriaCommonFlatten
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommonFlatten"/> class.
        /// </summary>
        public LogChainedQueryCriteriaCommonFlatten()
        {
            this.IsToCompareDateCommonOftOfCommon= false; this.IsToCompareLowerBoundDateCommonOftOfCommon=false;this.LowerBoundDateCommonOftOfCommon=DateTime.Now;this.IsToCompareUpperBoundDateCommonOftOfCommon=false;this.UpperBoundDateCommonOftOfCommon=DateTime.Now;
            this.IsToCompareThreadCommonOftOfCommon= false; this.ValueToBeContainedThreadCommonOftOfCommon= null;
            this.IsToCompareLevelCommonOftOfCommon= false; this.ValueToBeContainedLevelCommonOftOfCommon= null;
            this.IsToCompareLoggerCommonOftOfCommon= false; this.ValueToBeContainedLoggerCommonOftOfCommon= null;
            this.IsToCompareMessageCommonOftOfCommon= false; this.ValueToBeContainedMessageCommonOftOfCommon= null;
            this.IsToCompareExceptionCommonOftOfCommon= false; this.ValueToBeContainedExceptionCommonOftOfCommon= null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommonFlatten"/> class.
        /// </summary>
        /// <param name="isToCompareDateCommonOftOfCommon">will compare/filter DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="isToCompareLowerBoundDateCommonOftOfCommon">will compare/filter to lower bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="lowerBoundDateCommonOftOfCommon">value of lower bound</param>
        /// <param name="isToCompareUpperBoundDateCommonOftOfCommon">will compare/filter to upper bound of DateCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="upperBoundDateCommonOftOfCommon">upper bound</param>
        /// <param name="isToCompareThreadCommonOftOfCommon">will compare/filter ThreadCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedThreadCommonOftOfCommon">value to compare/filter with ThreadCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLevelCommonOftOfCommon">will compare/filter LevelCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLevelCommonOftOfCommon">value to compare/filter with LevelCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareLoggerCommonOftOfCommon">will compare/filter LoggerCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedLoggerCommonOftOfCommon">value to compare/filter with LoggerCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareMessageCommonOftOfCommon">will compare/filter MessageCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedMessageCommonOftOfCommon">value to compare/filter with MessageCommonOftOfCommon property/field/column</param>
        /// <param name="isToCompareExceptionCommonOftOfCommon">will compare/filter ExceptionCommonOftOfCommon property/field/column if true, otherwise false</param>
        /// <param name="valueToBeContainedExceptionCommonOftOfCommon">value to compare/filter with ExceptionCommonOftOfCommon property/field/column</param>
        public LogChainedQueryCriteriaCommonFlatten(
            bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime? lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime? upperBoundDateCommonOftOfCommon
            , bool isToCompareThreadCommonOftOfCommon, System.String valueToBeContainedThreadCommonOftOfCommon
            , bool isToCompareLevelCommonOftOfCommon, System.String valueToBeContainedLevelCommonOftOfCommon
            , bool isToCompareLoggerCommonOftOfCommon, System.String valueToBeContainedLoggerCommonOftOfCommon
            , bool isToCompareMessageCommonOftOfCommon, System.String valueToBeContainedMessageCommonOftOfCommon
            , bool isToCompareExceptionCommonOftOfCommon, System.String valueToBeContainedExceptionCommonOftOfCommon
            )
        {
            this.IsToCompareDateCommonOftOfCommon= isToCompareDateCommonOftOfCommon; this.IsToCompareLowerBoundDateCommonOftOfCommon=isToCompareLowerBoundDateCommonOftOfCommon;this.LowerBoundDateCommonOftOfCommon=lowerBoundDateCommonOftOfCommon;this.IsToCompareUpperBoundDateCommonOftOfCommon=isToCompareUpperBoundDateCommonOftOfCommon;this.UpperBoundDateCommonOftOfCommon=upperBoundDateCommonOftOfCommon;
            this.IsToCompareThreadCommonOftOfCommon= isToCompareThreadCommonOftOfCommon; this.ValueToBeContainedThreadCommonOftOfCommon= valueToBeContainedThreadCommonOftOfCommon;
            this.IsToCompareLevelCommonOftOfCommon= isToCompareLevelCommonOftOfCommon; this.ValueToBeContainedLevelCommonOftOfCommon= valueToBeContainedLevelCommonOftOfCommon;
            this.IsToCompareLoggerCommonOftOfCommon= isToCompareLoggerCommonOftOfCommon; this.ValueToBeContainedLoggerCommonOftOfCommon= valueToBeContainedLoggerCommonOftOfCommon;
            this.IsToCompareMessageCommonOftOfCommon= isToCompareMessageCommonOftOfCommon; this.ValueToBeContainedMessageCommonOftOfCommon= valueToBeContainedMessageCommonOftOfCommon;
            this.IsToCompareExceptionCommonOftOfCommon= isToCompareExceptionCommonOftOfCommon; this.ValueToBeContainedExceptionCommonOftOfCommon= valueToBeContainedExceptionCommonOftOfCommon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaCommonFlatten"/> class.
        /// </summary>
        public LogChainedQueryCriteriaCommonFlatten(LogChainedQueryCriteriaCommon input)
            : this(
            input.LogQueryCriteriaCommon.DateCommonOft.IsToCompare, input.LogQueryCriteriaCommon.DateCommonOft.IsToCompareLowerBound, input.LogQueryCriteriaCommon.DateCommonOft.LowerBound, input.LogQueryCriteriaCommon.DateCommonOft.IsToCompareUpperBound, input.LogQueryCriteriaCommon.DateCommonOft.UpperBound
            , input.LogQueryCriteriaCommon.ThreadCommonOft.IsToCompare, input.LogQueryCriteriaCommon.ThreadCommonOft.ValueToBeContained
            , input.LogQueryCriteriaCommon.LevelCommonOft.IsToCompare, input.LogQueryCriteriaCommon.LevelCommonOft.ValueToBeContained
            , input.LogQueryCriteriaCommon.LoggerCommonOft.IsToCompare, input.LogQueryCriteriaCommon.LoggerCommonOft.ValueToBeContained
            , input.LogQueryCriteriaCommon.MessageCommonOft.IsToCompare, input.LogQueryCriteriaCommon.MessageCommonOft.ValueToBeContained
            , input.LogQueryCriteriaCommon.ExceptionCommonOft.IsToCompare, input.LogQueryCriteriaCommon.ExceptionCommonOft.ValueToBeContained
            )
        {
        }

        #endregion constructors

        #region Propertyies

        public bool IsToCompareDateCommonOftOfCommon { get; set; } public bool IsToCompareLowerBoundDateCommonOftOfCommon { get; set; } public System.DateTime? LowerBoundDateCommonOftOfCommon { get; set; } public bool IsToCompareUpperBoundDateCommonOftOfCommon { get; set; } public System.DateTime? UpperBoundDateCommonOftOfCommon { get; set; }
        public bool IsToCompareThreadCommonOftOfCommon { get; set; } public System.String ValueToBeContainedThreadCommonOftOfCommon { get; set; }
        public bool IsToCompareLevelCommonOftOfCommon { get; set; } public System.String ValueToBeContainedLevelCommonOftOfCommon { get; set; }
        public bool IsToCompareLoggerCommonOftOfCommon { get; set; } public System.String ValueToBeContainedLoggerCommonOftOfCommon { get; set; }
        public bool IsToCompareMessageCommonOftOfCommon { get; set; } public System.String ValueToBeContainedMessageCommonOftOfCommon { get; set; }
        public bool IsToCompareExceptionCommonOftOfCommon { get; set; } public System.String ValueToBeContainedExceptionCommonOftOfCommon { get; set; }

        #endregion Propertyies
    }

    /// <summary>
    /// BusinessLogicLayerChainedQueryCriteria, key=All
    /// </summary>
    public class LogChainedQueryCriteriaAll
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaAll"/> class.
        /// </summary>
        public LogChainedQueryCriteriaAll()

        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaAll"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public LogChainedQueryCriteriaAll(LogChainedQueryCriteriaAllFlatten input)
            : this(

            )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaAll"/> class.
        /// </summary>

        public LogChainedQueryCriteriaAll(
            LogQueryCriteriaAll logQueryCriteriaAll
            )
        {
            this.LogQueryCriteriaAll = logQueryCriteriaAll;
        }

        #endregion constructors

        #region Propertyies

        /// <summary>
        /// DataQueryPerQuerySetting, key is All
        /// </summary>
        public LogQueryCriteriaAll LogQueryCriteriaAll { get; set; }
        #endregion Propertyies
    }

    public class LogChainedQueryCriteriaAllFlatten
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaAllFlatten"/> class.
        /// </summary>
        public LogChainedQueryCriteriaAllFlatten()
        {

        }

        #endregion constructors

        #region Propertyies

        #endregion Propertyies
    }

    /// <summary>
    /// BusinessLogicLayerChainedQueryCriteria, key=ByIdentifier
    /// </summary>
    public class LogChainedQueryCriteriaByIdentifier
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifier"/> class.
        /// </summary>
        public LogChainedQueryCriteriaByIdentifier()
            : this(new LogChainedQueryCriteriaByIdentifierFlatten())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifier"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public LogChainedQueryCriteriaByIdentifier(LogChainedQueryCriteriaByIdentifierFlatten input)
            : this(
                input.IsToCompareIdByIdentifierOftOfByIdentifier, input.ValueToCompareIdByIdentifierOftOfByIdentifier.HasValue ? input.ValueToCompareIdByIdentifierOftOfByIdentifier.Value : default(long)
            )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifier"/> class.
        /// </summary>

        public LogChainedQueryCriteriaByIdentifier(
            LogQueryCriteriaByIdentifier logQueryCriteriaByIdentifier
            )
        {
            this.LogQueryCriteriaByIdentifier = logQueryCriteriaByIdentifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifier"/> class.
        /// </summary>
        /// <param name="idByIdentifierOftOfByIdentifier">Initialize criteria of IdByIdentifierOftOfByIdentifier</param>
        public LogChainedQueryCriteriaByIdentifier(
            QuerySystemInt64EqualsCriteria idByIdentifierOftOfByIdentifier
            )
            : this(
            new LogQueryCriteriaByIdentifier(idByIdentifierOftOfByIdentifier)
                )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifier"/> class.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        public LogChainedQueryCriteriaByIdentifier(
            bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier
            )
            : this(
            new QuerySystemInt64EqualsCriteria(isToCompareIdByIdentifierOftOfByIdentifier, valueToCompareIdByIdentifierOftOfByIdentifier)
                )
        {
        }

        #endregion constructors

        #region Propertyies

        /// <summary>
        /// DataQueryPerQuerySetting, key is ByIdentifier
        /// </summary>
        public LogQueryCriteriaByIdentifier LogQueryCriteriaByIdentifier { get; set; }
        #endregion Propertyies
    }

    public class LogChainedQueryCriteriaByIdentifierFlatten
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifierFlatten"/> class.
        /// </summary>
        public LogChainedQueryCriteriaByIdentifierFlatten()
        {
            this.IsToCompareIdByIdentifierOftOfByIdentifier= false; this.ValueToCompareIdByIdentifierOftOfByIdentifier= default(long);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifierFlatten"/> class.
        /// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>
        public LogChainedQueryCriteriaByIdentifierFlatten(
            bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier
            )
        {
            this.IsToCompareIdByIdentifierOftOfByIdentifier= isToCompareIdByIdentifierOftOfByIdentifier; this.ValueToCompareIdByIdentifierOftOfByIdentifier= valueToCompareIdByIdentifierOftOfByIdentifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogChainedQueryCriteriaByIdentifierFlatten"/> class.
        /// </summary>
        public LogChainedQueryCriteriaByIdentifierFlatten(LogChainedQueryCriteriaByIdentifier input)
            : this(
            input.LogQueryCriteriaByIdentifier.IdByIdentifierOft.IsToCompare, input.LogQueryCriteriaByIdentifier.IdByIdentifierOft.ValueToCompare
            )
        {
        }

        #endregion constructors

        #region Propertyies

        public bool IsToCompareIdByIdentifierOftOfByIdentifier { get; set; } public System.Int64? ValueToCompareIdByIdentifierOftOfByIdentifier { get; set; }

        #endregion Propertyies
    }

}

