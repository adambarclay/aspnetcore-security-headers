namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>Configures the "referrer-policy" header value.</summary>
	public sealed class ReferrerPolicy
	{
		private const string NoReferrerValue = "no-referrer";
		private const string NoReferrerWhenDowngradeValue = "no-referrer-when-downgrade";
		private const string OriginValue = "origin";
		private const string OriginWhenCrossOriginValue = "origin-when-cross-origin";
		private const string SameOriginValue = "same-origin";
		private const string StrictOriginValue = "strict-origin";
		private const string StrictOriginWhenCrossOriginValue = "strict-origin-when-cross-origin";
		private const string UnsafeUrlValue = "unsafe-url";

		private readonly SecurityHeaderPolicyBuilder securityHeaderPolicyBuilder;
		private string referrerPolicy;

		internal ReferrerPolicy(SecurityHeaderPolicyBuilder securityHeaderPolicyBuilder)
		{
			this.securityHeaderPolicyBuilder = securityHeaderPolicyBuilder;
			this.referrerPolicy = ReferrerPolicy.StrictOriginWhenCrossOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder NoReferrer()
		{
			this.referrerPolicy = ReferrerPolicy.NoReferrerValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer-when-downgrade".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder NoReferrerWhenDowngrade()
		{
			this.referrerPolicy = ReferrerPolicy.NoReferrerWhenDowngradeValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder Origin()
		{
			this.referrerPolicy = ReferrerPolicy.OriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin-when-cross-origin".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder OriginWhenCrossOrigin()
		{
			this.referrerPolicy = ReferrerPolicy.OriginWhenCrossOriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "same-origin".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder SameOrigin()
		{
			this.referrerPolicy = ReferrerPolicy.SameOriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder StrictOrigin()
		{
			this.referrerPolicy = ReferrerPolicy.StrictOriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin-when-cross-origin". This is the default.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder StrictOriginWhenCrossOrigin()
		{
			this.referrerPolicy = ReferrerPolicy.StrictOriginWhenCrossOriginValue;

			return this.securityHeaderPolicyBuilder;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "unsafe-url".</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public SecurityHeaderPolicyBuilder UnsafeUrl()
		{
			this.referrerPolicy = ReferrerPolicy.UnsafeUrlValue;

			return this.securityHeaderPolicyBuilder;
		}

		internal string Build()
		{
			return this.referrerPolicy;
		}
	}
}
