using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public  decimal Price { get; set; }

        public Product() { }
        public Product(string name, string type, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
