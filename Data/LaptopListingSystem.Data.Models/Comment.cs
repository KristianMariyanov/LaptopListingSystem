namespace LaptopListingSystem.Data.Models
{
    public class Comment
    {
        public string Content { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public string UserId { get; set; }

        public User ApplicationUser { get; set; }
    }
}
