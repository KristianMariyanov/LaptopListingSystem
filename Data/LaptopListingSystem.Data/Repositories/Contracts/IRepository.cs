namespace LaptopListingSystem.Data.Repositories.Contracts
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(params object[] id);

        void Detach(T entity);

        T GetById(params object[] id);

        Task<T> GetByIdAsync(params object[] id);

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
