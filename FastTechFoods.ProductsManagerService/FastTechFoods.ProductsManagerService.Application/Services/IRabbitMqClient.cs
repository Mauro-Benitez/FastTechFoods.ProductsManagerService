using FastTechFoods.ProductsManagerService.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Application.Services
{
    public interface IRabbitMqClient
    {
        Task PublicMessageCreate(CreateOrEditProductInputModel product);

        Task PublicMessageUpdate(CreateOrEditProductInputModel product);
    }
}
