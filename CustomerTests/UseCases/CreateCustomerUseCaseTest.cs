using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.UseCases.CustomerUseCases;
using CustomersWebApp.Application.Validations;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Exceptions;
using CustomersWebApp.Domain.Interfaces;
using Moq;

namespace CustomerTests.UseCases;

public class CreateCustomerUseCaseTest
{
    private readonly CreateCustomerUseCase createCustomerUseCase;
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;
    private readonly Mock<IEmailRepository> _mockEmailRepository;

    public CreateCustomerUseCaseTest()
    {
        _mockCustomerRepository = new Mock<ICustomerRepository>();
        _mockEmailRepository = new Mock<IEmailRepository>();
        createCustomerUseCase = new CreateCustomerUseCase(_mockCustomerRepository.Object, _mockEmailRepository.Object);
    }

    [Fact]
    public async Task CreateCustomerShouldReturnResponseWhenSuccess()
    {
        var customerRequest = new CustomerRequest
        {
            Name = "Gabriel",
            Phone = "(11) 98535-6473",
            Emails = new List<EmailRequest> { new EmailRequest { EmailAddress = "gabriel@gmail.com" } },
            Addresses = new List<AddressRequest> { new AddressRequest { Street = "Rua teste", City = "Sao paulo", State = "SP" } }
        };

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = customerRequest.Name,
            Phone = customerRequest.Phone,
            Emails = new List<Email> { new Email { Id = Guid.NewGuid(), EmailAddress = "gabriel@example.com" } },
            Addresses = new List<Address> { new Address { Id = Guid.NewGuid(), Street = "Rua A", City = "São Paulo", State = "SP" } }
        };

        _mockEmailRepository.Setup(repo => repo.GetByEmailsAsync(It.IsAny<List<string>>()))
            .ReturnsAsync(new List<Email>());

        _mockCustomerRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>()))
            .ReturnsAsync(customer);

        var result = await createCustomerUseCase.CreateCustomer(customerRequest);

        Assert.NotNull(result);
        Assert.Equal(customer.Id, result.Id);
    }

    [Fact]
    public async Task CreateCustomerShouldThrowExceptionWhenFail()
    {
        var customerRequest = new CustomerRequest
        {
            Name = "Gabriel",
            Phone = "(11) 98535-6473",
            Emails = new List<EmailRequest> { new EmailRequest { EmailAddress = "gabriel@gmail.com" } },
            Addresses = new List<AddressRequest> { new AddressRequest { Street = "Rua teste", City = "Sao paulo", State = "SP" } }
        };

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = customerRequest.Name,
            Phone = customerRequest.Phone,
            Emails = new List<Email> { new Email { Id = Guid.NewGuid(), EmailAddress = "gabriel@example.com" } },
            Addresses = new List<Address> { new Address { Id = Guid.NewGuid(), Street = "Rua A", City = "São Paulo", State = "SP" } }
        };

        var existingEmails = new List<Email>
        {
            new Email { EmailAddress = "gabriel@example.com"}
        };

        _mockEmailRepository.Setup(repo => repo.GetByEmailsAsync(It.IsAny<List<string>>()))
            .ReturnsAsync(existingEmails);

        Func<Task> result = async () => await createCustomerUseCase.CreateCustomer(customerRequest);

        await Assert.ThrowsAsync<AlreadyRegisteredException>(result);
    }


}
