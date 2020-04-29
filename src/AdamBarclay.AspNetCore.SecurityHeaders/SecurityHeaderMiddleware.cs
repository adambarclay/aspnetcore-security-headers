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
			return applicationBuilder.UseSecurityHeaders(o => { });
		}

		/// <summary>Adds the security headers to the ASP.NET Core pipeline.</summary>
		/// <param name="applicationBuilder">The ASP.NET Core <see cref="IApplicationBuilder"/>.</param>
		/// <param name="securityHeaderPolicyBuilder">Builds the security header policy configuration.</param>
		/// <returns>The same ASP.NET Core <see cref="IApplicationBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="applicationBuilder"/> or <paramref name="securityHeaderPolicyBuilder"/> is <see langword="null"/>.</exception>
		public static IApplicationBuilder UseSecurityHeaders(
			this IApplicationBuilder applicationBuilder,
			Action<SecurityHeaderPolicyBuilder> securityHeaderPolicyBuilder)
		{
			if (applicationBuilder == null)
			{
				throw new ArgumentNullException(nameof(applicationBuilder));
			}

			if (securityHeaderPolicyBuilder == null)
			{
				throw new ArgumentNullException(nameof(securityHeaderPolicyBuilder));
			}

			var policyBuilder = new SecurityHeaderPolicyBuilder();

			securityHeaderPolicyBuilder.Invoke(policyBuilder);

			var securityHeaderPolicy = policyBuilder.Build();

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
