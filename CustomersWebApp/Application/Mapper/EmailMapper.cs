using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Domain.Entitites;
using CustomersWebApp.Domain.Enums;

namespace CustomersWebApp.Application.Mapper;

public class EmailMapper
{
    public static EmailResponseDTO MapToEmailResponseDTO(Email email)
    {
        return new EmailResponseDTO
        {
            EmailAddress = email.EmailAddress,
            Id = email.Id,
        };
    }

    public static List<EmailResponseDTO> MapToEmailResponseList(List<Email> emails)
    {
        return emails.Select(email => new EmailResponseDTO
        {
            Id = email.Id,
            EmailAddress = email.EmailAddress,
        }).ToList();
    }

    public static List<Email> MapToListAddress(List<EmailRequest> emailRequests)
    {
        return emailRequests.Select((email, index) => new Email
        {
            EmailAddress = email.EmailAddress,
            EmailType = index == 0 ? EmailType.Primary : EmailType.Secondary,
        }).ToList();
    }
}
