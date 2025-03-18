using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
public interface ICustomerService
{
    /// <summary>
    /// Creates a new Customer.
    /// </summary>
    /// <param name="Customer">The Customer entity to create.</param>
    /// <returns>The created Customer entity.</returns>
    Task<Customer> CreateAsync(Customer Customer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Customer by its ID.
    /// </summary>
    /// <param name="id">The ID of the Customer to retrieve.</param>
    /// <returns>The Customer entity, or null if not found.</returns>
    Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all Customers.
    /// </summary>
    /// <returns>A collection of all Customer entities.</returns>
    Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default);
}