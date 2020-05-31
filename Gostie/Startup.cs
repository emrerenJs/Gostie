using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gostie.Entities;
using Gostie.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gostie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
                /*
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));*/
                })
                .AddRazorRuntimeCompilation();
            string con = "Server=(localdb)\\MSSQLLocalDB;Database=Gostie;Trusted_Connection=True";
            services.AddDbContext<GostieContext>(option=>option.UseSqlServer(con));
            services.AddDbContext<AppIdentityDbContext>(option => option.UseSqlServer(con));
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options=>
            {
                options.Password.RequireDigit = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/User/Login";
                option.LogoutPath = "/User/Logout";
                option.AccessDeniedPath = "/User/stat404";
                option.SlidingExpiration = false;
                option.ExpireTimeSpan = TimeSpan.FromHours(1);
                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Gostie.User.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);
        }
        public void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
