using System;
using FastTechFoods.ProductsManagerService.Application.IMessaging;
using MassTransit;
using OrderService.Contracts.Events;

namespace FastTechFoods.ProductsManagerService.Infraestructure.Messaging
{
    public class UpdateProductEventPublisher : EventPublisherBase<UpdateProductEvent>, IUpdateProductEventPublisher
    {
        public UpdateProductEventPublisher(IPublishEndpoint publishEndpoint)
           : base(publishEndpoint)
        {
        }

        Task IUpdateProductEventPublisher.PublishAsync(UpdateProductEvent updateProductEvent)
        {
            return base.PublishAsync(updateProductEvent);
        }
    }
    
    
}
