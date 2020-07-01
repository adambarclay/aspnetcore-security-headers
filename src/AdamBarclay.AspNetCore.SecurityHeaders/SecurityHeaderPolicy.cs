using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal sealed class SecurityHeaderPolicy
	{
		private readonly string contentSecurityPolicy;
		private readonly string frameOptions;
		private readonly string referrerPolicy;
		private readonly string strictTransportSecurity;

		internal SecurityHeaderPolicy(
			string contentSecurityPolicy,
			string frameOptions,
			string referrerPolicy,
			string strictTransportSecurity)
		{
			Debug.Assert(contentSecurityPolicy != null);
			Debug.Assert(contentSecurityPolicy.Length > 0);
			Debug.Assert(frameOptions != null);
			Debug.Assert(frameOptions.Length > 0);
			Debug.Assert(referrerPolicy != null);
			Debug.Assert(referrerPolicy.Length > 0);
			Debug.Assert(strictTransportSecurity != null);
			Debug.Assert(strictTransportSecurity.Length > 0);

			this.contentSecurityPolicy = contentSecurityPolicy;
			this.frameOptions = frameOptions;
			this.referrerPolicy = referrerPolicy;
			this.strictTransportSecurity = strictTransportSecurity;
		}

		internal void WriteHeaders(IHeaderDictionary headers, bool isHttps)
		{
			Debug.Assert(headers != null);

			SecurityHeaderPolicy.SetHeader(headers, "content-security-policy", this.contentSecurityPolicy);
			SecurityHeaderPolicy.SetHeader(headers, "x-content-type-options", "nosniff");
			SecurityHeaderPolicy.SetHeader(headers, "x-frame-options", this.frameOptions);
			SecurityHeaderPolicy.SetHeader(headers, "referrer-policy", this.referrerPolicy);

			if (isHttps)
			{
				SecurityHeaderPolicy.SetHeader(headers, "strict-transport-security", this.strictTransportSecurity);
			}
		}

		private static void SetHeader(IHeaderDictionary headers, string name, string value)
		{
			Debug.Assert(headers != null);
			Debug.Assert(name != null);
			Debug.Assert(name.Length > 0);
			Debug.Assert(value != null);
			Debug.Assert(value.Length > 0);

			if (!headers.ContainsKey(name))
			{
				headers[name] = value;
			}
		}
	}
}
