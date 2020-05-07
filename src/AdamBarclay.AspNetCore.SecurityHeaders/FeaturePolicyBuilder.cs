using System;
using System.Collections.Generic;
using System.Text;

namespace AdamBarclay.AspNetCore.SecurityHeaders
{
	/// <summary>Configures the "feature-policy" header value.</summary>
	public sealed class FeaturePolicyBuilder
	{
		private static readonly Comparer<string> StringComparer =
			Comparer<string>.Create((a, b) => string.Compare(a, b, StringComparison.Ordinal));

		private readonly SortedList<string, FeaturePolicyValueBuilder> features =
			new SortedList<string, FeaturePolicyValueBuilder>(FeaturePolicyBuilder.StringComparer);

		internal FeaturePolicyBuilder()
		{
			// This is the list from https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Feature-Policy#Directives to
			// allow implementing a default of "none" for all feature directives. If the feature-policy header ever gets a
			// "default" directive similar to the content-security-policy header, this list will be removed.
			this.features.Add("accelerometer", new FeaturePolicyValueBuilder());
			this.features.Add("ambient-light-sensor", new FeaturePolicyValueBuilder());
			this.features.Add("autoplay", new FeaturePolicyValueBuilder());
			this.features.Add("battery", new FeaturePolicyValueBuilder());
			this.features.Add("camera", new FeaturePolicyValueBuilder());
			this.features.Add("display-capture", new FeaturePolicyValueBuilder());
			this.features.Add("document-domain", new FeaturePolicyValueBuilder());
			this.features.Add("encrypted-media", new FeaturePolicyValueBuilder());
			this.features.Add("execution-while-not-rendered", new FeaturePolicyValueBuilder());
			this.features.Add("execution-while-out-of-viewport", new FeaturePolicyValueBuilder());
			this.features.Add("fullscreen", new FeaturePolicyValueBuilder());
			this.features.Add("geolocation", new FeaturePolicyValueBuilder());
			this.features.Add("gyroscope", new FeaturePolicyValueBuilder());
			this.features.Add("layout-animations", new FeaturePolicyValueBuilder());
			this.features.Add("legacy-image-formats", new FeaturePolicyValueBuilder());
			this.features.Add("magnetometer", new FeaturePolicyValueBuilder());
			this.features.Add("microphone", new FeaturePolicyValueBuilder());
			this.features.Add("midi", new FeaturePolicyValueBuilder());
			this.features.Add("navigation-override", new FeaturePolicyValueBuilder());
			this.features.Add("oversized-images", new FeaturePolicyValueBuilder());
			this.features.Add("payment", new FeaturePolicyValueBuilder());
			this.features.Add("picture-in-picture", new FeaturePolicyValueBuilder());
			this.features.Add("publickey-credentials-get", new FeaturePolicyValueBuilder());
			this.features.Add("sync-xhr", new FeaturePolicyValueBuilder());
			this.features.Add("usb", new FeaturePolicyValueBuilder());
			this.features.Add("vr", new FeaturePolicyValueBuilder());
			this.features.Add("wake-lock", new FeaturePolicyValueBuilder());
			this.features.Add("xr-spatial-tracking", new FeaturePolicyValueBuilder());

			this.Default = new FeaturePolicyValueBuilder(this.features);
		}

		/// <summary>Gets the default policy for all feature directives.</summary>
		public FeaturePolicyValueBuilder Default { get; }

		/// <summary>Adds a feature directive to the feature policy.</summary>
		/// <param name="name">The name of the feature to add.</param>
		/// <returns>The <see cref="FeaturePolicyValueBuilder"/>.</returns>
		public FeaturePolicyValueBuilder Feature(string name)
		{
			if (this.features.ContainsKey(name))
			{
				return this.features[name];
			}

			var builder = new FeaturePolicyValueBuilder();

			this.features.Add(name, builder);

			return builder;
		}

		internal string Build()
		{
			var stringBuilder = new StringBuilder(256);

			foreach ((var featureName, var featureBuilder) in this.features)
			{
				featureBuilder.Build(stringBuilder, featureName);
			}

			return stringBuilder.ToString();
		}

		/// <summary>Configures the policy value for a feature which has one or more origins.</summary>
		public sealed class FeaturePolicyOriginValueBuilder
		{
			private readonly SortedList<string, FeaturePolicyValueBuilder>? features;
			private readonly SortedSet<string> origins;

			internal FeaturePolicyOriginValueBuilder(
				SortedSet<string> origins,
				SortedList<string, FeaturePolicyValueBuilder>? features)
			{
				this.origins = origins;
				this.features = features;
			}

			/// <summary>Adds an origin to the feature policy value.</summary>
			/// <param name="origin">The origin to add.</param>
			/// <returns>The <see cref="FeaturePolicyOriginValueBuilder"/>.</returns>
			public FeaturePolicyOriginValueBuilder AddOrigin(string origin)
			{
				if (this.features != null)
				{
					foreach (var feature in this.features.Values)
					{
						feature.AddOrigin(origin);
					}
				}

				if (!this.origins.Contains(origin))
				{
					this.origins.Add(origin);
				}

				return this;
			}
		}

		/// <summary>Configures the policy value for a feature.</summary>
		public sealed class FeaturePolicyValueBuilder
		{
			private const string AllValue = "*";
			private const string NoneValue = "'none'";
			private const string SelfValue = "'self'";

			private readonly SortedList<string, FeaturePolicyValueBuilder>? features;
			private readonly SortedSet<string> origins = new SortedSet<string>(FeaturePolicyBuilder.StringComparer);

			private FeatureOption option;

			internal FeaturePolicyValueBuilder()
			{
				this.option = FeatureOption.None;
			}

			internal FeaturePolicyValueBuilder(SortedList<string, FeaturePolicyValueBuilder> features)
			{
				this.features = features;
			}

			private enum FeatureOption
			{
				None,
				All,
				Origins
			}

			/// <summary>Adds an origin to the feature policy value.</summary>
			/// <param name="origin">The origin to add.</param>
			/// <returns>The <see cref="FeaturePolicyOriginValueBuilder"/>.</returns>
			public FeaturePolicyOriginValueBuilder AddOrigin(string origin)
			{
				this.option = FeatureOption.Origins;

				return new FeaturePolicyOriginValueBuilder(this.origins, this.features).AddOrigin(origin);
			}

			/// <summary>Sets the feature policy value to "*".</summary>
			public void All()
			{
				if (this.features != null)
				{
					foreach (var feature in this.features.Values)
					{
						feature.All();
					}
				}

				this.option = FeatureOption.All;
			}

			/// <summary>Sets the feature policy value to "'none'". This is the default.</summary>
			public void None()
			{
				if (this.features != null)
				{
					foreach (var feature in this.features.Values)
					{
						feature.None();
					}
				}

				this.option = FeatureOption.None;
			}

			/// <summary>Adds an origin of "'self'" to the feature policy value.</summary>
			/// <returns>The <see cref="FeaturePolicyOriginValueBuilder"/>.</returns>
			public FeaturePolicyOriginValueBuilder Self()
			{
				this.option = FeatureOption.Origins;

				return new FeaturePolicyOriginValueBuilder(this.origins, this.features).AddOrigin(
					FeaturePolicyValueBuilder.SelfValue);
			}

			internal void Build(StringBuilder stringBuilder, string name)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(";");
				}

				stringBuilder.Append(name);
				stringBuilder.Append(" ");

				switch (this.option)
				{
					case FeatureOption.None:
					{
						stringBuilder.Append(FeaturePolicyValueBuilder.NoneValue);

						break;
					}

					case FeatureOption.All:
					{
						stringBuilder.Append(FeaturePolicyValueBuilder.AllValue);

						break;
					}

					case FeatureOption.Origins:
					{
						stringBuilder.AppendJoin(" ", this.origins);

						break;
					}
				}
			}
		}
	}
}
