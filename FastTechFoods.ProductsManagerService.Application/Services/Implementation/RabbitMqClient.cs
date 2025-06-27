using FastTechFoods.ProductsManagerService.Application.Events;
using FastTechFoods.ProductsManagerService.Application.InputModels;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Application.Services.Implementation
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;


        public RabbitMqClient(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task PublicMessageCreate(CreateOrEditProductInputModel product)
        {
            var productCreatedEvent = new ProductCreatedEvent
            {
                Id = product.Id,
                Name = product.Name,
                ProductType = product.ProductType,
                Description = product.Description,
                Price = product.Price,
                Availability = product.Availability,
                CreatedAt = DateTime.UtcNow
            };
            await _bus.Publish(productCreatedEvent);
           

        }

        public async Task PublicMessageUpdate(CreateOrEditProductInputModel product)
        {
            var productUpdatedEvent = new ProductUpdatedEvent
            {
                Id = product.Id,
                Name = product.Name,
                ProductType = product.ProductType,
                Description = product.Description,
                Price = product.Price,
                Availability = product.Availability,
                UpdatedAt = DateTime.UtcNow
            };

            await _bus.Publish(productUpdatedEvent);
        }
    }
}
