using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
public class UpdateSaleHandler(IMapper mapper, ISaleService saleService) :
    IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var saleEntity = await saleService.GetSaleByIdAsync(command.Id, cancellationToken) ?? 
                         throw new KeyNotFoundException($"Sale with ID {command.Id} not found"); 
        
        mapper.Map(command, saleEntity);

        saleEntity.Items.Clear();
        var saleItems = mapper.Map<List<SaleItem>>(command.Items);

        foreach (var item in saleItems)
        {
            saleEntity.AddItem(item);
            if (!saleEntity.ValidationResultDetail.IsValid)
                throw new ValidationException(string.Join(", ", saleEntity.ValidationResultDetail.Errors.Select(e => e.Error)));
        }

        var updatedSale = await saleService.UpdateAsync(saleEntity, cancellationToken);
        var result = mapper.Map<UpdateSaleResult>(updatedSale);
        return result;
    }
}
