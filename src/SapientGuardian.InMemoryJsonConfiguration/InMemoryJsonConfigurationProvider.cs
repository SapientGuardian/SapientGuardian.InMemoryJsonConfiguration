using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace SapientGuardian.InMemoryJsonConfiguration
{
    class InMemoryJsonConfigurationProvider : IConfigurationProvider
    {
        private readonly string json;
        private readonly JsonConfigurationProvider provider;
        public InMemoryJsonConfigurationProvider(string json)
        {
            this.json = json;
            provider = new JsonConfigurationProvider(new JsonConfigurationSource { Optional = true });            
        }
        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            return provider.GetChildKeys(earlierKeys, parentPath);
        }

        public IChangeToken GetReloadToken()
        {
            return provider.GetReloadToken();
        }

        public void Load()
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(this.json)))
            {
                provider.Load(stream);
            }
        }

        public void Set(string key, string value)
        {
            provider.Set(key, value);
        }

        public bool TryGet(string key, out string value)
        {
            return provider.TryGet(key, out value);
        }
    }
}
