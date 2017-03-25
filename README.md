# SapientGuardian.InMemoryJsonConfiguration

[![Build status](https://ci.appveyor.com/api/projects/status/5r9pl7lgq1josu02?svg=true)](https://ci.appveyor.com/project/SapientGuardian/sapientguardian-inmemoryjsonconfiguration)
[![NuGet Package](https://img.shields.io/nuget/vpre/SapientGuardian.InMemoryJsonConfiguration.svg)](https://www.nuget.org/packages/SapientGuardian.InMemoryJsonConfiguration/)

## Description
SapientGuardian.InMemoryJsonConfiguration SapientGuardian.InMemoryJsonConfiguration is a configuration provider based on Microsoft.Extensions.Configuration.Json that allows you to use in-memory Json as a configuration source.

## How to use it

```C#    
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
```
