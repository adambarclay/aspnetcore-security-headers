using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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
			return applicationBuilder.UseSecurityHeaders(o => { });
		}

		/// <summary>Adds the security headers to the ASP.NET Core pipeline.</summary>
		/// <param name="applicationBuilder">The ASP.NET Core <see cref="IApplicationBuilder"/>.</param>
		/// <param name="configure">Builds the security header policy configuration.</param>
		/// <returns>The same ASP.NET Core <see cref="IApplicationBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="applicationBuilder"/> or <paramref name="configure"/> is <see langword="null"/>.</exception>
		public static IApplicationBuilder UseSecurityHeaders(
			this IApplicationBuilder applicationBuilder,
			Action<SecurityHeaderPolicyBuilder> configure)
		{
			if (applicationBuilder == null)
			{
				throw new ArgumentNullException(nameof(applicationBuilder));
			}

			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			var securityHeaderPolicyBuilder = new SecurityHeaderPolicyBuilder();

			configure.Invoke(securityHeaderPolicyBuilder);

			var securityHeaderPolicy = securityHeaderPolicyBuilder.Build();

			Func<object, Task> onStartingCallback = state =>
			{
				var context = (HttpContext)state;

				securityHeaderPolicy.WriteHeaders(context.Response.Headers, context.Request.IsHttps);

				return Task.CompletedTask;
			};

			applicationBuilder.Use(
				async (context, next) =>
				{
					context.Response.OnStarting(onStartingCallback, context);

					await next.Invoke();
				});

			return applicationBuilder;
		}
	}
}
