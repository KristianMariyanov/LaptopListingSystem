using System.ComponentModel.DataAnnotations;

namespace LaptopListingSystem.Data.Models
{
    using System.Collections.Generic;

    using LaptopListingSystem.Common.Constants;
    using LaptopListingSystem.Data.Models.Common;

    public class Manufacturer : AuditInfo
    {
        private ICollection<Laptop> laptops;

        public Manufacturer()
        {
            this.laptops = new HashSet<Laptop>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops
        {
            get { return this.laptops; }
            set { this.laptops = value; }
        }
    }
}
