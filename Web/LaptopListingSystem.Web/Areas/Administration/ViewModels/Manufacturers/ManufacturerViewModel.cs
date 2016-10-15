namespace LaptopListingSystem.Web.Areas.Administration.ViewModels.Manufacturers
{
    using System;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Mapping;

    public class ManufacturerViewModel : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
