using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.Dtos;
using FastTechFoods.ProductsManagerService.Application.IMessaging;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using FastTechFoods.ProductsManagerService.Domain.Abstraction;
using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Repositories;
using OrderService.Contracts.Events;

namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICreateProductEventPublisher _createProductEventPublisher;
        private readonly IUpdateProductEventPublisher _updateProductEventPublisher;
        private readonly IDeleteProductEventPublisher _deleteProductEventPublisher; 

        public ProductService(IProductRepository productRepository, ICreateProductEventPublisher createProductEventPublisher, IUpdateProductEventPublisher updateProductEventPublisher, IDeleteProductEventPublisher deleteProductEventPublisher)
        {
            _productRepository = productRepository;
            _createProductEventPublisher = createProductEventPublisher;
            _updateProductEventPublisher = updateProductEventPublisher;
            _deleteProductEventPublisher = deleteProductEventPublisher;
        }

        public async Task<Result> CreateProductAsync(CreateOrEditProductInputModel product)
        {
            var newProduct = new Product(product.Name, product.ProductType, product.Price, product.Description, product.Availability);

            var result = await _productRepository.CreateProductAsync(newProduct);


            await _createProductEventPublisher
                .PublishAsync(new CreateProductEvent
                {
                    Id = result.Id,
                    Name = result.Name,
                    ProductType = (OrderService.Contracts.Enums.ProductTypeEnum)result.ProductType,
                    Price = result.Price,
                    Description = result.Description,
                    Availability = (OrderService.Contracts.Enums.AvailabilityStatusEnum)result.Availability
                });


            return Result<ProductDto>.Success(new ProductDto { Id = result.Id, Name = result.Name, Price = result.Price, Availability = result.Availability });

        }

        public async Task<Result> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product is null)
                return Result.Failure("Product not found");

            await _productRepository.DeleteProductAsync(id);

            await _deleteProductEventPublisher
                .PublishAsync(new DeleteProductEvent
                {
                    Id = id
                });

            return Result.Success("Product deleted successfully.");
        }

        public async Task<Result<PagedResult<ProductDto>>> GetProductAsync(int page, int quantityPerPage)
        {
            var pagedProducts = await _productRepository.GetProductAsync(page, quantityPerPage);

            if (pagedProducts == null || !pagedProducts.Items.Any())
                return Result<PagedResult<ProductDto>>.Failure("No products found");

            var productDtos = pagedProducts.Items.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Availability = product.Availability
            }).ToList();

            var pagedResult = new PagedResult<ProductDto>
            {
                Items = productDtos,
                TotalPages = pagedProducts.TotalPages,
                CurrentPage = pagedProducts.CurrentPage,
                
            };

            return Result<PagedResult<ProductDto>>.Success(pagedResult);
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


            var updatedProduct = await _productRepository.UpdateProductAsync(product);
            

            await _updateProductEventPublisher
                .PublishAsync(new UpdateProductEvent
                {
                    Id = updatedProduct.Id,
                    Name = updatedProduct.Name,
                    ProductType = (OrderService.Contracts.Enums.ProductTypeEnum)updatedProduct.ProductType,
                    Price = updatedProduct.Price,
                    Description = updatedProduct.Description,
                    Availability = (OrderService.Contracts.Enums.AvailabilityStatusEnum)updatedProduct.Availability
                });


            return Result<ProductDto>.Success(new ProductDto { Id = updatedProduct.Id, Name = updatedProduct.Name, Price = updatedProduct.Price, Availability = updatedProduct.Availability });
        }
    }
}
