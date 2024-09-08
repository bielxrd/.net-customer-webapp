using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Interfaces;
using CustomersWebApp.Application.Mapper;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebApp.Application.UseCases.CustomerUseCases;

public class GetCustomersUseCase : IGetCustomersUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PaginatedResult<CustomerResponseDTO>> Get(int pageNumber, int pageSize)
    {
        var query = await this._customerRepository.GetAllAsync();

        var totalItems =  query.Count();

        var customers = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return CustomerMapper.MapToPaginatedCustomers
            (
                CustomerMapper.MapToCostumerResponseDTOList(customers),
                pageNumber,
                pageSize,
                totalItems
            );
    }
}
