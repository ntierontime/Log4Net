using System;
using System.Runtime.Serialization;

namespace Log4Net.EntityContracts
{

	public interface ILogIdentifier
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


    /// <summary>
    ///  a property defined when <see cref="LogIdentifier"/> is used in other classes.
    /// </summary>
    public interface WithIdentifierContractLog<T>
        where T : ILogIdentifier
    {
        T LogIdentifier { get; set; }
    }
}