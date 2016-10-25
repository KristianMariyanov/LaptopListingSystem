namespace LaptopListingSystem.Web.Tests.Routing
{
    using LaptopListingSystem.Web.Controllers;
    using LaptopListingSystem.Web.InputModels.Votes;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class VotesControllerRoutesTests
    {
        [Fact]
        public void VoteForLaptopShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/votes")
                    .WithJsonBody(new { LaptopId = 1 })
                    .WithMethod("POST"))
                .To<VotesController>(c => c.Post(new VoteInputModel { LaptopId = 1}));
        }
    }
}
