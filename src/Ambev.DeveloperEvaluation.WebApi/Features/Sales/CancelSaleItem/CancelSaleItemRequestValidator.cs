using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Validator for the <see cref="CancelSaleItemRequest"/>.
/// </summary>
public class CancelSaleItemRequestValidator : AbstractValidator<CancelSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleItemRequestValidator"/> class.
    /// </summary>
    public CancelSaleItemRequestValidator()
    {
        RuleFor(x => x.SaleItemId)
            .NotEmpty()
            .WithMessage("Sale item ID is required");

        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}