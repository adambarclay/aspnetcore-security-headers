using System;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		private readonly FeaturePolicyBuilder featurePolicyBuilder;
		private readonly FrameOptionsBuilder frameOptionsBuilder;
		private readonly ReferrerPolicyBuilder referrerPolicyBuilder;
		private readonly StrictTransportSecurityBuilder strictTransportSecurityBuilder;

		internal SecurityHeaderPolicyBuilder()
		{
			this.featurePolicyBuilder = new FeaturePolicyBuilder();
			this.frameOptionsBuilder = new FrameOptionsBuilder();
			this.referrerPolicyBuilder = new ReferrerPolicyBuilder();
			this.strictTransportSecurityBuilder = new StrictTransportSecurityBuilder();
		}

		/// <summary>Configures the "feature-policy" header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configure"/> is <see langword="null"/>.</exception>
		public SecurityHeaderPolicyBuilder FeaturePolicy(Action<FeaturePolicyBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			configure.Invoke(this.featurePolicyBuilder);

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

			configure.Invoke(this.strictTransportSecurityBuilder);

			return this;
		}

		internal SecurityHeaderPolicy Build()
		{
			return new SecurityHeaderPolicy(
				"default-src 'self'",
				this.featurePolicyBuilder.Build(),
				this.frameOptionsBuilder.Build(),
				this.referrerPolicyBuilder.Build(),
				this.strictTransportSecurityBuilder.Build());
		}
	}
}
