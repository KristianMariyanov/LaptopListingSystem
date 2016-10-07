namespace LaptopListingSystem.Data.Models.Common
{
    using System;

    using LaptopListingSystem.Data.Models.Common.Contracts;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        //[Index] // TODO: Move to context
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
