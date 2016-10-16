namespace LaptopListingSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using LaptopListingSystem.Data.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;

        public AuthController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromForm]string email, [FromForm]string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}
