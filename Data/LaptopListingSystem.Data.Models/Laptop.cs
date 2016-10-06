using System.ComponentModel.DataAnnotations;

namespace LaptopListingSystem.Data.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int ManufactureId { get; set; }

        public virtual Manufacture Manufacture { get; set; }
    }
}
