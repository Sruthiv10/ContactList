using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure
{
    /// <summary>
    /// Default implementation of <see cref="IHttpClientFactoryCustom"/>
    /// </summary>
    public class HttpClientFactory : IHttpClientFactoryCustom
    {
        internal static HttpClientFactory Instance = new HttpClientFactory();

        HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public HttpClientFactory()
        {
            this.client = new HttpClient();
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpClient"/>
        /// </summary>
        /// <returns></returns>
        public HttpClient Create()
        {
            return this.client;
        }
    }
}
