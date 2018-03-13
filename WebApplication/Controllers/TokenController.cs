using System;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ILogger _logger;
        public TokenController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> LoginAsync([FromBody]LoginCredentials credentials)
        {
            var disco = await DiscoveryClient.GetAsync("http://IdentityServer:9090");
            if (disco.IsError)
            {
                _logger.LogError("Failed LoginAsync DiscoveryClient", disco);
                return string.Empty;
            }
            var tokenClient = new TokenClient(disco.TokenEndpoint, credentials.Username, credentials.Password);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("ProjectManagementAPI");
            if (tokenResponse.IsError)
            {
                _logger.LogError("Failed LoginAsync", tokenResponse.Error);
                return string.Empty;
            }
            return tokenResponse.AccessToken;
        }
    }
}
