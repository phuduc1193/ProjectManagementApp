using System;
using System.Threading.Tasks;
using BusinessModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        public TokenController(ILogger<TokenController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        public string Login([FromBody]string username, [FromBody]string password)
        {
            var identityClient = Task.Run(async() => await DiscoveryClient.GetAsync(_config.GetSection("ApplicationEndpoint").GetValue<string>("IdentityServer"))).Result;
            if (identityClient.IsError)
            {
                _logger.LogError("Error DiscoveryClient.GetAsync", identityClient);
                return string.Empty;
            }
            var tokenClient = new TokenClient(identityClient.TokenEndpoint, "ResourceOwner", "ctkLz8gr");
            var tokenResponse = Task.Run(async () => await tokenClient.RequestResourceOwnerPasswordAsync(username, password, "ProjectManagementAPI")).Result;
            if (tokenResponse.IsError)
            {
                _logger.LogError("Failed LoginAsync", tokenResponse.Error);
                return string.Empty;
            }
            return tokenResponse.AccessToken;
        }
    }
}
