# ByteGuard.SecurityHeaders ![NuGet Version](https://img.shields.io/nuget/v/ByteGuard.SecurityHeaders)

**ByteGuard.SecurityHeaders** is a lightweight security-focused middleware package for adding a baseline set of security response headers to **ASP.NET Core REST APIs**.

It gives you:

- A single `app.UseDefaultSecurityHeaders()` call to apply sane defaults
- OWASP-inspired header values based on the REST Security Cheat Sheet
- An `Enforce` option to ensure the standard values are applied even if set elsewhere

> ⚠️ **Important:** This package is one layer in a defense-in-depth strategy.  
> It does **not** replace proper authentication/authorization, input validation, TLS configuration, CORS hardening, or other security controls.

## Features

- ✅ Add default security headers to every response
- ✅ OWASP-inspired defaults for REST APIs
- ✅ Non-breaking by default (does not override existing headers)
- ✅ Optional **enforcement mode** to overwrite existing values
- ✅ Minimal setup (`UseDefaultSecurityHeaders`)

## Getting Started

### Installation

This package is published and installed via [NuGet](https://www.nuget.org/packages/ByteGuard.SecurityHeaders).

Reference the package in your project:

```bash
dotnet add package ByteGuard.SecurityHeaders
```

## Usage

### Basic Usage

Add the middleware early in your pipeline:

```csharp
var app = builder.Build();

app.UseDefaultSecurityHeaders();

app.MapControllers();
app.Run();
```

### Enforce standard header values

By default, the middleware will not override headers that are already present. If you want to ensure the standard values are always used (even if other middleware/controllers set them), enable enforcement:

```csharp
app.UseDefaultSecurityHeaders(options =>
{
    options.Enforce = true;
});
```

## Headers Added

The middleware adds the following headers based on the OWASP REST Security Cheat Sheet:

- `Cache-Control: no-store`
- `Content-Security-Policy: frame-ancestors 'none'`
- `X-Content-Type-Options: nosniff`
- `X-Frame-Options: DENY`

> **Note:** `Enforce = false` uses "add-if-missing" behavior. `Enforce = true` overwrites any existing value for the headers above.

## When to use this package

- ✅ When building REST APIs and you want a consistent baseline across services
- ✅ When you want a simple “secure-by-default” middleware without a large configuration surface
- ✅ When you want the option to enforce standard values across an entire API

## Disclaimer

ByteGuard.SecurityHeaders is an independent open-source project maintained by the ByteGuard community.  
It is not affiliated with, endorsed by, or sponsored by OWASP or the OWASP Foundation.

OWASP® is a trademark or registered trademark of the OWASP Foundation.  
Any references to OWASP materials are for informational, educational, and interoperability purposes only.

## License

_ByteGuard.SecurityHeaders is Copyright © ByteGuard Contributors - Provided under the MIT license._
