using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    ///  include information of a query, filter critieria, paging, sorting
    /// </summary>
    /// <typeparam name="TQueryCriteria">The type of the filter/query criteria.</typeparam>
    public class BusinessLogicLayerRequestMessageBase<TQueryCriteria>
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBase&lt;TQueryCriteria&gt;"/> class.
        /// </summary>
        public BusinessLogicLayerRequestMessageBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBase&lt;TQueryCriteria&gt;"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>        
        /// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        public BusinessLogicLayerRequestMessageBase(
            BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			)
			: this(businessLogicLayerRequestTypes, businessLogicLayerRequestTypeKey, businessLogicLayerRequestID, -1, -1, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBase&lt;TQueryCriteria&gt;"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>
        /// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public BusinessLogicLayerRequestMessageBase(
            BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			, int currentIndex
            , int pageSize
			, string queryOrderByExpression)
        {
            this.BusinessLogicLayerRequestID = businessLogicLayerRequestID;
            this.BusinessLogicLayerRequestTypeKey = businessLogicLayerRequestTypeKey;
            this.BusinessLogicLayerRequestTypes = businessLogicLayerRequestTypes;
			this.QueryPagingSetting = new Framework.EntityContracts.QueryPagingSetting(currentIndex, pageSize);
			this.QueryOrderBySettingCollection = new Framework.EntityContracts.QueryOrderBySettingCollection(queryOrderByExpression);
        }

        #endregion constructors

        #region Properties

		/// <summary>
        /// Gets or sets the business logic layer request types.
        /// </summary>
        /// <value>
        /// The business logic layer request types.
        /// </value>
		[DataMember]
        public BusinessLogicLayerRequestTypes BusinessLogicLayerRequestTypes { get; set; }

        /// <summary>
        /// can find which class sent the request
        /// </summary>
        /// <value>
        /// The business logic layer request type key.
        /// </value>
		[DataMember]
        public string BusinessLogicLayerRequestTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the business logic layer request ID.
        /// </summary>
        /// <value>
        /// The business logic layer request ID.
        /// </value>
		[DataMember]
        public string BusinessLogicLayerRequestID { get; set; }

        /// <summary>
        /// Gets or sets the critieria.
        /// </summary>
        /// <value>
        /// The critieria.
        /// </value>
		[DataMember]
        public TQueryCriteria Critieria { get; set; }

		/// <summary>
        /// Gets or sets the query order by setting collection.
        /// </summary>
        /// <value>
        /// The query order by setting collection.
        /// </value>
		[DataMember]
		public Framework.EntityContracts.QueryOrderBySettingCollection QueryOrderBySettingCollection { get; set; }

		/// <summary>
        /// Gets or sets the query paging setting.
        /// </summary>
        /// <value>
        /// The query paging setting.
        /// </value>
		[DataMember]
		public Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }
		

        /// <summary>
        /// Gets or sets the status change_ date period id_ later.
        /// </summary>
        /// <value>
        /// The status change_ date period id_ later.
        /// </value>
		[DataMember]
		public long StatusChange_DatePeriodId_Later { get; set; }
        /// <summary>
        /// Gets or sets the status change_ date period id_ ealier.
        /// </summary>
        /// <value>
        /// The status change_ date period id_ ealier.
        /// </value>
		[DataMember]
		public long StatusChange_DatePeriodId_Ealier { get; set; }
        /// <summary>
        /// Gets or sets the status change_ time period id_ later.
        /// </summary>
        /// <value>
        /// The status change_ time period id_ later.
        /// </value>
		[DataMember]
		public short StatusChange_TimePeriodId_Later { get; set; }
        /// <summary>
        /// Gets or sets the status change_time period id_ ealier.
        /// </summary>
        /// <value>
        /// The status change_time period id_ ealier.
        /// </value>
		[DataMember]
		public short StatusChange_timePeriodId_Ealier { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        [DataMember]
        public Framework.DataServiceTypes DataServiceType { get; set; }

        #endregion Properties
    }
}