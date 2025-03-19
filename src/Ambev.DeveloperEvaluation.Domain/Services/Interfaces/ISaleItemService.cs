namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
public interface ISaleItemService
{
    /// <summary>
    /// Cancel a item of sale.
    /// </summary>
    /// <param name="id">The id of the sale item.</param>
    Task CancelItemAsync(Guid id, CancellationToken cancellationToken = default);
}