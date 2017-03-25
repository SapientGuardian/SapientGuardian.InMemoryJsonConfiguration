using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SapientGuardian.InMemoryJsonConfiguration
{
    public class InMemoryJsonConfigurationSource : IConfigurationSource
    {
        public string JSON { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new InMemoryJsonConfigurationProvider(JSON);
    }
}
