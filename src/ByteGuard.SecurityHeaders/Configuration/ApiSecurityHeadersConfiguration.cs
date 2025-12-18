namespace ByteGuard.SecurityHeaders;

/// <summary>
/// Configuration object for API security headers.
/// </summary>
public class ApiSecurityHeadersConfiguration
{
    /// <summary>
    /// Enforce default API security headers.
    /// </summary>
    /// <remarks>
    /// If set to <c>true</c> the default API security headers will be enforced, removing any other potential header values.
    /// Will not affect any headers besides the defined API security headers.
    /// Defaults to <c>false</c>.
    /// </remarks>
    public bool Enforce { get; set; } = false;
}
