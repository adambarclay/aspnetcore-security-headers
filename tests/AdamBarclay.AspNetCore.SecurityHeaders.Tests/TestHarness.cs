using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests
{
	internal static class TestHarness
	{
		internal static Task<IHeaderDictionary> Test(Action<IApplicationBuilder> configure)
		{
			return TestHarness.InternalTest(configure, true);
		}

		internal static Task<IHeaderDictionary> TestHttp(Action<IApplicationBuilder> configure)
		{
			return TestHarness.InternalTest(configure, false);
		}

		private static async Task<IHeaderDictionary> InternalTest(Action<IApplicationBuilder> configure, bool useHttps)
		{
			Func<Task> onStarting = () => Task.CompletedTask;

			var headers = new HeaderDictionary();

			var contextMock = new Mock<HttpContext>(MockBehavior.Strict);

			contextMock.Setup(o => o.Request.IsHttps).Returns(useHttps);
			contextMock.Setup(o => o.Response.Headers).Returns(headers);
			contextMock.Setup(o => o.Response.OnStarting(It.IsAny<Func<Task>>()))
				.Callback<Func<Task>>(func => onStarting = func);

			var app = new ApplicationBuilder(null);

			configure.Invoke(app);

			app.Run(async context => await onStarting.Invoke());

			await app.Build().Invoke(contextMock.Object);

			return headers;
		}
	}
}
