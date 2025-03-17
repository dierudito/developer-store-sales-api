using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a branch where sales occur.
/// This entity encapsulates the branch's information and behavior.
/// </summary>
public class Branch : BaseEntity
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