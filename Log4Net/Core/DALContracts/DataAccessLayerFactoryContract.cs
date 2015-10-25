using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Log4Net.DALContracts
{
    /// <summary>
    /// There is one method for each entity class, which creates data access layer instance.
    /// </summary>
    public interface DataAccessLayerFactoryContract
//        <

//		TDALContractOfLog, TCollectionOfLog, TOfLog, TIdentifierOfLog


//        >


//            where TDALContractOfLog : DataAccessLayerEntityContractLog<TCollectionOfLog, TOfLog, TIdentifierOfLog>
//            where TCollectionOfLog : IList<TOfLog>, new()
//            where TOfLog : Log4Net.EntityContracts.ILog, new()
//            where TIdentifierOfLog : Log4Net.EntityContracts.ILogIdentifier, new()


    {

        /// <summary>
        /// Creates the DAL instance of Log4Net.DALContracts.DataAccessLayerEntityContractLog for entity TDALContractOfLog .
        /// </summary>
        /// <returns>one instance of data access layer class</returns>
        //TDALContractOfLog CreateDALInstanceOfLog();
		Log4Net.DALContracts.DataAccessLayerEntityContractLog CreateDALInstanceOfLog();


	}
}