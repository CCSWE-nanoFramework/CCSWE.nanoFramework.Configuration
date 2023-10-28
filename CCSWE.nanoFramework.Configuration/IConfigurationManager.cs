using System;

namespace CCSWE.nanoFramework.Configuration
{
    /// <summary>
    /// An interface used to manage configuration objects from an <see cref="IConfigurationStorage"/> source.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// An event that is fired when a configuration changes.
        /// </summary>
        event ConfigurationChangedEventHandler? ConfigurationChanged;

        /// <summary>
        /// Checks if a configuration has been register.
        /// </summary>
        /// <param name="name">The name of the configuration to check.</param>
        /// <returns>true if the configuration is registered; otherwise false.</returns>
        public bool Contains(string name);

        /// <summary>
        /// Retrieves the latest configuration object.
        /// </summary>
        /// <param name="name">The name of the configuration to retrieve.</param>
        /// <returns>The configuration object.</returns>
        public object GetConfiguration(string name);

        /// <summary>
        /// Retrieve a list of configurations that have been registered.
        /// </summary>
        /// <returns>A list of configurations that have been registered.</returns>
        public string[] GetNames();

        /// <summary>
        /// Retrieves the <see cref="Type"/> of the configuration object.
        /// </summary>
        /// <param name="name">The name of the configuration <see cref="Type"/> to retrieve.</param>
        /// <returns>The <see cref="Type"/> of the configuration object.</returns>
        public Type GetType(string name);

        /// <summary>
        /// Saves the configuration object to the registered <see cref="IConfigurationStorage"/>.
        /// </summary>
        /// <param name="name">The name of the configuration to save.</param>
        /// <param name="configuration">The configuration object.</param>
        public void SaveConfiguration(string name, object configuration);

        /// <summary>
        /// Asynchronously saves the configuration object to the registered <see cref="IConfigurationStorage"/>.
        /// </summary>
        /// <param name="name">The name of the configuration to save.</param>
        /// <param name="configuration">The configuration object.</param>
        public void SaveConfigurationAsync(string name, object configuration);
    }
}
