namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>The security header policy builder.</summary>
	public sealed class SecurityHeaderPolicyBuilder
	{
		internal SecurityHeaderPolicyBuilder()
		{
			this.FrameOptions = new FrameOptions(this);
		}

		/// <summary>Gets the frame options configuration builder.</summary>
		public FrameOptions FrameOptions { get; }

		internal SecurityHeaderPolicy Build()
		{
			return new SecurityHeaderPolicy(
				"default-src 'self'",
				"accelerometer 'none';ambient-light-sensor 'none';autoplay 'none';battery 'none';camera 'none';display-capture 'none';document-domain 'none';encrypted-media 'none';fullscreen 'none';geolocation 'none';gyroscope 'none';layout-animations 'none';legacy-image-formats 'none';magnetometer 'none';microphone 'none';midi 'none';oversized-images 'none';payment 'none';picture-in-picture 'none';publickey-credentials 'none';sync-xhr 'none';unsized-media 'none';usb 'none';xr-spatial-tracking 'none';",
				this.FrameOptions.Build(),
				"strict-origin-when-cross-origin",
				"max-age=31536000;includeSubdomains");
		}
	}
}
