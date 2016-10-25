namespace LaptopListingSystem.Web.Tests.Routing
{
    using LaptopListingSystem.Web.Controllers;
    using LaptopListingSystem.Web.InputModels.Comments;

    using Microsoft.AspNetCore.Http;

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
                    .WithLocation("/api/laptops")
                    .WithMethod("Get"))
                .To<LaptopsController>(c => c.Get());
        }

        [Fact]
        public void GetLaptopShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/laptops/1")
                    .WithMethod("Get"))
                .To<LaptopsController>(c => c.Get(1));
        }

        [Fact]
        public void FilterLaptopsShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/laptops/filter")
                    .WithQueryString("?term=term&order=order")
                    .WithMethod("Get"))
                .To<LaptopsController>(c => c.Filter("term", "order"));
        }

        [Fact]
        public void GetLaptopsWithPagingShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/laptops/all")
                    .WithQueryString("?page=2")
                    .WithMethod("Get"))
                .To<LaptopsController>(c => c.All(2));
        }
    }
}
