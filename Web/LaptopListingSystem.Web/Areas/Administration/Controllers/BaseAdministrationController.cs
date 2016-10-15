namespace LaptopListingSystem.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "Administrator")]
    [Route("api/administration/[controller]")]
    public class BaseAdministrationController : Controller
    {
    }
}
