using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Services;
public class SaleService(ISaleRepository repository, ILogger<SaleService> logger) : 
    ISaleService
{
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await repository.CreateAsync(sale, cancellationToken);
        await repository.CommitAsync(cancellationToken);
        
        // Publicar o evento de venda criada (log no aplicativo)
        logger.LogInformation("SaleCreated event published: SaleId = {SaleId}", sale.Id);
        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await repository.UpdateAsync(sale);
        await repository.CommitAsync(cancellationToken);

        // Publicar o evento de venda modificada (log no aplicativo)
        logger.LogInformation("SaleModified event published: SaleId = {SaleId}", sale.Id);
        return sale;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync(id);
        await repository.CommitAsync(cancellationToken);
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default) =>
        await repository.GetAllAsync(cancellationToken);

    public async Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await repository.GetByIdAsync(id, cancellationToken);

    public async Task CancelItemAsync(Sale sale, SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        sale.CancelItem(saleItem);
        await repository.UpdateAsync(sale);
        await repository.CommitAsync(cancellationToken);

        // Publicar o evento de Item Cancelado (log no aplicativo)
        logger.LogInformation("ItemCancelled event published: SaleId = {SaleId}", sale.Id);
    }
}