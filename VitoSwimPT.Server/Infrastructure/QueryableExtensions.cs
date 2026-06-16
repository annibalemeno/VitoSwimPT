using System.Linq.Expressions;

namespace VitoSwimPT.Server.Infrastructure

{
    public static class QueryableExtensions
    {

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string property)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.PropertyOrField(param, property);
            var keySelector = Expression.Lambda(body, param);

            return Queryable.OrderBy(source, (dynamic)keySelector);
        }

        public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string property)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.PropertyOrField(param, property);
            var keySelector = Expression.Lambda(body, param);

            return Queryable.OrderByDescending(source, (dynamic)keySelector);
        }
    }
}
