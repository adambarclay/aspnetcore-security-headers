using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderMiddleware
{
	public static class UseSecurityHeaders_Calls_The_Next_Module_In_The_Pipeline
	{
		[Fact]
		public static async Task Always()
		{
			bool nextRan;

			Func<HttpContext, Func<Task>, Task> middleware = async (context, next) =>
			{
				nextRan = true;

				await next.Invoke();
			};

			nextRan = false;
			await TestHarness.Test(app => app.UseSecurityHeaders().Use(middleware));
			Assert.True(nextRan);

			nextRan = false;
			await TestHarness.Test(app => app.UseSecurityHeaders(o => { }).Use(middleware));
			Assert.True(nextRan);
		}
	}
}
