namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Administration.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Comments;

    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : BaseAdministrationController<Comment>
    {
        private readonly IDeletableEntityRepository<User> users;
        private readonly IMappingService mappingService;

        public CommentsController(
            IUsersDataService usersData,
            IDeletableEntityAdministrationService<Comment> administrationService,
            IDeletableEntityRepository<User> users,
            IMappingService mappingService)
            : base(usersData, administrationService)
        {
            this.users = users;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var commentModels = this.mappingService.MapCollection<CommentViewModel>(
                this.AdministrationService.Read().OrderByDescending(l => l.CreatedOn));

            return this.Json(commentModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var commentModel = this.mappingService
                .MapCollection<CommentViewModel>(this.AdministrationService.Read().Where(c => c.Id == id))
                .FirstOrDefault();

            return this.Json(commentModel);
        }

        [HttpPost]
        public IActionResult Post(string content, int laptopId, string userEmail)
        {
            if (!string.IsNullOrWhiteSpace(content) && laptopId != default(int) && !string.IsNullOrWhiteSpace(userEmail))
            {
                var userId = this.UsersData.GetUserIdByEmail(userEmail);
                var comment = new Comment { Content = content, LaptopId = laptopId, UserId = userId };
                this.AdministrationService.Create(comment);

                return this.Created(string.Empty, comment);
            }

            return this.BadRequest("Invalid input");
        }

        [HttpPut]
        public IActionResult Put(int commentId, string content, int laptopId, string userEmail)
        {
            if (!string.IsNullOrWhiteSpace(content) && laptopId != default(int) && !string.IsNullOrWhiteSpace(userEmail))
            {
                var userId = this.users.All().Where(u => u.Email == userEmail).Select(u => u.Id).FirstOrDefault();

                var comment = this.AdministrationService.Get(commentId);
                if (comment != null)
                {
                    comment.Content = content;
                    comment.LaptopId = laptopId;
                    comment.UserId = userId;
                    this.AdministrationService.Update(comment);

                    return this.Ok();
                }
            }

            return this.BadRequest("Invalid input");
        }

        [HttpDelete("{commentId}")]
        public IActionResult Delete(int commentId)
        {
            if (commentId != default(int))
            {
                this.AdministrationService.Delete(commentId);

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }
    }
}
