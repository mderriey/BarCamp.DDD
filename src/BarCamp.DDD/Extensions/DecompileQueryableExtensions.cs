namespace BarCamp.DDD
{
    using DelegateDecompiler;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class DecompileQueryableExtensions
    {
        public static IQueryable<T> Include<T, TEnumerable>(this IQueryable<T> queryable, Expression<Func<T, IEnumerable<TEnumerable>>> path)
        {
            var body = path.Body;
            var member = (PropertyInfo)((MemberExpression)body).Member;
            var decompiled = DecompileExpressionVisitor.Decompile(body) as MethodCallExpression;
            var converted = Expression.Convert(decompiled.Arguments[0], typeof(ICollection<TEnumerable>));
            var collectionExpression = Expression.Lambda<Func<T, ICollection<TEnumerable>>>(converted, path.Parameters);
            return QueryableExtensions.Include(queryable, collectionExpression);
        }
    }
}
