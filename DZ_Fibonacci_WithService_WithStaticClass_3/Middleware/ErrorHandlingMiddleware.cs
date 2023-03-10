using System.IO;

namespace DZ_Fibonacci_WithService_WithStaticClass_3.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }   

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
            var resp = context.Response;
            if(resp.StatusCode == 403)
            {
                context.Response.Headers.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h2 style='color: red'>The site is not found!</h2>");
            }
            else if (resp.StatusCode == 404)
            {
                context.Response.Headers.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h2 style='color: red'>The index must be from 0 to 40!</h2>");
            }
            else if (resp.StatusCode == 405)
            {
                context.Response.Headers.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"<h2 style='color: red'>The site is not found!</h2>");
            }
        }
    }
}