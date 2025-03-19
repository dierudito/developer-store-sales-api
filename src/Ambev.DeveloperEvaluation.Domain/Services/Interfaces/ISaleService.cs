using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
public interface ISaleService
{
    /// <summary>
    /// Creates a new sale.
    /// </summary>
    /// <param name="sale">The sale entity to create.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The created sale entity.</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sale.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a sale.
    /// </summary>
    /// <param name="id">The ID of the sale.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The updated sale entity.</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all sales.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A collection of all sale entities.</returns>
    Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The sale entity, or null if not found.</returns>
    Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a specific item within a sale.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <param name="saleItem">The SaleItem to be cancelled.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CancelItemAsync(Sale sale, SaleItem saleItem, CancellationToken cancellationToken = default);
}