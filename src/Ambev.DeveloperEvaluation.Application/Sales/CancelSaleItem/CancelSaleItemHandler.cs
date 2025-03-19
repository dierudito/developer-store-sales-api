using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemHandler(ISaleService service) : IRequestHandler<CancelSaleItemCommand, bool>
{
    public async Task<bool> Handle(CancelSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await service.GetSaleByIdAsync(command.SaleId, cancellationToken) ??
                       throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found");

        var saleItem = sale.Items.FirstOrDefault(item => item.Id == command.SaleItemId) ??
                       throw new KeyNotFoundException($"Sale item with ID {command.SaleItemId} not found");

        await service.CancelItemAsync(sale, saleItem, cancellationToken);
        return true;
    }
}
