using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;

namespace CustomersWebApp.Domain.Interfaces;

public interface IEmailRepository
{
    public Task<Email> GetByEmailAsync(string email);
    public Task<Email> GetEmailByCustomerIDAndEmailType(Guid CustomerId, EmailType type);
    public Task<List<Email>> GetByEmailsAsync(List<string> emailAddresses);
    public Task<List<Email>> AddMultipleEmailAsync(List<Email> emails);
}
