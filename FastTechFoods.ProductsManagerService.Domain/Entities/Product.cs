using FastTechFoods.ProductsManagerService.Domain.Enums;

namespace FastTechFoods.ProductsManagerService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AvailabilityStatusEnum Availability { get; set; }

        public Product() { } 
        public Product(string name, ProductTypeEnum productType, decimal price, string description, AvailabilityStatusEnum availability)
        {
            Name = name;
            ProductType = productType;
            Price = price;
            Description = description;
            Availability = availability;
        }
    }
}
