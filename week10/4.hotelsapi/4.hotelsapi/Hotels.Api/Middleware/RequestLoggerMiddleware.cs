using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Api.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class RequestLoggerMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            this.logger.LogInformation("Handling request: " + context.Request.Path);
            await this.next.Invoke(context);
            this.logger.LogInformation("Finished handling request.Time:{0}", DateTime.UtcNow - startTime);
        }
    }
}
