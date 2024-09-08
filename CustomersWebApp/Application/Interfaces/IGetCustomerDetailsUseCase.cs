using CustomersWebApp.Application.Dtos;

namespace CustomersWebApp.Application.Interfaces;

public interface IGetCustomerDetailsUseCase
{
    public Task<CustomerDetailsDTO> GetCustomerById(Guid id);
}
