using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Pagination;

namespace CustomersWebApp.Application.Interfaces;

public interface IGetCustomersUseCase
{
    public Task<PaginatedResult<CustomerResponseDTO>> Get(int pageNumber, int pageSize);
}
