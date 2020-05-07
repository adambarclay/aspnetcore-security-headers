using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Feature_Policy_Header
	{
		private static readonly string[] Features =
		{
			"accelerometer",
			"ambient-light-sensor",
			"autoplay",
			"battery",
			"camera",
			"display-capture",
			"document-domain",
			"encrypted-media",
			"execution-while-not-rendered",
			"execution-while-out-of-viewport",
			"fullscreen",
			"geolocation",
			"gyroscope",
			"layout-animations",
			"legacy-image-formats",
			"magnetometer",
			"microphone",
			"midi",
			"navigation-override",
			"oversized-images",
			"payment",
			"picture-in-picture",
			"publickey-credentials-get",
			"sync-xhr",
			"usb",
			"vr",
			"wake-lock",
			"xr-spatial-tracking"
		};

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_All_Of_Its_Origins_If_Configured_More_Than_Once()
		{
			var origin = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.FeaturePolicy(
						x =>
						{
							x.Feature("aaa").AddOrigin(origin);
							x.Feature("aaa").Self();
						})));

			var expectedvalue = "aaa 'self' " + origin + ";" +
				WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_All_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Feature("aaa").All())));

			var expectedvalue = "aaa *;" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_Its_Latest_Value_If_Configured_More_Than_Once()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.FeaturePolicy(
						x =>
						{
							x.Feature("aaa").AddOrigin(Guid.NewGuid().ToString());
							x.Feature("aaa").All();
						})));

			var expectedvalue = "aaa *;" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_Multiple_Origins_When_Configured()
		{
			var origin1 = Guid.NewGuid().ToString();
			var origin2 = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.FeaturePolicy(x => x.Feature("aaa").AddOrigin(origin1).AddOrigin(origin2))));

			var expectedvalue = (string.CompareOrdinal(origin1, origin2) < 0
					? "aaa " + origin1 + " " + origin2 + ";"
					: "aaa " + origin2 + " " + origin1 + ";") +
				WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_None_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Feature("aaa").None())));

			var expectedvalue = "aaa 'none';" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_None_When_Not_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Feature("aaa"))));

			var expectedvalue = "aaa 'none';" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_Origin_When_Configured()
		{
			var origin = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Feature("aaa").AddOrigin(origin))));

			var expectedvalue = "aaa " + origin + ";" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_A_Custom_Feature_Set_To_Self_When_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Feature("aaa").Self())));

			var expectedvalue = "aaa 'self';" + WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_All_Features_Set_To_All_When_Default_Is_Configured()
		{
			var headers =
				await TestHarness.Test(app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Default.All())));

			var expectedvalue = WriteHeaders_Writes_Feature_Policy_Header.SetDefault("*");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_All_Features_Set_To_Multiple_Origins_When_Default_Is_Configured()
		{
			var origin1 = Guid.NewGuid().ToString();
			var origin2 = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(
					o => o.FeaturePolicy(x => x.Default.AddOrigin(origin1).AddOrigin(origin2))));

			var expectedvalue = string.CompareOrdinal(origin1, origin2) < 0
				? WriteHeaders_Writes_Feature_Policy_Header.SetDefault(origin1 + " " + origin2)
				: WriteHeaders_Writes_Feature_Policy_Header.SetDefault(origin2 + " " + origin1);

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_All_Features_Set_To_None_When_Default_Is_Configured()
		{
			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Default.None())));

			var expectedvalue = WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_All_Features_Set_To_Origin_When_Default_Is_Configured()
		{
			var origin = Guid.NewGuid().ToString();

			var headers = await TestHarness.Test(
				app => app.UseSecurityHeaders(o => o.FeaturePolicy(x => x.Default.AddOrigin(origin))));

			var expectedvalue = WriteHeaders_Writes_Feature_Policy_Header.SetDefault(origin);

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_No_Option_Is_Configured()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders(o => { }));

			var expectedvalue = WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			var expectedvalue = WriteHeaders_Writes_Feature_Policy_Header.SetDefault("'none'");

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}

		private static string SetDefault(string value)
		{
			return string.Join(";", WriteHeaders_Writes_Feature_Policy_Header.Features.Select(o => o + " " + value));
		}
	}
}
