using FastTechFoods.ProductsManagerService.Domain.Enums;

namespace FastTechFoods.ProductsManagerService.Application.Events
{
    public class ProductCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AvailabilityStatusEnum Availability { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
