namespace LaptopListingSystem.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public static class DbSetExtensions
    {
        public static TEntity Find<TEntity>(this DbSet<TEntity> set, params object[] keyValues)
            where TEntity : class
        {
            var context = set.GetService<ICurrentDbContext>().Context;

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = FindEntriesInChangeTracker<TEntity>(context, key, keyValues);

            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }

            var query = BuildFindQuery(set, key, keyValues);

            // Look in the database
            return query.FirstOrDefault();
        }

        public static async Task<TEntity> FindAsync<TEntity>(this DbSet<TEntity> set, params object[] keyValues)
            where TEntity : class
        {
            var context = set.GetService<ICurrentDbContext>().Context;

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = FindEntriesInChangeTracker<TEntity>(context, key, keyValues);

            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }

            // Look in the database
            var query = BuildFindQuery(set, key, keyValues);

            return await query.FirstOrDefaultAsync();
        }

        private static IEnumerable<EntityEntry<TEntity>> FindEntriesInChangeTracker<TEntity>(
            DbContext context,
            IKey key,
            params object[] keyValues)
            where TEntity : class
        {
            var entries = context.ChangeTracker.Entries<TEntity>();

            for (var i = 0; i < key.Properties.Count; i++)
            {
                var property = key.Properties[i];
                var currentKey = keyValues[i];

                entries = entries.Where(e => e.Property(property.Name).CurrentValue == currentKey);
            }

            return entries;
        }

        private static IQueryable<TEntity> BuildFindQuery<TEntity>(
            IQueryable<TEntity> set,
            IKey key,
            params object[] keyValues)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");

            var query = set;
            for (var i = 0; i < key.Properties.Count; i++)
            {
                query = query.Where(
                    (Expression<Func<TEntity, bool>>)Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, key.Properties[i].Name),
                            Expression.Constant(keyValues[i])),
                        parameter));
            }

            return query;
        }
    }
}
