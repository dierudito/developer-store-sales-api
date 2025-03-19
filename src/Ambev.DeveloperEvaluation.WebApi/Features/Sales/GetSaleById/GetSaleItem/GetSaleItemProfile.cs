using Ambev.DeveloperEvaluation.Application.Sales.GetSale.SaleItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale.GetSaleItem;

/// <summary>
/// Profile for mapping between Application and API GetSaleItem responses
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<GetSaleItemRequest, GetSaleItemCommand>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}