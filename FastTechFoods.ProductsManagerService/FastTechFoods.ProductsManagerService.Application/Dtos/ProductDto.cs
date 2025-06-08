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
        public string Type { get; set; }
        public decimal Price { get; set; }
        
        public ProductDto(Guid id,string name, string type, decimal price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
