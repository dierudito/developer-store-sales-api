namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Response model for GetCustomer operation
/// </summary>
public class GetCustomerResult
{
    /// <summary>
    /// The unique identifier of the Customer
    /// </summary>
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