using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	[ExcludeFromCodeCoverage]
	public static class WriteHeaders_Writes_Content_Type_Options_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal("nosniff", headers["x-content-type-options"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("nosniff", headers["x-content-type-options"]);
		}
	}
}
