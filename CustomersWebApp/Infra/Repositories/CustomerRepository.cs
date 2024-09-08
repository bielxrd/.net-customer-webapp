using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Domain.Pagination;
using CustomersWebApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace customers_api.Infra.Repositories;

public class CustomerRepository : ICustomerRepository
{

    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        var customerSaved = this._context.Customers.Add(customer);


        if (customerSaved != null)
        {
            await this._context.SaveChangesAsync();
            return customerSaved.Entity;
        }

        return null;
    }

    public async Task<IQueryable<Customer>> GetAllAsync()
    {
       return this._context.Customers.AsQueryable();
    }

    public async Task<Customer?> GetById(Guid Id)
    {
        return await this._context.Customers
            .Include(c => c.Emails)
            .Include(c => c.Addresses)
            .FirstOrDefaultAsync(c => c.Id == Id);
    }
}
