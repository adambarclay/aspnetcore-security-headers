using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal sealed class SecurityHeaderPolicy
	{
		private readonly (string Name, string Value)[] policies;

		internal SecurityHeaderPolicy((string Name, string Value)[] policies)
		{
			Debug.Assert(policies != null);

			this.policies = policies;
		}

		internal void SetHeaders(IHeaderDictionary headers)
		{
			Debug.Assert(headers != null);

			foreach ((var name, var value) in this.policies)
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
