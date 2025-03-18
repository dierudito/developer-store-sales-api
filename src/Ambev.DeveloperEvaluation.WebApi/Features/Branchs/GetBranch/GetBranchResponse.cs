namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

/// <summary>
/// API response model for GetBranch operation
/// </summary>
public class GetBranchResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created branch in the system.</value>
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