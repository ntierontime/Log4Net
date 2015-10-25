using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLLEntities
{
    /// <summary>
    /// BuiltIn BusinessLogicLayerRequestMessage for entity Log4Net.Log
    /// </summary>
    public class BusinessLogicLayerRequestMessageBuiltInLog
        : Framework.CommonBLLEntities.BusinessLogicLayerRequestMessageBase<Log4Net.DataSourceEntities.LogCollection>
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInLog"/> class.
        /// </summary>
        public BusinessLogicLayerRequestMessageBuiltInLog()
			: base()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>        
		/// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        public BusinessLogicLayerRequestMessageBuiltInLog(
            Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			)
			: base(businessLogicLayerRequestTypes, businessLogicLayerRequestTypeKey, businessLogicLayerRequestID)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>
        /// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public BusinessLogicLayerRequestMessageBuiltInLog(
            Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			, int currentIndex
            , int pageSize
			, string queryOrderByExpression)
			: base(businessLogicLayerRequestTypes, businessLogicLayerRequestTypeKey, businessLogicLayerRequestID, currentIndex, pageSize, queryOrderByExpression)
        {
        }

        #endregion constructors
    }

    /// <summary>
    /// BuiltIn BusinessLogicLayerRequestMessage for entity Log4Net.DataSourceEntities.LogIdentifier
    /// </summary>
    public class BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog
        : Framework.CommonBLLEntities.BusinessLogicLayerRequestMessageBase<Log4Net.DataSourceEntities.LogIdentifier>
    {
#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog"/> class.
        /// </summary>
        public BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog()
			: base()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>        
		/// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        public BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog(
            Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			)
			: base(businessLogicLayerRequestTypes, businessLogicLayerRequestTypeKey, businessLogicLayerRequestID)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerRequestMessageBuiltInLog"/> class.
        /// </summary>
        /// <param name="businessLogicLayerRequestTypes">The business logic layer request types.</param>
        /// <param name="businessLogicLayerRequestTypeKey">The business logic layer request type key.</param>
        /// <param name="businessLogicLayerRequestID">The business logic layer request ID.</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="queryOrderByExpression">The query order by expression.</param>
        public BusinessLogicLayerRequestMessageBuiltInOfIdentifierLog(
            Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes businessLogicLayerRequestTypes
            , string businessLogicLayerRequestTypeKey
            , string businessLogicLayerRequestID
			, int currentIndex
            , int pageSize
			, string queryOrderByExpression)
			: base(businessLogicLayerRequestTypes, businessLogicLayerRequestTypeKey, businessLogicLayerRequestID, currentIndex, pageSize, queryOrderByExpression)
        {
        }

        #endregion constructors
    }
}