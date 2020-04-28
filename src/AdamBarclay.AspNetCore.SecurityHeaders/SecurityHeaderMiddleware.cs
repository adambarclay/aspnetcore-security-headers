using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security headers ASP.NET Core pipline extension.</summary>
	public static class SecurityHeaderMiddleware
	{
		/// <summary>Adds the security headers to the ASP.NET Core pipeline.</summary>
		/// <param name="applicationBuilder">The ASP.NET Core <see cref="IApplicationBuilder"/>.</param>
		/// <returns>The same ASP.NET Core <see cref="IApplicationBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="applicationBuilder"/> is <see langword="null"/>.</exception>
		public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder applicationBuilder)
		{
			if (applicationBuilder == null)
			{
				throw new ArgumentNullException(nameof(applicationBuilder));
			}

			var securityHeaderPolicy = new SecurityHeaderPolicy(
				"default-src 'self'",
				"accelerometer 'none';ambient-light-sensor 'none';autoplay 'none';battery 'none';camera 'none';display-capture 'none';document-domain 'none';encrypted-media 'none';fullscreen 'none';geolocation 'none';gyroscope 'none';layout-animations 'none';legacy-image-formats 'none';magnetometer 'none';microphone 'none';midi 'none';oversized-images 'none';payment 'none';picture-in-picture 'none';publickey-credentials 'none';sync-xhr 'none';unsized-media 'none';usb 'none';xr-spatial-tracking 'none';",
				"deny",
				"strict-origin-when-cross-origin",
				"max-age=31536000;includeSubdomains");

			applicationBuilder.Use(
				async (context, next) =>
				{
					context.Response.OnStarting(
						() =>
						{
							securityHeaderPolicy.WriteHeaders(context.Response.Headers, context.Request.IsHttps);

							return Task.CompletedTask;
						});

					await next.Invoke();
				});

			return applicationBuilder;
		}
	}
}
