using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler(IMapper mapper, ISaleService service) : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    /// <summary>
    /// Handles the GetSaleCommand request
    /// </summary>
    /// <param name="command">The GetSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found</returns>
    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await service.GetSaleByIdAsync(command.Id, cancellationToken) ??
                   throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
        return mapper.Map<GetSaleResult>(sale);
    }
}
