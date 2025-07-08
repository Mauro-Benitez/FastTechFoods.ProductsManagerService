using FastTechFoods.ProductsManagerService.Application.InputModels;
using FastTechFoods.ProductsManagerService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastTechFoods.ProductsManagerService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
       

        public ProductController(IProductService productService)
        {
            this._productService = productService;
            
        }
       

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateOrEditProductInputModel product)
        {
            try
            {
                 var result = await _productService.CreateProductAsync(product);                
                 return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }               
        }     


        [HttpPut]
        [Authorize(Roles = "Gerente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(CreateOrEditProductInputModel product)
        {
            try
            {
                var result = await _productService.UpdateProductAsync(product);                
                return Ok(result);
               
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int quantityPerPage)
        {
            if (page <= 0 || quantityPerPage <= 0)
                return BadRequest("The 'page' and 'quantityPerPage' parameters must be greater than zero");

            var result = await _productService.GetProductAsync(page, quantityPerPage);

            if (!result.IsSuccess || !result.IsFound)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Authorize(Roles = "Gerente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                return Ok(result);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
