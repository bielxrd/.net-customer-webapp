using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Pagination;

namespace CustomersWebApp.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IQueryable<Customer>> GetAllAsync();
    Task<Customer> AddAsync(Customer customer);

    Task<Customer> GetById(Guid Id);
}
