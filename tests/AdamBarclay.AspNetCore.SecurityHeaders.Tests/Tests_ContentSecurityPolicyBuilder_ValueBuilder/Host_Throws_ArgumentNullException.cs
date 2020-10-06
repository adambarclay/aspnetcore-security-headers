using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_ContentSecurityPolicyBuilder_ValueBuilder
{
	[ExcludeFromCodeCoverage]
	public static class Host_Throws_ArgumentNullException
	{
		[Fact]
		public static async Task When_The_Host_Parameter_Is_Null()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(
					app => app.UseSecurityHeaders(
						o => o.ContentSecurityPolicy(
							p => p.ConfigureDirective(Guid.NewGuid().ToString()).Host(null!)))));
		}
	}
}
