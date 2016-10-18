namespace LaptopListingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using LaptopListingSystem.Common.Constants;
    using LaptopListingSystem.Data.Models.Common;

    public class Laptop : AuditInfo
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Laptop()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.LaptopModelMaxLength)]
        public string Model { get; set; }

        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        [Required]
        [MaxLength(ValidationConstants.LaptopImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        [MaxLength(ValidationConstants.LaptopAdditionalPartsMaxLength)]
        public string AdditionalParts { get; set; }

        [MaxLength(ValidationConstants.LaptopDescriptionMaxLength)]
        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
