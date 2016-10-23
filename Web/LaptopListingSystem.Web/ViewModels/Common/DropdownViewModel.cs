namespace LaptopListingSystem.Web.ViewModels.Common
{
    using AutoMapper;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Mapping;
    public class DropdownViewModel: IMapFrom<Manufacturer>, IMapFrom<Laptop>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Laptop, DropdownViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Model + " | " + e.Manufacturer.Name));
        }
    }
}
