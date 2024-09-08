using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;

namespace CustomersWebApp.Domain.Interfaces;

public interface IAddressRepository
{
    public Task<List<Address>> AddMultipleAsync(List<Address> addresses);
    public Task<Address> GetAddressByCustomerIdAndEmailType(Guid customerId, AddressType addressType);
}
