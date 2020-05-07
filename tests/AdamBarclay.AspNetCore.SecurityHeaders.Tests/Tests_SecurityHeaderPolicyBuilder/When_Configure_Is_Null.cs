using System;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	public static class When_Configure_Is_Null
	{
		[Fact]
		public static async Task FeaturePolicy_Throws_ArgumentNullException()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FeaturePolicy(null!))));
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
