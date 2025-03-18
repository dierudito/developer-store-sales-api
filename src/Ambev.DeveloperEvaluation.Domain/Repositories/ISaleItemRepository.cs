using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Defines the contract for the Sale Item repository.
/// </summary>
public interface ISaleItemRepository : IBaseRepository<SaleItem>
{
    /// <summary>
    /// Adds a range of sale items to the repository asynchronously.
    /// </summary>
    /// <param name="saleItems">The list of sale items to add.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddRangeAsync(List<SaleItem> saleItems, CancellationToken cancellationToken = default);
}