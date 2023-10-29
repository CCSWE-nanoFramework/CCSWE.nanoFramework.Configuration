using System;
using System.IO;
using System.Text;
using CCSWE.nanoFramework.Configuration.Internal;
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

            // TODO: Abstract this into a separate FileStorage library
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            //using var reader = new StreamReader(stream);
            
            return JsonConvert.DeserializeObject(stream, type);
        }

        /// <inheritdoc />
        public void WriteConfiguration(string section, object configuration)
        {
            var path = GetPath(section);

            // TODO: Look into adding a JsonConvert method for serialization directly to a stream
            var serializedConfiguration = JsonConvert.SerializeObject(configuration);

            // TODO: Abstract this into a separate FileStorage library
            var buffer = Encoding.UTF8.GetBytes(serializedConfiguration);

            // TODO: Write in chunks?
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
        }
    }
}
