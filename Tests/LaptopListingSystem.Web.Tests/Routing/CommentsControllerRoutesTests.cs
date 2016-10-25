namespace LaptopListingSystem.Web.Tests.Routing
{
    using LaptopListingSystem.Web.Controllers;
    using LaptopListingSystem.Web.InputModels.Comments;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class CommentsControllerRoutesTests
    {
        [Fact]
        public void CommentLaptopShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/comments")
                    .WithJsonBody(new { LaptopId = 1, Content = "TestContent"})
                    .WithMethod("POST"))
                .To<CommentsController>(c => c.Post(new CommentInputModel { LaptopId = 1, Content = "TestContent" }));
        }
    }
}
