namespace LaptopListingSystem.Web.Areas.Administration.InputModels.Laptops
{
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Mapping;
    public class LaptopInputModel : IMapTo<Laptop>
    {
        public int Id { get; set; }
        
        // TODO: Add validation
        public string Model { get; set; }

        // TODO : Add validation
        public double Monitor { get; set; }

        // TODO : Add validation
        public int HardDisk { get; set; }

        // TODO : Add validation
        public int Ram { get; set; }

        // TODO : Add validation
        public string ImageUrl { get; set; }

        // TODO : Add validation
        public decimal Price { get; set; }

        // TODO : Add validation
        public double? Weight { get; set; }

        // TODO : Add validation
        public string AdditionalParts { get; set; }

        // TODO : Add validation
        public string Description { get; set; }

        public int ManufacturerId { get; set; }
    }
}
