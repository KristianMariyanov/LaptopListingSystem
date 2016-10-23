namespace LaptopListingSystem.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IDeletableEntityRepository<Vote> votes;
        private readonly IDeletableEntityRepository<User> users;

        public VotesController(
            IUsersDataService usersData,
            IDeletableEntityRepository<Vote> votes,
            IDeletableEntityRepository<User> users)
            : base(usersData)
        {
            this.votes = votes;
            this.users = users;
        }

        public IActionResult Post(int laptopId)
        {
            if (laptopId != default(int))
            {
                // TODO: Prevent user to vote more then once.
                var email = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userId = this.users.All().Where(u => u.Email == email).Select(u => u.Id).FirstOrDefault();
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
