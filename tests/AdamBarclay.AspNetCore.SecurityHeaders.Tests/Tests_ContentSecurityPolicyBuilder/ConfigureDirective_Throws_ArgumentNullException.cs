using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_ContentSecurityPolicyBuilder
{
	[ExcludeFromCodeCoverage]
	public static class ConfigureDirective_Throws_ArgumentNullException
	{
		[Fact]
		public static async Task When_The_Name_Parameter_Is_Null()
		{
			await Assert.ThrowsAnyAsync<ArgumentNullException>(
				async () => await TestHarness.Test(
					app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureDirective(null!)))));
		}
	}
}
