namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// API response model for GetCustomer operation
/// </summary>
public class GetCustomerResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created branch in the system.</value>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the customer.
    /// </summary>
    public string? Email { get; set; }
}