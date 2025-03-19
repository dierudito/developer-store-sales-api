using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Services;
public class SaleService(ISaleRepository saleRepository, ILogger<SaleService> logger) : 
    ISaleService
{
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await saleRepository.CreateAsync(sale, cancellationToken);
        await saleRepository.CommitAsync(cancellationToken);
        
        // Publicar o evento de venda criada (log no aplicativo)
        logger.LogInformation("SaleCreated event published: SaleId = {SaleId}", sale.Id);
        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await saleRepository.UpdateAsync(sale);
        await saleRepository.CommitAsync(cancellationToken);

        // Publicar o evento de venda modificada (log no aplicativo)
        logger.LogInformation("SaleModified event published: SaleId = {SaleId}", sale.Id);
        return sale;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await saleRepository.DeleteAsync(id);
        await saleRepository.CommitAsync(cancellationToken);
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default) =>
        await saleRepository.GetAllAsync(cancellationToken);

    public async Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await saleRepository.GetByIdAsync(id, cancellationToken);
}