namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// API response model for CreateCustomer operation
/// </summary>
public class CreateCustomerResponse
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