using Microsoft.Extensions.Configuration;
using SapientGuardian.InMemoryJsonConfiguration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InMemoryJsonConfigurationTests
{
    public class JsonConfigurationSourceTest
    {
        // Taken from https://github.com/aspnet/Configuration/blob/dev/test/Microsoft.Extensions.Configuration.Json.Test/JsonConfigurationTest.cs
        [Fact]
        public void LoadKeyValuePairsFromValidJson()
        {
            var json = @"
{
    'firstname': 'test',
    'test.last.name': 'last.name',
        'residential.address': {
            'street.name': 'Something street',
            'zipcode': '12345'
        }
}";
            var configurationBuilder = new ConfigurationBuilder();
            var config = configurationBuilder.AddJson(json)
                .Build();


            Assert.Equal("test", config["firstname"]);
            Assert.Equal("last.name", config["test.last.name"]);
            Assert.Equal("Something street", config["residential.address:STREET.name"]);
            Assert.Equal("12345", config["residential.address:zipcode"]);
        }

        [Fact]
        public void LoadKeyValuePairsFromValidJsonWithOverrides()
        {
            var json1 = @"
{
    'firstname': 'test',
    'test.last.name': 'last.name',
        'residential.address': {
            'street.name': 'Something street',
            'zipcode': '12345'
        }
}";

            var json2 = @"
{
    'firstname': 'test2'
}";
            var configurationBuilder = new ConfigurationBuilder();
            var config = configurationBuilder.AddJson(json1)
                .AddJson(json2)
                .Build();


            Assert.Equal("test2", config["firstname"]);
            Assert.Equal("last.name", config["test.last.name"]);
            Assert.Equal("Something street", config["residential.address:STREET.name"]);
            Assert.Equal("12345", config["residential.address:zipcode"]);
        }
    }
}
