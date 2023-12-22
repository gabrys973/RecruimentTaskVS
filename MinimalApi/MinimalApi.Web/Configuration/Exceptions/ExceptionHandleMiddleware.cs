using MinimalApi.Application.Services.Exceptions;
using Serilog;

namespace MinimalApi.Web.Configuration.Exceptions;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(ex, httpContext);
        }
    }

    private async Task HandleException(Exception e, HttpContext httpContext)
    {
        Log.Error(e, "Error handled");
        
        if (e is InvalidFileDataException)
        {
            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsJsonAsync(new ResponseModel
            {
                StatusCode = 400,
                Message = e.Message
            });
        }
        else if (e is ArgumentException)
        {
            await httpContext.Response.WriteAsync("Invalid argument");
        }
        else
        {
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new ResponseModel
            {
                StatusCode = 500,
                Message = "System error."
            });
        }
    }
}