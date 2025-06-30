using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.Dtos;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using FastTechFoods.ProductsManagerService.Domain.Entities;


namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public interface IProductService
    {
        Task<Result> CreateProductAsync(CreateOrEditProductInputModel product);
        Task<Result> UpdateProductAsync(CreateOrEditProductInputModel contact);
        Task<Result> DeleteProductAsync(Guid id);
        Task<Result<List<ProductDto>>> GetProducts();
    }
}
