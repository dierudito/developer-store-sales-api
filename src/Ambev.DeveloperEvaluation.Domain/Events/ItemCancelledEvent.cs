using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ItemCancelledEvent : SaleEvent
{
    public string SaleNumber { get; init; } = null!;
    public Guid SaleItemId { get; init; }
}