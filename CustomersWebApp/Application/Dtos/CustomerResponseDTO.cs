namespace CustomersWebApp.Application.Dtos;

public class CustomerResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<EmailResponseDTO> Emails { get; set; }
    public List<AddressResponseDTO> Addresses { get; set; }
}
