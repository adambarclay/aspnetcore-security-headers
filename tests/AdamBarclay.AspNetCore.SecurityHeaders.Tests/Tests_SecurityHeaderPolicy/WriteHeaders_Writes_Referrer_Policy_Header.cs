using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	[ExcludeFromCodeCoverage]
	public static class WriteHeaders_Writes_Referrer_Policy_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal("strict-origin-when-cross-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("strict-origin-when-cross-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_No_Referrer_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.NoReferrer())));

			Assert.Equal("no-referrer", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_No_Referrer_When_Downgrade_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.NoReferrerWhenDowngrade())));

			Assert.Equal("no-referrer-when-downgrade", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Origin_When_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.Origin())));

			Assert.Equal("origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Origin_When_Cross_Origin_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.OriginWhenCrossOrigin())));

			Assert.Equal("origin-when-cross-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Same_Origin_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.SameOrigin())));

			Assert.Equal("same-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Strict_Origin_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.StrictOrigin())));

			Assert.Equal("strict-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Strict_Origin_When_Cross_Origin_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.StrictOriginWhenCrossOrigin())));

			Assert.Equal("strict-origin-when-cross-origin", headers["referrer-policy"]);
		}

		[Fact]
		public static async Task With_Value_Unsafe_Url_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ReferrerPolicy(x => x.UnsafeUrl())));

			Assert.Equal("unsafe-url", headers["referrer-policy"]);
		}
	}
}
