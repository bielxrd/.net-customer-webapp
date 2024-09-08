using CustomersWebApp.Application.Dtos;
using FluentValidation;

namespace CustomersWebApp.Application.Validations;

public class AddressValidator : AbstractValidator<AddressRequest>
{
    public AddressValidator()
    {
        RuleFor(address => address.Street)
            .NotEmpty().WithMessage("o campo rua não pode ser vazio");

        RuleFor(address => address.City)
            .NotEmpty().WithMessage("o campo cidade não pode ser vazio");

        RuleFor(address => address.State)
            .NotEmpty().WithMessage("o campo estado não pode ser vazio");
    }
}
