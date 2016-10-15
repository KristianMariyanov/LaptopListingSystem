namespace LaptopListingSystem.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "Administrator")]
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IDeletableEntityRepository<Vote> votes;
        private readonly IDeletableEntityRepository<User> users;

        public VotesController(
            IDeletableEntityRepository<Vote> votes,
            IDeletableEntityRepository<User> users)
        {
            this.votes = votes;
            this.users = users;
        }

        public IActionResult Post(int laptopId)
        {
            if (laptopId != default(int))
            {
                // TODO: Prevent user to vote more then once.
                var userName = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userId = this.users.All().Where(u => u.UserName == userName).Select(u => u.Id).FirstOrDefault();
                var vote = new Vote { LaptopId = laptopId, UserId = userId };
                this.votes.Add(vote);
                this.votes.SaveChanges();

                // We don't have view of single comments
                return this.Created(string.Empty, vote);
            }

            return this.BadRequest("Invalid input");
        }
    }
}
