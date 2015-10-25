using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Log4Net.LinqDAL
{
    /// <summary>
    /// a factory class, can create all data access layer class instances for each entity.
    /// </summary>
    public class LinqToSqlDataAccessLayerFactory
        : Log4Net.DALContracts.DataAccessLayerFactoryContract
	{
        #region properties

        /// <summary>
        /// connection string to connect a database
        /// </summary>
        public string ConnectionString { get; set; }

        #endregion properties

        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public LinqToSqlDataAccessLayerFactory()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Log4Net"].ConnectionString;
        }


        /// <summary>
        /// constructor with connection string as paramter
        /// </summary>
        /// <param name="connectionString">database connection string</param>
		public LinqToSqlDataAccessLayerFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #endregion constructors

		#region Entity related


        /// <summary>
        /// method to create an data access layer class instance of <see cref="Log4Net.DALContracts.DataAccessLayerEntityContractLog"/>
        /// </summary>
        /// <returns>a new instance of <see cref="Log4Net.DALContracts.DataAccessLayerEntityContractLog"/>.</returns>
        public Log4Net.DALContracts.DataAccessLayerEntityContractLog CreateDALInstanceOfLog()
        {
            return new Log4Net.LinqDAL.LinqToSqlDataAccessLayerEntityLog(new Log4Net.LinqToSqlContexts.Log4NetContext(this.ConnectionString));
        }



		#endregion Entity related
    }

    /// <summary>
    /// singlton class of <see cref="LinqToSqlDataAccessLayerFactory"/>
    /// </summary>
    public class LinqToSqlDataAccessLayerFactorySingleton : Framework.Singleton<LinqToSqlDataAccessLayerFactory>
    {
    }
}