using System;
using FastTechFoods.ProductsManagerService.Application.IMessaging;
using MassTransit;
using OrderService.Contracts.Events;

namespace FastTechFoods.ProductsManagerService.Infraestructure.Messaging
{
    public class DeleteProductEventPublisher : EventPublisherBase<DeleteProductEvent>, IDeleteProductEventPublisher
    {
        public DeleteProductEventPublisher(IPublishEndpoint publishEndpoint)
           : base(publishEndpoint)
        {
        }

        Task IDeleteProductEventPublisher.PublishAsync(DeleteProductEvent deleteProductEvent)
        {
            return base.PublishAsync(deleteProductEvent);
        }
    }
}
