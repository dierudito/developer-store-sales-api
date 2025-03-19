namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.UpdateSaleItem;

/// <summary>
/// API response model for SaleItem within a Sale.
/// </summary>
public class UpdateSaleItemResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in the sale item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in the sale item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }
}