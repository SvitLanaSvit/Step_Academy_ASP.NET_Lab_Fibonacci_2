namespace Lab_Fibonacci_WithStaticClass_2
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate next;

        public AuthenticateMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string token = context.Request.Query["token"];
            if (token == "svit")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h2 style='color: green'>" +
                    "START</h2>");
                await next.Invoke(context);
            }
            else if (token != "svit")
            {
                context.Response.StatusCode = 403;   
            }
        }
    }
}
