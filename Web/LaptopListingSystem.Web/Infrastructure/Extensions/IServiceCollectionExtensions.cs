﻿namespace LaptopListingSystem.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using LaptopListingSystem.Data;
    using LaptopListingSystem.Data.Repositories;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Administration.Contracts;
    using LaptopListingSystem.Services.Common;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Services.Common.Mapping;
    using LaptopListingSystem.Services.Data.Contracts;
    using LaptopListingSystem.Web.Infrastructure.Mapping;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static void AddLaptopListingSystemServices(this IServiceCollection services)
        {
            var serviceAssemblies = new[]
            {
                typeof(IService).GetTypeInfo().Assembly,
                typeof(IUsersDataService).GetTypeInfo().Assembly,
                typeof(IAdministrationService<>).GetTypeInfo().Assembly
            };

            var typeServiceRegistrationsInfo = serviceAssemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t =>
                    typeof(IService).IsAssignableFrom(t) &&
                    !t.GetTypeInfo().IsAbstract)
                .Select(t => new
                {
                    ConcreteType = t,
                    ServiceTypes = t
                        .GetInterfaces()
                        .Where(i =>
                            i.GetTypeInfo().IsPublic &&
                            i != typeof(IService))
                })
                .ToList();

            foreach (var registration in typeServiceRegistrationsInfo)
            {
                foreach (var serviceType in registration.ServiceTypes)
                {
                    services.AddScoped(serviceType, registration.ConcreteType);
                }
            }
            
            services.AddTransient(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddTransient(typeof(IRepository<>), typeof(EfGenericRepository<>));
            services.AddTransient<DbContext, LaptopListingSystemDbContext>();
            services.AddScoped<IMappingService, AutoMapperMappingService>();
            services.AddScoped<IMapper>(ctx => AutoMapperConfig.MapperConfiguration?.CreateMapper());
        }
    }
}
