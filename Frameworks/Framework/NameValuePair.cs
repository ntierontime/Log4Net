using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Framework
{
    #region interface

    /// <summary>
    /// interface of NameValuePair
    /// </summary>
	public interface INameValuePair
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string Value { get; set; }
    }

    /// <summary>
    /// interface of NameValuePairCollection
    /// </summary>
    /// <typeparam name="T">entity class</typeparam>
    public interface INameValuePairEntityCollection<T> : IList<T>
        where T : INameValuePair
    {
        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        void Add(long value, string name);
        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        void Add(string value, string name);
    }
    
    #endregion interface

    #region class NameValuePairContractHelper

    /// <summary>
    /// Helper class for INameValuePair
    /// </summary>
    public static class NameValuePairContractHelper
    {
		/// <summary>
        /// Copies the specified from.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void Copy<T1, T2>(T1 from, T2 to)
            where T1 : INameValuePair
            where T2 : INameValuePair
        {
            to.Name = from.Name;
            to.Value = from.Value;
        }

        /// <summary>
        /// Equalses the specified from.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>true if equals, otherwise false</returns>
		public static bool Equals<T1, T2>(T1 from, T2 to)
            where T1 : INameValuePair
            where T2 : INameValuePair
        {
            bool _retval = true;
            _retval = _retval && to.Name == from.Name;
            _retval = _retval && to.Value == from.Value;
            return _retval;
        }

        /// <summary>
        /// Clones the specified from parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <returns>cloned new instance</returns>
        public static T2 Clone<T1, T2>(T1 from)
            where T1 : INameValuePair
            where T2 : INameValuePair, new()
        {
            T2 _retval = new T2();
            Copy<T1, T2>(from, _retval);
            return _retval;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <typeparam name="T">entity type implements <see cref="INameValuePair"/></typeparam>
        /// <param name="input">The input.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
		public static string ToString<T>(T input)
            where T : INameValuePair
        {
            string _Format = "Name:{0};Value:{1};";
            return string.Format(_Format, input.Name, input.Value);
        }
    }

    #endregion class NameValuePairContractHelper

    #region class NameValueCollection<T>


    /// <summary>
    /// Generic NameValueCollection
    /// </summary>
    /// <typeparam name="T">entity class implements <see cref="INameValuePair"/></typeparam>
	public class NameValueCollection<T> : List<T>, INameValuePairEntityCollection<T>
        where T : INameValuePair, new()
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValueCollection&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public NameValueCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValueCollection&lt;T&gt;"/> class.
        /// </summary>        
		public NameValueCollection(IEnumerable<T> input)
            : base(input)
        {
        }

        #endregion constructors

        #region PrediacteByName


        /// <summary>
        /// Prediacte By Name
        /// </summary>
		private class PrediacteByName
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NameValueCollection&lt;T&gt;.PrediacteByName"/> class.
            /// </summary>
            /// <param name="comparedToName">Name of the compared to.</param>
			public PrediacteByName(string comparedToName)
            {
                this.ComparedToName = comparedToName;
            }


            /// <summary>
            /// Gets or sets the name of the compared to.
            /// </summary>
            /// <value>
            /// The name of the compared to.
            /// </value>
            private string ComparedToName { get; set; }

            /// <summary>
            /// Predicates the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns>true if meets criteria, otherwise false</returns>
            public bool Predicate(T input)
            {
                return input != null && input.Name == ComparedToName;
            }
        }


        /// <summary>
        /// Exists the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
		public bool ExistsByName(string name)
        {
            return this.Count(t => t.Name == name) > 0;
        }


        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the 1st instance if meets criteria, otherwise null</returns>
        public T GetByName(string name)
        {
            return this.Single(t => t.Name == name);
        }

        /// <summary>
        /// Gets the name of the collection by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the collection which each item meets criteria, otherwise null</returns>
        public NameValueCollection<T> GetCollectionByName(string name)
        {
            NameValueCollection<T> _retval = new NameValueCollection<T>();
            _retval.AddRange(this.Where(t => t.Name == name));
            return _retval;
        }

        #endregion PrediacteByName

        #region PrediacteByValue
 
        /// <summary>
        /// Prediacte by Value
        /// </summary>
        private class PrediacteByValue
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NameValueCollection&lt;T&gt;.PrediacteByValue"/> class.
            /// </summary>
            /// <param name="comparedToValue">The compared to value.</param>
            public PrediacteByValue(string comparedToValue)
            {
                this.ComparedToValue = comparedToValue;
            }

            /// <summary>
            /// Gets or sets the compared to value.
            /// </summary>
            /// <value>
            /// The compared to value.
            /// </value>
            private string ComparedToValue { get; set; }

            /// <summary>
            /// Predicates the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns>true if meets criteria, otherwise false</returns>
            public bool Predicate(T input)
            {
                return input != null && input.Value == ComparedToValue;
            }
        }

        /// <summary>
        /// Exists the by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        public bool ExistsByValue(string value)
        {
            return this.Count(t => t.Value == value) > 0;
        }

        /// <summary>
        /// Gets the by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the 1st instance if meets criteria, otherwise null</returns>
        public T GetByValue(string value)
        {
            return this.Single(t => t.Value == value);
        }


        /// <summary>
        /// Gets the collection by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the collection which each item meets criteria, otherwise null</returns>
        public NameValueCollection<T> GetCollectionByValue(string value)
        {
            NameValueCollection<T> _retval = new NameValueCollection<T>();
            _retval.AddRange(this.Where(t => t.Value == value));
            return _retval;
        }

        #endregion PrediacteByValue

        #region Add(value, name)

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public void Add(string value, string name)
        {
            T _NewItem = new T();
            _NewItem.Name = name;
            _NewItem.Value = value;
            this.Add(_NewItem);
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public void Add(System.Guid value, string name)
        {
            this.Add(value.ToString(), name);
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
		public void Add(long value, string name)
        {
            this.Add(value.ToString(), name);
        }

        #endregion Add(value, name)

    }

    #endregion class NameValueCollection<T>

    #region class NameValuePair and NameValueCollection

	/// <summary>
    /// Concrete NameValuePair
    /// </summary>
    [DataContract]
    public class NameValuePair : INameValuePair
    {
		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValuePair"/> class.
        /// </summary>
        public NameValuePair() { }

		public NameValuePair(
            long value, string name
            )
			: this(value.ToString(), name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValuePair"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public NameValuePair(
            Guid value, string name
            )
			: this(value.ToString(), name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValuePair"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public NameValuePair(
            string value, string name
            ) 
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValuePair"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public NameValuePair(
            decimal value, string name
            )
            : this(value.ToString(), name)
        {
        }

		#endregion Constructors

		#region Properties


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
		[DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
		[DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Name { get; set; }

		#endregion Properties

		#region ToString()


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
		public override string ToString()
        {
            return string.Format("{0}:{1}", this.Value, this.Name);
        }

		#endregion ToString()

		#region Equals(...)
		
        /// <summary>
        /// http://blog.ariankulp.com/2013/07/fixing-selecteditem-must-always-be-set.html
        /// Fixing SelectedItem must always be set to a valid value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            try
            {
                if (obj is NameValuePair)
                {
                    return obj != null && ((NameValuePair)obj).Value == this.Value;
                }
                else
                {
                    return obj != null && string.IsNullOrWhiteSpace(this.Value) && this.Value == obj.ToString();
                }
            }
            catch
            {
                return false;
            }
        }

		#endregion Equals(...)

        #region Parse value to .net value

        public System.Boolean ParseToSystemBoolean(string defaultValueString)
        {
            System.Boolean retValue;
            if (!System.Boolean.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Boolean.Parse(defaultValueString);
                }
                else
                {
                    retValue = false;
                }
            }
            return retValue;
        }


        public System.Byte ParseToSystemByte(string defaultValueString)
        {
            System.Byte retValue;
            if (!System.Byte.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Byte.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Char ParseToSystemChar(string defaultValueString)
        {
            return string.IsNullOrWhiteSpace(this.Value) || this.Value.Length == 0 ? ' ' : this.Value.ToCharArray()[0];
        }


        public System.DateTime ParseToSystemDateTime(string defaultValueString)
        {
            System.DateTime retValue;
            if (!System.DateTime.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.DateTime.Parse(defaultValueString);
                }
                else
                {
                    retValue = System.DateTime.Now;
                }
            }
            return retValue;
        }


        public System.Decimal ParseToSystemDecimal(string defaultValueString)
        {
            System.Decimal retValue;
            if (!System.Decimal.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Decimal.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Double ParseToSystemDouble(string defaultValueString)
        {
            System.Double retValue;
            if (!System.Double.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Double.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Guid ParseToSystemGuid(string defaultValueString)
        {
            System.Guid retValue;
            if (!System.Guid.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Guid.Parse(defaultValueString);
                }
                else
                {
                    retValue = System.Guid.NewGuid();
                }
            }
            return retValue;
        }


        public System.Int16 ParseToSystemInt16(string defaultValueString)
        {
            System.Int16 retValue;
            if (!System.Int16.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Int16.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Int32 ParseToSystemInt32(string defaultValueString)
        {
            System.Int32 retValue;
            if (!System.Int32.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Int32.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Int64 ParseToSystemInt64(string defaultValueString)
        {
            System.Int64 retValue;
            if (!System.Int64.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Int64.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.Single ParseToSystemSingle(string defaultValueString)
        {
            System.Single retValue;
            if (!System.Single.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.Single.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.String ParseToSystemString(string defaultValueString)
        {
            return this.Value;
        }


        public System.SByte ParseToSystemSByte(string defaultValueString)
        {
            System.SByte retValue;
            if (!System.SByte.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.SByte.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.UInt16 ParseToSystemUInt16(string defaultValueString)
        {
            System.UInt16 retValue;
            if (!System.UInt16.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.UInt16.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.UInt32 ParseToSystemUInt32(string defaultValueString)
        {
            System.UInt32 retValue;
            if (!System.UInt32.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.UInt32.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }


        public System.UInt64 ParseToSystemUInt64(string defaultValueString)
        {
            System.UInt64 retValue;
            if (!System.UInt64.TryParse(this.Value, out retValue))
            {
                if (!string.IsNullOrWhiteSpace(defaultValueString))
                {
                    retValue = System.UInt64.Parse(defaultValueString);
                }
                else
                {
                    retValue = 0;
                }
            }
            return retValue;
        }

        #endregion Parse value to .net value
    }


    /// <summary>
    /// Concrete NameValueCollection 
    /// </summary>
	public class NameValueCollection : NameValueCollection<NameValuePair>
    {
        #region constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="NameValueCollection"/> class.
        /// </summary>
        public NameValueCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValueCollection"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public NameValueCollection(IEnumerable<NameValuePair> input)
            : base(input)
        {
        }

		        /// <summary>
        /// Initializes/Parse a new instance of the <see cref="NameValueCollection"/> class.
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="delimiter">delimiter between 2 namevalue pair</param>
        /// <param name="nameValueSparator">delimiter between name and value</param>
        public NameValueCollection(string input, string delimiter, string nameValueSparator)
        {
            string[] _Split = input.Split(delimiter.ToCharArray());
            if (_Split != null)
            {
                foreach (string _NameValuePair in _Split)
                {
                    string[] _SplitNameValue = _NameValuePair.Split(nameValueSparator.ToCharArray());
                    if (_SplitNameValue.Length == 2)
                    {
                        this.Add(_SplitNameValue[1], _SplitNameValue[0]);
                    }
                }
            }
        }

        #endregion constructors    


        #region  this[string name]

        /// <summary>
        /// string indexer by name
        /// </summary>
        /// <param name="name">the name</param>
        /// <returns>the value</returns>
        public string this[string name]
        {
            get
            {
                NameValuePair _Item = this.GetByName(name);
                if (_Item != null)
                {
                    return _Item.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                NameValuePair _Item;
                
                if(this.ExistsByName(name))
                {
                    _Item= this.GetByName(name);
                    _Item.Value = value;
                }
                else
                {
                    this.Add(new NameValuePair(value, name));
                }
            }
        }

        #endregion  this[string name]
    }

    #endregion class NameValuePair and NameValueCollection
}