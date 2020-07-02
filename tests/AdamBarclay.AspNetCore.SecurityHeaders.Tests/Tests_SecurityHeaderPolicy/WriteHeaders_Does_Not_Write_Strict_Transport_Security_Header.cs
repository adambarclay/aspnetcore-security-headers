using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Does_Not_Write_Strict_Transport_Security_Header
	{
		[Fact]
		public static async Task When_No_Option_Is_Configured_And_The_Request_Is_Not_Https()
		{
			var headers = await TestHarness.TestHttp(app => app.UseSecurityHeaders(o => { }));

			Assert.Empty(headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task When_The_Header_Is_Disabled()
		{
			var headers = await TestHarness.TestHttp(
				app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => x.Disable())));

			Assert.Empty(headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task When_Using_Default_Configuration_And_The_Request_Is_Not_Https()
		{
			var headers = await TestHarness.TestHttp(app => app.UseSecurityHeaders());

			Assert.Empty(headers["strict-transport-security"]);
		}
	}
}
