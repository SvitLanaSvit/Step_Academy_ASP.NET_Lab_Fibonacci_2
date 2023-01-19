using System;

var builder = WebApplication.CreateBuilder(args);
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
    else if(token != "svit")
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

static long Fibonacci(int i)
{
    long[] arr = new long[100];
    arr[0] = 0;
    arr[1] = 1;
    for(int j = 2; j < arr.Length; j++)
    {
        arr[j] = arr[j - 1] + arr[j - 2];
    }
    return arr[i];
}

app.Run();