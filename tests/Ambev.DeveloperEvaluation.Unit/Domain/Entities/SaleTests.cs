using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;
public class SaleTests
{
    [Fact(DisplayName = "UpdateSale should update properties correctly")]
    public void UpdateSale_ShouldUpdatePropertiesCorrectly()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var updatedSale = SaleTestData.GenerateValidSale();
        updatedSale.SaleNumber = "UpdatedSaleNumber";
        updatedSale.SaleDate = DateTime.Now.AddDays(1);
        updatedSale.CustomerId = Guid.NewGuid();
        updatedSale.BranchId = Guid.NewGuid();

        // Act
        sale.UpdateSale(updatedSale);

        // Assert
        Assert.Equal(updatedSale.SaleNumber, sale.SaleNumber);
        Assert.Equal(updatedSale.SaleDate, sale.SaleDate);
        Assert.Equal(updatedSale.CustomerId, sale.CustomerId);
        Assert.Equal(updatedSale.BranchId, sale.BranchId);
        Assert.NotNull(sale.UpdatedAt);
    }

    [Fact(DisplayName = "AddItem should add item and calculate total amount")]
    public void AddItem_ShouldAddItemAndCalculateTotalAmount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        item.IsCancelled = false;

        // Act
        sale.AddItem(item);

        var totalAmountExpected = (item.Quantity * item.UnitPrice) -
            (item.Quantity * item.UnitPrice * sale.Discount / 100);

        // Assert
        Assert.Single(sale.Items);
        Assert.Equal(totalAmountExpected, sale.TotalAmount);
    }

    [Fact(DisplayName = "AddItem should not add invalid item")]
    public void AddItem_ShouldNotAddInvalidItem()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var invalidItem = SaleItemTestData.GenerateInvalidSaleItem();

        // Act
        sale.AddItem(invalidItem);

        // Assert
        Assert.Empty(sale.Items);
        Assert.NotEmpty(sale.ValidationResultDetail.Errors);
    }

    [Fact(DisplayName = "UpdateItem should not update cancelled item")]
    public void UpdateItem_ShouldNotUpdateCancelledItem()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        sale.AddItem(item);
        sale.CancelItem(item);
        var updatedItem = SaleItemTestData.GenerateValidSaleItem();
        updatedItem.ProductId = Guid.NewGuid();

        // Act
        sale.UpdateItem(item, updatedItem);

        // Assert
        Assert.NotEqual(updatedItem.ProductId, item.ProductId);
        Assert.NotEmpty(sale.ValidationResultDetail.Errors);
    }

    [Fact(DisplayName = "CancelItem should cancel item and calculate total amount")]
    public void CancelItem_ShouldCancelItemAndCalculateTotalAmount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        sale.AddItem(item);

        // Act
        sale.CancelItem(item);

        // Assert
        Assert.True(item.IsCancelled);
        Assert.NotNull(sale.UpdatedAt);
        Assert.Equal(0, sale.TotalAmount);
    }

    [Fact(DisplayName = "CalculateDiscount should apply second level discount")]
    public void CalculateDiscount_ShouldApplySecondLevelDiscount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        item.Quantity = 11;
        item.IsCancelled = false;

        // Act
        sale.AddItem(item);

        // Assert
        Assert.Equal(20, sale.Discount);
    }

    [Fact(DisplayName = "CalculateDiscount should apply first level discount")]
    public void CalculateDiscount_ShouldApplyFirstLevelDiscount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        item.Quantity = 5;
        item.IsCancelled = false;

        // Act
        sale.AddItem(item);

        // Assert
        Assert.Equal(10, sale.Discount);
    }

    [Fact(DisplayName = "CalculateDiscount should apply no discount")]
    public void CalculateDiscount_ShouldApplyNoDiscount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        item.Quantity = 2;
        item.IsCancelled = false;

        // Act
        sale.AddItem(item);

        // Assert
        Assert.Equal(0, sale.Discount);
    }
}