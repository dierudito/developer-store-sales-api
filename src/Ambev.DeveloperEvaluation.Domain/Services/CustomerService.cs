using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Services;
public class CustomerService(ICustomerRepository CustomerRepository) : ICustomerService
{
    public async Task<Customer> CreateAsync(Customer Customer, CancellationToken cancellationToken = default)
    {
        await CustomerRepository.CreateAsync(Customer, cancellationToken);
        await CustomerRepository.CommitAsync(cancellationToken);
        return Customer;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default) =>
        await CustomerRepository.GetAllAsync(cancellationToken);

    public async Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await CustomerRepository.GetByIdAsync(id, cancellationToken);
}
