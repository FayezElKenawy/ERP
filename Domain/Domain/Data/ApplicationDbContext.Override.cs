using Domain.baseData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using System.Threading;
using System.IO;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Domain.Models;

namespace Domain.Data
{
    public partial class ApplicationDbContext
    {
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseDataClass
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        static readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
        private static IList<Type> _entityTypeCache;

        private static IList<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }

            _entityTypeCache = (from a in GetReferencingAssemblies()
                                from t in a.DefinedTypes
                                where t.BaseType == typeof(BaseDataClass)
                                select t.AsType()).ToList();

            return _entityTypeCache;
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies;
        }

        private string GetLoggedInEmployeeId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                if (httpContext.User != null)
                {
                    var user = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                    if (user != null)
                    {
                        var userIdStr = user.Value;
                        return userIdStr;
                    }
                }
            }
            return null;
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is BaseDataClass trackable)
                {
                    var now = DateTime.UtcNow;
                    var userId = GetLoggedInEmployeeId();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastModified = now;
                            trackable.ModifiedById = userId;
                            break;

                        case EntityState.Added:
                            trackable.DateCreated = now;
                            trackable.LastModified = now;
                            trackable.IsDeleted = false;
                            trackable.ModifiedById = userId;
                            trackable.CreatedById = userId;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            trackable.ModifiedById = userId;
                            trackable.LastModified = now;
                            trackable.IsDeleted = true;
                            break;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
          base.OnModelCreating(modelBuilder);
        }
    }
}
