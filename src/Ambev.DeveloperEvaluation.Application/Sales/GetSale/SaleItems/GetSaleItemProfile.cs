using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.SaleItems;
/// <summary>
/// Profile for mapping between SaleItem entity and GetSaleItemCommand
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItem operation
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<GetSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, GetSaleItemResult>();
    }
}
