namespace LaptopListingSystem.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Models.Common.Contracts;

    public class LaptopListingSystemDbContext : IdentityDbContext<User>
    {
        public LaptopListingSystemDbContext(DbContextOptions<LaptopListingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Manufacturer>().HasIndex(m => m.Name).IsUnique();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            var auditInfoEntries = this.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in auditInfoEntries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
