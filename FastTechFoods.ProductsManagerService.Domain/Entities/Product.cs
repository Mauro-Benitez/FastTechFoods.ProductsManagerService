using FastTechFoods.ProductsManagerService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.ProductsManagerService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        public ProductTypeEnum ProductType { get; set; }

        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters.")]
        public string Description { get; set; }

        [Required]
        public AvailabilityStatusEnum Availability { get; set; }

        public Product() { } 
        public Product(string name, ProductTypeEnum productType, decimal price, string description, AvailabilityStatusEnum availability)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            Name = name;
            ProductType = productType;
            Price = price;
            Description = description;
            Availability = availability;
        }

        public Product(Guid id, string name, ProductTypeEnum productType, decimal price, string description, AvailabilityStatusEnum availability)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            Id = id;
            Name = name;
            ProductType = productType;
            Price = price;
            Description = description;
            Availability = availability;
        }

        public void UpdateDetails(string name, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.", nameof(price));

            Name = name;
            Price = price;
            Description = description;
        }
    }
}
