using System.Diagnostics;
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

		internal void WriteHeaders(IHeaderDictionary headers, bool isHttps)
		{
			Debug.Assert(headers != null);

			foreach ((var name, var value) in this.policies)
			{
				if (!headers.ContainsKey(name))
				{
					headers[name] = value;
				}
			}

			if (isHttps)
			{
				foreach ((var name, var value) in this.secureOnlyPolicies)
				{
					if (!headers.ContainsKey(name))
					{
						headers[name] = value;
					}
				}
			}
		}
	}
}
