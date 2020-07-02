namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "x-frame-options" header value.</summary>
	public sealed class FrameOptionsBuilder
	{
		private string frameOptions;

		internal FrameOptionsBuilder()
		{
			this.Enabled = true;

			this.frameOptions = string.Empty;
		}

		internal bool Enabled { get; private set; }

		/// <summary>Configures the "x-frame-options" header to have the value "deny". This is the default.</summary>
		public void Deny()
		{
			this.frameOptions = "deny";
		}

		/// <summary>Disables the "x-frame-options" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}

		/// <summary>Configures "the x-frame-options" header to have the value "sameorigin".</summary>
		public void SameOrigin()
		{
			this.frameOptions = "sameorigin";
		}

		internal string Build()
		{
			return this.frameOptions;
		}
	}
}
