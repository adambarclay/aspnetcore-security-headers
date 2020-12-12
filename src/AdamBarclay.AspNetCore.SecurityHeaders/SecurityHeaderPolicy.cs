using Microsoft.AspNetCore.Http;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal sealed class SecurityHeaderPolicy
	{
		private readonly (string Name, string Value)[] policies;

		internal SecurityHeaderPolicy((string Name, string Value)[] policies)
		{
			this.policies = policies;
		}

		internal void SetHeaders(IHeaderDictionary headers)
		{
			foreach ((var name, var value) in this.policies)
			{
				if (!headers.ContainsKey(name))
				{
					headers[name] = value;
				}
			}
		}
	}
}
