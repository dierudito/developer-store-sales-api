using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
public class CreateBranchHandler(IMapper mapper, IBranchService branchService) :
    IRequestHandler<CreateBranchCommand, CreateBranchResult>
{
    public async Task<CreateBranchResult> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = mapper.Map<Branch>(command);
        var createdBranch = await branchService.CreateAsync(branch, cancellationToken);
        var result = mapper.Map<CreateBranchResult>(createdBranch);
        return result;
    }
}
