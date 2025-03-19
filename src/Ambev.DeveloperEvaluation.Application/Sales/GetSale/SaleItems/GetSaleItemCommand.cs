namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.SaleItems;

public class GetSaleItemCommand
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}