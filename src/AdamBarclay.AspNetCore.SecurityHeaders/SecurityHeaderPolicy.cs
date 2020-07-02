using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal sealed class SecurityHeaderPolicy
	{
		private readonly (string Name, string Value)[] policies;
		private readonly (string Name, string Value)[] secureOnlyPolicies;

		internal SecurityHeaderPolicy(
			(string Name, string Value)[] policies,
			(string Name, string Value)[] secureOnlyPolicies)
		{
			Debug.Assert(policies != null);
			Debug.Assert(secureOnlyPolicies != null);

			this.policies = policies;
			this.secureOnlyPolicies = secureOnlyPolicies;
		}

		internal void WriteHeaders(IHeaderDictionary headers, bool requestIsHttps)
		{
			Debug.Assert(headers != null);

			SecurityHeaderPolicy.WriteHeaders(headers, this.policies);

			if (requestIsHttps)
			{
				SecurityHeaderPolicy.WriteHeaders(headers, this.secureOnlyPolicies);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteHeaders(IHeaderDictionary headers, (string Name, string Value)[] headerValues)
		{
			Debug.Assert(headers != null);
			Debug.Assert(headerValues != null);

			foreach ((var name, var value) in headerValues)
			{
				Debug.Assert(name != null);
				Debug.Assert(value != null);

				if (!headers.ContainsKey(name))
				{
					headers[name] = value;
				}
			}
		}
	}
}
