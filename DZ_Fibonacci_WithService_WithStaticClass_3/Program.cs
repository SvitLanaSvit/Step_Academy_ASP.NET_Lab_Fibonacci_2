using DZ_Fibonacci_WithService_WithStaticClass_3.Middleware;
using DZ_Fibonacci_WithService_WithStaticClass_3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Fibonacci>();
builder.Services.AddTransient<FibonacciService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMyErrorHandlingMiddleware();
app.UseMyAuthenticateMiddleware();
app.UseMyRoutingMiddleware();

app.Run();