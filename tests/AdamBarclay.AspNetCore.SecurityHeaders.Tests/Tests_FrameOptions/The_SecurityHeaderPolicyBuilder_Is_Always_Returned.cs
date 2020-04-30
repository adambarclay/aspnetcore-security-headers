using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_FrameOptions
{
	public static class The_SecurityHeaderPolicyBuilder_Is_Always_Returned
	{
		[Fact]
		public static void By_Deny()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.FrameOptions.Deny());
		}

		[Fact]
		public static void By_SameOrigin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.FrameOptions.SameOrigin());
		}
	}
}
