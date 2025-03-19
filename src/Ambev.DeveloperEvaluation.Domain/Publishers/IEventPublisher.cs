using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Publishers;
public interface IEventPublisher
{
    Task PublishSaleCreatedEvent(SaleCreatedEvent saleCreatedEvent);
    Task PublishSaleModifiedEvent(SaleModifiedEvent saleModifiedEvent);
    Task PublishSaleCancelledEvent(SaleCancelledEvent saleCancelledEvent);
    Task PublishItemCancelledEvent(ItemCancelledEvent itemCancelledEvent);
}