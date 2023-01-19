using Lab_Fibonacci_WithStaticClass_2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMyErrorHandlingMiddleware();
app.UseMyAuthenticateMiddleware();
app.UseMyRoutingMiddleware();

app.Run();