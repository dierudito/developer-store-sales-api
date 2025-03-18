using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public class SaleItemRepository(DefaultContext context) : BaseRepository<SaleItem>(context), ISaleItemRepository
{
    public async Task AddRangeAsync(List<SaleItem> saleItems, CancellationToken cancellationToken = default) =>
        await _dbSet.AddRangeAsync(saleItems, cancellationToken);
}