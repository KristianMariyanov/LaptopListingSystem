namespace LaptopListingSystem.Web.ViewModels.Laptops
{
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Mapping;

    public class LaptopShortViewModel : IMapFrom<Laptop>
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ManufacturerName { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
