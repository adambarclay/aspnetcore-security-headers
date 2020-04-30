using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Strict_Transport_Security_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured_And_The_Request_Is_Https()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal("max-age=31536000;includeSubdomains", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration_And_The_Request_Is_Https()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("max-age=31536000;includeSubdomains", headers["strict-transport-security"]);
		}
	}
}
