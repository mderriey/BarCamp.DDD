namespace BarCamp.DDD
{
    using DelegateDecompiler;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    internal static class DecompileQueryableExtensions
    {
        public static IQueryable<T> Include<T, TEnumerable>(this IQueryable<T> queryable, Expression<Func<T, IEnumerable<TEnumerable>>> path)
        {
            var decompiled = (Expression<Func<T, IEnumerable<TEnumerable>>>)DecompileExpressionVisitor.Decompile(path);
            return QueryableExtensions.Include(queryable, decompiled);
        }
    }
}
