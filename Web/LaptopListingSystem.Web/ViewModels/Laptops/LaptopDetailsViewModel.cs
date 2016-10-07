namespace LaptopListingSystem.Web.ViewModels.Laptops
{
    using System.Collections.Generic;

    using LaptopListingSystem.Web.ViewModels.Comments;

    public class LaptopDetailsViewModel : LaptopShortViewModel
    {
        public int Id { get; set; }

        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        public double? Weight { get; set; }
        
        public string AdditionalParts { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
