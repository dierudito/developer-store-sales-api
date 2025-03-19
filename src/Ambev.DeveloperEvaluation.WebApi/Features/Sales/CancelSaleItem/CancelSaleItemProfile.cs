using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// AutoMapper profile for mapping between <see cref="CancelSaleItemRequest"/> and <see cref="CancelSaleItemCommand"/>.
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleItemProfile"/> class.
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>();
    }
}
