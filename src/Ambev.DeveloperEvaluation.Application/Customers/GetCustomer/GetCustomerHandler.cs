using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Handler for processing GetCustomerCommand requests
/// </summary>
public class GetCustomerHandler(IMapper mapper, ICustomerService service) :
    IRequestHandler<GetCustomerCommand, GetCustomerResult>
{

    /// <summary>
    /// Handles the GetCustomerCommand request
    /// </summary>
    /// <param name="command">The GetCustomer command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Customer details if found</returns>
    public async Task<GetCustomerResult> Handle(GetCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetCustomerValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = await service.GetCustomerByIdAsync(command.Id, cancellationToken);
        
        return customer == null
            ? throw new KeyNotFoundException($"Customer with ID {command.Id} not found")
            : mapper.Map<GetCustomerResult>(customer);
    }
}