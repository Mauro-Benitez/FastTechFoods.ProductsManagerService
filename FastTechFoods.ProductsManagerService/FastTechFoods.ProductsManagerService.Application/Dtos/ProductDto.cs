using FastTechFoods.ProductsManagerService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
