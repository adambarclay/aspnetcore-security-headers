using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_ContentSecurityPolicyBuilder
{
	[ExcludeFromCodeCoverage]
	public static class A_ValueBuilder_With_The_Correct_Directive_Name_Is_Returned
	{
		[Fact]
		public static async Task By_ConfigureChild()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureChild().Self())));

			Assert.Equal(
				"child-src 'self';default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureConnect()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureConnect().Self())));

			Assert.Equal(
				"connect-src 'self';default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureDefault()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureDefault().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureFont()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureFont().Self())));

			Assert.Equal(
				"default-src 'self';font-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureFrame()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureFrame().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';frame-src 'self';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureImage()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureImage().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';img-src 'self';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureManifest()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureManifest().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';manifest-src 'self';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureMedia()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureMedia().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';media-src 'self';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureObject()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureObject().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigurePrefetch()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigurePrefetch().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';prefetch-src 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScript()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureScript().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';script-src 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScriptInAttributes()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => p.ConfigureScriptInAttributes().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';script-src-attr 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScriptInElements()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureScriptInElements().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';script-src-elem 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyle()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureStyle().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';style-src 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyleInAttributes()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => p.ConfigureStyleInAttributes().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';style-src-attr 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyleInElements()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureStyleInElements().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';style-src-elem 'self'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureWorker()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureWorker().Self())));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none';worker-src 'self'",
				headers["content-security-policy"]);
		}
	}
}
