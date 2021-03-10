using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Product>  Products { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //costum identity tables
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
            modelBuilder.Entity<SalesDetails>()
               .HasKey(cs => new { cs.ProductID, cs.InvoiceId });
            modelBuilder.Entity<Product>()
            .Property(b => b.Cost)
            .HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.SalePrice)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.Balance)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.OpenBalance)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.OpenCost)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.LastBalance)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.LastCost)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.ForignCost)
.HasDefaultValue(0);
            modelBuilder.Entity<Product>()
.Property(b => b.DateCreated)
.HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Product>()
.Property(b => b.LastModified)
.HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Product>()
.Property(b => b.IsDeleted)
.HasDefaultValue(0);
            foreach (var type in GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            }
        }
    }

}
