using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Publishers;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler(ISaleService service, IEventPublisher eventPublisher) : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="command">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await service.DeleteAsync(command.Id, cancellationToken);
        var saleEntity = await service.GetSaleByIdAsync(command.Id, cancellationToken);

        var saleCancelledEvent = new SaleCancelledEvent
        {
            SaleId = command.Id
        };

        if (saleEntity == null)
            await eventPublisher.PublishSaleCancelledEvent(saleCancelledEvent);

        return new DeleteSaleResponse { Success = saleEntity == null };
    }
}
