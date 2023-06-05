using System.Net;

namespace MovieApp.Web.Infastructure.Middlewares;

public class GlobalExceptionHandlers
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlers(RequestDelegate next)
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

            await HandleException(context, ex); 
        }
    }

    private async Task HandleException(HttpContext context,Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

      await  context.Response.WriteAsync(exception.Message);
    }
}
