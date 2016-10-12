namespace LaptopListingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using LaptopListingSystem.Data.Models.Common;

    public class Comment : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)] // TODO: Move to constants
        public string Content { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        // TODO: Uncomment
        //[Required] 
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
