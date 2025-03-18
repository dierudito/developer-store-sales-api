using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
public class CreateSaleHandler(IMapper mapper, ISaleService saleService) :
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
        var result = mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}
