using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Winter.Models;

namespace Winter.Data
{
    public class WinterContext : IdentityDbContext
    {
        public WinterContext()
        {
        }
        public WinterContext (DbContextOptions<WinterContext> options)
            : base(options)
        {
        }
        //public DBModels()
        //    : base("name=DBModels")
        //{
        //}



        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductFile> ProductFile { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");

                IConfiguration Configuration = builder.Build();

                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            }
        }
    }
}
