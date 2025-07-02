using FastTechFoods.ProductsManagerService.Domain.Abstraction;
using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Infraestructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var result = await GetProductByIdAsync(product.Id);

            return result;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                throw new ArgumentException("Product not found");

            _context.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                throw new ArgumentException("Product not found");

            return product;
        }

        public async Task<PagedResult<Product>> GetProductAsync(int page, int quantityPerPage)
        {
            var totalProducts = await _context.Products.CountAsync();

            if (totalProducts == 0)
                throw new ArgumentException("No products found");

            var totalPages = (int)Math.Ceiling(totalProducts / (double)quantityPerPage);

            var products = await _context.Products
            .Skip((page - 1) * quantityPerPage)
            .Take(quantityPerPage)
            .ToListAsync();

            return new PagedResult<Product>
            {
                Items = products,
                TotalPages = totalPages,
                CurrentPage = page
            };
        }



        public async Task<Product> UpdateProductAsync(Product product)
        {

            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (product is null)
                throw new ArgumentException("Product not found");

            _context.Products.Update(product);
            await _context.SaveChangesAsync();           

            return result;

        }
    }
}
