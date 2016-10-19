namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Administration.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Manufacturers;

    using Microsoft.AspNetCore.Mvc;

    public class ManufacturersController : BaseAdministrationController<Manufacturer>
    {
        private readonly IMappingService mappingService;

        public ManufacturersController(
            IUsersDataService usersData,
            IAdministrationService<Manufacturer> administrationService,
            IMappingService mappingService)
            : base(usersData, administrationService)
        {
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var commentModels = this.mappingService.MapCollection<ManufacturerViewModel>(
                this.AdministrationService.Read().OrderByDescending(l => l.CreatedOn));

            return this.Json(commentModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var manufacturerModel = this.mappingService.Map<ManufacturerViewModel>(this.AdministrationService.Get(id));

            return this.Json(manufacturerModel);
        }

        [HttpPost]
        public IActionResult Post(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var manufacturer = new Manufacturer { Name = name };
                this.AdministrationService.Create(manufacturer);

                return this.Created(string.Empty, manufacturer);
            }

            return this.BadRequest("Invalid input");
        }

        [HttpPut]
        public IActionResult Put(int manufacturerId, string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && manufacturerId != default(int))
            {
                var comment = this.AdministrationService.Get(manufacturerId);
                if (comment != null)
                {
                    comment.Name = name;
                    this.AdministrationService.Update(comment);

                    return this.Ok();
                }
            }

            return this.BadRequest("Invalid input");
        }

        [HttpDelete("{manufacturerId}")]
        public IActionResult Delete(int manufacturerId)
        {
            if (manufacturerId != default(int))
            {
                this.AdministrationService.Delete(manufacturerId);

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }
    }
}
