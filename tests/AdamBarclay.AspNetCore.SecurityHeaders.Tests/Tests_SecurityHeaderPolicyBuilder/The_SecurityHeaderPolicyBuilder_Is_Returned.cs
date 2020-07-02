using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	public static class The_SecurityHeaderPolicyBuilder_Is_Returned
	{
		[Fact]
		public static void By_ContentSecurityPolicy()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ContentSecurityPolicy(o => { }));
		}

		[Fact]
		public static void By_ContentTypeOptions()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ContentTypeOptions(o => { }));
		}

		[Fact]
		public static void By_FrameOptions()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.FrameOptions(o => { }));
		}

		[Fact]
		public static void By_ReferrerPolicy()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ReferrerPolicy(o => { }));
		}

		[Fact]
		public static void By_StrictTransportSecurity()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.StrictTransportSecurity(o => { }));
		}
	}
}
