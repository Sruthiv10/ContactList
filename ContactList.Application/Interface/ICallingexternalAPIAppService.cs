using RFL.TechStack.Application.CTO;
using RFL.TechStack.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Interface
{
    public interface ICallingexternalAPIAppService
    {
       // public async Task NewAPICall()
        ExecuteResult<int> Save(IEnumerable<PurchaseOrderRequestCT> data);
    }
}
