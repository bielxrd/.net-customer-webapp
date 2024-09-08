using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Validations;
using FluentValidation.TestHelper;
using System.Runtime.CompilerServices;

namespace CustomerTests.Validator;

public class EmailValidatorTest
{
    private readonly EmailValidator validator;

    public EmailValidatorTest()
    {
        validator = new EmailValidator();
    }

    [Fact]
    public void ShouldReturnErrorWhenEmailIsInvalid()
    {
        var emailRequest = new EmailRequest
        {
            EmailAddress = "@gmail.com"
        };

        var validate = this.validator.TestValidate(emailRequest);

        Assert.False(validate.IsValid);
    }
}
