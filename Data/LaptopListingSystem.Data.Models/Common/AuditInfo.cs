﻿namespace LaptopListingSystem.Data.Models.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using LaptopListingSystem.Data.Models.Common.Contracts;

    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
