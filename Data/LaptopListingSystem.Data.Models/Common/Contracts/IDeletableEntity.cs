namespace LaptopListingSystem.Data.Models.Common.Contracts
{
    using System;

    public interface IDeletableEntity : IAuditInfo
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
