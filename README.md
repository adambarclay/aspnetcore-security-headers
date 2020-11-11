# ASP.NET Core Security Headers

[![License: MIT](https://img.shields.io/github/license/adambarclay/aspnetcore-security-headers?color=blue)](https://github.com/adambarclay/aspnetcore-security-headers/blob/main/LICENSE) [![build](https://img.shields.io/github/workflow/status/adambarclay/aspnetcore-security-headers/Build/main)](https://github.com/adambarclay/aspnetcore-security-headers/actions?query=workflow%3ABuild+branch%3Amain) [![coverage](https://img.shields.io/codecov/c/github/adambarclay/aspnetcore-security-headers/main)](https://codecov.io/gh/adambarclay/aspnetcore-security-headers/branch/main)

## Usage

Install the `AdamBarclay.AspNetCore.SecurityHeaders` nuget package.

```powershell
    Install-Package AdamBarclay.AspNetCore.SecurityHeaders
```

To include the security headers middleware in the ASP.NET pipeline, during application configuration include:

```c#
    using AdamBarclay.AspNetCore.SecurityHeaders;
```

and call:

```c#
    app.UseSecurityHeaders()
```

## Defaults

Calling `app.UseSecurityHeaders()` is eqivalent to calling:

```c#
    app.UseSecurityHeaders(
        c =>
        {
            c.ContentSecurityPolicy(o =>
            {
                o.ConfigureDefault().Self();
                o.ConfigureObject().None();
                o.ConfigureDirective("frame-ancestors").None();
            });

            c.FrameOptions(o => o.Deny());

            c.ReferrerPolicy(o => o.StrictOriginWhenCrossOrigin());

            c.StrictTransportSecurity(o => o.MaxAge(TimeSpan.FromDays(365)).IncludeSubdomains());
        });
```

By default, all of the security headers are included. To disable any of the headers, call `Disable()` on that header's configuration builder.

```c#
    app.UseSecurityHeaders(
        c =>
        {
            c.ContentSecurityPolicy(o => o.Disable());
            c.ContentTypeOptions(o => o.Disable());
            c.FrameOptions(o => o.Disable());
            c.ReferrerPolicy(o => o.Disable());
            c.StrictTransportSecurity(o => o.Disable());
        });
```

## Headers

### Content Security Policy (content-security-policy)

The default value for `content-security-policy` is `default-src 'self';frame-ancestors 'none';object-src 'none'`.

### Content Type Options (x-content-type-options)

The default value for `x-content-type-options` is `nosniff`.

No other values can be configured.

### Frame Options (x-frame-options)

The default value for `x-frame-options` is `deny`.

Use the `FrameOptions()` configuration builder to configure the value.

Call `Deny()` to set the value to `deny`.

```c#
    app.UseSecurityHeaders(c => c.FrameOptions(o => o.Deny()));
```

Call `SameOrigin()` to set the value to `sameorigin`.

```c#
    app.UseSecurityHeaders(c => c.FrameOptions(o => o.SameOrigin()));
```

### Referrer Policy (referrer-policy)

The default value for `referrer-policy` is `strict-origin-when-cross-origin`.

### Strict Transport Security (strict-transport-security)

The default value for `strict-transport-security` is `max-age=31536000;includeSubdomains`.
