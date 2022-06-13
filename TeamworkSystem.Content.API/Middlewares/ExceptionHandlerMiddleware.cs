using System.Net;
using TeamworkSystem.Shared.Exceptions;

namespace TeamworkSystem.Content.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = e switch
            {
                EntityNotFoundException => (int) HttpStatusCode.NotFound,
                _ => (int) HttpStatusCode.InternalServerError,
            };

            await context.Response.WriteAsJsonAsync(new { e.Message });
        }
    }
}
