using System.Threading.Tasks;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_SecurityHeaderPolicy
{
	public static class WriteHeaders_Writes_Feature_Policy_Header
	{
		[Fact]
		public static async Task With_Default_Value_When_Using_Default_Configuration()
		{
			var headers = await TestHarness.Test(app => app.UseSecurityHeaders());

			const string expectedvalue =
				"accelerometer 'none';ambient-light-sensor 'none';autoplay 'none';battery 'none';camera 'none';display-capture 'none';document-domain 'none';encrypted-media 'none';fullscreen 'none';geolocation 'none';gyroscope 'none';layout-animations 'none';legacy-image-formats 'none';magnetometer 'none';microphone 'none';midi 'none';oversized-images 'none';payment 'none';picture-in-picture 'none';publickey-credentials 'none';sync-xhr 'none';unsized-media 'none';usb 'none';xr-spatial-tracking 'none';";

			Assert.Equal(expectedvalue, headers["feature-policy"]);
		}
	}
}
