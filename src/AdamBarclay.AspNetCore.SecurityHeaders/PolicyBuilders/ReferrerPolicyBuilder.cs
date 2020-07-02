namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "referrer-policy" header value.</summary>
	public sealed class ReferrerPolicyBuilder
	{
		private string referrerPolicy;

		internal ReferrerPolicyBuilder()
		{
			this.Enabled = true;

			this.referrerPolicy = string.Empty;
		}

		internal bool Enabled { get; private set; }

		/// <summary>Disables the "referrer-policy" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer".</summary>
		public void NoReferrer()
		{
			this.referrerPolicy = "no-referrer";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "no-referrer-when-downgrade".</summary>
		public void NoReferrerWhenDowngrade()
		{
			this.referrerPolicy = "no-referrer-when-downgrade";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin".</summary>
		public void Origin()
		{
			this.referrerPolicy = "origin";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "origin-when-cross-origin".</summary>
		public void OriginWhenCrossOrigin()
		{
			this.referrerPolicy = "origin-when-cross-origin";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "same-origin".</summary>
		public void SameOrigin()
		{
			this.referrerPolicy = "same-origin";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin".</summary>
		public void StrictOrigin()
		{
			this.referrerPolicy = "strict-origin";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "strict-origin-when-cross-origin". This is the default.</summary>
		public void StrictOriginWhenCrossOrigin()
		{
			this.referrerPolicy = "strict-origin-when-cross-origin";
		}

		/// <summary>Configures the "referrer-policy" header to have the value "unsafe-url".</summary>
		public void UnsafeUrl()
		{
			this.referrerPolicy = "unsafe-url";
		}

		internal string Build()
		{
			return this.referrerPolicy;
		}
	}
}
