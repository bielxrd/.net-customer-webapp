namespace CustomersWebApp.Application.Dtos;

public class CustomerRequest
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<AddressRequest> Addresses { get; set; }
    public List<EmailRequest> Emails { get; set; }
}
