using FastTechFoods.ProductsManagerService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.ProductsManagerService.Application.Dtos
{
    public class ProductDto
    {

        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ]{2,50}$", ErrorMessage = "Invalid name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        public AvailabilityStatusEnum Availability { get; set; }

        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "The price must be between 0.01 and 99999.99.")]
        public decimal Price { get; set; }        
       
    }
}
