using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public class SaleRepository(DefaultContext context) : BaseRepository<Sale>(context), ISaleRepository
{
    public override async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbSet
        .Include(s => s.Branch)
        .Include(s => s.Customer)
        .Include(s => s.Items)
        .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        
}