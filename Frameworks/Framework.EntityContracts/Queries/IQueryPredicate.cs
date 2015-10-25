using System;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using System.Linq;

namespace Framework.EntityContracts
{
    /// <summary>
    /// provides a structure for all prodicates.
    /// </summary>
    /// <typeparam name="T">entity type</typeparam>
    public interface IQueryPredicate<T>
        where T : class
    {
        /// <summary>
        /// Predicates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>true if meets criteria, otherwise false</returns>
        bool Predicate(T input);
        /// <summary>
        /// Gets the predicate expression for T.
        /// </summary>
        /// <returns>Predicate expression</returns>
        Expression<Func<T, bool>> GetPredicateExpression();
    }
}