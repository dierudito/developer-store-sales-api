using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command to cancel a specific item within a sale.
/// </summary>
public class CancelSaleItemCommand : IRequest<bool>
{
    ///<summary>
    /// The unique identifier of the sale item to cancel.
    /// </summary>
    public Guid SaleItemId { get; set; }

    ///<summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid SaleId { get; set; }
}