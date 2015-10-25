using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// ??
    /// </summary>
    [Obsolete("The original purpose is the utilize LinqKit predicate builder, retired.")]
	public enum QueryPredicateTypes
    {
        /// <summary>
        /// Contains
        /// </summary>
        Contains, // for string type only, e.g. LIKE
        /// <summary>
        /// Equals
        /// </summary>
        Equals,
        /// <summary>
        /// InRange
        /// </summary>
        InRange,
        /// <summary>
        /// InSelectedList
        /// </summary>
        InSelectedList,
    }
}