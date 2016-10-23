namespace LaptopListingSystem.Web.Tests.Routing
{
    using LaptopListingSystem.Web.Controllers;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class VotesControllerRoutesTests
    {
        [Fact]
        public void GetAddressAndPaymentShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/votes/1")
                    .WithMethod("POST"))
                .To<VotesController>(c => c.Post(1));
        }
    }
}
