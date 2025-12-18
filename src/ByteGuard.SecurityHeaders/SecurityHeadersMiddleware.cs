using Microsoft.AspNetCore.Builder;

namespace ByteGuard.SecurityHeaders;

/// <summary>
/// Security headers middleware.
/// </summary>
public static class SecurityHeadersMiddleware
{
    /// <summary>
    /// Add default API security headers middleware.
    /// </summary>
    /// <remarks>
    /// Adds a small baseline set of <see href="https://cheatsheetseries.owasp.org/cheatsheets/REST_Security_Cheat_Sheet.html#security-headers">OWASP-inspired</see> security headers suitable for many REST APIs.
    /// </remarks>
    /// <param name="app">Application builder.</param>
    public static IApplicationBuilder UseDefaultApiSecurityHeaders(this IApplicationBuilder app) =>
        app.UseDefaultApiSecurityHeaders(_ => { });

    /// <summary>
    /// Add default security headers middleware.
    /// </summary>
    /// <remarks>
    /// Adds a small baseline set of <see href="https://cheatsheetseries.owasp.org/cheatsheets/REST_Security_Cheat_Sheet.html#security-headers">OWASP-inspired</see> security headers suitable for many REST APIs.
    /// </remarks>
    /// <param name="app">Application builder.</param>
    /// <param name="configure">Security headers configuration.</param>
    public static IApplicationBuilder UseDefaultApiSecurityHeaders(this IApplicationBuilder app, Action<ApiSecurityHeadersConfiguration> configure)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(configure);

        var config = new ApiSecurityHeadersConfiguration();
        configure(config);

        return app.Use(async (context, next) =>
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.AddSecurityHeader("Cache-Control", "no-store", config.Enforce);
                context.Response.Headers.AddSecurityHeader("Content-Security-Policy", "frame-ancestors 'none'", config.Enforce);
                context.Response.Headers.AddSecurityHeader("X-Content-Type-Options", "nosniff", config.Enforce);
                context.Response.Headers.AddSecurityHeader("X-Frame-Options", "DENY", config.Enforce);

                return Task.CompletedTask;
            });

            await next();
        });
    }
}
