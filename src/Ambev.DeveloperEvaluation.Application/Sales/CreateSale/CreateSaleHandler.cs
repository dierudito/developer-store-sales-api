using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Publishers;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
public class CreateSaleHandler(IMapper mapper, ISaleService saleService, IEventPublisher eventPublisher) :
    IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = mapper.Map<Sale>(command);
        var saleItems = mapper.Map<List<SaleItem>>(command.Items);

        foreach (var item in saleItems)
        {
            sale.AddItem(item);
            if (!sale.ValidationResultDetail.IsValid)
                throw new ValidationException(string.Join(", ", sale.ValidationResultDetail.Errors.Select(e => e.Error)));
        }

        var createdSale = await saleService.CreateAsync(sale, cancellationToken);
        var saleCreatedEvent = new SaleCreatedEvent
        {
            SaleId = createdSale.Id,
            BranchId = createdSale.BranchId,
            CustomerId = createdSale.CustomerId,
            SaleNumber = createdSale.SaleNumber
        };
        await eventPublisher.PublishSaleCreatedEvent(saleCreatedEvent);
        var result = mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
