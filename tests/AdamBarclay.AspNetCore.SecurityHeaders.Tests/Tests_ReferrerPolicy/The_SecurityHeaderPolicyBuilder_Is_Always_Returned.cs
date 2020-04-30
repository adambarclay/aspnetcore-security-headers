using Microsoft.AspNetCore.Builder;
using Xunit;

namespace AdamBarclay.AspNetCore.SecurityHeaders.Tests.Tests_ReferrerPolicy
{
	public static class The_SecurityHeaderPolicyBuilder_Is_Always_Returned
	{
		[Fact]
		public static void By_NoReferrer()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.NoReferrer());
		}

		[Fact]
		public static void By_NoReferrerWhenDowngrade()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.NoReferrerWhenDowngrade());
		}

		[Fact]
		public static void By_Origin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.Origin());
		}

		[Fact]
		public static void By_OriginWhenCrossOrigin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.OriginWhenCrossOrigin());
		}

		[Fact]
		public static void By_SameOrigin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.SameOrigin());
		}

		[Fact]
		public static void By_StrictOrigin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.StrictOrigin());
		}

		[Fact]
		public static void By_StrictOriginWhenCrossOrigin()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.StrictOriginWhenCrossOrigin());
		}

		[Fact]
		public static void By_UnsafeUrl()
		{
			SecurityHeaderPolicyBuilder builder = null!;

			new ApplicationBuilder(null).UseSecurityHeaders(o => builder = o);

			Assert.Same(builder, builder.ReferrerPolicy.UnsafeUrl());
		}
	}
}
