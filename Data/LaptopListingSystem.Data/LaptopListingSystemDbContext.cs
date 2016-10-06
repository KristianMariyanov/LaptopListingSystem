using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaptopListingSystem.Data
{
    using LaptopListingSystem.Data.Models;

    public class LaptopListingSystemDbContext : IdentityDbContext<User>
    {
        public LaptopListingSystemDbContext(DbContextOptions<LaptopListingSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Manufacture>().HasIndex(m => m.Name).IsUnique();
        }
    }
}
