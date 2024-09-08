using CustomersWebApp.Domain.Exceptions;
using System.Net;

namespace CustomersWebApp.Infra.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.BadRequest;
        string result;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = exception.Message;
                break;

            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                result = exception.Message;
                break;

            case AlreadyRegisteredException alreadyRegisteredException:
                statusCode = HttpStatusCode.BadRequest;
                result = exception.Message;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                result = exception.Message;
                break;
        }


        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsJsonAsync(result);
    }
}
