using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Services.TestData;

public static class SaleItemTestData
{
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(si => si.ProductId, f => Guid.NewGuid())
        .RuleFor(si => si.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(si => si.UnitPrice, f => f.Random.Decimal(5, 50))
        .RuleFor(si => si.IsCancelled, f => f.Random.Bool());

    public static SaleItem GenerateValidSaleItem()
    {
        return SaleItemFaker.Generate();
    }
    
    public static SaleItem GenerateInvalidSaleItem()
    {
        var faker = new Faker<SaleItem>()
            .RuleFor(si => si.ProductId, f => Guid.NewGuid())
            .RuleFor(si => si.Quantity, f => f.Random.Number(21, 50))
            .RuleFor(si => si.UnitPrice, f => f.Random.Decimal(5, 50))
            .RuleFor(si => si.IsCancelled, f => f.Random.Bool());

        return faker.Generate();
    }
}