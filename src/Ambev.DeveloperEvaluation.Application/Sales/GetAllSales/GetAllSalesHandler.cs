using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Handler for processing GetAllSalesCommand requests
/// </summary>
public class GetAllSalesHandler(IMapper mapper, ISaleService service) : IRequestHandler<GetAllSalesCommand, List<GetAllSalesResult>>
{
    /// <summary>
    /// Handles the GetAllSalesCommand request
    /// </summary>
    /// <param name="command">The GetAllSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found</returns>
    public async Task<List<GetAllSalesResult>> Handle(GetAllSalesCommand command, CancellationToken cancellationToken)
    {
        var sales = await service.GetAllSalesAsync(cancellationToken);
        return mapper.Map<List<GetAllSalesResult>>(sales);
    }
}
