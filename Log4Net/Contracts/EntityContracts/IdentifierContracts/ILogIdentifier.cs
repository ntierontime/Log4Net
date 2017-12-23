using System;
using System.Runtime.Serialization;

namespace Log4Net.EntityContracts
{

    public partial interface ILogIdentifier
    {

        System.Int64 Id { get; set; }

    }

    public class QueryPredicateLogByIdentifier<T>
        where T : ILog
    {
        public QueryPredicateLogByIdentifier(ILogIdentifier criteria)
        {
            this.Criteria = criteria;
        }

        public ILogIdentifier Criteria { get; set; }

        public bool Predicate(T input)
        {
            return input != null && this.Criteria != null &&

        input.Id == this.Criteria.Id
;
        }
    }
}

