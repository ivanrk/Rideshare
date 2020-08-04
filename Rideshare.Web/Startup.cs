namespace Rideshare.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Rideshare.Data;
    using Rideshare.Data.Models;
    using Rideshare.Services;
    using Rideshare.Services.Admin.Forum;
    using Rideshare.Services.Admin.Forum.Implementations;
    using Rideshare.Services.Forum;
    using Rideshare.Services.Implementations;
    using Rideshare.Web.Infrastructure.Mapping;
    using System;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RideshareDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<RideshareDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ITravelService, TravelService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubforumService, SubforumService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IHtmlService, HtmlService>();

            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            services.AddAutoMapper();

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "profile",
                    template: "[controller]/[action]/{username}");
            });

            app.UseCookiePolicy();

            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            Task.Run(async () =>
            {
                var roles = new string[] { "Admin" };

                foreach (var role in roles)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role);

                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var adminRole = "Admin";
                var adminUser = await userManager.FindByEmailAsync("test@test.com");
                var isInRole = await userManager.IsInRoleAsync(adminUser, adminRole);

                if (!isInRole)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            })
            .Wait();
        }
    }
}
