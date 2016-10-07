namespace LaptopListingSystem.Data.Repositories.Contracts
{
    using System.Linq;

    using LaptopListingSystem.Data.Models.Common.Contracts;

    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);

        void Undelete(T entity);
    }
}
