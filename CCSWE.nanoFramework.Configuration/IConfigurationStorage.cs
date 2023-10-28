using System;

namespace CCSWE.nanoFramework.Configuration
{
    /// <summary>
    /// An interface for reading and writing configuration objects from a storage location (filesystem, REST api, database, etc.)
    /// </summary>
    public interface IConfigurationStorage
    {
        /// <summary>
        /// Removes configuration from storage.
        /// </summary>
        /// <param name="name">The name of the configuration.</param>
        void DeleteConfiguration(string name);

        /// <summary>
        /// Read configuration from storage.
        /// </summary>
        /// <remarks>The configuration object is not validated at this point.</remarks>
        /// <param name="name">The name of the configuration.</param>
        /// <param name="type">The type of the configuration.</param>
        /// <returns>The configuration object.</returns>
        object? ReadConfiguration(string name, Type type);

        /// <summary>
        /// Write configuration to storage.
        /// </summary>
        /// <remarks>The <paramref name="configuration"/> should be validated prior to writing.</remarks>
        /// <param name="name">The name of the configuration.</param>
        /// <param name="configuration">The configuration object.</param>
        void WriteConfiguration(string name, object configuration);
    }
}
