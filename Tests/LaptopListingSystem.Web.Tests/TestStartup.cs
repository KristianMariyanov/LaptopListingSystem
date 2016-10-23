namespace LaptopListingSystem.Web.Tests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env)
            : base(env)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }
    }
}
