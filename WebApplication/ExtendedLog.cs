using Microsoft.AspNetCore.Http;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;

namespace WebApplication
{
    public class ExtendedLog : Log
    {
        public ExtendedLog(IHttpContextAccessor accessor)
        {
            string browser = accessor.HttpContext.Request.Headers["User-Agent"];
            if (!string.IsNullOrEmpty(browser) && (browser.Length > 255))
            {
                browser = browser.Substring(0, 255);
            }

            this.Browser = browser;
            this.Host = accessor.HttpContext.Connection?.RemoteIpAddress?.ToString();
            this.User = accessor.HttpContext.User?.Identity?.Name;
            this.Path = accessor.HttpContext.Request.Path;
        }

        protected ExtendedLog()
        {
        }

        public string Browser { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string User { get; set; }
    }
}
