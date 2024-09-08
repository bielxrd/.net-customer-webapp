using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;

namespace CustomersWebApp.Application.Mapper;

public class AddressMapper
{
    public static AddressResponseDTO AddressToResponse(Address address)
    {
        return new AddressResponseDTO
        {
            Id = address.Id,
            Street = address.Street,
            City = address.City,
            State = address.State,
        };
    }

    public static List<AddressResponseDTO> MapToAddressResponseList(List<Address> addresses)
    {
        return addresses.Select(address => new AddressResponseDTO
        {
            Id = address.Id,
            Street = address.Street,
            City = address.City,
            State = address.State,
        }).ToList();
    }
    public static List<Address> MapToListAddress(List<AddressRequest> addressRequests)
    {
        return addressRequests.Select((address, index) => new Address
        {
            Street = address.Street,
            City = address.City,
            State = address.State,
            AddressType = index == 0 ? AddressType.Primary : AddressType.Secondary,
        }).ToList();
    }
}
