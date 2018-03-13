using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ClientExtension
    {
        public string ClientId { get; set; }
        public ICollection<string> AllowedGrantTypes { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
        public string APISecret { get; set; }
    }
}
