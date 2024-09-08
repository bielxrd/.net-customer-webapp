using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace customers_api.Infra.Repositories;

public class EmailRepository : IEmailRepository
{

    private readonly DataContext _context;

    public EmailRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Email>> AddMultipleEmailAsync(List<Email> emails)
    {
        await this._context.Emails.AddRangeAsync(emails);

        await _context.SaveChangesAsync();

        return emails;
    }

    public async Task<Email?> GetByEmailAsync(string emailAddress)
    {
        var email = await this._context.Emails.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);

        return email;
    }

    public async Task<List<Email>> GetByEmailsAsync(List<string> emailAddresses)
    {
        return await _context.Emails.
                            Where(e => emailAddresses.Contains(e.EmailAddress))
                            .ToListAsync();
                            
    }

    public async Task<Email?> GetEmailByCustomerIDAndEmailType(Guid CustomerId, EmailType type)
    {
        return (await _context.Emails.FirstOrDefaultAsync(email => email.CustomerId == CustomerId && email.EmailType == type));
    }
}
