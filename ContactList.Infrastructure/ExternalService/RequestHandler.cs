using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RFL.TechStack.Core.Common;
using RFL.TechStack.Core.Interface;
using RFL.TechStack.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.ExternalService
{
    public class RequestHandler : RequestBaseHandler,IRequestHandler
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<RequestHandler> logger;
        private readonly IConfiguration configuration;

        public RequestHandler(IHttpClientFactory httpClientFactory, ILogger<RequestHandler> logger, IConfiguration configuration)
             :base(httpClientFactory, logger, configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            this.configuration = configuration;
        }
    }
}
