using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent : SaleEvent
{
    public Guid CustomerId { get; init; }
    public Guid BranchId { get; init; }
    public string SaleNumber { get; init; } = null!;
}
