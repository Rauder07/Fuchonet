using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;

namespace Fuchonet.Repositories.Utils
{
    public static class Pagination
    {
        public static IQueryable<T> OrderByPropertyOrField<T>( this IQueryable <T> queryable, string propertyOrFieldName, bool ascending = true)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFiledExpression = Expression.PropertyOrField(parameterExpression,propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFiledExpression, parameterExpression);

            var orderbyExpression = Expression.Call(typeof(Queryable),
                                                orderByMethodName,
                                                new[] { elementType, propertyOrFiledExpression.Type },
                                                queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderbyExpression);

        }
    }
}
