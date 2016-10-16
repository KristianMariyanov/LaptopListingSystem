namespace LaptopListingSystem.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Web.InputModels.Comments;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IDeletableEntityRepository<Comment> comments;
        private readonly IDeletableEntityRepository<User> users;

        public CommentsController(
            IDeletableEntityRepository<Comment> comments,
            IDeletableEntityRepository<User> users)
        {
            this.comments = comments;
            this.users = users;
        }

        public IActionResult Post(CommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var email = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userId = this.users.All().Where(u => u.Email == email).Select(u => u.Id).FirstOrDefault();
                var comment = new Comment { Content = inputModel.Content, LaptopId = inputModel.LaptopId, UserId = userId };
                this.comments.Add(comment);
                this.comments.SaveChanges();
                // We don't have view of single comments
                return this.Created(string.Empty, comment);
            }

            return this.BadRequest("Invalid input");
        }
    }
}
