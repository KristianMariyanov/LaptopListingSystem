namespace LaptopListingSystem.Web.Controllers
{
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Web.InputModels.Comments;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IDeletableEntityRepository<Vote> votes;

        public VotesController(IDeletableEntityRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public IActionResult Post(int laptopId)
        {
            if (laptopId != default(int))
            {
                // TODO: get user
                var vote = new Vote { LaptopId = laptopId };
                this.votes.Add(vote);

                // We don't have view of single vote
                return this.Created(string.Empty, vote);
            }

            return this.BadRequest("Invalid input");
        }
    }
}
