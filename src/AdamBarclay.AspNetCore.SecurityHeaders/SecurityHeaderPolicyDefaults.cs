using System;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal static class SecurityHeaderPolicyDefaults
	{
		internal static FrameOptionsBuilder DefaultFrameOptions()
		{
			var frameOptionsBuilder = new FrameOptionsBuilder();

			frameOptionsBuilder.Deny();

			return frameOptionsBuilder;
		}

		internal static ReferrerPolicyBuilder DefaultReferrerPolicy()
		{
			var referrerPolicyBuilder = new ReferrerPolicyBuilder();

			referrerPolicyBuilder.StrictOriginWhenCrossOrigin();

			return referrerPolicyBuilder;
		}

		internal static StrictTransportSecurityBuilder DefaultStrictTransportSecurity()
		{
			var strictTransportSecurityBuilder = new StrictTransportSecurityBuilder();

			strictTransportSecurityBuilder.MaxAge(TimeSpan.FromDays(365)).IncludeSubdomains();

			return strictTransportSecurityBuilder;
		}
	}
}
