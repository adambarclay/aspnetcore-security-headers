using System;
using System.Collections.Generic;
using System.Text;

namespace AdamBarclay.AspNetCore.SecurityHeaders.PolicyBuilders
{
	/// <summary>Configures the "content-security-policy" header value.</summary>
	public sealed class ContentSecurityPolicyBuilder
	{
		private readonly SortedList<string, ValueBuilder> directives;
		private readonly Comparer<string> stringComparer;

		internal ContentSecurityPolicyBuilder()
		{
			this.Enabled = true;

			this.stringComparer = Comparer<string>.Create((a, b) => string.Compare(a, b, StringComparison.Ordinal));
			this.directives = new SortedList<string, ValueBuilder>(this.stringComparer);
		}

		internal bool Enabled { get; private set; }

		/// <summary>Configures a content security policy directive.</summary>
		/// <param name="name">The name of the fetch directive e.g. "default-src".</param>
		/// <returns>The <see cref="ValueBuilder"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public ValueBuilder ConfigureDirective(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			var builder = new ValueBuilder(this.stringComparer);

			this.directives[name] = builder;

			return builder;
		}

		/// <summary>Disables the "content-security-policy" header.</summary>
		public void Disable()
		{
			this.Enabled = false;
		}

		internal string Build()
		{
			var stringBuilder = new StringBuilder(256);

			foreach ((var policyName, var policyBuilder) in this.directives)
			{
				policyBuilder.Build(stringBuilder, policyName);
			}

			return stringBuilder.ToString();
		}

		/// <summary>Builds the source list value for a content security policy directive.</summary>
		public sealed class ValueBuilder
		{
			private readonly SortedSet<string> values;

			internal ValueBuilder(Comparer<string> stringComparer)
			{
				this.values = new SortedSet<string>(stringComparer);
			}

			/// <summary>Adds a host URL to the policy value.</summary>
			/// <param name="host">The host URL.</param>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			/// <exception cref="ArgumentNullException"><paramref name="host"/> is <see langword="null"/>.</exception>
			public ValueBuilder Host(string host)
			{
				if (host == null)
				{
					throw new ArgumentNullException(nameof(host));
				}

				this.values.Add(host);

				return this;
			}

			/// <summary>Adds "'none'" to the policy value.</summary>
			public void None()
			{
				this.values.Add("'none'");
			}

			/// <summary>Adds "'self'" to the policy value.</summary>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			public ValueBuilder Self()
			{
				this.values.Add("'self'");

				return this;
			}

			/// <summary>Adds "'strict-dynamic'" to the policy value.</summary>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			public ValueBuilder StrictDynamic()
			{
				this.values.Add("'strict-dynamic'");

				return this;
			}

			/// <summary>Adds "'unsafe-eval'" to the policy value.</summary>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			public ValueBuilder UnsafeEval()
			{
				this.values.Add("'unsafe-eval'");

				return this;
			}

			/// <summary>Adds "'unsafe-hashes'" to the policy value.</summary>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			public ValueBuilder UnsafeHashes()
			{
				this.values.Add("'unsafe-hashes'");

				return this;
			}

			/// <summary>Adds "'unsafe-inline'" to the policy value.</summary>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			public ValueBuilder UnsafeInline()
			{
				this.values.Add("'unsafe-inline'");

				return this;
			}

			/// <summary>Adds a URI scheme to the policy value.</summary>
			/// <param name="scheme">The URI scheme e.g. "https:".</param>
			/// <returns>The <see cref="ValueBuilder"/>.</returns>
			/// <exception cref="ArgumentNullException"><paramref name="scheme"/> is <see langword="null"/>.</exception>
			public ValueBuilder UriScheme(string scheme)
			{
				if (scheme == null)
				{
					throw new ArgumentNullException(nameof(scheme));
				}

				this.values.Add(scheme);

				return this;
			}

			internal void Build(StringBuilder stringBuilder, string name)
			{
				if (this.values.Count > 0)
				{
					if (stringBuilder.Length != 0)
					{
						stringBuilder.Append(';');
					}

					stringBuilder.Append(name);
					stringBuilder.Append(' ');
					stringBuilder.AppendJoin(' ', this.values);
				}
			}
		}
	}
}
