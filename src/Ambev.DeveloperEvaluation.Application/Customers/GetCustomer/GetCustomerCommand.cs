using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Command for retrieving a Customer by their ID
/// </summary>
public class GetCustomerCommand : IRequest<GetCustomerResult>
{
    /// <summary>
    /// The unique identifier of the Customer to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
