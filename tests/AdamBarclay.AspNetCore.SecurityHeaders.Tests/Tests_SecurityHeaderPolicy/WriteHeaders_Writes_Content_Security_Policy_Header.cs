using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Content_Security_Policy_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}
	}
}
