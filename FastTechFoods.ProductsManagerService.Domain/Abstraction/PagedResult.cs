using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Domain.Abstraction
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
