using CustomersWebApp.Application.Dtos;
using FluentValidation;

namespace CustomersWebApp.Application.Validations;

public class CustomerValidator : AbstractValidator<CustomerRequest>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.");

        RuleFor(customer => customer.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório")
            .Matches(@"^\(?\d{2}\)?\s?\d{5}-?\d{4}$").WithMessage("O telefone informado não está em um formato válido."); ;

        RuleFor(customer => customer.Emails)
            .NotEmpty().WithMessage("Pelo menos um email é obrigatório.");

        RuleForEach(customer => customer.Emails)
            .SetValidator(new EmailValidator());

        RuleFor(customer => customer.Addresses)
            .NotEmpty().WithMessage("Pelo menos um endereço é obrigatório.");

        RuleForEach(customer => customer.Addresses)
            .SetValidator(new AddressValidator());
    }
}
