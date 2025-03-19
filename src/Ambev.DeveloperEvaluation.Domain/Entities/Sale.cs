using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale record in the system.
/// This entity encapsulates all the details of a sale, including customer, products, and totals.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique number of the sale.
    /// </summary>
    public string SaleNumber { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the customer associated with the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// It's for ef navigation 
    /// </summary>
    public virtual Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets the branch where the sale was made.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// It's for ef navigation 
    /// </summary>
    public virtual Branch Branch { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; private set; } = [];

    /// <summary>
    /// Gets or sets the discount applied to the sale item.
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Gets or sets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the sale is cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the date and time of the last update to the sale's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Updates the properties of the current Sale instance with the values from the provided Sale object.
    /// </summary>
    /// <param name="sale">The Sale object containing the updated values.</param>
    public void UpdateSale(Sale sale)
    {
        SaleNumber = sale.SaleNumber;
        SaleDate = sale.SaleDate;
        CustomerId = sale.CustomerId;
        BranchId = sale.BranchId;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds a new item to the sale.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(SaleItem item)
    {
        var itemValidate = item.Validate();

        if (!itemValidate.IsValid)
        {
            AddValidationError(itemValidate.Errors.ToList());
            return;
        }

        item.SaleId = Id;

        Items.Add(item);
        CalculateTotalAmount();
    }

    /// <summary>
    /// Updates an existing item in the sale with the provided updated item details.
    /// </summary>
    /// <param name="existingItem">The existing SaleItem to be updated.</param>
    /// <param name="itemUpdated">The SaleItem containing the updated values.</param>
    public void UpdateItem(SaleItem existingItem, SaleItem itemUpdated)
    {
        if (existingItem.IsCancelled)
        {
            AddValidationError([(ValidationErrorDetail) new ValidationFailure("Item", "The item is already cancelled")]);
            return;
        }

        var itemValidate = itemUpdated.Validate();

        if (!itemValidate.IsValid)
        {
            AddValidationError(itemValidate.Errors.ToList());
            return;
        }

        existingItem.ProductId = itemUpdated.ProductId;
        existingItem.Quantity = itemUpdated.Quantity;
        existingItem.UnitPrice = itemUpdated.UnitPrice;

        CalculateTotalAmount();
    }

    /// <summary>
    /// Cancels an item from the sale.
    /// </summary>
    /// <param name="item">The item to cancel.</param>
    public void CancelItem(SaleItem item)
    {
        var saleItem = Items.FirstOrDefault(i => i.Id == item.Id);
        if (saleItem != null)
        {
            saleItem.IsCancelled = true;
            UpdatedAt = DateTime.UtcNow;
            CalculateTotalAmount();
        }
    }
    
    /// <summary>
    /// Calculates the total amount of the sale based on the items.
    /// </summary>
    private void CalculateTotalAmount()
    {
        var totalAmountWithouDiscount = Items.Where(saleItem => !saleItem.IsCancelled).Sum(saleItem => saleItem.Quantity * saleItem.UnitPrice);
        CalculateDiscount();
        var discountAmount = totalAmountWithouDiscount * Discount / 100;
        TotalAmount = totalAmountWithouDiscount - discountAmount;
    }

    private void CalculateDiscount()
    {
        Discount = (HasSecondDiscountLevel(), HasFirstDiscountLevel()) switch
        {
            (true, _) => 20,
            (false, true) => 10,
            _ => 0
        };
    }
    private bool HasSecondDiscountLevel() => 
        Items.Any(saleItem => !saleItem.IsCancelled && saleItem.Quantity is >= 10 and < 20);

    private bool HasFirstDiscountLevel() => 
        Items.Any(saleItem => !saleItem.IsCancelled && saleItem.Quantity > 4);
}