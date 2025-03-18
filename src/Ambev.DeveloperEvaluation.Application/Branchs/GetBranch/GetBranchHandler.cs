using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Handler for processing GetBranchCommand requests
/// </summary>
public class GetBranchHandler(IMapper mapper, IBranchService service) :
    IRequestHandler<GetBranchCommand, GetBranchResult>
{

    /// <summary>
    /// Handles the GetBranchCommand request
    /// </summary>
    /// <param name="command">The GetBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The branch details if found</returns>
    public async Task<GetBranchResult> Handle(GetBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetBranchValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = await service.GetBranchByIdAsync(command.Id, cancellationToken);
        
        return branch == null
            ? throw new KeyNotFoundException($"Branch with ID {command.Id} not found")
            : mapper.Map<GetBranchResult>(branch);
    }
}