using System;
using System.Collections.Generic;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		private FrameOptionsBuilder frameOptionsBuilder;
		private ReferrerPolicyBuilder referrerPolicyBuilder;
		private StrictTransportSecurityBuilder strictTransportSecurityBuilder;

		internal SecurityHeaderPolicyBuilder()
		{
			this.frameOptionsBuilder = SecurityHeaderPolicyDefaults.DefaultFrameOptions();
			this.referrerPolicyBuilder = SecurityHeaderPolicyDefaults.DefaultReferrerPolicy();
			this.strictTransportSecurityBuilder = SecurityHeaderPolicyDefaults.DefaultStrictTransportSecurity();
		}

		/// <summary>Configures the "x-frame-options" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder FrameOptions(Action<FrameOptionsBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			this.frameOptionsBuilder = new FrameOptionsBuilder();

			configure.Invoke(this.frameOptionsBuilder);

			return this;
		}

		/// <summary>Configures the "referrer-policy" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder ReferrerPolicy(Action<ReferrerPolicyBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			this.referrerPolicyBuilder = new ReferrerPolicyBuilder();

			configure.Invoke(this.referrerPolicyBuilder);

			return this;
		}

		/// <summary>Configures the "strict-transport-security" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder StrictTransportSecurity(Action<StrictTransportSecurityBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			this.strictTransportSecurityBuilder = new StrictTransportSecurityBuilder();

			configure.Invoke(this.strictTransportSecurityBuilder);

			return this;
		}

		internal SecurityHeaderPolicy Build()
		{
			var policies = new List<(string, string)>
			{
				("content-security-policy", "default-src 'self';frame-ancestors 'none';object-src 'none'"),
				("x-content-type-options", "nosniff"),
				("x-frame-options", this.frameOptionsBuilder.Build()),
				("referrer-policy", this.referrerPolicyBuilder.Build())
			};

			var secureOnlyPolicies = new List<(string, string)>
			{
				("strict-transport-security", this.strictTransportSecurityBuilder.Build())
			};

			return new SecurityHeaderPolicy(policies.ToArray(), secureOnlyPolicies.ToArray());
		}
	}
}
