namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetBranchResult
{
    /// <summary>
    /// The unique identifier of the branch
    /// </summary>
    public Guid Id { get; set; }

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