using Azure;
using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Pagination;
using System.Net;

namespace CustomersWebApp.Application.Mapper;

public class CustomerMapper
{

    public static Customer MapToCostumer(CustomerRequest customerRequest)
    {
        return new Customer
        {
            Name = customerRequest.Name,
            Phone = customerRequest.Phone,
            Emails = EmailMapper.MapToListAddress(customerRequest.Emails),
            Addresses = AddressMapper.MapToListAddress(customerRequest.Addresses)
        };
    }

    public static CustomerDetailsDTO MapToCostumerDetailsDTO(Customer customer, AddressResponseDTO addressResponse, EmailResponseDTO emailResponseDTO)
    {
        return new CustomerDetailsDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Phone = customer.Phone,
            address = addressResponse,
            email = emailResponseDTO
        };
    }

    public static CustomerResponseDTO MapToCustomerResponseDTO(Customer customer, List<AddressResponseDTO> addresses, List<EmailResponseDTO> emails)
    {
        return new CustomerResponseDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Phone = customer.Phone,
            Emails = emails,
            Addresses = addresses
        };
    }

    public static List<CustomerResponseDTO> MapToCostumerResponseDTOList(List<Customer> customers)
    {
        return customers.Select(customer => new CustomerResponseDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Phone = customer.Phone,
            Addresses = null,
            Emails = null
        }).ToList();
    }

    public static PaginatedResult<CustomerResponseDTO> MapToPaginatedCustomers(List<CustomerResponseDTO> customers, int pageNumber, int pageSize, int totalItems)
    {
        return new PaginatedResult<CustomerResponseDTO>
        {
            Data = customers,
            PageSize = pageSize,
            PageNumber = pageNumber,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double) pageSize)
        };
    }
}
