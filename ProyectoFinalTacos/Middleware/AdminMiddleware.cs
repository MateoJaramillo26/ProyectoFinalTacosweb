using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AdminMiddleware
{
    private readonly RequestDelegate _next;

    public AdminMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value.ToLower();
        if (path == "/" || path.StartsWith("/home") || path.StartsWith("/usuarios/login")  || path.StartsWith("/usuarios/registro")) //Aquí se pone lo público
        {
            await _next(context);
            return;
        }

        var isAdmin = context.Session.GetString("IsAdmin");
        if (isAdmin != "true")
        {
            context.Response.Redirect("/Home");
            return;
        }

        await _next(context);
    }
}
