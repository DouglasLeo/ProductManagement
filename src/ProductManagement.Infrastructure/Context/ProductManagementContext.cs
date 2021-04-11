using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Context
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductManagementContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}