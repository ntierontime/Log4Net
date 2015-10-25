using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.DataSourceEntities
{
    public class DataAccessLayerMessageBase<T>
    {
		#region properties

        /// <summary>
        /// Gets or sets the data access layer message status.
        /// </summary>
        /// <value>
        /// The data access layer message status.
        /// </value>
        public DataAccessLayerMessageStatus DataAccessLayerMessageStatus { get; set; }
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public T Result { get; set; }
        /// <summary>
        /// Gets or sets the query paging result.
        /// </summary>
        /// <value>
        /// The query paging result.
        /// </value>
        public Framework.EntityContracts.QueryPagingResult QueryPagingResult { get; set; }
        /// <summary>
        /// Gets or sets the Original Value, this property used in Insert/Update/Delete, not for Query
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public T OriginalValue { get; set; }
        /// <summary>
        /// Gets or sets the message source component.
        /// </summary>
        /// <value>
        /// The message source component.
        /// </value>
        public string MessageSourceComponent { get; set; }
        /// <summary>
        /// Gets or sets the message source function.
        /// </summary>
        /// <value>
        /// The message source function.
        /// </value>
        public string MessageSourceFunction { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
		
		#endregion properties
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of Integer
    /// </summary>
    public class DataAccessLayerMessageOfInteger
        : DataAccessLayerMessageBase<int>
    {
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of Boolean
    /// </summary>
    public class DataAccessLayerMessageOfBoolean
        : DataAccessLayerMessageBase<bool>
    {
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of NameValuePairEntityCollection
    /// </summary>
    public class DataAccessLayerMessageOfNameValuePairEntityCollection
        : DataAccessLayerMessageBase<Framework.NameValueCollection>
    {
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of NameValuePair
    /// </summary>
    public class DataAccessLayerMessageOfNameValuePairEntity
        : DataAccessLayerMessageBase<Framework.NameValuePair>
    {
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of RssItemCollection
    /// </summary>
	public class DataAccessLayerMessageOfRssItemCollection
        : DataAccessLayerMessageBase<Framework.RssItemCollection>
    {
    }

    /// <summary>
    /// Built-in DataAccessLayerMessage of RssItem
    /// </summary>
    public class DataAccessLayerMessageRssItem
        : DataAccessLayerMessageBase<Framework.RssItem>
    {
    }

    /// <summary>
    /// status of all DataAccessLayerMessage
    /// </summary>
    public enum DataAccessLayerMessageStatus
    {
        /// <summary>
        /// Successfully load data from data source.
        /// </summary>
        Success,
        /// <summary>
        /// Error when load data from data source
        /// </summary>
        Fail,
        /// <summary>
        /// no data and no error
        /// </summary>
		SuccessButNoResult,
    }
}