using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.InputModels;


namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public interface IProductService
    {
        Task<Result> CreateProductAsync(CreateOrEditContactInputModel product);
        Task<Result> UpdateProductAsync(CreateOrEditContactInputModel contact);
        Task<Result> DeleteProductAsync(Guid id);
    }
}
