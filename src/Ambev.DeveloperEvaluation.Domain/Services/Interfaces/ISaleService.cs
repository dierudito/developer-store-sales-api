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
    /// Updates an existing sale.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a sale.
    /// </summary>
    /// <param name="id">The ID of the sale.</param>
    /// <returns>The updated sale entity.</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all sales.
    /// </summary>
    /// <returns>A collection of all sale entities.</returns>
    Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve.</param>
    /// <returns>The sale entity, or null if not found.</returns>
    Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default);
}