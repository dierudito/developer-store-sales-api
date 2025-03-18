using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Command for creating a new branch.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a branch,
/// including name, address, phone number, and email.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// that returns a <see cref="CreateBranchResult"/>.
/// </remarks>
public class CreateBranchCommand : IRequest<CreateBranchResult>
{
    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the address of the branch.
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phone number of the branch.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the branch.
    /// </summary>
    public string Email { get; set; } = null!;
}