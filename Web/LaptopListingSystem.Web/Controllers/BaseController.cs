namespace LaptopListingSystem.Web.Controllers
{
    using System.Security.Claims;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Services.Data.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public BaseController(IUsersDataService usersData)
        {
            this.UsersData = usersData;

            //var email = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        protected IUsersDataService UsersData { get; set; }

        public User UserProfile { get; set; }
    }
}
