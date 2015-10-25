using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// Query OrderBy Setting
    /// </summary>
    public class QueryOrderBySetting
	{
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOrderBySetting"/> class.
        /// </summary>
		public QueryOrderBySetting()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOrderBySetting"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
#if NETFX_CORE
        public QueryOrderBySetting(
            string propertyName
            , string direction)
        {
            this.PropertyName = propertyName;
            this.Direction = direction;
        }
#else
        public QueryOrderBySetting(
            string propertyName
            , System.ComponentModel.ListSortDirection direction)
        {
            this.PropertyName = propertyName;
            this.Direction = direction;
        }
#endif
		#endregion constructors

		#region properties

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>

        public string PropertyName { get; set; }
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
#if NETFX_CORE
        public string Direction { get; set; }
#else
        public System.ComponentModel.ListSortDirection Direction { get; set; }
#endif


		#endregion properties

    }

    /// <summary>
    /// a list/collection can have several order by clause
    /// </summary>
    public class QueryOrderBySettingCollection : List<QueryOrderBySetting>
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOrderBySettingCollection"/> class.
        /// </summary>
		public QueryOrderBySettingCollection()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOrderBySettingCollection"/> class.
        /// </summary>
        /// <param name="queryOrderByExpression">The query order by expression can be parsed to <see cref="QueryOrderBySettingCollection"/> .</param>
		public QueryOrderBySettingCollection(string queryOrderByExpression)
		{
			if (string.IsNullOrWhiteSpace(queryOrderByExpression) == false)
            {
                string[] _Splitted1 = queryOrderByExpression.Split("|".ToCharArray());
                if (_Splitted1 != null && _Splitted1.Length > 0)
                {
                    foreach (string _Splitted1Item in _Splitted1)
                    {
                        if (string.IsNullOrWhiteSpace(_Splitted1Item) == false)
                        {
                            string[] _Splitted2 = _Splitted1Item.Trim().Split("~".ToCharArray());
#if NETFX_CORE     
                            if (_Splitted2.Length == 1)
                            {
                                this.Add(_Splitted2[0], "Ascending");
                            }
                            else if (_Splitted2.Length > 1)
                            {
                                string _ListSortDirection;
                                if (_Splitted2[1].Trim().ToLower() == "DESC".ToLower())
                                {
                                    _ListSortDirection = "Descending";
                                }
                                else
                                {
                                    _ListSortDirection = "Ascending";
                                }
                                this.Add(_Splitted2[0], _ListSortDirection);
                            }
#else
                            if (_Splitted2.Length == 1)
                            {
                                this.Add(_Splitted2[0], System.ComponentModel.ListSortDirection.Ascending);
                            }
                            else if (_Splitted2.Length > 1)
                            {
                                System.ComponentModel.ListSortDirection _ListSortDirection;
                                if (_Splitted2[1].Trim().ToLower() == "DESC".ToLower())
                                {
                                    _ListSortDirection = System.ComponentModel.ListSortDirection.Descending;
                                }
                                else
                                {
                                    _ListSortDirection = System.ComponentModel.ListSortDirection.Ascending;
                                }
                                this.Add(_Splitted2[0], _ListSortDirection);
                            }
#endif
                        }
                    }
                }
            }
		}

		#endregion constructors

        /// <summary>
        /// Adds one item of QueryOrderBySetting to this collection
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
#if NETFX_CORE        
        public void Add(
            string propertyName
            , string direction)
        {
            this.Add(new QueryOrderBySetting(propertyName, direction));
        }
#else
        public void Add(
            string propertyName
            , System.ComponentModel.ListSortDirection direction)
        {
            this.Add(new QueryOrderBySetting(propertyName, direction));
        }
#endif

        /// <summary>
        /// Gets the OrderBy expression.
        /// </summary>
        /// <returns>order by expression in string</returns>
        public string GetOrderByExpression()
        {
            StringBuilder _SB = new StringBuilder();

            int _Count = 0;
            foreach (QueryOrderBySetting _QueryOrderBySetting in this)
            {
                if (_Count == 0)
                {
                    _Count++;
                }
                else
                {
                    _SB.Append(",");
                }
#if NETFX_CORE        
                _SB.Append(string.Format("{0}{1}", _QueryOrderBySetting.PropertyName, _QueryOrderBySetting.Direction == "Ascending" ? "" : " DESC"));
#else
                _SB.Append(string.Format("{0}{1}", _QueryOrderBySetting.PropertyName, _QueryOrderBySetting.Direction == System.ComponentModel.ListSortDirection.Ascending ? "" : " DESC"));
#endif
            }

            return _SB.ToString();
        }
    }
}