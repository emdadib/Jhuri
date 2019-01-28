using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jhuri.Code;
using Jhuri.Data;
using Jhuri.Models;
using Jhuri.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Jhuri
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
            services.AddDbContext<ApplicationDbContext>
                (option => option.UseSqlServer(Configuration.GetConnectionString("JhuriCon"))
                );
            services.AddIdentity<ApplicationUsers, ApplicationRoles>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = ".Jhuri.Session";
                option.IdleTimeout = TimeSpan.FromDays(20);
                option.Cookie.HttpOnly = true;
            });
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                option.Lockout.MaxFailedAccessAttempts = 10;
                option.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.Cookie.Expiration = TimeSpan.FromDays(150);
                option.LoginPath = "/Users/Login";
                option.LogoutPath = "/Users/Logout";
                option.AccessDeniedPath = "/Users/AccessDenied";
                option.SlidingExpiration = true;
            });
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider, UserManager<ApplicationUsers> userManager, RoleManager<ApplicationRoles> roleManager)
        {

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            //for first time seed data
       //     IdentityDbInitializer.SeedData(userManager, roleManager);
        //    DbInitializer.Initialize(provider.GetRequiredService<ApplicationDbContext>());

            if (env.IsDevelopment())
            {
                app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
