using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Abstraction;


namespace FastTechFoods.ProductsManagerService.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<PagedResult<Product>> GetProductAsync(int page, int quantityPerPage);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);

       
    }
}
