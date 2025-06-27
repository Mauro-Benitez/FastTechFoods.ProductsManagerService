using FastTechFoods.ProductsManagerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTechFoods.ProductsManagerService.Infraestructure
{
    public class ProductDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.ProductType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(p => p.Availability).IsRequired();

        }
    }
    
}
