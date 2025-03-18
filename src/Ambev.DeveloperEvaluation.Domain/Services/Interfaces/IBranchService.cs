using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
public interface IBranchService
{
    /// <summary>
    /// Creates a new branch.
    /// </summary>
    /// <param name="branch">The branch entity to create.</param>
    /// <returns>The created branch entity.</returns>
    Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a branch by its ID.
    /// </summary>
    /// <param name="id">The ID of the branch to retrieve.</param>
    /// <returns>The branch entity, or null if not found.</returns>
    Task<Branch?> GetBranchByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all branchs.
    /// </summary>
    /// <returns>A collection of all branch entities.</returns>
    Task<IEnumerable<Branch>> GetAllBranchsAsync(CancellationToken cancellationToken = default);
}