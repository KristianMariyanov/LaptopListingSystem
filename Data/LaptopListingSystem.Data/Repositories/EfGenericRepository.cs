namespace LaptopListingSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using LaptopListingSystem.Common.Extensions;
    using LaptopListingSystem.Data.Repositories.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class EfGenericRepository<T> : IRepository<T>
        where T : class
    {
        public EfGenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(
                    nameof(context),
                    "An instance of DbContext is required to use this repository.");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> All() => this.DbSet.AsQueryable();

        public virtual void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(params object[] id)
        {
            var entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public T GetById(params object[] id)
        {
            return this.DbSet.Find(id);
        }

        public Task<T> GetByIdAsync(params object[] id)
        {
            return this.DbSet.FindAsync(id);
        }

        public int SaveChanges() => this.Context.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            this.Context.SaveChangesAsync(cancellationToken);
    }
}
