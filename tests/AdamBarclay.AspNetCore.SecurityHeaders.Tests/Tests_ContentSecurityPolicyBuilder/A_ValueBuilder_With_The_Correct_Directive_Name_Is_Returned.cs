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

			Assert.Equal("child-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureConnect()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureConnect().Self())));

			Assert.Equal("connect-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureDefault()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureDefault().Self())));

			Assert.Equal("default-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureFont()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureFont().Self())));

			Assert.Equal("font-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureFrame()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureFrame().Self())));

			Assert.Equal("frame-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureImage()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureImage().Self())));

			Assert.Equal("img-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureManifest()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureManifest().Self())));

			Assert.Equal("manifest-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureMedia()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureMedia().Self())));

			Assert.Equal("media-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureObject()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureObject().Self())));

			Assert.Equal("object-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigurePrefetch()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigurePrefetch().Self())));

			Assert.Equal("prefetch-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScript()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureScript().Self())));

			Assert.Equal("script-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScriptInAttributes()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => p.ConfigureScriptInAttributes().Self())));

			Assert.Equal("script-src-attr 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureScriptInElements()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureScriptInElements().Self())));

			Assert.Equal("script-src-elem 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyle()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureStyle().Self())));

			Assert.Equal("style-src 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyleInAttributes()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => p.ConfigureStyleInAttributes().Self())));

			Assert.Equal("style-src-attr 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureStyleInElements()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureStyleInElements().Self())));

			Assert.Equal("style-src-elem 'self'", headers["content-security-policy"]);
		}

		[Fact]
		public static async Task By_ConfigureWorker()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.ContentSecurityPolicy(p => p.ConfigureWorker().Self())));

			Assert.Equal("worker-src 'self'", headers["content-security-policy"]);
		}
	}
}
