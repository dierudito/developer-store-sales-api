using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.ORM.Repositories.Base;
[ExcludeFromCodeCoverage]
public class BaseRepository<TEntity> (DefaultContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected DbSet<TEntity> _dbSet = context.Set<TEntity>();
    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Yield();
        _dbSet.Update(entity);
        return entity;
    }

    public virtual async Task<int> CommitAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);

    public virtual async Task DeleteAsync(Guid id)
    {
        await Task.Yield();
        var entity = new TEntity { Id = id };
        _dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbSet.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
}