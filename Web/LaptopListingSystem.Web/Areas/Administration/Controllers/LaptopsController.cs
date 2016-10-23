namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Administration.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;
    using LaptopListingSystem.Web.Areas.Administration.InputModels.Laptops;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Laptops;
    using LaptopListingSystem.Web.ViewModels.Common;

    using Microsoft.AspNetCore.Mvc;

    public class LaptopsController : BaseAdministrationController<Laptop>
    {
        private readonly IMappingService mappingService;

        public LaptopsController(
            IUsersDataService usersData,
            IAdministrationService<Laptop> administrationService,
            IMappingService mappingService)
            : base(usersData, administrationService)
        {
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var laptopModels = this.mappingService.MapCollection<LaptopViewModel>(
                this.AdministrationService.Read().OrderByDescending(l => l.CreatedOn));

            return this.Json(laptopModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var laptopModel = this.mappingService
                .MapCollection<LaptopViewModel>(this.AdministrationService.Read().Where(c => c.Id == id))
                .FirstOrDefault();

            return this.Json(laptopModel);
        }

        [HttpGet("[action]")]
        public IActionResult GetDropdownItems()
        {
            var laptopModel = this.mappingService.MapCollection<DropdownViewModel>(this.AdministrationService.Read());

            return this.Json(laptopModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody]LaptopInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var laptop = this.mappingService.Map<Laptop>(inputModel);
                this.AdministrationService.Create(laptop);

                return this.Created(string.Empty, laptop);
            }

            return this.BadRequest("Invalid input");
        }

        [HttpPut]
        public IActionResult Put([FromBody]LaptopInputModel inputModel)
        {
            if (inputModel != null)
            {
                var laptop = this.AdministrationService.Get(inputModel.Id);

                this.mappingService.Map(inputModel, laptop);
                this.AdministrationService.Update(laptop);

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }

        [HttpDelete("{laptopId}")]
        public IActionResult Delete(int laptopId)
        {
            if (laptopId != default(int))
            {
                this.AdministrationService.Delete(laptopId);

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }
    }
}
