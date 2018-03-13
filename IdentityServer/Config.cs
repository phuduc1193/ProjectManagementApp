using IdentityServer4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var listResources = LoadApiResources();
            return listResources.Select(x => new ApiResource(x.Name, x.DisplayName));
        }

        public static IEnumerable<Client> GetClients()
        {
            var listClients = LoadClients();
            return listClients.Select(x => new Client
            {
                ClientId = x.ClientId,
                AllowedGrantTypes = x.AllowedGrantTypes,
                ClientSecrets = { new Secret(x.APISecret.Sha256()) },
                AllowedScopes = x.AllowedScopes
            });
        }

        private static List<ApiResource> LoadApiResources()
        {
            var path = Directory.GetCurrentDirectory() + @"\Settings\apiResources.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<ApiResource>>(json);
                return result;
            }
        }

        private static List<ClientExtension> LoadClients()
        {
            var path = Directory.GetCurrentDirectory() + @"\Settings\clients.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<ClientExtension>>(json);
                return result;
            }
        }
    }
}
