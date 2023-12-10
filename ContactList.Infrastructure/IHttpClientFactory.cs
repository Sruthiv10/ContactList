using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure
{
    public interface IHttpClientFactoryCustom
    {
        /// <summary>
        /// Creates an instance of <see cref="HttpClient"/>
        /// </summary>
        /// <returns></returns>
        HttpClient Create();
    }
}
