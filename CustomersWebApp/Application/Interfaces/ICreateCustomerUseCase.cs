using CustomersWebApp.Application.Dtos;

namespace CustomersWebApp.Application.Interfaces;

public interface ICreateCustomerUseCase
{
    Task<CustomerResponseDTO> CreateCustomer(CustomerRequest customerRequest);
}
