using nanoFramework.Hosting;

// ReSharper disable once CheckNamespace
namespace CCSWE.nanoFramework.Configuration
{
    /// <summary>
    /// Extension methods for <see cref="ConfigurationManager"/>.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Adds a <see cref="ConfigurationManager"/>.
        /// </summary>
        public static IHostBuilder UseConfigurationManager(this IHostBuilder builder, ConfigureConfigurationManagerOptions? configureOptions = null)
        {
            builder.ConfigureServices(services => services.AddConfigurationManager(configureOptions));

            return builder;
        }
    }
}
