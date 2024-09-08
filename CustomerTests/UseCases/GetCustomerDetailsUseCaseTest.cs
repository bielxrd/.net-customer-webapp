using CustomersWebApp.Application.UseCases.CustomerUseCases;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Domain.Enums;
using Moq;

namespace CustomerTests.UseCases;

public class GetCustomerDetailsUseCaseTest
{
    private readonly GetCustomerDetailsUseCase getCustomerDetailsUse;
    private readonly Mock<ICustomerRepository> _customerRepository;

    public GetCustomerDetailsUseCaseTest()
    {
        this._customerRepository = new Mock<ICustomerRepository>();
        this.getCustomerDetailsUse = new GetCustomerDetailsUseCase(_customerRepository.Object);
    }

    [Fact]
    public async void ShouldReturnCustomerDetailsUseCase()
    {
        var customer = new Customer
        {
            Id = new Guid(),
            Name = "example",
            Phone = "(00) 00000-0000",
            Addresses = new List<Address> { new Address { Id = new Guid(), Street = "Rua example", City = "Sao Paulo", State = "SP", AddressType = AddressType.Primary} },
            Emails =  new List<Email> { new Email { Id = new Guid(), EmailAddress = "example@hotmail.com", EmailType = EmailType.Primary} } 
        };

        _customerRepository.Setup(repo => repo.GetById(customer.Id)).ReturnsAsync(customer);

        var result = await getCustomerDetailsUse.GetCustomerById(customer.Id);

        Assert.NotNull(result);
        Assert.Equal(result.Id, customer.Id);
    }
}
