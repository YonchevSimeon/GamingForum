namespace GamingForum.Web
{
    using AutoMapper;
    using Data;
    using GamingForum.Web.Infrastructure;
    using Infrastructure.Extensions;
    using Infrastructure.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services
                .AddDbContext<GamingForumDbContext>(options =>
                    options
                        .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"))
                        .UseLazyLoadingProxies());

            services
                .AddDefaultIdentity<GamingForumUser>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GamingForumDbContext>();

            services
                .AddAutoMapper(cfg =>
                    cfg.AddProfile<GamingForumProfile>());

            services.AddAntiforgery();

            services
                .AddDomainServices();

            services
                .AddRouting(routing =>
                    routing.LowercaseUrls = true);

            services
                .AddMvc(options =>
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMiddleware(typeof(SeedRolesMiddleware));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: "areas",
                       template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
