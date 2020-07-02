using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderMiddleware
{
	public static class UseSecurityHeaders_Returns_An_ApplicationBuilder
	{
		[Fact]
		public static void Identical_To_The_One_Passed_To_It()
		{
			var app = new ApplicationBuilder(null);

			Assert.Same(app, app.UseSecurityHeaders());
			Assert.Same(app, app.UseSecurityHeaders(o => { }));
		}
	}
}
