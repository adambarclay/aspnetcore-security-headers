using System;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	internal static class SecurityHeaderPolicyDefaults
	{
		internal static ContentSecurityPolicyBuilder DefaultContentSecurityPolicy()
		{
			var contentSecurityPolicyBuilder = new ContentSecurityPolicyBuilder();

			contentSecurityPolicyBuilder.ConfigureDefault().Self();
			contentSecurityPolicyBuilder.ConfigureObject().None();
			contentSecurityPolicyBuilder.ConfigureDirective("frame-ancestors").None();

			return contentSecurityPolicyBuilder;
		}

		internal static ContentTypeOptionsBuilder DefaultContentTypeOptions()
		{
			return new ContentTypeOptionsBuilder();
		}

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
