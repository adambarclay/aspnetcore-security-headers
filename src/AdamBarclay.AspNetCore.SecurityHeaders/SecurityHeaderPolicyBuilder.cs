using System;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		private readonly StrictTransportSecurityBuilder strictTransportSecurityBuilder;

		internal SecurityHeaderPolicyBuilder()
		{
			this.FrameOptions = new FrameOptions(this);
			this.ReferrerPolicy = new ReferrerPolicy(this);
			this.strictTransportSecurityBuilder = new StrictTransportSecurityBuilder();
		}

		/// <summary>Gets the frame options configuration builder.</summary>
		public FrameOptions FrameOptions { get; }

		/// <summary>Gets the referrer policy configuration builder.</summary>
		public ReferrerPolicy ReferrerPolicy { get; }

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
				this.FrameOptions.Build(),
				this.ReferrerPolicy.Build(),
				this.strictTransportSecurityBuilder.Build());
		}
	}
}
