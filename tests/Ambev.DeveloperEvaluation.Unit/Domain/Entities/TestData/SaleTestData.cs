using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
public static class SaleTestData
{
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.SaleNumber, f => f.Random.Number(1000, 9999).ToString())
        .RuleFor(s => s.SaleDate, f => f.Date.Past())
        .RuleFor(s => s.CustomerId, f => Guid.NewGuid())
        .RuleFor(s => s.BranchId, f => Guid.NewGuid())
        .RuleFor(s => s.Discount, f => f.Random.Decimal(0, 20))
        .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(10, 1000))
        .RuleFor(s => s.IsCancelled, f => f.Random.Bool())
        .RuleFor(s => s.CreatedAt, f => f.Date.Past())
        .RuleFor(s => s.UpdatedAt, f => f.Date.Future());

    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }
}