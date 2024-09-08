using CustomersWebApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersWebApp.Domain.Entitites;

public class Address
{
    public Guid Id { get; set; }

    [MaxLength(255)]
    public string Street { get; set; }
    [MaxLength(100)]
    public string City { get; set; }
    [MaxLength(100)]
    public string State { get; set; }
    public AddressType AddressType { get; set; }
    public Guid CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}
