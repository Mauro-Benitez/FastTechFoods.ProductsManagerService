using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.Dtos;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Repositories;
using FastTechFoods.ProductsManagerService.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> CreateProductAsync(CreateOrEditContactInputModel product)
        {
            var newProduct = new Product(product.Name, product.Type, product.Price);

            var result = await _productRepository.CreateProductAsync(newProduct);

            return Result<ProductDto>.Success(new ProductDto(result.Id, result.Name, result.Type, result.Price));                

        }

        public async Task<Result> DeleteProductAsync(Guid id)
        {
            var product = _productRepository.GetProductByIdAsync(id);

            if (product is null)
                return Result.Failure("Product not found");

            await _productRepository.DeleteProductAsync(id);

            return Result.Success("Product deleted successfully.");
        }

  
        public async Task<Result> UpdateProductAsync(CreateOrEditContactInputModel editModel)
        {
            var product = await _productRepository.GetProductByIdAsync(editModel.Id);

            if (product is null)
                return Result.Failure("Product not found");

            product.Name = editModel.Name;
            product.Price = editModel.Price;          
            product.Type = editModel.Type;

            var updatedProduct = await _productRepository.UpdateProductAsync(product);

            return Result<ProductDto>.Success(new ProductDto(updatedProduct.Id, updatedProduct.Name, updatedProduct.Type, updatedProduct.Price));
        }
    }
}
