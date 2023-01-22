using DZ_Fibonacci_WithService_3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<FibonacciService>();
builder.Services.AddTransient<Fibonacci>();
var app = builder.Build();

app.Use(async (context, next) =>
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
        context.Response.Headers.ContentType = "text/html; charset=utf-8";
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("<h2 style='color: red'>The site is not found!</h2>");
    }
});

app.Run(async context =>
{
    string? path = context.Request.Path.Value?.ToLower();
    string val = context.Request.Query["index"];
    if(path == "/fibonacci")
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        if(val != null)
        {
            int index = int.Parse(val);
            if(index >= 0 && index <= 40)
            {
                FibonacciService? fibonacciService = app.Services.GetService<FibonacciService>();
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"<h2>F[{index}] = {fibonacciService?.GetValue(index)}</h2>");
            }
            else
            {
                context.Response.Headers.ContentType = "text/html; charset=utf-8";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("<h2 style='color: red'>The index must be from 0 to 40!</h2>");
            }
        }
    }
    else
    {
        context.Response.Headers.ContentType = "text/html; charset=utf-8";
        context.Response.StatusCode = 405;
        await context.Response.WriteAsync($"<h2 style='color: red'>The site {path} is not found!</h2>");
    }
});

app.Run();