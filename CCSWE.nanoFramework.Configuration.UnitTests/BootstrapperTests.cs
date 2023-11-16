using CCSWE.nanoFramework.Configuration.UnitTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using nanoFramework.TestFramework;

namespace CCSWE.nanoFramework.Configuration.UnitTests
{
    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        public void AddConfigurationManager_should_register_ConfigurationManager()
        {
            Assert.SkipTest("Can't test this yet because the test framework times out if a thread is still running but suspended");

            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(typeof(ILogger), typeof(LoggerMock));

            // Act
            serviceCollection.AddConfigurationManager();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var result1 = serviceProvider.GetService(typeof(IConfigurationManager));
            var result2 = serviceProvider.GetService(typeof(IConfigurationManager));

            // Assert
            Assert.IsNotNull(result1);
            Assert.IsInstanceOfType(result1, typeof(ConfigurationManager));
            Assert.AreEqual(result1, result2);

            var configurationManager = (ConfigurationManager)result1;
            configurationManager.Dispose();
        }

        [TestMethod]
        public void AddConfigurationManager_should_register_InternalConfigurationStorage()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(typeof(ILogger), typeof(LoggerMock));

            // Act
            serviceCollection.AddConfigurationManager(options => { options.UseInternalStorage = true;});

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var result1 = serviceProvider.GetService(typeof(IConfigurationStorage));
            var result2 = serviceProvider.GetService(typeof(IConfigurationStorage));

            // Assert
            Assert.IsNotNull(result1);
            Assert.IsInstanceOfType(result1, typeof(InternalConfigurationStorage));
            Assert.AreEqual(result1, result2);
        }

        // TODO: Add BindConfiguration Tests
    }
}
