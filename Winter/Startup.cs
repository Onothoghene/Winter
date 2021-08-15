using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Winter.Logic;
using Microsoft.AspNetCore.Mvc;
using Winter.Services;
using Winter.Data;
using Winter.Models;
using AutoMapper;
using Winter.ViewModels.Input_Models;
using Winter.ILogic;
using Microsoft.AspNetCore.Http;

namespace Winter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSession();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentityCore<ApplicationUser>(options => { });
            //services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, IdentityRole, ApplicationDbContext>>();
            //services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole, ApplicationDbContext>>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                           .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<WinterContext>();
            services.AddSingleton<ModelFactory, ModelFactory>();
            services.AddScoped<IProduct, EFProduct>();
            services.AddScoped<IOrder, EFOrder>();
            services.AddScoped<ICategory, EFCategory>();
            services.AddScoped<IUsers, EFUser>();
            services.AddScoped<IWishList, EFWishList>();
            services.AddScoped<IAdmin, EFAdmin>();
            services.AddScoped<ICartItem, EFCartItem>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseAuthentication();

            Mapper.Initialize(cfg =>
            {
               
                cfg.CreateMap<ProductInputViewModel, Product>();

                cfg.CreateMap<ProductFileInputViewModel, Files>();

            });

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Winter API");
                // c.RoutePrefix = string.Empty;
            });

        }
    }

}