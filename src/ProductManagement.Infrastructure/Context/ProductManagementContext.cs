using System.ComponentModel.DataAnnotations.Schema;
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
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}