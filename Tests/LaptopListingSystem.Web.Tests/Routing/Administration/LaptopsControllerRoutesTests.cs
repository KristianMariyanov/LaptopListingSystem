namespace LaptopListingSystem.Web.Tests.Routing.Administration
{
    using LaptopListingSystem.Web.Areas.Administration.Controllers;
    using LaptopListingSystem.Web.Areas.Administration.InputModels.Laptops;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class LaptopsControllerRoutesTests
    {
        [Fact]
        public void GetLaptopsShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/administration/laptops")
                    .WithMethod("GET"))
                .To<LaptopsController>(c => c.Get());
        }

        [Fact]
        public void GetLaptopShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/administration/laptops/1")
                    .WithMethod("GET"))
                .To<LaptopsController>(c => c.Get(1));
        }

        [Fact]
        public void GetLaptopDropdownItemsShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/administration/laptops/getdropdownitems")
                    .WithMethod("GET"))
                .To<LaptopsController>(c => c.GetDropdownItems());
        }

        [Fact]
        public void AddLaptopShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/administration/laptops")
                    .WithJsonBody(
                        new
                        {
                            Model = "Model",
                            AdditionalParts = "AdditionalParts",
                            Description = "Description",
                            HardDisk = 200,
                            ImageUrl = "ImageUrl",
                            ManufacturerId = 1,
                            Monitor = 15.6,
                            Price = 1000,
                            Ram = 16,
                            Weight = (double?)null
                        })
                    .WithMethod("POST"))
                .To<LaptopsController>(c => c.Post(
                    new LaptopInputModel
                    {
                        Model = "Model",
                        AdditionalParts = "AdditionalParts",
                        Description = "Description",
                        HardDisk = 200,
                        ImageUrl = "ImageUrl",
                        ManufacturerId = 1,
                        Monitor = 15.6,
                        Price = 1000,
                        Ram = 16,
                        Weight = null
                    }));
        }
    }
}
