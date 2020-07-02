using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderMiddleware
{
	public static class UseSecurityHeaders_Calls_The_Next_Module_In_The_Pipeline
	{
		[Fact]
		public static async Task When_Not_Using_Default_Configuration()
		{
			var nextRan = false;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(o => { })
					.Use(
						async (context, next) =>
						{
							nextRan = true;

							await next.Invoke();
						}));

			Assert.True(nextRan);
		}

		[Fact]
		public static async Task When_Using_Default_Configuration()
		{
			var nextRan = false;

			await TestHarness.Test(
				app => app.UseSecurityHeaders()
					.Use(
						async (context, next) =>
						{
							nextRan = true;

							await next.Invoke();
						}));

			Assert.True(nextRan);
		}
	}
}
