namespace LaptopListingSystem.Web.Infrastructure.Extensions
{
    using System.Reflection;

    using LaptopListingSystem.Web.Infrastructure.Mapping;

    using Microsoft.AspNetCore.Builder;
    
    public static class IApplicationBuilderExtensions
    {
        public static void RegisterAutoMapperMappings(this IApplicationBuilder app, params Assembly[] assemblies)
        {
            AutoMapperConfig.RegisterMappings(assemblies);
        }
    }
}
