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
            var nomeFila = _configuration.GetSection("MassTransit")["FilaCreate"] ?? "create-product-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(product);

        }

        public async Task PublicMessageUpdate(CreateOrEditProductInputModel product)
        {
            var nomeFila = "update-product-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(product);
        }
    }
}
