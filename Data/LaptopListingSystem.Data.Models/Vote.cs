namespace LaptopListingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using LaptopListingSystem.Data.Models.Common;

    public class Vote : DeletableEntity
    {
        public int Id { get; set; }

        public int LaptopId { get; set; }

        public Laptop Laptop { get; set; }

        // TODO: Uncomment
        //[Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
