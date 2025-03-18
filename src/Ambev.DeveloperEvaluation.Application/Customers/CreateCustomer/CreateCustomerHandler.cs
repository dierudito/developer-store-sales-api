using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
public class CreateCustomerHandler(IMapper mapper, ICustomerService CustomerService) :
    IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(command);
        var createdCustomer = await CustomerService.CreateAsync(customer, cancellationToken);
        var result = mapper.Map<CreateCustomerResult>(createdCustomer);
        return result;
    }
}
