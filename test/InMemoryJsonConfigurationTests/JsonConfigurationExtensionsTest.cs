// Adapted from https://github.com/aspnet/Configuration/blob/dev/test/Microsoft.Extensions.Configuration.Json.Test/JsonConfigurationExtensionsTest.cs
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace InMemoryJsonConfigurationTests
{
    public class JsonConfigurationExtensionsTest
    {
        [Fact]
        public void AddJsonFile_ThrowsIfJsonIsNull()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();

            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => InMemoryJsonConfigurationExtensions.AddJson(configurationBuilder, null));
    
        }

        [Fact]
        public void AddJsonFile_ThrowsIfJsonIsEmpty()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();

            // Act and Assert
            var ex = Assert.Throws<FormatException>(() => InMemoryJsonConfigurationExtensions.AddJson(configurationBuilder, string.Empty));

        }
    }
}
