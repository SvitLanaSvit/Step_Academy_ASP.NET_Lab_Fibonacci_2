namespace Lab_Fibonacci_WithStaticClass_2
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseMyAuthenticateMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticateMiddleware>();
        }
        public static IApplicationBuilder UseMyErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
        public static IApplicationBuilder UseMyRoutingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
