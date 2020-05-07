namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>Configures the "x-frame-options" header value.</summary>
	public sealed class FrameOptionsBuilder
	{
		private const string DenyValue = "deny";
		private const string SameOriginValue = "sameorigin";

		private string frameOptions;

		internal FrameOptionsBuilder()
		{
			this.frameOptions = FrameOptionsBuilder.DenyValue;
		}

		/// <summary>Configures the "x-frame-options" header to have the value "deny". This is the default.</summary>
		public void Deny()
		{
			this.frameOptions = FrameOptionsBuilder.DenyValue;
		}

		/// <summary>Configures "the x-frame-options" header to have the value "sameorigin".</summary>
		public void SameOrigin()
		{
			this.frameOptions = FrameOptionsBuilder.SameOriginValue;
		}

		internal string Build()
		{
			return this.frameOptions;
		}
	}
}
