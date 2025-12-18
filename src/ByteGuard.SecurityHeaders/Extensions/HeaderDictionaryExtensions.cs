using Microsoft.AspNetCore.Http;

namespace ByteGuard.SecurityHeaders;

internal static class HeaderDictionaryExtensions
{
    /// <summary>
    /// Add security header
    /// </summary>
    /// <param name="headers">Header dictionary.</param>
    /// <param name="name">Header name.</param>
    /// <param name="value">Header value.</param>
    /// <param name="enforce">Whether the value should override any preexisting value.</param>
    internal static void AddSecurityHeader(this IHeaderDictionary headers, string name, string value, bool enforce)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (enforce)
        {
            headers[name] = value;
            return;
        }

        headers.TryAdd(name, value);
    }
}
