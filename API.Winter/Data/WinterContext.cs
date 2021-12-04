using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Winter.Data
{
    public class ApplicationUser : IdentityUser
    {
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //if (!optionsBuilder.IsConfigured)
            //{

            //    var builder = new ConfigurationBuilder()
            //                   .SetBasePath(Directory.GetCurrentDirectory())
            //                   .AddJsonFile("appsettings.json");

            //    IConfiguration Configuration = builder.Build();

            //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            //}
     //   }
    }
}
