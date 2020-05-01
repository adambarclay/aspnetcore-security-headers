using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Frame_Options_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal("deny", headers["x-frame-options"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("deny", headers["x-frame-options"]);
		}

		[Fact]
		public static async Task With_Value_Deny_When_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FrameOptions(x => x.Deny())));

			Assert.Equal("deny", headers["x-frame-options"]);
		}

		[Fact]
		public static async Task With_Value_Same_Origin_When_Configured()
		{
			var headers =
				await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FrameOptions(x => x.SameOrigin())));

			Assert.Equal("sameorigin", headers["x-frame-options"]);
		}
	}
}
