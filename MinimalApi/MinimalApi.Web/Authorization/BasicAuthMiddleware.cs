using System.Net.Http.Headers;
using System.Text;
using MinimalApi.Web.Authorization.Services;

namespace MinimalApi.Web.Authorization;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userService)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            await WriteRespondeAsync(context, "Missing header authorization.");
            return;
        }

        var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
        var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
        var username = credentials[0];
        var password = credentials[1];

        var user = await userService.Authenticate(username, password);

        if (user is null)
        {
            await WriteRespondeAsync(context, "Wrong username or password.");
            return;
        }

        await _next(context);
    }

    private static async Task WriteRespondeAsync(HttpContext context, string message)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsJsonAsync(new
        {
            message, StatusCode = StatusCodes.Status401Unauthorized
        });
    }
}