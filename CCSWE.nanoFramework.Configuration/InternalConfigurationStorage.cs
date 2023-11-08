using System;
using System.IO;
using System.Text;
using CCSWE.nanoFramework.Configuration.Internal;
using CCSWE.nanoFramework.FileStorage;
using nanoFramework.Json;

namespace CCSWE.nanoFramework.Configuration
{
    // TODO: Add Trace logging?
    internal class InternalConfigurationStorage: IConfigurationStorage
    {
        private const string Root = "I:";
        
        private static string GetPath(string section) => Path.Combine(Root, $"ccswe-{ConfigurationDescriptor.NormalizeSection(section)}.config");

        /// <inheritdoc />
        public void DeleteConfiguration(string section)
        {
            var path = GetPath(section);

            if (!File.Exists(path))
            {
                return;
            }

            File.Delete(path);
        }

        /// <inheritdoc />
        public object? ReadConfiguration(string section, Type type)
        {
            var path = GetPath(section);

            if (!File.Exists(path))
            {
                return null;
            }

            using var stream = FileInternal.OpenRead(path);
            
            return JsonConvert.DeserializeObject(stream, type);
        }

        /// <inheritdoc />
        public void WriteConfiguration(string section, object configuration)
        {
            var path = GetPath(section);

            // TODO: Look into adding a JsonConvert method for serialization directly to a stream
            var serializedConfiguration = JsonConvert.SerializeObject(configuration);

            FileInternal.WriteAllText(path, serializedConfiguration);
        }
    }
}
