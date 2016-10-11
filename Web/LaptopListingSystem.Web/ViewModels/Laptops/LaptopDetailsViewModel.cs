namespace LaptopListingSystem.Web.ViewModels.Laptops
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.ViewModels.Comments;

    using Suls.Common.Mapping;

    public class LaptopDetailsViewModel : LaptopShortViewModel, IHaveCustomMappings
    {
        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        public double? Weight { get; set; }
        
        public string AdditionalParts { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<string> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Laptop, LaptopDetailsViewModel>()
                .ForMember(m => m.Comments, opt => opt.MapFrom(e => e.Comments.Select(c => c.Content)));
        }
    }
}
