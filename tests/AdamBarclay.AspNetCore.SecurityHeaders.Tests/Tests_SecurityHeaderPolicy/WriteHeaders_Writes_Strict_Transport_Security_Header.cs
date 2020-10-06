using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	[ExcludeFromCodeCoverage]
	public static class WriteHeaders_Writes_Strict_Transport_Security_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured_And_The_Request_Is_Https()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal("max-age=31536000;includeSubdomains", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration_And_The_Request_Is_Https()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal("max-age=31536000;includeSubdomains", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_IncludeSubdomains_And_Preload_When_Configured()
		{
			var maxAge = new Random().Next();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.StrictTransportSecurity(
						x => x.MaxAge(TimeSpan.FromSeconds(maxAge)).IncludeSubdomains().Preload())));

			Assert.Equal($"max-age={maxAge};includeSubdomains;preload", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_IncludeSubdomains_When_Configured()
		{
			var maxAge = new Random().Next();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.StrictTransportSecurity(x => x.MaxAge(TimeSpan.FromSeconds(maxAge)).IncludeSubdomains())));

			Assert.Equal($"max-age={maxAge};includeSubdomains", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_Max_Age_Set_To_The_Configured_Value()
		{
			var maxAge = new Random().Next();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.StrictTransportSecurity(x => x.MaxAge(TimeSpan.FromSeconds(maxAge)))));

			Assert.Equal($"max-age={maxAge}", headers["strict-transport-security"]);
		}

		[Fact]
		public static async Task With_Preload_And_Without_IncludeSubdomains_When_Configured()
		{
			var maxAge = new Random().Next();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.StrictTransportSecurity(x => x.MaxAge(TimeSpan.FromSeconds(maxAge)).Preload())));

			Assert.Equal($"max-age={maxAge};preload", headers["strict-transport-security"]);
		}
	}
}
