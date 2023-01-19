namespace Lab_Fibonacci_WithStaticClass_2
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate next;
        public RoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? path = context.Request.Path.Value?.ToLower();
            string val = context.Request.Query["index"];
            if (path == "/fibonacci")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h2 style='color: green'>" +
                    "This is a site with calculation index of fibonacci:</h2>");
                if (val != null)
                {
                    int index = int.Parse(val);
                    if (index >= 0 && index <= 40)
                    {
                        context.Response.Headers.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync($"<h2>F[{index}] = {Fibonacci(index)}</h2>");
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

        private static long Fibonacci(int i)
        {
            long[] arr = new long[100];
            arr[0] = 0;
            arr[1] = 1;
            for (int j = 2; j < arr.Length; j++)
            {
                arr[j] = arr[j - 1] + arr[j - 2];
            }
            return arr[i];
        }
    }
}