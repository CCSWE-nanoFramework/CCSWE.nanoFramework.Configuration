﻿using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Configuration
{
    /// <summary>
    /// Options used to configure <see cref="ConfigurationManager"/>.
    /// </summary>
    public class ConfigurationManagerOptions
    {
        /// <summary>
        /// The default <see cref="LogLevel"/> used for debug log messages.
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        /// <summary>
        /// If set to <value>true</value> an <see cref="IConfigurationStorage"/> that uses internal storage will be registered.
        /// </summary>
        public bool UseInternalStorage { get; set; } = true;
    }

    /// <summary>
    /// An action for configuring the <see cref="ConfigurationManager"/>.
    /// </summary>
    public delegate void ConfigureConfigurationManagerOptions(ConfigurationManagerOptions options);
}
