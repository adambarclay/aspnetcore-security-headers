namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "content-security-policy" header value.</summary>
	public sealed class ContentSecurityPolicyBuilder
	{
		internal ContentSecurityPolicyBuilder()
		{
			this.Enabled = true;
		}

		internal bool Enabled { get; private set; }

		/// <summary>Disables the "content-security-policy" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}
	}
}
