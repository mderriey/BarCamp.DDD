namespace BarCamp.DDD
{
    using DelegateDecompiler;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class EntityTypeConfigurationExtensions
    {
        public static ManyNavigationPropertyConfiguration<T, TTarget> HasMany<T, TTarget>(
            this EntityTypeConfiguration<T> source,
            Expression<Func<T, IEnumerable<TTarget>>> navigationPropertyExpression)
            where T : class 
            where TTarget : class
        {
            var body = navigationPropertyExpression.Body;
            var member = (PropertyInfo)((MemberExpression)body).Member;
            var decompiled = DecompileExpressionVisitor.Decompile(body) as MethodCallExpression;
            var converted = Expression.Convert(decompiled.Arguments[0], typeof(ICollection<TTarget>));
            var collectionExpression = Expression.Lambda<Func<T, ICollection<TTarget>>>(converted, navigationPropertyExpression.Parameters);
            return source.HasMany(collectionExpression);
        }
    }
}
