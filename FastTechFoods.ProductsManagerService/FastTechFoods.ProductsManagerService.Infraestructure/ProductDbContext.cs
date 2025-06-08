using FastTechFoods.ProductsManagerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            modelBuilder.Entity<Product>().Property(p => p.Type).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
        }
    }
    
}
