using System.ComponentModel.DataAnnotations;

namespace CustomersWebApp.Domain.Entitites;

public class Customer
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Phone]
    public string Phone { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Email> Emails { get; set; }

}
