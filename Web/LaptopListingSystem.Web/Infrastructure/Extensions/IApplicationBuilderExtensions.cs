namespace LaptopListingSystem.Web.Infrastructure.Extensions
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;

    using Suls.Common.Mapping;

    public static class IApplicationBuilderExtensions
    {
        public static void RegisterAutoMapperMappings(this IApplicationBuilder app, params Assembly[] assemblies)
        {
            AutoMapperConfig.RegisterMappings(assemblies);
        }
    }
}
