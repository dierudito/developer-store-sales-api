using Ambev.DeveloperEvaluation.Domain.Common;

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
    public string SaleNumber { get; set; }

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
    /// Cancels the sale.
    /// </summary>
    public void CancelSale()
    {
        IsCancelled = true;
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

        Items.Add(item);
        CalculateTotalAmount();
    }

    /// <summary>
    /// Removes an item from the sale.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    public void RemoveItem(SaleItem item)
    {
        Items.Remove(item);
        CalculateTotalAmount();
    }
    
    /// <summary>
    /// Calculates the total amount of the sale based on the items.
    /// </summary>
    private void CalculateTotalAmount()
    {
        var totalAmountWithouDiscount = Items.Sum(saleItem => saleItem.Quantity * saleItem.UnitPrice);
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
    private bool HasSecondDiscountLevel()
    {
        return Items.Any(item => item.Quantity is >= 10 and < 20);
    }

    private bool HasFirstDiscountLevel()
    {
        return Items.Any(item => item.Quantity > 4);
    }
}