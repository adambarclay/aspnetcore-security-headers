using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	[ExcludeFromCodeCoverage]
	public static class When_The_Configure_Parameter_Is_Null
	{
		[Fact]
		public static async Task ContentSecurityPolicy_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(null!))));
		}

		[Fact]
		public static async Task ContentTypeOptions_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(app => app.UseSecurityHeaders(o => o.ContentTypeOptions(null!))));
		}

		[Fact]
		public static async Task FrameOptions_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FrameOptions(null!))));
		}

		[Fact]
		public static async Task ReferrerPolicy_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(app => app.UseSecurityHeaders(o => o.ReferrerPolicy(null!))));
		}

		[Fact]
		public static async Task StrictTransportSecurity_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(
					app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(null!))));
		}
	}
}
