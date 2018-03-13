using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ClientExtension : Client
    {
        public string APISecret { get; set; }
    }
}
