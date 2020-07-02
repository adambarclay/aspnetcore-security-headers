using System;
using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderMiddleware
{
	public static class UseSecurityHeaders_Throws_ArgumentNullException
	{
		[Fact]
		public static void When_Not_Using_Default_Configuration_And_The_ApplicationBuilder_Parameter_Is_Null()
		{
			Assert.ThrowsAny<ArgumentNullException>(() => SecurityHeaderMiddleware.UseSecurityHeaders(null!, o => { }));
		}

		[Fact]
		public static void When_The_SecurityHeaderPolicyBuilder_Parameter_Is_Null()
		{
			Assert.ThrowsAny<ArgumentNullException>(() => new ApplicationBuilder(null).UseSecurityHeaders(null!));
		}

		[Fact]
		public static void When_Using_Default_Configuration_And_The_ApplicationBuilder_Parameter_Is_Null()
		{
			Assert.ThrowsAny<ArgumentNullException>(() => SecurityHeaderMiddleware.UseSecurityHeaders(null!));
		}
	}
}
