using System;
using System.Globalization;
using System.Text;

namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "strict-transport-security" header value.</summary>
	public sealed class StrictTransportSecurityBuilder
	{
		private bool includeSubdomains;
		private int maxAge;
		private bool preload;

		internal StrictTransportSecurityBuilder()
		{
			this.Enabled = true;

			this.maxAge = 0;
			this.includeSubdomains = false;
			this.preload = false;
		}

		internal bool Enabled { get; private set; }

		/// <summary>Disables the "strict-transport-security" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}

		/// <summary>Configure the maximum amount of time the policy will apply.</summary>
		/// <param name="maxAgeTimeSpan">A <see cref="TimeSpan"/> representing the maximum amount of time the policy will apply.</param>
		/// <returns>The <see cref="StrictTransportSecurityOptionalBuilder"/>.</returns>
		public StrictTransportSecurityOptionalBuilder MaxAge(TimeSpan maxAgeTimeSpan)
		{
			this.maxAge = (int)maxAgeTimeSpan.TotalSeconds;

			return new StrictTransportSecurityOptionalBuilder(this);
		}

		internal string Build()
		{
			var stringBuilder = new StringBuilder(44);

			stringBuilder.Append("max-age=");
			stringBuilder.Append(this.maxAge.ToString(CultureInfo.InvariantCulture));

			if (this.includeSubdomains)
			{
				stringBuilder.Append(";includeSubdomains");
			}

			if (this.preload)
			{
				stringBuilder.Append(";preload");
			}

			return stringBuilder.ToString();
		}

		/// <summary>The builder for the optional "includeSubdomains" and "preload" parameters.</summary>
		public sealed class StrictTransportSecurityOptionalBuilder
		{
			private readonly StrictTransportSecurityBuilder strictTransportSecurityBuilder;

			internal StrictTransportSecurityOptionalBuilder(
				StrictTransportSecurityBuilder strictTransportSecurityBuilder)
			{
				this.strictTransportSecurityBuilder = strictTransportSecurityBuilder;
			}

			/// <summary>Include subdomains.</summary>
			/// <returns>The <see cref="StrictTransportSecurityOptionalPreloadBuilder"/>.</returns>
			public StrictTransportSecurityOptionalPreloadBuilder IncludeSubdomains()
			{
				this.strictTransportSecurityBuilder.includeSubdomains = true;

				return new StrictTransportSecurityOptionalPreloadBuilder(this.strictTransportSecurityBuilder);
			}

			/// <summary>Use the HSTS preload service. See https://hstspreload.org for details.</summary>
			public void Preload()
			{
				this.strictTransportSecurityBuilder.preload = true;
			}
		}

		/// <summary>The builder for the optional "preload" parameter.</summary>
		public sealed class StrictTransportSecurityOptionalPreloadBuilder
		{
			private readonly StrictTransportSecurityBuilder strictTransportSecurityBuilder;

			internal StrictTransportSecurityOptionalPreloadBuilder(
				StrictTransportSecurityBuilder strictTransportSecurityBuilder)
			{
				this.strictTransportSecurityBuilder = strictTransportSecurityBuilder;
			}

			/// <summary>Use the HSTS preload service. See https://hstspreload.org for details.</summary>
			public void Preload()
			{
				this.strictTransportSecurityBuilder.preload = true;
			}
		}
	}
}
