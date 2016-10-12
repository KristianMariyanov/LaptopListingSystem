namespace LaptopListingSystem.Web.Controllers
{
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Web.InputModels.Comments;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IDeletableEntityRepository<Comment> comments;

        public CommentsController(IDeletableEntityRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IActionResult Post(CommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                // TODO: get user
                var comment = new Comment { Content = inputModel.Content, LaptopId = inputModel.LaptopId };
                this.comments.Add(comment);

                // We don't have view of single comments
                return this.Created(string.Empty, comment);
            }

            return this.BadRequest("Invalid input");
        }
    }
}
