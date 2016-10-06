using System.ComponentModel.DataAnnotations;

namespace LaptopListingSystem.Data.Models
{
    using System.Collections.Generic;

    public class Manufacture
    {
        private ICollection<Laptop> laptops;

        public Manufacture()
        {
            this.laptops = new HashSet<Laptop>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops
        {
            get { return this.laptops; }
            set { this.laptops = value; }
        }
    }
}
