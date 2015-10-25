using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// Generic Summary Data container
    /// </summary>
    public class SummaryData
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryData"/> class.
        /// </summary>
        public SummaryData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryData"/> class.
        /// </summary>
        /// <param name="KnownMathCalculation">The known math calculation.</param>
        /// <param name="ValueType">Type of the value.</param>
        /// <param name="SummaryValueDouble">The summary value double.</param>
        /// <param name="SummaryValueDateTime">The summary value date time.</param>
        /// <param name="SummaryValueString">The summary value string.</param>
        /// <param name="HeaderString">The header string.</param>
        /// <param name="DisplayFormat">The display format.</param>
        public SummaryData(
            Framework.EntityContracts.KnownMathCalculations KnownMathCalculation,
            System.Type ValueType,
            System.Double? SummaryValueDouble,
            System.DateTime? SummaryValueDateTime,
            System.String SummaryValueString,
            System.String HeaderString,
            System.String DisplayFormat
            )
        {
            this.KnownMathCalculation = KnownMathCalculation;
            this.ValueType = ValueType;
            this.SummaryValueDouble = SummaryValueDouble;
            this.SummaryValueDateTime = SummaryValueDateTime;
            this.SummaryValueString = SummaryValueString;
            this.HeaderString = HeaderString;
            this.DisplayFormat = DisplayFormat;
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the known math calculation.
        /// </summary>
        /// <value>
        /// The known math calculation.
        /// </value>
        public KnownMathCalculations KnownMathCalculation { get; set; }
        /// <summary>
        /// Gets or sets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public Type ValueType { get; set; }
        /// <summary>
        /// Gets or sets the summary value double.
        /// </summary>
        /// <value>
        /// The summary value double.
        /// </value>
        public double? SummaryValueDouble { get; set; }
        /// <summary>
        /// Gets or sets the summary value date time.
        /// </summary>
        /// <value>
        /// The summary value date time.
        /// </value>
        public DateTime? SummaryValueDateTime { get; set; }
        /// <summary>
        /// Gets or sets the summary value string.
        /// </summary>
        /// <value>
        /// The summary value string.
        /// </value>
        public string SummaryValueString { get; set; }
        /// <summary>
        /// Gets or sets the header string.
        /// </summary>
        /// <value>
        /// The header string.
        /// </value>
        public string HeaderString { get; set; }
        /// <summary>
        /// Gets or sets the display format.
        /// </summary>
        /// <value>
        /// The display format.
        /// </value>
        public string DisplayFormat { get; set; }

        #endregion properties

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("KnownMathCalculation:{0};ValueType:{1};SummaryValueDouble:{2};SummaryValueDateTime:{3};SummaryValueString:{4};HeaderString:{5};DisplayFormat:{6};", this.KnownMathCalculation, this.ValueType, this.SummaryValueDouble, this.SummaryValueDateTime, this.SummaryValueString, this.HeaderString, this.DisplayFormat);
        }

        #endregion override string ToString()

    }

    /// <summary>
    /// collection class of <see cref="SummaryData"/>, Generic Summary Data container collection
    /// </summary>
    public class SummaryDataCollection
        : List<SummaryData>
    {
        #region Add(...)

        /// <summary>
        /// Adds the specified known math calculation.
        /// </summary>
        /// <param name="KnownMathCalculation">The known math calculation.</param>
        /// <param name="ValueType">Type of the value.</param>
        /// <param name="SummaryValueDouble">The summary value double.</param>
        /// <param name="SummaryValueDateTime">The summary value date time.</param>
        /// <param name="SummaryValueString">The summary value string.</param>
        /// <param name="HeaderString">The header string.</param>
        /// <param name="DisplayFormat">The display format.</param>
        public void Add(
            Framework.EntityContracts.KnownMathCalculations KnownMathCalculation,
            System.Type ValueType,
            System.Double? SummaryValueDouble,
            System.DateTime? SummaryValueDateTime,
            System.String SummaryValueString,
            System.String HeaderString,
            System.String DisplayFormat)
        {
            SummaryData _Item = new SummaryData(
                KnownMathCalculation,
                ValueType,
                SummaryValueDouble,
                SummaryValueDateTime,
                SummaryValueString,
                HeaderString,
                DisplayFormat);
            this.Add(_Item);
        }

        #endregion Add(...)

        #region override string ToString()

        public override string ToString()
        {
            StringBuilder _SB = new StringBuilder();
            foreach (SummaryData _SummaryData in this)
            {
                _SB.AppendFormat("{0}^{1}|", this.IndexOf(_SummaryData), _SummaryData.ToString());
            }

            return _SB.ToString();
        }

        #endregion override string ToString()

    }
}