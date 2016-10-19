namespace LaptopListingSystem.Web
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;

    using LaptopListingSystem.Data;
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Extensions;
    using LaptopListingSystem.Web.Infrastructure.TokenProvider;

    public class Startup
    {
        // TODO: Store SecretKey in more secure place
        private const string SecretKey = "needtogetthisfromenvironment";
        private readonly SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // Mvc
            services.AddApplicationInsightsTelemetry(this.Configuration);
            
            services.AddDbContext<LaptopListingSystemDbContext>(options =>
               options.UseSqlServer(
                   this.Configuration.GetConnectionString("DefaultConnection"), 
                   builder => builder.MigrationsAssembly("LaptopListingSystem.Web")));

            services.AddIdentity<User, IdentityRole>(s =>
                {
                    s.Password.RequireDigit = false;
                    s.Password.RequireLowercase = false;
                    s.Password.RequireUppercase = false;
                    s.Password.RequireNonAlphanumeric = false;
                    s.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<LaptopListingSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
            });

            services.AddMemoryCache();

            services.AddMvc();

            // Custom
            services.AddLaptopListingSystemServices();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var tokenProviderAppSettingOptions = this.Configuration.GetSection(nameof(TokenProviderOptions));

            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = tokenProviderAppSettingOptions[nameof(TokenProviderOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = tokenProviderAppSettingOptions[nameof(TokenProviderOptions.Audience)],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = this.signingKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/api/token",
                Audience = tokenProviderAppSettingOptions[nameof(TokenProviderOptions.Audience)],
                Issuer = tokenProviderAppSettingOptions[nameof(TokenProviderOptions.Issuer)],
                SigningCredentials = new SigningCredentials(this.signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = this.GetIdentity
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && 
                    !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseStaticFiles();

            app.UseMvc();

            app.RegisterAutoMapperMappings(
                typeof(Startup).GetTypeInfo().Assembly);
        }

        private async Task<ClaimsIdentity> GetIdentity(HttpContext context)
        {
            var email = context.Request.Form["email"];

            var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var password = context.Request.Form["password"];
                var isValidPassword = await userManager.CheckPasswordAsync(user, password);
                if (isValidPassword)
                {
                    return new GenericIdentity(email, "Token");
                }
            }

            return null;
        }
    }
}
