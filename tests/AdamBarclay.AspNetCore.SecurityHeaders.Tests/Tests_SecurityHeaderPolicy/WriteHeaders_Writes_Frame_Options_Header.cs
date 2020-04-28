using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Frame_Options_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("deny", headers["x-frame-options"]);
		}
	}
}
