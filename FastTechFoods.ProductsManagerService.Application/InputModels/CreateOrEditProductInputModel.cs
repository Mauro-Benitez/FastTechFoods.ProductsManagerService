using FastTechFoods.ProductsManagerService.Domain.Enums;

namespace FastTechFoods.ProductsManagerService.Application.InputModels
{
    public class CreateOrEditProductInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public AvailabilityStatusEnum Availability { get; set; }

    }
}
