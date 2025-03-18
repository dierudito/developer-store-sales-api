using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;
public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(saleItem => saleItem.Quantity)
            .NotEmpty()
            .LessThanOrEqualTo(20)
            .WithMessage("The quantity of identical items cannot be greater than 20.");
    }
}