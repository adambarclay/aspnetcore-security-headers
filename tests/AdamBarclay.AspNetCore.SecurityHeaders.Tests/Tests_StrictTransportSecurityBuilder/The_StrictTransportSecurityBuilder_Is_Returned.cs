using System;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_StrictTransportSecurityBuilder
{
	public static class The_StrictTransportSecurityBuilder_Is_Returned
	{
		[Fact]
		public static void By_DontIncludeSubdomains()
		{
			StrictTransportSecurityBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => builder = x)));

			Assert.Same(builder, builder.DontIncludeSubdomains());
		}

		[Fact]
		public static void By_DontPreload()
		{
			StrictTransportSecurityBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => builder = x)));

			Assert.Same(builder, builder.DontPreload());
		}

		[Fact]
		public static void By_IncludeSubdomains()
		{
			StrictTransportSecurityBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => builder = x)));

			Assert.Same(builder, builder.IncludeSubdomains());
		}

		[Fact]
		public static void By_MaxAge()
		{
			StrictTransportSecurityBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => builder = x)));

			Assert.Same(builder, builder.MaxAge(TimeSpan.FromSeconds(31536000)));
		}

		[Fact]
		public static void By_Preload()
		{
			StrictTransportSecurityBuilder builder = null!;

			TestHarness.Test(app => app.UseSecurityHeaders(o => o.StrictTransportSecurity(x => builder = x)));

			Assert.Same(builder, builder.Preload());
		}
	}
}
