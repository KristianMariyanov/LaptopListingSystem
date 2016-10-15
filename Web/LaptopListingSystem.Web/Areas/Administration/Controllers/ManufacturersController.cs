namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Comments;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Manufacturers;

    using Microsoft.AspNetCore.Mvc;

    public class ManufacturersController : BaseAdministrationController
    {
        private readonly IRepository<Manufacturer> manufacturers;
        private readonly IMappingService mappingService;

        public ManufacturersController(
            IRepository<Manufacturer> manufacturers,
            IMappingService mappingService)
        {
            this.manufacturers = manufacturers;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var commentModels = this.mappingService.MapCollection<ManufacturerViewModel>(
                this.manufacturers.All().OrderByDescending(l => l.CreatedOn));

            return this.Json(commentModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var manufacturerModel = this.mappingService
                .MapCollection<ManufacturerViewModel>(this.manufacturers.All().Where(c => c.Id == id))
                .FirstOrDefault();

            return this.Json(manufacturerModel);
        }

        [HttpPost]
        public IActionResult Post(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var manufacturer = new Manufacturer { Name = name };
                this.manufacturers.Add(manufacturer);
                this.manufacturers.SaveChanges();

                return this.Created(string.Empty, manufacturer);
            }

            return this.BadRequest("Invalid input");
        }

        [HttpPut]
        public IActionResult Put(int manufacturerId, string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && manufacturerId != default(int))
            {
                var comment = this.manufacturers.GetById(manufacturerId);

                comment.Name = name;

                this.manufacturers.SaveChanges();

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }

        [HttpDelete("{manufacturerId}")]
        public IActionResult Delete(int manufacturerId)
        {
            if (manufacturerId != default(int))
            {
                var comment = this.manufacturers.GetById(manufacturerId);
                this.manufacturers.Delete(comment);
                this.manufacturers.SaveChanges();

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }
    }
}
