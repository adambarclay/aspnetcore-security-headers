using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	[ExcludeFromCodeCoverage]
	public static class WriteHeaders_Does_Not_Write_Referrer_Policy_Header
	{
		[Fact]
		public static async Task When_The_Header_Is_Disabled()
		{
			var headers =
				await TestHarness.Test(app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.Disable())));

			Assert.Empty(headers["referrer-policy"]);
		}
	}
}
