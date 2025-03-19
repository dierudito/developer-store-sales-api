using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Validator for the <see cref="CancelSaleItemCommand"/>.
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleItemValidator"/> class.
    /// </summary>
    public CancelSaleItemValidator()
    {
        RuleFor(x => x.SaleItemId)
            .NotEmpty()
            .WithMessage("Sale Item ID is required");

        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}