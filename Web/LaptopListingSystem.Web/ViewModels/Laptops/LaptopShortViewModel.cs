namespace LaptopListingSystem.Web.ViewModels.Laptops
{
    using LaptopListingSystem.Data.Models;

    using Suls.Common.Mapping;
    public class LaptopShortViewModel : IMapFrom<Laptop>
    {
        public string Model { get; set; }

        public string ManufacturerName { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
