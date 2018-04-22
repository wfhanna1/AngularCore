using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace BFFsAngularDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthenticationOptions>(Configuration.GetSection("Authentication:AzureAd"));
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddOpenIdConnect(o =>
            {
                o.ClientId = Configuration["Authentication:AzureAd:ClientId"];
                o.ClientSecret = Configuration["Authentication:AzureAd:ClientSecret"];
                o.Authority = Configuration["Authentication:AzureAd:AADInstance"] + Configuration["Authentication:AzureAd:TenantId"];
                o.CallbackPath = Configuration["Authentication:AzureAd:CallbackPath"];
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    // map the claimsPrincipal's roles to the roles claim
                    RoleClaimType = ClaimTypes.Role,
                };
                o.ResponseType = OpenIdConnectResponseType.CodeIdToken;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Angular",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" }
                );


                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
