using System;
using System.Collections.Generic;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		private ContentSecurityPolicyBuilder contentSecurityPolicyBuilder;
		private ContentTypeOptionsBuilder contentTypeOptionsBuilder;
		private FrameOptionsBuilder frameOptionsBuilder;
		private ReferrerPolicyBuilder referrerPolicyBuilder;
		private StrictTransportSecurityBuilder strictTransportSecurityBuilder;

		internal SecurityHeaderPolicyBuilder()
		{
			this.contentSecurityPolicyBuilder = SecurityHeaderPolicyDefaults.DefaultContentSecurityPolicy();
			this.contentTypeOptionsBuilder = SecurityHeaderPolicyDefaults.DefaultContentTypeOptions();
			this.frameOptionsBuilder = SecurityHeaderPolicyDefaults.DefaultFrameOptions();
			this.referrerPolicyBuilder = SecurityHeaderPolicyDefaults.DefaultReferrerPolicy();
			this.strictTransportSecurityBuilder = SecurityHeaderPolicyDefaults.DefaultStrictTransportSecurity();
		}

		/// <summary>Configures the "content-security-policy" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder ContentSecurityPolicy(Action<ContentSecurityPolicyBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			this.contentSecurityPolicyBuilder = new ContentSecurityPolicyBuilder();

			configure.Invoke(this.contentSecurityPolicyBuilder);

			return this;
		}

		/// <summary>Configures the "x-content-type-options" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder ContentTypeOptions(Action<ContentTypeOptionsBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			this.contentTypeOptionsBuilder = new ContentTypeOptionsBuilder();

			configure.Invoke(this.contentTypeOptionsBuilder);

			return this;
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
			var policies = new List<(string, string)>();

			if (this.contentSecurityPolicyBuilder.Enabled)
			{
				policies.Add(
					("content-security-policy", "default-src 'self';frame-ancestors 'none';object-src 'none'"));
			}

			if (this.contentTypeOptionsBuilder.Enabled)
			{
				policies.Add(("x-content-type-options", "nosniff"));
			}

			if (this.frameOptionsBuilder.Enabled)
			{
				policies.Add(("x-frame-options", this.frameOptionsBuilder.Build()));
			}

			if (this.referrerPolicyBuilder.Enabled)
			{
				policies.Add(("referrer-policy", this.referrerPolicyBuilder.Build()));
			}

			if (this.strictTransportSecurityBuilder.Enabled)
			{
				policies.Add(("strict-transport-security", this.strictTransportSecurityBuilder.Build()));
			}

			return new SecurityHeaderPolicy(policies.ToArray());
		}
	}
}
