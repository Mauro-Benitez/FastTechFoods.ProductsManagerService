using OrderService.Contracts.Events;

namespace FastTechFoods.ProductsManagerService.Application.IMessaging
{
    public interface ICreateProductEventPublisher
    {
        Task PublishAsync(CreateProductEvent createProductEvent);
    }
}
