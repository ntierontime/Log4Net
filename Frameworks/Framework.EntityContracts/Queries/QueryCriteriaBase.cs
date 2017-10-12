using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    #region QueryCriterias

    /// <summary>
    /// QueryCriteriaBase class for all concrete Query Critieria classes
    /// </summary>
    /// <typeparam name="T">.Net value type</typeparam>
    public abstract class QueryCriteriaBase<T>: Framework.PropertyChangedNotifier
    {
        public const string Strings_NotToCompare = "(Not To Compare)";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryCriteriaBase()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        public QueryCriteriaBase(bool isToCompare)
        {
            this.IsToCompare = isToCompare;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is to compare.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is to compare; otherwise, <c>false</c>.
        /// </value>
        public bool IsToCompare { get; set; }

        protected static Framework.NameValueCollection GetListWithLocalizedResource(string resourcePrefix, Type type)
        {
            string format = "{0}_{2}";
            var results = new Framework.NameValueCollection();
            var prefix = string.IsNullOrWhiteSpace(resourcePrefix) ? type.Name : resourcePrefix;
            foreach (var name in Enum.GetNames(type))
            {
                string resourceName = string.Format(format, prefix, null, name);
                string resourceString = Framework.Resx.UIStringResource.ResourceManager.GetString(resourceName);
                results.Add(name, resourceString);

            }

            return results;
        }

    }

    #endregion QueryCriterias

    #region Equals Criterias

    /// <summary>
    /// for all concrete Query Critieria classes which process equals predicate
    /// </summary>
    /// <typeparam name="T">.Net value type</typeparam>
    public abstract class QueryEqualsCriteriaBase<T> : QueryCriteriaBase<T>
    {
        /// <summary>
        /// Gets or sets the value to compare.
        /// </summary>
        /// <value>
        /// The value to compare.
        /// </value>
        public T ValueToCompare { get; set; }

        public abstract T NullableValueToCompare { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryEqualsCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryEqualsCriteriaBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryEqualsCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QueryEqualsCriteriaBase(bool isToCompare, T valueToCompare)
            : base(isToCompare)
        {
            //this.IsToCompare = IsToCompare;
            this.ValueToCompare = valueToCompare;
        }

        //public override bool _Predicate(T input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.ValueToCompare.Equals(input));
        //}

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (IsToCompare)
            {
                return string.Format("Value={0}", this.ValueToCompare);
            }
            else
            {
                return Strings_NotToCompare;
            }
        }

        #endregion override string ToString()
    }

    public class QueryEqualsCriteriaBaseNullable<T> : QueryEqualsCriteriaBase<T?>
        where T : struct
    {
        public QueryEqualsCriteriaBaseNullable()
        {
        }

        public QueryEqualsCriteriaBaseNullable(bool isToCompare, T? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
            //this.IsToCompare = IsToCompare;
            this.ValueToCompare = valueToCompare;
        }

        public override T? NullableValueToCompare
        {
            get { return ValueToCompare; }

            set
            {
                if (!value.Equals(ValueToCompare))
                {
                    ValueToCompare = value;
                    IsToCompare = value.HasValue;
                }
            }
        }
    }

    /// <summary>
    /// concrete class for Boolean of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemBooleanEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Boolean>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemBooleanEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemBooleanEqualsCriteria()
        {
            ValueToCompare = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemBooleanEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">if set to <c>true</c> [value to compare].</param>
        public QuerySystemBooleanEqualsCriteria(bool isToCompare, System.Boolean? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
            ValueToCompare = valueToCompare ?? false;
        }

        #endregion constructors

        Framework.EntityContracts.PredefinedBooleanSelectedValues m_PredefinedBooleanSelectedValue;
        public Framework.EntityContracts.PredefinedBooleanSelectedValues PredefinedBooleanSelectedValue
        {
            get
            {
                return m_PredefinedBooleanSelectedValue;
            }
            set
            {
                m_PredefinedBooleanSelectedValue = value;
                IsToCompare = m_PredefinedBooleanSelectedValue != Framework.EntityContracts.PredefinedBooleanSelectedValues.All;
                ValueToCompare = m_PredefinedBooleanSelectedValue == Framework.EntityContracts.PredefinedBooleanSelectedValues.True;
            }
        }

        public static Framework.NameValueCollection GetList(string resourcePrefix)
        {
            Type type = typeof(Framework.EntityContracts.PredefinedBooleanSelectedValues);
            return GetListWithLocalizedResource(resourcePrefix, type);
        }
    }

    /// <summary>
    /// concrete class for Byte of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemByteEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Byte>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemByteEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemByteEqualsCriteria(bool isToCompare, System.Byte? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Char of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemCharEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Char>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemCharEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemCharEqualsCriteria(bool isToCompare, System.Char? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for DateTime of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.DateTime>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemDateTimeEqualsCriteria(bool isToCompare, System.DateTime? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for DateTimeOffset of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeOffsetEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.DateTimeOffset>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeOffsetEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemDateTimeOffsetEqualsCriteria(bool isToCompare, System.DateTimeOffset? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Decimal of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDecimalEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Decimal>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemDecimalEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemDecimalEqualsCriteria(bool isToCompare, System.Decimal? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Double of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDoubleEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Double>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemDoubleEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemDoubleEqualsCriteria(bool isToCompare, System.Double? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Guid of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemGuidEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Guid>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemGuidEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemGuidEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemGuidEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemGuidEqualsCriteria(bool isToCompare, System.Guid? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Int16 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt16EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Int16>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16EqualsCriteria"/> class.
        /// </summary>
        public QuerySystemInt16EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemInt16EqualsCriteria(bool isToCompare, System.Int16? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Int32 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt32EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Int32>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32EqualsCriteria"/> class.
        /// </summary>
        public QuerySystemInt32EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemInt32EqualsCriteria(bool isToCompare, System.Int32? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Int64 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt64EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Int64>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64EqualsCriteria"/> class.
        /// </summary>
        public QuerySystemInt64EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemInt64EqualsCriteria(bool isToCompare, System.Int64? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for SByte of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSByteEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.SByte>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemSByteEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemSByteEqualsCriteria(bool isToCompare, System.SByte? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Single of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSingleEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.Single>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemSingleEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemSingleEqualsCriteria(bool isToCompare, System.Single? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for String of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemStringEqualsCriteria : QueryEqualsCriteriaBase<System.String>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemStringEqualsCriteria()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemStringEqualsCriteria(bool isToCompare, System.String valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors

        public override string NullableValueToCompare
        {
            get { return ValueToCompare; }

            set
            {
                ValueToCompare = value;
                IsToCompare = string.IsNullOrWhiteSpace(ValueToCompare);
            }
        }
    }

    /// <summary>
    /// concrete class for TimeSpan of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemTimeSpanEqualsCriteria : QueryEqualsCriteriaBaseNullable<System.TimeSpan>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemTimeSpanEqualsCriteria()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemTimeSpanEqualsCriteria(bool isToCompare, System.TimeSpan? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for UInt16 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt16EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.UInt16>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16EqualsCriteria"/> class.
        /// </summary>
        public QuerySystemUInt16EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemUInt16EqualsCriteria(bool isToCompare, System.UInt16 valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for UInt32 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt32EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.UInt32>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32EqualsCriteria"/> class
        /// </summary>
        public QuerySystemUInt32EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemUInt32EqualsCriteria(bool isToCompare, System.UInt32? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for UInt64 of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt64EqualsCriteria : QueryEqualsCriteriaBaseNullable<System.UInt64>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64EqualsCriteria"/> class.
        /// </summary>
        public QuerySystemUInt64EqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64EqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemUInt64EqualsCriteria(bool isToCompare, System.UInt64? valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// concrete class for Enum of QueryEqualsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemEnumEqualsCriteria : QueryEqualsCriteriaBase<Enum>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemEnumEqualsCriteria"/> class.
        /// </summary>
        public QuerySystemEnumEqualsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemEnumEqualsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToCompare">The value to compare.</param>
        public QuerySystemEnumEqualsCriteria(bool isToCompare, System.Enum valueToCompare)
            : base(isToCompare, valueToCompare)
        {
        }

        public override Enum NullableValueToCompare
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion constructors
    }

    #endregion Equals Criterias

    #region Range Criterias

    /// <summary>
    /// for all concrete Query Critieria classes which process range predicate
    /// </summary>
    /// <typeparam name="T">.Net value type</typeparam>
    public abstract class QueryRangeCriteriaBase<T> : QueryCriteriaBase<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is to compare lower bound.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is to compare lower bound; otherwise, <c>false</c>.
        /// </value>
        public bool IsToCompareLowerBound { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is to include lower bound.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is to include lower bound; otherwise, <c>false</c>.
        /// </value>
        public bool IsToIncludeLowerBound { get; set; }
        /// <summary>
        /// Gets or sets the lower bound.
        /// </summary>
        /// <value>
        /// The lower bound.
        /// </value>
        public T LowerBound { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is to compare upper bound.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is to compare upper bound; otherwise, <c>false</c>.
        /// </value>
        public bool IsToCompareUpperBound { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is to include upper bound.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is to include upper bound; otherwise, <c>false</c>.
        /// </value>
        public bool IsToIncludeUpperBound { get; set; }
        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        /// <value>
        /// The upper bound.
        /// </value>
        public T UpperBound { get; set; }

        public abstract T NullableLowerBound { get; set; }
        public abstract T NullableUpperBound { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryRangeCriteriaBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QueryRangeCriteriaBase(bool isToCompare, T lowerBound, T upperBound)
            : this(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QueryRangeCriteriaBase(bool isToCompare, bool isToCompareLowerBound, T lowerBound, bool isToCompareUpperBound, T upperBound)
            : base(isToCompare)
        {
            //this.IsToCompare = isToCompare;
            this.IsToCompareLowerBound = isToCompareLowerBound;
            this.IsToCompareUpperBound = isToCompareUpperBound;
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
            this.IsToIncludeLowerBound = true;
            this.IsToIncludeUpperBound = false;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (IsToCompare)
            {
                string _Format_Lower;
                if (IsToCompareLowerBound)
                {
                    if (IsToIncludeLowerBound)
                    {
                        _Format_Lower = "{0}<=";
                    }
                    else
                    {
                        _Format_Lower = "{0}<";
                    }
                }
                else
                {
                    _Format_Lower = "";
                }
                string _Format_Upper;
                if (IsToCompareUpperBound)
                {
                    if (IsToIncludeUpperBound)
                    {
                        _Format_Upper = "<={1}";
                    }
                    else
                    {
                        _Format_Upper = "<{1}";
                    }
                }
                else
                {
                    _Format_Upper = "";
                }
                string _Format = string.Format("{0}x{1}", _Format_Lower, _Format_Upper);
                return string.Format(_Format, this.LowerBound, this.UpperBound);
            }
            else
            {
                return Strings_NotToCompare;
            }
        }

    }

    public abstract class QueryRangeCriteriaBaseNullable<T> : QueryRangeCriteriaBase<T?>
        where T : struct
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryRangeCriteriaBaseNullable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QueryRangeCriteriaBaseNullable(bool isToCompare, T? lowerBound, T? upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRangeCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QueryRangeCriteriaBaseNullable(bool isToCompare, bool isToCompareLowerBound, T? lowerBound, bool isToCompareUpperBound, T? upperBound)
            : base(isToCompare, isToCompareLowerBound, lowerBound, isToCompareUpperBound, upperBound)
        {
            //this.IsToCompare = isToCompare;
            this.IsToCompareLowerBound = isToCompareLowerBound;
            this.IsToCompareUpperBound = isToCompareUpperBound;
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
            this.IsToIncludeLowerBound = true;
            this.IsToIncludeUpperBound = false;
        }

        /// <summary>
        /// Gets or sets the nullable lower bound.
        /// </summary>
        /// <value>
        /// The nullable lower bound.
        /// </value>
        public override T? NullableLowerBound
        {
            get { return LowerBound; }
            set
            {
                LowerBound = value;
                IsToCompareLowerBound = value.HasValue;
                IsToCompare = IsToCompareLowerBound || IsToCompareUpperBound;
            }
        }

        public override T? NullableUpperBound
        {
            get { return UpperBound; }
            set
            {
                UpperBound = value;
                IsToCompareUpperBound = value.HasValue;
                IsToCompare = IsToCompareLowerBound || IsToCompareUpperBound;
            }
        }
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemByteRangeCriteria : QueryRangeCriteriaBaseNullable<System.Byte>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteRangeCriteria"/> class.
        /// </summary>
        public QuerySystemByteRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemByteRangeCriteria(bool isToCompare, System.Byte lowerBound, System.Byte upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemByteRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Byte lowerBound, bool isToCompareUpperBound, System.Byte upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Byte input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Char of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemCharRangeCriteria : QueryRangeCriteriaBaseNullable<System.Char>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharRangeCriteria"/> class.
        /// </summary>
        public QuerySystemCharRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemCharRangeCriteria(bool isToCompare, System.Char lowerBound, System.Char upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemCharRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Char lowerBound, bool isToCompareUpperBound, System.Char upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Char input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeRangeCriteria : QueryRangeCriteriaBaseNullable<System.DateTime>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeRangeCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDateTimeRangeCriteria(bool isToCompare, System.DateTime? lowerBound, System.DateTime? upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDateTimeRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.DateTime? lowerBound, bool isToCompareUpperBound, System.DateTime? upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        Framework.EntityContracts.PreDefinedDateTimeRanges m_PreDefinedDateTimeRange = Framework.EntityContracts.PreDefinedDateTimeRanges.Today;

        public Framework.EntityContracts.PreDefinedDateTimeRanges PreDefinedDateTimeRange
        {
            get
            {
                return m_PreDefinedDateTimeRange;
            }
            set
            {
                m_PreDefinedDateTimeRange = value;
                var calculated = GetBounds(value);
                LowerBound = calculated.LowerBound;
                UpperBound = calculated.UpperBound;
                IsCustomEditor = m_PreDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.Custom;
                RaisePropertyChanged("PreDefinedDateTimeRange");
                RaisePropertyChanged("IsCustomEditor");
                RaisePropertyChanged("LowerBound");
                RaisePropertyChanged("UpperBound");
            }
        }

        public bool IsCustomEditor { get; set; }

        public static QuerySystemDateTimeRangeCriteria GetBounds(Framework.EntityContracts.PreDefinedDateTimeRanges preDefinedDateTimeRange)
        {
            if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.Custom)
            {
                var lowerBound = DateTime.Now;
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastTenYears)
            // include this year + 10 years
            {
                var lowerBound = DateTime.Now.AddYears(-10);
                lowerBound = new DateTime(lowerBound.Year, 1, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastFiveYears)
            // include this year + 5 years
            {
                var lowerBound = DateTime.Now.AddYears(-5);
                lowerBound = new DateTime(lowerBound.Year, 1, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastYear)
            // include this year + 1 year
            {
                var lowerBound = DateTime.Now.AddYears(-1);
                lowerBound = new DateTime(lowerBound.Year, 1, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastSixMonths)
            // include this month + 6 month
            {
                var lowerBound = DateTime.Now.AddMonths(-6);
                lowerBound = new DateTime(lowerBound.Year, lowerBound.Month, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastThreeMonths)
            // include this month + 3 month
            {
                var lowerBound = DateTime.Now.AddMonths(-3);
                lowerBound = new DateTime(lowerBound.Year, lowerBound.Month, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastMonth)
                // include this month + 1 month
            {
                var lowerBound = DateTime.Now.AddMonths(-1);
                lowerBound = new DateTime(lowerBound.Year, lowerBound.Month, 1);
                var upperBound = DateTime.Now;
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.LastWeek)
                // include this week + 1 week
            {
                var lowerBound = DateTime.Now.AddDays(-7);
                lowerBound = lowerBound.AddDays(-(int)lowerBound.DayOfWeek);// starting from Sunday
                lowerBound = new DateTime(lowerBound.Year, lowerBound.Month, 1);
                var upperBound = lowerBound.AddDays(7);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.Yesterday)
                // exclude today
            {
                var lowerBound = DateTime.Now.AddDays(-1);
                lowerBound = new DateTime(lowerBound.Year, lowerBound.Month, lowerBound.Day, 0, 0, 0);
                var upperBound = lowerBound.AddDays(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.ThisYear)
            {
                var lowerBound = new DateTime(DateTime.Now.Year, 1, 1);
                var upperBound = lowerBound.AddYears(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.ThisMonth)
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var upperBound = lowerBound.AddMonths(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.ThisWeek)
            {
                var lowerBound = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                var upperBound = lowerBound.AddDays(7);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.Today)
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var upperBound = lowerBound.AddDays(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.Tomorrow)
            // exclude today
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
                var upperBound = lowerBound.AddDays(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextWeek)
            // exclude this week
            {
                var lowerBound = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek).AddDays(7);
                var upperBound = lowerBound.AddDays(7);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextMonth)
            // exclude this month
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                var upperBound = lowerBound.AddMonths(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextThreeMonths)
            // exclude this month
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                var upperBound = lowerBound.AddMonths(3);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextSixMonths)
            // exclude this month
            {
                var lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                var upperBound = lowerBound.AddMonths(6);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextYear)
            // exclude this year
            {
                var lowerBound = new DateTime(DateTime.Now.Year, 1, 1).AddYears(1);
                var upperBound = lowerBound.AddYears(1);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextFiveYears)
            // exclude this year
            {
                var lowerBound = new DateTime(DateTime.Now.Year, 1, 1).AddYears(1);
                var upperBound = lowerBound.AddYears(5);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }
            else if (preDefinedDateTimeRange == Framework.EntityContracts.PreDefinedDateTimeRanges.NextTenYears)
            // exclude this year
            {
                var lowerBound = new DateTime(DateTime.Now.Year, 1, 1).AddYears(1);
                var upperBound = lowerBound.AddYears(10);
                return new QuerySystemDateTimeRangeCriteria(true, lowerBound, upperBound);
            }

            return new QuerySystemDateTimeRangeCriteria(false, null, null);

        }

        #region special constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeRangeCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeRangeCriteria(
            DateTime? lowerBoundNullable
            , Framework.EntityContracts.Queries.DateTimeUnit dateTimeUnitOfInterval
            , System.Int32 interval)
        {
            DateTime? _CurrentCriteriaUpperBound;
            if (lowerBoundNullable.HasValue)
            {
                DateTime lowerBound = lowerBoundNullable.Value;

                if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Year)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddYears(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Month)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddMonths(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Week)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddDays(interval * 7);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Day)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddDays(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Hour)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddHours(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Minute)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddMinutes(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Second)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddSeconds(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.MilliSecond)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddMilliseconds(interval);
                }
                else if (dateTimeUnitOfInterval == Framework.EntityContracts.Queries.DateTimeUnit.Tick)
                {
                    _CurrentCriteriaUpperBound = lowerBound.AddTicks(interval);
                }
                else
                {
                    _CurrentCriteriaUpperBound = this.UpperBound;
                }
            }
            else
            {
                _CurrentCriteriaUpperBound = null;

            }

            this.UpperBound = _CurrentCriteriaUpperBound;
            this.LowerBound = lowerBoundNullable;
            this.IsToCompare = true;
            this.IsToCompareLowerBound = true;
            this.IsToCompareUpperBound = true;
            this.IsToIncludeLowerBound = true;
            this.IsToIncludeUpperBound = false;
        }

        #endregion special constructors

        #region Get...RangeOf(DateTime dateTime)

        public static QuerySystemDateTimeRangeCriteria GetYearRangeOf(DateTime dateTime)
        {
            DateTime _FirstDay = new DateTime(dateTime.Year, 1, 1);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddYears(1));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetQuarterOfYearRangeOf(DateTime dateTime)
        {
            int _FirstMonthOfQuarterOfYear = (dateTime.Month - 1) / 3 + 1;

            DateTime _FirstDay = new DateTime(dateTime.Year, _FirstMonthOfQuarterOfYear, 1);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddMonths(3));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetMonthRangeOf(DateTime dateTime)
        {
            DateTime _FirstDay = new DateTime(dateTime.Year, dateTime.Month, 1);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddMonths(1));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetSemiMonthRangeOf(DateTime dateTime)
        {
            DateTime _FirstDay = new DateTime(dateTime.Year, dateTime.Month, 1);

            QuerySystemDateTimeRangeCriteria _retval;
            if (dateTime.Day <= 15)
            // 1st - 15th
            {
                _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddDays(15));
            }
            else
            // 16th -> 1st of next month
            {
                _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay.AddDays(15), _FirstDay.AddMonths(1));
            }

            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetBiWeekRangeOf(DateTime dateTime)
        {
            DateTime _SunDay = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            DateTime _FirstDay = new DateTime(_SunDay.Year, _SunDay.Month, _SunDay.Day);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddDays(14));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetWeekRangeOf(DateTime dateTime)
        {
            DateTime _SunDay = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            DateTime _FirstDay = new DateTime(_SunDay.Year, _SunDay.Month, _SunDay.Day);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstDay, _FirstDay.AddDays(7));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetDayRangeOf(DateTime dateTime)
        {
            DateTime _FirstHour = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstHour, _FirstHour.AddDays(1));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        public static QuerySystemDateTimeRangeCriteria GetHourRangeOf(DateTime dateTime)
        {
            DateTime _FirstMinute = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);

            QuerySystemDateTimeRangeCriteria _retval = new QuerySystemDateTimeRangeCriteria(true, _FirstMinute, _FirstMinute.AddHours(1));
            _retval.IsToIncludeUpperBound = false;
            return _retval;
        }

        #endregion Get...Of(DateTime dateTime)

        #region Predicate(DateTime input)

        public bool Predicate(DateTime input)
        {
            bool _retval;
            if (this.IsToCompare == true)
            {
                if (this.IsToCompareLowerBound == true)
                {
                    _retval = this.IsToIncludeLowerBound ? input >= this.LowerBound : input > this.LowerBound;
                }
                else
                {
                    _retval = true;
                }

                if (_retval == true)
                {
                    if (this.IsToCompareUpperBound == true)
                    {
                        _retval = this.IsToIncludeUpperBound ? input <= this.UpperBound : input < this.UpperBound;
                    }
                    else
                    {
                        _retval = true;
                    }
                }
            }
            else
            {
                _retval = true;
            }

            return _retval;
        }

        #endregion Predicate(DateTime input)

        #region CalculateConsecutiveDistributionCriteria(...)

        public QuerySystemDateTimeRangeCriteria[] CalculateConsecutiveDistributionCriteria(Framework.EntityContracts.Queries.DateTimeUnit dateTimeUnitOfInterval, int interval)
        {
            List<QuerySystemDateTimeRangeCriteria> _retval = new List<QuerySystemDateTimeRangeCriteria>();

            DateTime? _CurrentCriteriaLowerBound = this.LowerBound;
            while (_CurrentCriteriaLowerBound < this.UpperBound)
            {
                QuerySystemDateTimeRangeCriteria _OneCriteria = new QuerySystemDateTimeRangeCriteria(_CurrentCriteriaLowerBound, dateTimeUnitOfInterval, interval);
                _CurrentCriteriaLowerBound = _OneCriteria.UpperBound;

                _retval.Add(_OneCriteria);
            }

            return _retval.ToArray();
        }

        #endregion CalculateConsecutiveDistributionCriteria(...)

        public static Framework.NameValueCollection GetList(string resourcePrefix)
        {
            Type type = typeof(Framework.EntityContracts.PreDefinedDateTimeRanges);
            return GetListWithLocalizedResource(resourcePrefix, type);
        }
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeOffsetRangeCriteria : QueryRangeCriteriaBaseNullable<System.DateTimeOffset>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetRangeCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeOffsetRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDateTimeOffsetRangeCriteria(bool isToCompare, System.DateTimeOffset lowerBound, System.DateTimeOffset upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDateTimeOffsetRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.DateTimeOffset lowerBound, bool isToCompareUpperBound, System.DateTimeOffset upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.DateTimeOffset input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDecimalRangeCriteria : QueryRangeCriteriaBaseNullable<System.Decimal>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalRangeCriteria"/> class.
        /// </summary>
        public QuerySystemDecimalRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDecimalRangeCriteria(bool isToCompare, System.Decimal lowerBound, System.Decimal upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDecimalRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Decimal lowerBound, bool isToCompareUpperBound, System.Decimal upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }
        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Decimal input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDoubleRangeCriteria : QueryRangeCriteriaBaseNullable<System.Double>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleRangeCriteria"/> class.
        /// </summary>
        public QuerySystemDoubleRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDoubleRangeCriteria(bool isToCompare, System.Double lowerBound, System.Double upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemDoubleRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Double lowerBound, bool isToCompareUpperBound, System.Double upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Double input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt16RangeCriteria : QueryRangeCriteriaBaseNullable<System.Int16>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16RangeCriteria"/> class.
        /// </summary>
        public QuerySystemInt16RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt16RangeCriteria(bool isToCompare, System.Int16 lowerBound, System.Int16 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt16RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Int16 lowerBound, bool isToCompareUpperBound, System.Int16 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int16 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt32RangeCriteria : QueryRangeCriteriaBaseNullable<System.Int32>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32RangeCriteria"/> class.
        /// </summary>
        public QuerySystemInt32RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt32RangeCriteria(bool isToCompare, System.Int32 lowerBound, System.Int32 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt32RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Int32 lowerBound, bool isToCompareUpperBound, System.Int32 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int32 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt64RangeCriteria : QueryRangeCriteriaBaseNullable<System.Int64>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64RangeCriteria"/> class.
        /// </summary>
        public QuerySystemInt64RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt64RangeCriteria(bool isToCompare, System.Int64 lowerBound, System.Int64 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemInt64RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Int64 lowerBound, bool isToCompareUpperBound, System.Int64 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int64 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSByteRangeCriteria : QueryRangeCriteriaBaseNullable<System.SByte>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteRangeCriteria"/> class.
        /// </summary>
        public QuerySystemSByteRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemSByteRangeCriteria(bool isToCompare, System.SByte lowerBound, System.SByte upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemSByteRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.SByte lowerBound, bool isToCompareUpperBound, System.SByte upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Single input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSingleRangeCriteria : QueryRangeCriteriaBaseNullable<System.Single>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleRangeCriteria"/> class.
        /// </summary>
        public QuerySystemSingleRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemSingleRangeCriteria(bool isToCompare, System.Single lowerBound, System.Single upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemSingleRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.Single lowerBound, bool isToCompareUpperBound, System.Single upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Single input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Byte of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemStringRangeCriteria : QueryRangeCriteriaBase<System.String>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringRangeCriteria"/> class.
        /// </summary>
        public QuerySystemStringRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemStringRangeCriteria(bool isToCompare, System.String lowerBound, System.String upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemStringRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.String lowerBound, bool isToCompareUpperBound, System.String upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        public override string NullableLowerBound
        {
            get
            {
                return LowerBound;
            }

            set
            {
                LowerBound = value;
                IsToCompareLowerBound = !string.IsNullOrWhiteSpace(value);
                IsToCompare = IsToCompareLowerBound || IsToCompareUpperBound;
            }
        }

        public override string NullableUpperBound
        {
            get
            {
                return UpperBound;
            }

            set
            {
                UpperBound = value;
                IsToCompareUpperBound = !string.IsNullOrWhiteSpace(value);
                IsToCompare = IsToCompareLowerBound || IsToCompareUpperBound;
            }
        }

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.String input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input.CompareTo(this.LowerBound) > 0 && input.CompareTo(this.UpperBound) < 0);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for TimeSpan of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemTimeSpanRangeCriteria : QueryRangeCriteriaBaseNullable<System.TimeSpan>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanRangeCriteria"/> class.
        /// </summary>
        public QuerySystemTimeSpanRangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemTimeSpanRangeCriteria(bool isToCompare, System.TimeSpan lowerBound, System.TimeSpan upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanRangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemTimeSpanRangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.TimeSpan lowerBound, bool isToCompareUpperBound, System.TimeSpan upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.TimeSpan input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt16 of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt16RangeCriteria : QueryRangeCriteriaBaseNullable<System.UInt16>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16RangeCriteria"/> class.
        /// </summary>
        public QuerySystemUInt16RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt16RangeCriteria(bool isToCompare, System.UInt16 lowerBound, System.UInt16 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt16RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.UInt16 lowerBound, bool isToCompareUpperBound, System.UInt16 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt16 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt32 of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt32RangeCriteria : QueryRangeCriteriaBaseNullable<System.UInt32>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32RangeCriteria"/> class.
        /// </summary>
        public QuerySystemUInt32RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt32RangeCriteria(bool isToCompare, System.UInt32 lowerBound, System.UInt32 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt32RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.UInt32 lowerBound, bool isToCompareUpperBound, System.UInt32 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt32 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt64 of QueryRangeCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt64RangeCriteria : QueryRangeCriteriaBaseNullable<System.UInt64>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64RangeCriteria"/> class.
        /// </summary>
        public QuerySystemUInt64RangeCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt64RangeCriteria(bool isToCompare, System.UInt64 lowerBound, System.UInt64 upperBound)
            : base(isToCompare, lowerBound, upperBound)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64RangeCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="isToCompareLowerBound">if set to <c>true</c> [is to compare lower bound].</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="isToCompareUpperBound">if set to <c>true</c> [is to compare upper bound].</param>
        /// <param name="upperBound">The upper bound.</param>
        public QuerySystemUInt64RangeCriteria(bool isToCompare, bool isToCompareLowerBound, System.UInt64 lowerBound, bool isToCompareUpperBound, System.UInt64 upperBound)
            : base(isToCompare, isToCompare, lowerBound, isToCompare, upperBound)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt64 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && input > this.LowerBound && input < this.UpperBound);
        //}

        #endregion _Predicate method
    }

    #endregion QueryRangeCriterias

    #region InSelectedList Criterias

    /// <summary>
    ///  for all concrete Query Critieria classes which process In SelectList predicate
    /// </summary>
    /// <typeparam name="T">.Net value type</typeparam>
    public abstract class QueryInSelectedListCriteriaBase<T> : QueryCriteriaBase<T>
    {
        /// <summary>
        /// Gets or sets the selected list.
        /// </summary>
        /// <value>
        /// The selected list.
        /// </value>
        public T[] SelectedList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInSelectedListCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryInSelectedListCriteriaBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInSelectedListCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QueryInSelectedListCriteriaBase(bool isToCompare, T[] selectedList)
            : base(isToCompare)
        {
            //this.IsToCompare = isToCompare;
            this.SelectedList = selectedList;
        }
    }

    /// <summary>
    /// concrete class for Byte of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemByteInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Byte?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemByteInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemByteInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemByteInSelectedListCriteria(bool isToCompare, System.Byte?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Byte input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Char of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemCharInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Char?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemCharInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemCharInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemCharInSelectedListCriteria(bool isToCompare, System.Char?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate methodtoberemoved

        //public override bool _Predicate(System.Char input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for DateTime of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.DateTime?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemDateTimeInSelectedListCriteria(bool isToCompare, System.DateTime?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.DateTime input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for DateTimeOffset of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDateTimeOffsetInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.DateTimeOffset?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemDateTimeOffsetInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDateTimeOffsetInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemDateTimeOffsetInSelectedListCriteria(bool isToCompare, System.DateTimeOffset?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.DateTimeOffset input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Decimal of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDecimalInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Decimal?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemDecimalInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDecimalInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemDecimalInSelectedListCriteria(bool isToCompare, System.Decimal?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Decimal input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Double of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemDoubleInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Double?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemDoubleInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemDoubleInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemDoubleInSelectedListCriteria(bool isToCompare, System.Double?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Double input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Guid of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemGuidInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Guid?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemGuidInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemGuidInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemGuidInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemGuidInSelectedListCriteria(bool isToCompare, System.Guid?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Guid input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Int16 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt16InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Int16?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemInt16InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt16InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemInt16InSelectedListCriteria(bool isToCompare, System.Int16?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int16 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Int32 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt32InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Int32?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemInt32InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt32InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemInt32InSelectedListCriteria(bool isToCompare, System.Int32?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int32 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Int64 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemInt64InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Int64?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemInt64InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemInt64InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemInt64InSelectedListCriteria(bool isToCompare, System.Int64?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Int64 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for SByte of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSByteInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.SByte?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemSByteInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSByteInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemSByteInSelectedListCriteria(bool isToCompare, System.SByte?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Single input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Single of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemSingleInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Single?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemSingleInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemSingleInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemSingleInSelectedListCriteria(bool isToCompare, System.Single?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Single input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for String of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemStringInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.String>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemStringInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemStringInSelectedListCriteria(bool isToCompare, System.String[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.String input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for TimeSpan of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemTimeSpanInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.TimeSpan?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemTimeSpanInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemTimeSpanInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemTimeSpanInSelectedListCriteria(bool isToCompare, System.TimeSpan?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.TimeSpan input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt16 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt16InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.UInt16?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemUInt16InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt16InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemUInt16InSelectedListCriteria(bool isToCompare, System.UInt16?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt16 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt32 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt32InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.UInt32?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemUInt32InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt32InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemUInt32InSelectedListCriteria(bool isToCompare, System.UInt32?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt32 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for UInt64 of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemUInt64InSelectedListCriteria : QueryInSelectedListCriteriaBase<System.UInt64?>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64InSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemUInt64InSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemUInt64InSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemUInt64InSelectedListCriteria(bool isToCompare, System.UInt64?[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.UInt64 input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    /// <summary>
    /// concrete class for Enum of QueryInSelectedListCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemEnumInSelectedListCriteria : QueryInSelectedListCriteriaBase<System.Enum>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemEnumInSelectedListCriteria"/> class.
        /// </summary>
        public QuerySystemEnumInSelectedListCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemEnumInSelectedListCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="selectedList">The selected list.</param>
        public QuerySystemEnumInSelectedListCriteria(bool isToCompare, System.Enum[] selectedList)
            : base(isToCompare, selectedList)
        {
        }

        #endregion constructors

        #region _Predicate method toberemoved

        //public override bool _Predicate(System.Enum input)
        //{
        //    return (this.IsToCompare == false) || (this.IsToCompare == true && this.SelectedList.Contains(input));
        //}

        #endregion _Predicate method
    }

    #endregion InSelectedList Criterias

    #region string contains criteria

    /// <summary>
    ///  for all concrete Query Critieria classes which process Contains predicate
    /// </summary>
    /// <typeparam name="T">.Net value type</typeparam>
    public abstract class QueryContainsCriteriaBase<T> : QueryCriteriaBase<T>
    {
        /// <summary>
        /// Gets or sets the value to be contained.
        /// </summary>
        /// <value>
        /// The value to be contained.
        /// </value>
        public T ValueToBeContained { get; set; }

        public abstract T NullableValueToBeContained { get; set; }

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryContainsCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        public QueryContainsCriteriaBase()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryContainsCriteriaBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToBeContained">The value to be contained.</param>
        public QueryContainsCriteriaBase(bool isToCompare, T valueToBeContained)
            : base(isToCompare)
        {
            this.ValueToBeContained = valueToBeContained;
        }

        #endregion constructors

    }

    /// <summary>
    /// concrete class for string of QueryContainsCriteriaBase&lt;T&gt;
    /// </summary>
    public class QuerySystemStringContainsCriteria : QueryContainsCriteriaBase<string>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringContainsCriteria"/> class.
        /// </summary>
        public QuerySystemStringContainsCriteria()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySystemStringContainsCriteria"/> class.
        /// </summary>
        /// <param name="isToCompare">if set to <c>true</c> [is to compare].</param>
        /// <param name="valueToBeContained">The value to be contained.</param>
        public QuerySystemStringContainsCriteria(bool isToCompare, System.String valueToBeContained)
            : base(isToCompare, valueToBeContained)
        {
        }

        #endregion constructors toberemoved
        public override string NullableValueToBeContained
        {
            get { return ValueToBeContained; }

            set
            {
                ValueToBeContained = value;
                IsToCompare = !string.IsNullOrWhiteSpace(value);
            }
        }
    }

    #endregion string contains criteria
}

