namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "referrer-policy" header value.</summary>
	public sealed class ReferrerPolicyBuilder
	{
		private const string NoReferrerValue = "no-referrer";
		private const string NoReferrerWhenDowngradeValue = "no-referrer-when-downgrade";
		private const string OriginValue = "origin";
		private const string OriginWhenCrossOriginValue = "origin-when-cross-origin";
		private const string SameOriginValue = "same-origin";
		private const string StrictOriginValue = "strict-origin";
		private const string StrictOriginWhenCrossOriginValue = "strict-origin-when-cross-origin";
		private const string UnsafeUrlValue = "unsafe-url";

		private string referrerPolicy;

		internal ReferrerPolicyBuilder()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.StrictOriginWhenCrossOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer".</summary>
		public void NoReferrer()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.NoReferrerValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer-when-downgrade".</summary>
		public void NoReferrerWhenDowngrade()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.NoReferrerWhenDowngradeValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin".</summary>
		public void Origin()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.OriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin-when-cross-origin".</summary>
		public void OriginWhenCrossOrigin()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.OriginWhenCrossOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "same-origin".</summary>
		public void SameOrigin()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.SameOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin".</summary>
		public void StrictOrigin()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.StrictOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin-when-cross-origin". This is the default.</summary>
		public void StrictOriginWhenCrossOrigin()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.StrictOriginWhenCrossOriginValue;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "unsafe-url".</summary>
		public void UnsafeUrl()
		{
			this.referrerPolicy = ReferrerPolicyBuilder.UnsafeUrlValue;
		}

		internal string Build()
		{
			return this.referrerPolicy;
		}
	}
}
