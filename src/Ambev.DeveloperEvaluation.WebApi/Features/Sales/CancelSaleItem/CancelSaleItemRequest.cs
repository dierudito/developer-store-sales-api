namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// API request model for cancelling a sale item.
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// The unique identifier of the sale item to cancel
    /// </summary>
    public Guid SaleItemId { get; set; }
}