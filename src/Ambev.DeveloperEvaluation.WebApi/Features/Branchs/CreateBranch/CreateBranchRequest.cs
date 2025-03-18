namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// Represents a request to create a new branch in the system.
/// </summary>
public class CreateBranchRequest
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
