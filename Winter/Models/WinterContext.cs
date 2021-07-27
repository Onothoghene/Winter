using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Winter.Models
{
    public partial class WinterContext : DbContext
    {
        public WinterContext()
        {
        }

        public WinterContext(DbContextOptions<WinterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalInfo> AdditionalInfo { get; set; }
        public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<OrderRequest> OrderRequest { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Wish> Wish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Winter;Integrated Security=True");
            //            }

            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");

                IConfiguration Configuration = builder.Build();

                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalInfo>(entity =>
            {
                entity.Property(e => e.AdditionalPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdditionalInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Additiona__UserI__534D60F1");
            });

            modelBuilder.Entity<ApplicationRoles>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LastDateLoggedIn).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__ProductId__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__UserId__5070F446");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductFile_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductFile_Product_ProductId");
            });

            modelBuilder.Entity<OrderRequest>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateApproved).HasColumnType("datetime");

                entity.Property(e => e.DateCancelled).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.OrderRequest)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderRequ__Added__571DF1D5");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderRequest)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderRequ__Produ__5629CD9C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__5FB337D6");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__Categ__5CD6CB2B");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.AspNetId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(450);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__RoleI__76969D2E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__UserI__778AC167");
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wish)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wish__ProductId__4BAC3F29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wish)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wish__UserId__4CA06362");
            });
        }
    }
}
