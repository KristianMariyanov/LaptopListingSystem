namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Web.Areas.Administration.InputModels.Laptops;
    using LaptopListingSystem.Web.Areas.Administration.ViewModels.Laptops;

    using Microsoft.AspNetCore.Mvc;

    public class LaptopsController : BaseAdministrationController
    {
        private readonly IRepository<Laptop> laptops;
        private readonly IMappingService mappingService;

        public LaptopsController(
            IRepository<Laptop> laptops,
            IMappingService mappingService)
        {
            this.laptops = laptops;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var laptopModels = this.mappingService.MapCollection<LaptopViewModel>(
                this.laptops.All().OrderByDescending(l => l.CreatedOn));

            return this.Json(laptopModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var laptopModel = this.mappingService
                .MapCollection<LaptopViewModel>(this.laptops.All().Where(c => c.Id == id))
                .FirstOrDefault();

            return this.Json(laptopModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody]LaptopInputModel inputModel)
        {
            if (inputModel != null)
            {
                var laptop = this.mappingService.Map<Laptop>(inputModel);
                this.laptops.Add(laptop);
                this.laptops.SaveChanges();

                return this.Created(string.Empty, laptop);
            }

            return this.BadRequest("Invalid input");
        }

        [HttpPut]
        public IActionResult Put([FromBody]LaptopInputModel inputModel)
        {
            if (inputModel != null)
            {
                var laptop = this.laptops.GetById(inputModel.Id);

                this.mappingService.Map(inputModel, laptop);
                this.laptops.SaveChanges();

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }

        [HttpDelete("{laptopId}")]
        public IActionResult Delete(int laptopId)
        {
            if (laptopId != default(int))
            {
                var lapptop = this.laptops.GetById(laptopId);
                this.laptops.Delete(lapptop);
                this.laptops.SaveChanges();

                return this.Ok();
            }

            return this.BadRequest("Invalid input");
        }
    }
}
