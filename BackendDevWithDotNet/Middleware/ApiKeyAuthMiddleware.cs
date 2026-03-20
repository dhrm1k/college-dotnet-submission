namespace BackendDevWithDotNet.Middleware;

public class ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyHeaderName = "X-Api-Key";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/api/users"))
        {
            await next(context);
            return;
        }

        var expectedApiKey = configuration["ApiKey"];
        if (string.IsNullOrWhiteSpace(expectedApiKey))
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { message = "API key is not configured." });
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) || apiKey != expectedApiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "Missing or invalid API key." });
            return;
        }

        await next(context);
    }
}
