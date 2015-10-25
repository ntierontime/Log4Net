using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Log4Net.EntityFrameworkDAL
{
    /// <summary>
    /// a factory class, can create all data access layer class instances for each entity.
    /// </summary>
    public class EFDataAccessLayerFactory
        : Log4Net.DALContracts.DataAccessLayerFactoryContract
	{
        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public EFDataAccessLayerFactory()
        {
        }

        #endregion constructors

		#region Entity related


        /// <summary>
        /// method to create an data access layer class instance of <see cref="Log4Net.DALContracts.DataAccessLayerEntityContractLog"/>
        /// </summary>
        /// <returns>a new instance of <see cref="Log4Net.DALContracts.DataAccessLayerEntityContractLog"/>.</returns>
        public Log4Net.DALContracts.DataAccessLayerEntityContractLog CreateDALInstanceOfLog()
        {
            return new Log4Net.EntityFrameworkDAL.EFDataAccessLayerEntityLog(new Log4Net.EntityFrameworkContext.Log4NetEntities());
        }



		#endregion Entity related
    }

    /// <summary>
    /// singlton class of <see cref="EFDataAccessLayerFactory"/>
    /// </summary>
    public class EFDataAccessLayerFactorySingleton : Framework.Singleton<EFDataAccessLayerFactory>
    {
    }
}