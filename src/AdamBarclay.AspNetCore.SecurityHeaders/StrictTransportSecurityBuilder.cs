using System;
using System.Globalization;
using System.Text;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>Configures the "strict-transport-security" header value.</summary>
	public sealed class StrictTransportSecurityBuilder
	{
		private bool includeSubdomains;
		private int maxAge;
		private bool preload;

		internal StrictTransportSecurityBuilder()
		{
			this.maxAge = 31536000;
			this.includeSubdomains = true;
			this.preload = false;
		}

		/// <summary>Do not include subdomains.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public StrictTransportSecurityBuilder DontIncludeSubdomains()
		{
			this.includeSubdomains = false;

			return this;
		}

		/// <summary>Do not use the HSTS preload service. See https://hstspreload.org for details.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public StrictTransportSecurityBuilder DontPreload()
		{
			this.preload = false;

			return this;
		}

		/// <summary>Include subdomains.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public StrictTransportSecurityBuilder IncludeSubdomains()
		{
			this.includeSubdomains = true;

			return this;
		}

		/// <summary>Configure the maximum amount of time the policy will apply.</summary>
		/// <param name="maxAgeTimeSpan">A <see cref="TimeSpan"/> representing the maximum amount of time the policy will apply.</param>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public StrictTransportSecurityBuilder MaxAge(TimeSpan maxAgeTimeSpan)
		{
			this.maxAge = (int)maxAgeTimeSpan.TotalSeconds;

			return this;
		}

		/// <summary>Use the HSTS preload service. See https://hstspreload.org for details.</summary>
		/// <returns>The <see cref="SecurityHeaderPolicyBuilder"/>.</returns>
		public StrictTransportSecurityBuilder Preload()
		{
			this.preload = true;

			return this;
		}

		internal string Build()
		{
			var stringBuilder = new StringBuilder(44);

			stringBuilder.Append("max-age=");
			stringBuilder.Append(this.maxAge.ToString(CultureInfo.InvariantCulture));

			if (this.includeSubdomains)
			{
				stringBuilder.Append(";");
				stringBuilder.Append("includeSubdomains");
			}

			if (this.preload)
			{
				stringBuilder.Append(";");
				stringBuilder.Append("preload");
			}

			return stringBuilder.ToString();
		}
	}
}
