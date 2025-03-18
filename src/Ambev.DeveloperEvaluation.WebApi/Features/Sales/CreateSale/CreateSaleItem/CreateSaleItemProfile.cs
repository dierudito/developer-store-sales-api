using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.SaleItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.CreateSaleItem;

/// <summary>
/// Profile for mapping between Application and API CreateSaleItem responses
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}