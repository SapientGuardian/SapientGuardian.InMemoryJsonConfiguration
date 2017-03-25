using SapientGuardian.InMemoryJsonConfiguration;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class InMemoryJsonConfigurationExtensions
    {
        /// <summary>
        /// Adds the JSON configuration provider at <paramref name="path"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="json">The json string to parse and add 
        /// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJson(this IConfigurationBuilder builder, string json)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            if (json == string.Empty)
            {
                throw new FormatException(nameof(json));
            }

            return builder.Add(new InMemoryJsonConfigurationSource { JSON = json });
        }
    }
}
