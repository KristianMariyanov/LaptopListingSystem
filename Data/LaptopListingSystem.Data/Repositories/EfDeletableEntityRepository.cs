namespace LaptopListingSystem.Data.Repositories
{
    using System;
    using System.Linq;

    using LaptopListingSystem.Data.Models.Common.Contracts;
    using LaptopListingSystem.Data.Repositories.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class EfDeletableEntityRepository<T> : EfGenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, new()
    {
        public EfDeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All() => base.All().Where(x => !x.IsDeleted);

        public IQueryable<T> AllWithDeleted() => base.All();

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            this.Update(entity);
        }

        public virtual void HardDelete(T entity) => base.Delete(entity);

        public void Undelete(T entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;

            this.Update(entity);
        }
    }
}
