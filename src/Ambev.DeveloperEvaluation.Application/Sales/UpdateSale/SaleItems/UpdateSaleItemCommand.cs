﻿namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.SaleItems;

public class UpdateSaleItemCommand
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}