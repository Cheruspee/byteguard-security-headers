namespace ByteGuard.SecurityHeaders;

/// <summary>
/// configuration object for security headers.
/// </summary>
public class SecurityHeadersConfiguration
{
    /// <summary>
    /// Enforce default security headers.
    /// </summary>
    /// <remarks>
    /// If set to <c>true</c> the default security headers will be enforced, removing any other potential header values.
    /// Will not affect any headers besides the defined security headers.
    /// Defaults to <c>false</c>.
    /// </remarks>
    public bool Enforce { get; set; } = false;
}
