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
    public class BusinessLogicLayerChainedQueryCriteriaEntityLogCommon
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommon"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommon()
			: this(new BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten())
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommon"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten input)
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
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommon"/> class.
        /// </summary>

		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
			BusinessLogicLayerQueryCriteriaEntityLogCommon businessLogicLayerQueryCriteriaEntityLogCommon			
			)
		{
			this.BusinessLogicLayerQueryCriteriaEntityLogCommon = businessLogicLayerQueryCriteriaEntityLogCommon;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommon"/> class.
		/// </summary>
        /// <param name="dateCommonOftOfCommon">Initialize criteria of DateCommonOftOfCommon</param>
        /// <param name="threadCommonOftOfCommon">Initialize criteria of ThreadCommonOftOfCommon</param>
        /// <param name="levelCommonOftOfCommon">Initialize criteria of LevelCommonOftOfCommon</param>
        /// <param name="loggerCommonOftOfCommon">Initialize criteria of LoggerCommonOftOfCommon</param>
        /// <param name="messageCommonOftOfCommon">Initialize criteria of MessageCommonOftOfCommon</param>
        /// <param name="exceptionCommonOftOfCommon">Initialize criteria of ExceptionCommonOftOfCommon</param>	
		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
			QuerySystemDateTimeRangeCriteria dateCommonOftOfCommon
			, QuerySystemStringContainsCriteria threadCommonOftOfCommon
			, QuerySystemStringContainsCriteria levelCommonOftOfCommon
			, QuerySystemStringContainsCriteria loggerCommonOftOfCommon
			, QuerySystemStringContainsCriteria messageCommonOftOfCommon
			, QuerySystemStringContainsCriteria exceptionCommonOftOfCommon
			)
			: this(
			new BusinessLogicLayerQueryCriteriaEntityLogCommon(dateCommonOftOfCommon,threadCommonOftOfCommon,levelCommonOftOfCommon,loggerCommonOftOfCommon,messageCommonOftOfCommon,exceptionCommonOftOfCommon)
				)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommon"/> class.
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
		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommon(
			bool isToCompareDateCommonOftOfCommon, bool isToCompareLowerBoundDateCommonOftOfCommon, System.DateTime lowerBoundDateCommonOftOfCommon, bool isToCompareUpperBoundDateCommonOftOfCommon, System.DateTime upperBoundDateCommonOftOfCommon
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
        public BusinessLogicLayerQueryCriteriaEntityLogCommon BusinessLogicLayerQueryCriteriaEntityLogCommon { get; set; }
		#endregion Propertyies
	}

	public class BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten()
		{
			this.IsToCompareDateCommonOftOfCommon= false; this.IsToCompareLowerBoundDateCommonOftOfCommon=false;this.LowerBoundDateCommonOftOfCommon=DateTime.Now;this.IsToCompareUpperBoundDateCommonOftOfCommon=false;this.UpperBoundDateCommonOftOfCommon=DateTime.Now;
			this.IsToCompareThreadCommonOftOfCommon= false; this.ValueToBeContainedThreadCommonOftOfCommon= null;
			this.IsToCompareLevelCommonOftOfCommon= false; this.ValueToBeContainedLevelCommonOftOfCommon= null;
			this.IsToCompareLoggerCommonOftOfCommon= false; this.ValueToBeContainedLoggerCommonOftOfCommon= null;
			this.IsToCompareMessageCommonOftOfCommon= false; this.ValueToBeContainedMessageCommonOftOfCommon= null;
			this.IsToCompareExceptionCommonOftOfCommon= false; this.ValueToBeContainedExceptionCommonOftOfCommon= null;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten"/> class.
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
		public BusinessLogicLayerChainedQueryCriteriaEntityLogCommonFlatten(
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
    public class BusinessLogicLayerChainedQueryCriteriaEntityLogAll
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogAll"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogAll()
			
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogAll"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public BusinessLogicLayerChainedQueryCriteriaEntityLogAll(BusinessLogicLayerChainedQueryCriteriaEntityLogAllFlatten input)
            : this(

			)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogAll"/> class.
        /// </summary>

		public BusinessLogicLayerChainedQueryCriteriaEntityLogAll(
			BusinessLogicLayerQueryCriteriaEntityLogAll businessLogicLayerQueryCriteriaEntityLogAll			
			)
		{
			this.BusinessLogicLayerQueryCriteriaEntityLogAll = businessLogicLayerQueryCriteriaEntityLogAll;
		}


		#endregion constructors

		#region Propertyies

		
        /// <summary>
        /// DataQueryPerQuerySetting, key is All
        /// </summary>
        public BusinessLogicLayerQueryCriteriaEntityLogAll BusinessLogicLayerQueryCriteriaEntityLogAll { get; set; }
		#endregion Propertyies
	}

	public class BusinessLogicLayerChainedQueryCriteriaEntityLogAllFlatten
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogAllFlatten"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogAllFlatten()
		{

		}



		#endregion constructors

		#region Propertyies



		#endregion Propertyies
	}



    
	/// <summary>
    /// BusinessLogicLayerChainedQueryCriteria, key=ByIdentifier
    /// </summary>
    public class BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier()
			: this(new BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten())
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>
        /// <param name="input">Flatten query class</param>
        public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten input)
            : this(
				input.IsToCompareIdByIdentifierOftOfByIdentifier, input.ValueToCompareIdByIdentifierOftOfByIdentifier.HasValue ? input.ValueToCompareIdByIdentifierOftOfByIdentifier.Value : default(long)
			)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier"/> class.
        /// </summary>

		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
			BusinessLogicLayerQueryCriteriaEntityLogByIdentifier businessLogicLayerQueryCriteriaEntityLogByIdentifier			
			)
		{
			this.BusinessLogicLayerQueryCriteriaEntityLogByIdentifier = businessLogicLayerQueryCriteriaEntityLogByIdentifier;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier"/> class.
		/// </summary>
        /// <param name="idByIdentifierOftOfByIdentifier">Initialize criteria of IdByIdentifierOftOfByIdentifier</param>	
		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
			QuerySystemInt64EqualsCriteria idByIdentifierOftOfByIdentifier
			)
			: this(
			new BusinessLogicLayerQueryCriteriaEntityLogByIdentifier(idByIdentifierOftOfByIdentifier)
				)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier"/> class.
		/// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>	
		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifier(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64 valueToCompareIdByIdentifierOftOfByIdentifier
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
        public BusinessLogicLayerQueryCriteriaEntityLogByIdentifier BusinessLogicLayerQueryCriteriaEntityLogByIdentifier { get; set; }
		#endregion Propertyies
	}

	public class BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten"/> class.
        /// </summary>
		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten()
		{
			this.IsToCompareIdByIdentifierOftOfByIdentifier= false; this.ValueToCompareIdByIdentifierOftOfByIdentifier= default(long);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten"/> class.
		/// </summary>
        /// <param name="isToCompareIdByIdentifierOftOfByIdentifier">will compare/filter IdByIdentifierOftOfByIdentifier property/field/column if true, otherwise false</param>
        /// <param name="valueToCompareIdByIdentifierOftOfByIdentifier">value to compare/filter with IdByIdentifierOftOfByIdentifier property/field/column</param>	
		public BusinessLogicLayerChainedQueryCriteriaEntityLogByIdentifierFlatten(
			bool isToCompareIdByIdentifierOftOfByIdentifier, System.Int64? valueToCompareIdByIdentifierOftOfByIdentifier
			)
		{
			this.IsToCompareIdByIdentifierOftOfByIdentifier= isToCompareIdByIdentifierOftOfByIdentifier; this.ValueToCompareIdByIdentifierOftOfByIdentifier= valueToCompareIdByIdentifierOftOfByIdentifier;
		}



		#endregion constructors

		#region Propertyies

		public bool IsToCompareIdByIdentifierOftOfByIdentifier { get; set; } public System.Int64? ValueToCompareIdByIdentifierOftOfByIdentifier { get; set; }

		#endregion Propertyies
	}



}