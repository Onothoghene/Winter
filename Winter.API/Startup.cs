using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Winter.API.Data;
using Winter.API.Helpers;
using Winter.API.Logic;
using Winter.API.Logic.Interfaces;
using Winter.API.Models;

namespace Winter.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<WinterContext>();
            services.AddScoped<IProduct, EFProduct>();
            services.AddScoped<IOrder, EFOrder>();
            services.AddScoped<ICategory, EFCategory>();
            services.AddScoped<IUsers, EFUser>();
            services.AddScoped<IWishList, EFWishList>();
            services.AddScoped<IAdmin, EFAdmin>();
            services.AddScoped<ICartItem, EFCartItem>();
            services.AddScoped<ISubCategory, EFSubCategory>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WishProfile());
                mc.AddProfile(new CartProfile());
                mc.AddProfile(new ProductProfile());
                mc.AddProfile(new SubCategoryProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen();
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Winter API ");
                // c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
