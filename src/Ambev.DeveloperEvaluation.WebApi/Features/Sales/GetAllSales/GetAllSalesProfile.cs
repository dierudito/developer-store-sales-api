using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

/// <summary>
/// Profile for mapping GetAllSales feature requests to commands
/// </summary>
public class GetAllSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetAllSales feature
    /// </summary>
    public GetAllSalesProfile()
    {
        CreateMap<GetAllSalesResult, GetAllSalesResponse>();
    }
}
