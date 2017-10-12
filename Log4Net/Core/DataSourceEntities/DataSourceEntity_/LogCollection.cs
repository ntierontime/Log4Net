using System.Collections.Generic;
using System.Linq;

namespace Log4Net.DataSourceEntities
{
    /// <summary>
    /// collection class for entity <see cref="Log"/>
    /// </summary>
    public partial class LogCollection : List<Log>
    {

        #region constructors

        /// <summary>
        ///  default constructors
        /// </summary>
        public LogCollection(): base()
        {
        }

        /// <summary>
        /// constructor with IEnumerable input
        /// </summary>
        /// <param name="input">a set of <see cref="IEnumerable<Log"/></param>
        public LogCollection(IEnumerable<Log> input)
            : base(input)
        {
        }

        #endregion constructors

        #region Add(...)

        /// <summary>
        /// add an item with parameters of .net value type for each property
        /// </summary>
        public void Add(
            System.Int64 id
            , System.DateTime date
            , System.String thread
            , System.String level
            , System.String logger
            , System.String message
            , System.String exception)
        {
            Log _Item = new Log(
                id
                , date
                , thread
                , level
                , logger
                , message
                , exception            );
            this.Add(_Item);
        }

        #endregion Add(...)

    }

            /// <summary>

    /// <summary>
    ///  a property defined when <see cref="ILogCollection"/> is used in other classes.
    /// </summary>
    public partial interface ILogCollection
    {
        /// <summary>
        /// Gets or sets the LogCollection
        /// </summary>
        /// <value>
        /// LogCollection
        /// </value>
        LogCollection LogCollection { get; set; }
    }

    /// <summary>
    /// message definition, pass single entry, pulled from database, to business logic layer. <see cref="LogCollection"/> and <see cref="Framework.DataSourceEntities.DataAccessLayerMessageBase&lt;T&gt;"/> />
    /// </summary>
    public partial class DataAccessLayerMessageOfEntityCollectionLog
        : Framework.DataSourceEntities.DataAccessLayerMessageBase<LogCollection>
    {
    }

}