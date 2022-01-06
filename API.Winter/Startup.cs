using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using API.Winter.Data;
using API.Winter.Logic.Interfaces;
using API.Winter.Logic;
using AutoMapper;
using API.Winter.Helpers;

namespace API.Winter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sql => sql.MigrationsAssembly("API.Winter")));

            services.AddIdentityCore<ApplicationUser>(options => { });
            // services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, IdentityRole, ApplicationDbContext>>();
            // services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole, ApplicationDbContext>>();

            // dependency injections
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAccount, EFAccount>();
            services.AddScoped<IAdmin, EFAdmin>();
            services.AddScoped<IBrand, EFBrand>();
            services.AddScoped<ICartItem, EFCartItem>();
            services.AddScoped<ICategory, EFCategory>();
            services.AddScoped<IOrder, EFOrder>();
            services.AddScoped<IProduct, EFProduct>();
            services.AddScoped<ISubCategory, EFSubCategory>();
            services.AddScoped<IUsers, EFUser>();
            services.AddScoped<IWishList, EFWishList>();
            services.AddScoped<ICategoryType, EFCategoryType>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Winter API", Version = "v1" });

            });

            //Auto Mapper Configurations
           var mapperConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile(new WishProfile());
               mc.AddProfile(new CartProfile());
               mc.AddProfile(new ProductProfile());
               mc.AddProfile(new SubCategoryProfile());
               mc.AddProfile(new CategoryProfile());
               mc.AddProfile(new ProductFileProfile());
               mc.AddProfile(new CategoryTypeProfile());
           });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Winter API ");
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
