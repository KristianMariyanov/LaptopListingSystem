namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using LaptopListingSystem.Services.Administration.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;
    using LaptopListingSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "Administrator")]
    [Route("api/administration/[controller]")]
    public class BaseAdministrationController<TEntity> : BaseController
        where TEntity : class
    {
        public BaseAdministrationController(
            IUsersDataService usersData,
            IAdministrationService<TEntity> administrationService)
            : base(usersData)
        {
            this.AdministrationService = administrationService;
        }

        protected IAdministrationService<TEntity> AdministrationService { get; set; }
    }
}
