using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Command for list all sale
/// </summary>
public class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
}
