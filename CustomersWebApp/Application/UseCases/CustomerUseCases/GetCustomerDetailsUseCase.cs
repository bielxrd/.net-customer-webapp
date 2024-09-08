using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Interfaces;
using CustomersWebApp.Application.Mapper;
using CustomersWebApp.Domain.Exceptions;
using CustomersWebApp.Domain.Interfaces;

namespace CustomersWebApp.Application.UseCases.CustomerUseCases;

public class GetCustomerDetailsUseCase : IGetCustomerDetailsUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerDetailsUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDetailsDTO> GetCustomerById(Guid Id)
    {
        var customer = await this._customerRepository.GetById(Id);

        if (customer == null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        var addresses = customer.Addresses.Where(a => a.AddressType == Domain.Enums.AddressType.Primary);
        
        var emails = customer.Emails.Where(e => e.EmailType == Domain.Enums.EmailType.Primary);

        var address = AddressMapper.AddressToResponse(addresses.First());
        var email = EmailMapper.MapToEmailResponseDTO(emails.First());

        return CustomerMapper.MapToCostumerDetailsDTO(customer, address, email);
    }
}
