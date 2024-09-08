using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebApp.Infra.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly DataContext _context;

    public AddressRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Address>> AddMultipleAsync(List<Address> addresses)
    {
        await this._context.Addresses.AddRangeAsync(addresses);

        await this._context.SaveChangesAsync();

        return addresses;
    }

    public async Task<Address?> GetAddressByCustomerIdAndEmailType(Guid customerId, AddressType addressType)
    {
        return await this._context.Addresses.FirstOrDefaultAsync(ad => ad.CustomerId == customerId && ad.AddressType == addressType);
    }
}
