using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_FrameOptions
{
	public static class Deny_Returns_SecurityHeaderPolicyBuilder
	{
		[Fact]
		public static void Always()
		{
			SecurityHeaderPolicyBuilder securityHeaderPolicyBuilder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => securityHeaderPolicyBuilder = o);

			Assert.Same(securityHeaderPolicyBuilder, securityHeaderPolicyBuilder.FrameOptions.Deny());
		}
	}
}
