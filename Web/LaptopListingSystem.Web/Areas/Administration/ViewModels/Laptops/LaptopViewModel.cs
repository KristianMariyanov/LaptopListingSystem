namespace LaptopListingSystem.Web.Areas.Administration.ViewModels.Laptops
{
    using LaptopListingSystem.Web.ViewModels.Laptops;
    public class LaptopViewModel : LaptopShortViewModel
    {
        public double Monitor { get; set; }

        public int HardDisk { get; set; }

        public int Ram { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int VotesCount { get; set; }
    }
}
