using RFL.TechStack.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Interface
{
    public interface IRequestHandler
    {
        Task<ExecuteResult<string>> PostAsync(ExternalRequest requestData);
        Task<ExecuteResult<string>> GetAsync(ExternalRequest requestData);
    }
}
