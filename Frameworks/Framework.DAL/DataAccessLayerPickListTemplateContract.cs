using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DAL
{
    public interface DataAccessLayerPickListTemplateContract<TCollection>
    {
        TCollection BuildCollectionFromStringValue(string masterIDName, string masterID, string slaveIDName, List<string> slaveIDs);
        TCollection BuildCollectionFromStringValueWithSession(string masterIDName, string masterID, string slaveIDName, List<string> slaveIDs);
    }
}