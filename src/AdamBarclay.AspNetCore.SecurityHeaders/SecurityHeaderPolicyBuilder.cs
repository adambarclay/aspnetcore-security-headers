using System;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		private readonly FrameOptionsBuilder frameOptionsBuilder;
		private readonly ReferrerPolicyBuilder referrerPolicyBuilder;
		private readonly StrictTransportSecurityBuilder strictTransportSecurityBuilder;

		internal SecurityHeaderPolicyBuilder()
		{
			this.frameOptionsBuilder = new FrameOptionsBuilder();
			this.referrerPolicyBuilder = new ReferrerPolicyBuilder();
			this.strictTransportSecurityBuilder = new StrictTransportSecurityBuilder();
		}

		/// <summary>Configures the x-frame-options header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder FrameOptions(Action<FrameOptionsBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			configure.Invoke(this.frameOptionsBuilder);

			return this;
		}

		/// <summary>Configures the referrer-policy header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder ReferrerPolicy(Action<ReferrerPolicyBuilder> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			configure.Invoke(this.referrerPolicyBuilder);

			return this;
		}

		/// <summary>Configures the strict-transport-security header value.</summary>
		/// <param name="configure">The configuration action.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
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
				"accelerometer 'none';ambient-light-sensor 'none';autoplay 'none';battery 'none';camera 'none';display-capture 'none';document-domain 'none';encrypted-media 'none';fullscreen 'none';geolocation 'none';gyroscope 'none';layout-animations 'none';legacy-image-formats 'none';magnetometer 'none';microphone 'none';midi 'none';oversized-images 'none';payment 'none';picture-in-picture 'none';publickey-credentials 'none';sync-xhr 'none';unsized-media 'none';usb 'none';xr-spatial-tracking 'none';",
				this.frameOptionsBuilder.Build(),
				this.referrerPolicyBuilder.Build(),
				this.strictTransportSecurityBuilder.Build());
		}
	}
}
