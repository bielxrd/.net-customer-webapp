using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Interfaces;
using CustomersWebApp.Application.Mapper;
using CustomersWebApp.Application.Validations;
using CustomersWebApp.Domain.Exceptions;
using CustomersWebApp.Domain.Interfaces;
using FluentValidation.Results;


namespace CustomersWebApp.Application.UseCases.CustomerUseCases;

public class CreateCustomerUseCase : ICreateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmailRepository _emailRepository;

    public CreateCustomerUseCase(ICustomerRepository customerRepository, IEmailRepository emailRepository)
    {
        _customerRepository = customerRepository;
        _emailRepository = emailRepository;
    }

    public async Task<CustomerResponseDTO> CreateCustomer(CustomerRequest customerRequest)
    {
        CustomerValidator customerValidator = new CustomerValidator();

        var validate = customerValidator.Validate(customerRequest);

        if (!validate.IsValid)
        {
            var errors = validate.Errors
                .Select(error => $"{error.ErrorMessage}")
                .ToList();

            throw new ValidationException(string.Join("; ", errors));
        }

        var existingEmails = await this._emailRepository.GetByEmailsAsync(customerRequest.Emails.Select(e => e.EmailAddress).ToList());

        if (existingEmails.Any())
        {
            var emailAddresses = existingEmails.Select(e => e.EmailAddress);
            throw new AlreadyRegisteredException("Um ou mais emails já foram cadastrados: " + string.Join(", ", emailAddresses));
        }

        var customer = CustomerMapper.MapToCostumer(customerRequest);

        var response = await _customerRepository.AddAsync(customer);

        return CustomerMapper.MapToCustomerResponseDTO
            (
                response,
                AddressMapper.MapToAddressResponseList(response.Addresses),
                EmailMapper.MapToEmailResponseList(response.Emails)
            );
    }
}

