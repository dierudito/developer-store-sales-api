using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Services;
public class BranchService(IBranchRepository branchRepository) : IBranchService
{
    public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        await branchRepository.CreateAsync(branch, cancellationToken);
        await branchRepository.CommitAsync(cancellationToken);
        return branch;
    }

    public async Task<IEnumerable<Branch>> GetAllBranchsAsync(CancellationToken cancellationToken = default) =>
        await branchRepository.GetAllAsync(cancellationToken);

    public async Task<Branch?> GetBranchByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await branchRepository.GetByIdAsync(id, cancellationToken);
}
