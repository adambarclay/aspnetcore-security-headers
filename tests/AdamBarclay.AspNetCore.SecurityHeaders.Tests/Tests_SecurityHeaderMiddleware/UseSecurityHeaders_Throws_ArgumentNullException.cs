using System;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderMiddleware
{
	public static class UseSecurityHeaders_Throws_ArgumentNullException
	{
		[Fact]
		public static void When_ApplicationBuilder_Is_Null()
		{
			Assert.ThrowsAny<ArgumentNullException>(() => SecurityHeaderMiddleware.UseSecurityHeaders(null!));
		}
	}
}
