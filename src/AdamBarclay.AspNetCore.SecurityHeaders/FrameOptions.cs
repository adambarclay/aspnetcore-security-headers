namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>Configures the x-frame-options header value.</summary>
	public sealed class FrameOptions
	{
		private const string DenyValue = "deny";
		private const string SameOriginValue = "sameorigin";

		private readonly SecurityHeaderPolicyBuilder securityHeaderPolicyBuilder;
		private string frameOptions;

		internal FrameOptions(SecurityHeaderPolicyBuilder securityHeaderPolicyBuilder)
		{
			this.securityHeaderPolicyBuilder = securityHeaderPolicyBuilder;
			this.frameOptions = FrameOptions.DenyValue;
		}

		/// <summary>Configures the x-frame-options header to have the value "deny". This is the default.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder Deny()
		{
			this.frameOptions = FrameOptions.DenyValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the x-frame-options header to have the value "deny".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder SameOrigin()
		{
			this.frameOptions = FrameOptions.SameOriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		internal string Build()
		{
			return this.frameOptions;
		}
	}
}
