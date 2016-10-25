namespace LaptopListingSystem.Web.Tests.Routing
{
    using LaptopListingSystem.Web.Controllers;

    using Microsoft.AspNetCore.Http;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class AuthControllerRutesTests
    {
        [Fact]
        public void RegisterShouldBeRoutedCorrectly()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithLocation("/api/auth/register")
                    .WithMethod("POST")
                    .WithFormFields(new { Email = "user@domain.com", Password = "password" }))
                .To<AuthController>(c => c.Register("user@domain.com", "password"));
        }
    }
}
