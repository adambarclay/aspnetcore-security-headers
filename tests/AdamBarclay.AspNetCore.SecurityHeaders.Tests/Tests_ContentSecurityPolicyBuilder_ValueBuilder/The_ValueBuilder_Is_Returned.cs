using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_ContentSecurityPolicyBuilder_ValueBuilder
{
	[ExcludeFromCodeCoverage]
	public static class The_ValueBuilder_Is_Returned
	{
		[Fact]
		public static async Task By_Host()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.Host(Guid.NewGuid().ToString()));
		}

		[Fact]
		public static async Task By_Self()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.Self());
		}

		[Fact]
		public static async Task By_StrictDynamic()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.StrictDynamic());
		}

		[Fact]
		public static async Task By_UnsafeEval()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.UnsafeEval());
		}

		[Fact]
		public static async Task By_UnsafeHashes()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.UnsafeHashes());
		}

		[Fact]
		public static async Task By_UnsafeInline()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.UnsafeInline());
		}

		[Fact]
		public static async Task By_UriScheme()
		{
			ContentSecurityPolicyBuilder.ValueBuilder valueBuilder = null!;

			await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(p => valueBuilder = p.ConfigureDirective(Guid.NewGuid().ToString()))));

			Assert.Same(valueBuilder, valueBuilder.UriScheme(Guid.NewGuid().ToString()));
		}
	}
}
