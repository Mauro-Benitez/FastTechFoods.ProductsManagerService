using FastTechFoods.ProductsManagerService.Application.Abstraction;
using FastTechFoods.ProductsManagerService.Application.Dtos;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public interface IProductService
    {
        Task<Result> CreateProductAsync(CreateOrEditContactInputModel product);
        Task<Result> UpdateProductAsync(CreateOrEditContactInputModel contact);
        Task<Result> DeleteProductAsync(Guid id);
    }
}
