using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Does_Not_Write_Content_Type_Options_Header
	{
		[Fact]
		public static async Task When_The_Header_Is_Disabled()
		{
			var headers = await TestHarness.TestHttp(
				app => app.UseSecurityHeaders(o => o.ContentTypeOptions(x => x.Disable())));

			Assert.Empty(headers["x-content-type-options"]);
		}
	}
}
