namespace BackendDevWithDotNet.Middleware;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await next(context);

        logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
    }
}
