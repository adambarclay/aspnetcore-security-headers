using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	[ExcludeFromCodeCoverage]
	public static class The_SecurityHeaderPolicyBuilder_Is_Returned
	{
		[Fact]
		public static async Task By_ContentSecurityPolicy()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			await TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ContentSecurityPolicy(o => { }));
		}

		[Fact]
		public static async Task By_ContentTypeOptions()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			await TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ContentTypeOptions(o => { }));
		}

		[Fact]
		public static async Task By_FrameOptions()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			await TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.FrameOptions(o => { }));
		}

		[Fact]
		public static async Task By_ReferrerPolicy()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			await TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.ReferrerPolicy(o => { }));
		}

		[Fact]
		public static async Task By_StrictTransportSecurity()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			await TestHarness.Test(app => app.UseSecurityHeaders(o => builder = o));

			Assert.Same(builder, builder.StrictTransportSecurity(o => { }));
		}
	}
}
