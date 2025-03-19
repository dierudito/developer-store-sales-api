using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Publishers;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
public class UpdateSaleHandler(IMapper mapper, ISaleService saleService, IEventPublisher eventPublisher) :
    IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var saleEntity = await saleService.GetSaleByIdAsync(command.Id, cancellationToken) ?? 
                         throw new KeyNotFoundException($"Sale with ID {command.Id} not found"); 
        
        var saleFromCommand = mapper.Map<Sale>(command);
        saleEntity.UpdateSale(saleFromCommand);

        var saleItemsFromCommand = mapper.Map<List<SaleItem>>(command.Items);
        UpsertSaleItems(saleEntity, saleItemsFromCommand);

        var updatedSale = await saleService.UpdateAsync(saleEntity, cancellationToken);
        var saleModifiedEvent = new SaleModifiedEvent
        {
            SaleId = updatedSale.Id,
            BranchId = updatedSale.BranchId,
            CustomerId = updatedSale.CustomerId,
            SaleNumber = updatedSale.SaleNumber
        };
        await eventPublisher.PublishSaleModifiedEvent(saleModifiedEvent);

        var result = mapper.Map<UpdateSaleResult>(updatedSale);
        return result;
    }

    private static void UpsertSaleItems(Sale saleEntity, List<SaleItem> saleItemsEntity)
    {
        foreach (var saleItem in saleItemsEntity)
        {
            var existingItem = saleEntity.Items.FirstOrDefault(i => i.Id == saleItem.Id);

            if (existingItem != null) saleEntity.UpdateItem(existingItem, saleItem);
            else saleEntity.AddItem(saleItem);
            if (!saleEntity.ValidationResultDetail.IsValid)
                throw new ValidationException(string.Join(", ", saleEntity.ValidationResultDetail.Errors.Select(e => e.Error)));
        }
    }
}
