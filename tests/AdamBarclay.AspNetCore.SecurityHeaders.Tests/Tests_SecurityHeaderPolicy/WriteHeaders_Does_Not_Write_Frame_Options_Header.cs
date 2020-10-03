using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Does_Not_Write_Frame_Options_Header
	{
		[Fact]
		public static async Task When_The_Header_Is_Disabled()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FrameOptions(x => x.Disable())));

			Assert.Empty(headers["x-frame-options"]);
		}
	}
}
