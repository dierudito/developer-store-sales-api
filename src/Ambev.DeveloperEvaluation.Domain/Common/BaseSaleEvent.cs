namespace Ambev.DeveloperEvaluation.Domain.Common;
public abstract class SaleEvent
{
    public Guid SaleId { get; init; }
    public DateTime EventDate { get; init; } = DateTime.Now;
}