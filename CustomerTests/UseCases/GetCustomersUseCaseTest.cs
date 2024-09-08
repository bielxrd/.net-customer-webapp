using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Mapper;
using CustomersWebApp.Application.UseCases.CustomerUseCases;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Domain.Pagination;
using Moq;

namespace CustomerTests.UseCases;

public class GetCustomersUseCaseTest
{
    private CustomerMapper customerMapper;
    private readonly GetCustomersUseCase getCustomersUseCase;
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;

    public GetCustomersUseCaseTest()
    {
        _mockCustomerRepository = new Mock<ICustomerRepository>();
        getCustomersUseCase = new GetCustomersUseCase(_mockCustomerRepository.Object);
        customerMapper = new CustomerMapper();
    }

    [Fact]
    public async void ShouldReturnCustomersPaginatedSuccess()
    {
        int pageNumber = 1;
        int pageSize = 5;

        List<Customer> customersList = new List<Customer>
        {
            new Customer {Id = new Guid(), Name = "Customer 1"},
            new Customer {Id = new Guid(), Name = "Customer 2"},
            new Customer {Id = new Guid(), Name = "Customer 3"},
            new Customer {Id = new Guid(), Name = "Customer 4"},
        };

        var query = customersList.AsQueryable();

        var totalItems = query.Count();

        _mockCustomerRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(query);

        var result = await getCustomersUseCase.Get(pageNumber, pageSize);

        Assert.NotNull(result);
        Assert.IsType<PaginatedResult<CustomerResponseDTO>>(result);
        Assert.Equal(pageNumber, result.PageNumber);
        Assert.Equal(4, result.TotalItems);
    }
}
