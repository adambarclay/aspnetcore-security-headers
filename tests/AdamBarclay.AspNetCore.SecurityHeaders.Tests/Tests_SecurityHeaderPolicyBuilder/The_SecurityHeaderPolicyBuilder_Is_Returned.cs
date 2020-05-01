using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	public static class The_SecurityHeaderPolicyBuilder_Is_Returned
	{
		[Fact]
		public static void By_StrictTransportSecurity()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.StrictTransportSecurity(x => { }));
		}
	}
}
