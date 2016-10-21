namespace LaptopListingSystem.Data.Seed
{
    using System.Linq;

    using LaptopListingSystem.Common.Constants;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class LaptopListingSystemDbContextSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<LaptopListingSystemDbContext>();

            if (!context.Roles.Any())
            {
                context.Roles.Add(
                    new IdentityRole
                    {
                        Name = RoleNameConstants.Administrator,
                        NormalizedName = RoleNameConstants.Administrator
                    });
            }
        }
    }
}
