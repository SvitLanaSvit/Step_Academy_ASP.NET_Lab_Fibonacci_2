using DZ_Fibonacci_WithService_WithStaticClass_3.Services;

namespace DZ_Fibonacci_WithService_WithStaticClass_3.Middleware
{
    public class RoutingMiddleware
    {
        private readonly Fibonacci fibonacci;
        public RoutingMiddleware(RequestDelegate _, Fibonacci fibonacci)
        {
            this.fibonacci = fibonacci;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string? path = context.Request.Path.Value?.ToLower();
            string val = context.Request.Query["index"];
            if (path == "/fibonacci")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
         
                if (val != null)
                {
                    int index = int.Parse(val);
                    if (index >= 0 && index <= 40)
                    {
                        context.Response.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync($"<h2>F[{index}] = {fibonacci.GetValue(index)}</h2>");
                    }
                    else
                    {   
                        context.Response.StatusCode = 404;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = 405;
            }
        }
    }
}