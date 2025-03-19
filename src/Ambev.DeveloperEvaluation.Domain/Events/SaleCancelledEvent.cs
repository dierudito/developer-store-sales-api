using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCancelledEvent : SaleEvent
{
    public string SaleNumber { get; init; } = null!;
}
