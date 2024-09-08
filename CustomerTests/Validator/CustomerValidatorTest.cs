using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Validations;
using FluentValidation.TestHelper;

namespace CustomerTests.Validator;

public class CustomerValidatorTest
{
    private readonly CustomerValidator validator;

    public CustomerValidatorTest()
    {
        validator = new CustomerValidator();
    }

    [Fact]
    public void ShouldReturnErrorWhenPhoneIsInvalid()
    {
        var customerRequest = new CustomerRequest
        {
            Name = "Gabriel",
            Phone = "12345"
        };

        var validate = this.validator.TestValidate(customerRequest);

        Assert.False(validate.IsValid);

    }
}
