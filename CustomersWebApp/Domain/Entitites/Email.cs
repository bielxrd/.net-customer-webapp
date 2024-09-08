using CustomersWebApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersWebApp.Domain.Entitites;

[Index(nameof(EmailAddress), IsUnique = true)]
public class Email
{
    public Guid Id { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    public EmailType EmailType { get; set; }
    public Guid CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}
