namespace LaptopListingSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using LaptopListingSystem.Data.Models;

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
    }
}
