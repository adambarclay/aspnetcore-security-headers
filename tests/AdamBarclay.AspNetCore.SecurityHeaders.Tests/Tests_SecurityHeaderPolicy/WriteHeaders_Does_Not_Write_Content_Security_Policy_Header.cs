using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Does_Not_Write_Content_Security_Policy_Header
	{
		[Fact]
		public static async Task When_The_Header_Is_Disabled()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(x => x.Disable())));

			Assert.Empty(headers["content-security-policy"]);
		}
	}
}
