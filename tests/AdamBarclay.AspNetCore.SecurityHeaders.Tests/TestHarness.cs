using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests
{
	internal static class TestHarness
	{
		internal static async Task<IHeaderDictionary> Test(Action<IApplicationBuilder> configure)
		{
			Func<Task> onStarting = () => Task.CompletedTask;

			var headers = new HeaderDictionary();

			var contextMock = new Mock<HttpContext>(MockBehavior.Strict);

			contextMock.Setup(o => o.Response.Headers).Returns(headers);

			contextMock.Setup(o => o.Response.OnStarting(It.IsAny<Func<object, Task>>(), It.IsAny<object>()))
				.Callback<Func<object, Task>, object>((callback, state) => onStarting = () => callback(state));

			var app = new ApplicationBuilder(null);

			configure.Invoke(app);

			app.Run(async context => await onStarting.Invoke());

			await app.Build().Invoke(contextMock.Object);

			return headers;
		}
	}
}
