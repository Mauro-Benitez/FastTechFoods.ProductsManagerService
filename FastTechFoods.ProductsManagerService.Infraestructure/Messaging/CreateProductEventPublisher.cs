using FastTechFoods.ProductsManagerService.Application.IMessaging;
using MassTransit;
using OrderService.Contracts.Events;

namespace FastTechFoods.ProductsManagerService.Infraestructure.Messaging
{
    public class CreateProductEventPublisher : EventPublisherBase<CreateProductEvent>, ICreateProductEventPublisher
    {
        public CreateProductEventPublisher(IPublishEndpoint publishEndpoint)
            : base(publishEndpoint)
        {
        }

        public Task PublishAsync(CreateProductEvent createProductEvent)
        {
            return base.PublishAsync(createProductEvent);
        }
    }
}
