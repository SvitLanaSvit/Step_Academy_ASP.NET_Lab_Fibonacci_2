namespace DZ_Fibonacci_WithService_WithStaticClass_3.Middleware
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseMyErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
        public static IApplicationBuilder UseMyAuthenticateMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticateMiddleware>();
        }
        public static IApplicationBuilder UseMyRoutingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
