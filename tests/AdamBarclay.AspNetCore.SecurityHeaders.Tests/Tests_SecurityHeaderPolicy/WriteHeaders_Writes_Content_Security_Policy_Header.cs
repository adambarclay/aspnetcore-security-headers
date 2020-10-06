using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	[ExcludeFromCodeCoverage]
	public static class WriteHeaders_Writes_Content_Security_Policy_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			Assert.Equal(
				"default-src 'self';frame-ancestors 'none';object-src 'none'",
				headers["content-security-policy"]);
		}

		[Fact]
		public static async Task With_Value_Correct_Values_Sorted_By_Directive_Name()
		{
			var host = Guid.NewGuid().ToString();
			var none = Guid.NewGuid().ToString();
			var self = Guid.NewGuid().ToString();
			var strictDynamic = Guid.NewGuid().ToString();
			var unsafeEval = Guid.NewGuid().ToString();
			var unsafeHashes = Guid.NewGuid().ToString();
			var unsafeInline = Guid.NewGuid().ToString();
			var uriScheme = Guid.NewGuid().ToString();

			var hostValue = Guid.NewGuid().ToString();
			var uriSchemeValue = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.ContentSecurityPolicy(
						p =>
						{
							p.ConfigureDirective(host).Host(hostValue);
							p.ConfigureDirective(none).None();
							p.ConfigureDirective(self).Self();
							p.ConfigureDirective(strictDynamic).StrictDynamic();
							p.ConfigureDirective(unsafeEval).UnsafeEval();
							p.ConfigureDirective(unsafeHashes).UnsafeHashes();
							p.ConfigureDirective(unsafeInline).UnsafeInline();
							p.ConfigureDirective(uriScheme).UriScheme(uriSchemeValue);
						})));

			var values = new SortedDictionary<string, string>
			{
				{ host, hostValue },
				{ none, "'none'" },
				{ self, "'self'" },
				{ strictDynamic, "'strict-dynamic'" },
				{ unsafeEval, "'unsafe-eval'" },
				{ unsafeHashes, "'unsafe-hashes'" },
				{ unsafeInline, "'unsafe-inline'" },
				{ uriScheme, uriSchemeValue }
			};

			Assert.Equal(
				string.Join(';', values.Select(o => o.Key + " " + o.Value)),
				headers["content-security-policy"]);
		}
	}
}
