using System;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicyBuilder
{
	public static class StrictTransportSecurity_Throws_ArgumentNullException
	{
		[Fact]
		public static async Task When_Configure_Is_Null()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(
					app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(null!))));
		}
	}
}
