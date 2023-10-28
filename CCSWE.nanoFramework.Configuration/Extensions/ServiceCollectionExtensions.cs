using System;
using CCSWE.nanoFramework.Configuration.Internal;
using nanoFramework.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace CCSWE.nanoFramework.Configuration
{
    /// <summary>
    /// Extension methods for <see cref="ConfigurationManager"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a <see cref="ConfigurationManager"/>.
        /// </summary>
        public static IServiceCollection AddConfigurationManager(this IServiceCollection services, ConfigureConfigurationManagerOptions? configureOptions = null)
        {
            var options = new ConfigurationManagerOptions();

            configureOptions?.Invoke(options);

            services.AddSingleton(typeof(ConfigurationManagerOptions), options);
            services.AddSingleton(typeof(IConfigurationManager), typeof(ConfigurationManager));

            if (options.UseInternalStorage)
            {
                services.AddSingleton(typeof(IConfigurationStorage), typeof(InternalConfigurationStorage));
            }

            return services;
        }

        /// <summary>
        /// Registers a configuration object.
        /// </summary>
        public static IServiceCollection BindConfiguration(this IServiceCollection services, string name, object defaults, IValidateConfiguration? validator = null)
        {
            return services.BindConfiguration(name, defaults.GetType(), defaults, validator);
        }

        /// <summary>
        /// Registers a configuration object.
        /// </summary>
        public static IServiceCollection BindConfiguration(this IServiceCollection services, string name, Type type, object defaults, IValidateConfiguration? validator = null)
        {
            return services.BindConfiguration(new ConfigurationDescriptor(name, type, defaults, validator));
        }

        internal static IServiceCollection BindConfiguration(this IServiceCollection services, ConfigurationDescriptor descriptor)
        {
            services.AddSingleton(typeof(ConfigurationDescriptor), descriptor);

            return services;
        }
    }
}
