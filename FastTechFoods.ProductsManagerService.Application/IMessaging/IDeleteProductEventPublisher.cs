using OrderService.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FastTechFoods.ProductsManagerService.Application.IMessaging
{
    public interface IDeleteProductEventPublisher
    {
        Task PublishAsync(DeleteProductEvent deleteProductEvent);
    }
}
