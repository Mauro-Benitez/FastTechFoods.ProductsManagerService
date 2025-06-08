using FastTechFoods.ProductsManagerService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Application.InputModels
{
    public class CreateOrEditContactInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public AvailabilityStatusEnum Availability { get; set; }

    }
}
