using FastTechFoods.ProductsManagerService.Domain.Enums;

namespace FastTechFoods.ProductsManagerService.Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AvailabilityStatusEnum Availability { get; set; }    
        public decimal Price { get; set; }        
       
    }
}
