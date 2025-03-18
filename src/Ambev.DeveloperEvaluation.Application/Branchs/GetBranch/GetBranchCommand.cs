using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Command for retrieving a branch by their ID
/// </summary>
public class GetBranchCommand : IRequest<GetBranchResult>
{
    /// <summary>
    /// The unique identifier of the branch to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
