using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using LinqKit;

namespace Framework.LinqDAL
{
    /// <summary>
    /// some methods when using Linq to Sql
    /// </summary>
    public static class LinqToSqlHelper
    {
		/// <summary>
        /// Combines the linq expression.
        /// </summary>
        /// <typeparam name="T">entity class</typeparam>
        /// <param name="_PredicateExpressionListOfD">The _ predicate expression list of D.</param>
        /// <returns>predicate expression</returns>
        public static Expression<Func<T, bool>> CombineLinqExpression<T>(List<Expression<Func<T, bool>>> _PredicateExpressionListOfD)
        {
            Expression<Func<T, bool>> _Exp = null;
            foreach (Expression<Func<T, bool>> _Exp1 in _PredicateExpressionListOfD)
            {
                if (_Exp == null)
                {
                    _Exp = _Exp1;
                }
                else
                {
                    _Exp = _Exp.And(_Exp1);
                }
            }
            return _Exp;
        }

    }
}