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
        /// Checks if a configuration has been registered.
        /// </summary>
        /// <param section="section">The section of the configuration to check.</param>
        /// <returns>true if the configuration is registered; otherwise false.</returns>
        public bool Contains(string section);

        /// <summary>
        /// Retrieves the latest configuration object.
        /// </summary>
        /// <param section="section">The section of the configuration to retrieve.</param>
        /// <returns>The configuration object.</returns>
        public object GetConfiguration(string section);

        /// <summary>
        /// Retrieve a list of configurations that have been registered.
        /// </summary>
        /// <returns>A list of configurations that have been registered.</returns>
        public string[] GetSections();

        /// <summary>
        /// Retrieves the <see cref="Type"/> of the configuration object.
        /// </summary>
        /// <param section="section">The section of the configuration <see cref="Type"/> to retrieve.</param>
        /// <returns>The <see cref="Type"/> of the configuration object.</returns>
        public Type GetType(string section);

        /// <summary>
        /// Saves the configuration object to the registered <see cref="IConfigurationStorage"/>.
        /// </summary>
        /// <param section="section">The section of the configuration to save.</param>
        /// <param section="configuration">The configuration object.</param>
        public void SaveConfiguration(string section, object configuration);

        /// <summary>
        /// Asynchronously saves the configuration object to the registered <see cref="IConfigurationStorage"/>.
        /// </summary>
        /// <param section="section">The section of the configuration to save.</param>
        /// <param section="configuration">The configuration object.</param>
        public void SaveConfigurationAsync(string section, object configuration);
    }
}
