using CustomersWebApp.Application.Dtos;
using FluentValidation;

namespace CustomersWebApp.Application.Validations;

public class EmailValidator : AbstractValidator<EmailRequest>
{
    public EmailValidator()
    {
        RuleFor(email => email.EmailAddress).NotEmpty().WithMessage("Email é obrigatório")
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Email não está valido");
    }
}
