namespace CustomersWebApp.Application.Dtos;

public class CustomerDetailsDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public EmailResponseDTO email { get; set; }
    public AddressResponseDTO address { get; set; }
}
