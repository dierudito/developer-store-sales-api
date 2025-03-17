using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Services;
public class SaleService(ISaleRepository saleRepository, ISaleItemRepository saleItemRepository) : 
    ISaleService
{
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await saleRepository.CreateAsync(sale, cancellationToken);
        await saleItemRepository.AddRangeAsync(sale.Items, cancellationToken);
        return sale;
    }

    public Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public async Task<Sale> AddItemToSaleAsync(Guid saleId, SaleItem saleItem)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default) =>
        await saleRepository.GetAllAsync(cancellationToken);

    public async Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await saleRepository.GetByIdAsync(id, cancellationToken);

    public Task<Sale> RemoveItemFromSaleAsync(Guid saleId, Guid itemId)
    {
        throw new NotImplementedException();
    }
}