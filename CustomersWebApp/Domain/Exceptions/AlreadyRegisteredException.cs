namespace CustomersWebApp.Domain.Exceptions;

public class AlreadyRegisteredException : Exception
{
    public AlreadyRegisteredException(string message) : base(message) { }
}
