using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.Dtos;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Repositories;

namespace FastTechFoods.ProductsManagerService.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRabbitMqClient _rabbitMqClient;

        public ProductService(IProductRepository productRepository, IRabbitMqClient rabbitMqClient)
        {
            _productRepository = productRepository;
            _rabbitMqClient = rabbitMqClient;
        }

        public async Task<Result> CreateProductAsync(CreateOrEditProductInputModel product)
        {
            var newProduct = new Product(product.Name, product.ProductType, product.Price, product.Description, product.Availability);

            await _rabbitMqClient.PublicMessageCreate(product);

            var result = await _productRepository.CreateProductAsync(newProduct);

            

            return Result<ProductDto>.Success(new ProductDto { Id = result.Id, Name = result.Name, Price = result.Price, Availability = result.Availability });

        }

        public async Task<Result> DeleteProductAsync(Guid id)
        {
            var product = _productRepository.GetProductByIdAsync(id);

            if (product is null)
                return Result.Failure("Product not found");

            await _productRepository.DeleteProductAsync(id);

            return Result.Success("Product deleted successfully.");
        }


        public async Task<Result> UpdateProductAsync(CreateOrEditProductInputModel editModel)
        {
            var product = await _productRepository.GetProductByIdAsync(editModel.Id);

            if (product is null)
                return Result.Failure("Product not found");

            product.Name = editModel.Name;
            product.ProductType = editModel.ProductType;
            product.Price = editModel.Price;
            product.Description = editModel.Description;
            product.Availability = editModel.Availability;

            await _rabbitMqClient.PublicMessageUpdate(editModel);

            var updatedProduct = await _productRepository.UpdateProductAsync(product);

            

            return Result<ProductDto>.Success(new ProductDto { Id = updatedProduct.Id, Name = updatedProduct.Name, Price = updatedProduct.Price, Availability = updatedProduct.Availability });
        }
    }
}
