namespace LaptopListingSystem.Services.Administration.Contracts
{
    using System.Linq;

    using LaptopListingSystem.Data.Models.Common.Contracts;

    public interface IDeletableEntityAdministrationService<TDeletableEntity> : IAdministrationService<TDeletableEntity>
        where TDeletableEntity : class, IDeletableEntity
    {
        IQueryable<TDeletableEntity> ReadWithDeleted();

        void HardDelete(params object[] id);

        void HardDelete(TDeletableEntity entity);
    }
}
