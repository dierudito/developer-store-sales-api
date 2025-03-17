using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
public interface ISaleService
{
    /// <summary>
    /// Creates a new sale.
    /// </summary>
    /// <param name="sale">The sale entity to create.</param>
    /// <returns>The created sale entity.</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve.</param>
    /// <returns>The sale entity, or null if not found.</returns>
    Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sale.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a sale.
    /// </summary>
    /// <param name="id">The ID of the sale to cancel.</param>
    /// <returns>True if the sale was cancelled, false otherwise.</returns>
    Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an item to a sale.
    /// </summary>
    /// <param name="saleId">The ID of the sale.</param>
    /// <param name="saleItem">The item to add.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> AddItemToSaleAsync(Guid saleId, SaleItem saleItem);

    /// <summary>
    /// Removes an item from a sale.
    /// </summary>
    /// <param name="saleId">The ID of the sale.</param>
    /// <param name="itemId">The ID of the item to remove.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> RemoveItemFromSaleAsync(Guid saleId, Guid itemId);

    /// <summary>
    /// Retrieves all sales.
    /// </summary>
    /// <returns>A collection of all sale entities.</returns>
    Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default);
}