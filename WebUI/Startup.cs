using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastReport.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Domain.Entities;
using Application.Contracts;
using Infrastructure.Result;
using Infrastructure.Services;
using Domain.Models.Constants;
using Infrastructure.Repositories;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using WebUI.Controllers;
using Infrastructure;

namespace WebUI
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages().AddNewtonsoftJson();

            //For access identity in classes
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddAutoMapper(typeof(AutoMapperConfiguration).GetType().Assembly);

            //Repository
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISharedRepository, SharedRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddControllers()
                           .AddNewtonsoftJson(options =>
                           {
                    // Use the default property (Pascal) casing
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                           });


            services.AddControllersWithViews();
            object p = services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));


            //حتما باید باشه وگرنه خطا میده
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();


            //Cookie
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                //options.Cookie.Expiration 

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10080);
                options.LoginPath = "/Auth/SignIn";
                options.LogoutPath = "/Auth/SignIn";
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.SlidingExpiration = true;
                //options.ReturnUrlParameter=""
            });

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
               .RequireAuthenticatedUser()
               .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();


            //Session
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10080);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), op =>
                op.CommandTimeout(60)));

            // Add framework services.
            services
                .AddControllersWithViews()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Add Kendo UI services to the services container
            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //حتما باید بین
            //UseRouting
            //و
            //UseEndpoints
            //باشه
            app.UseSession();
            app.UseFastReport();

            //همیشه در آخر باشه تا روت های اریا اول تست بشه
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "User/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "Product/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "Order/{controller=Home}/{action=Index}/{id?}"
                );
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Auth}/{action=SignIn}/{id?}");
            //});
        }
    }
}
