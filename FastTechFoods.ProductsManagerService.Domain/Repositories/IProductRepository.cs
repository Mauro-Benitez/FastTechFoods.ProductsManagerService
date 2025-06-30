using FastTechFoods.ProductsManagerService.Domain.Entities;

namespace FastTechFoods.ProductsManagerService.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<List<Product>> GetProduct();
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);


    }
}
