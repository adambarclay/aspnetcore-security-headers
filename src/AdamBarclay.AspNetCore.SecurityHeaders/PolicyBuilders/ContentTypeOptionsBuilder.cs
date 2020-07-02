namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "x-content-type-options" header value.</summary>
	public sealed class ContentTypeOptionsBuilder
	{
		internal ContentTypeOptionsBuilder()
		{
			this.Enabled = true;
		}

		internal bool Enabled { get; private set; }

		/// <summary>Disables the "x-content-type-options" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}
	}
}
