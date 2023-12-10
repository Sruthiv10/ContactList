using RFL.TechStack.Application.CTO;
using RFL.TechStack.Application.DTO;
using RFL.TechStack.Core.Common;
//using RFL.TechStack.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Interface
{
    public interface IPurchaseorderEntryAppService
    {
        ExecuteResult<int> Save(IEnumerable<PurchaseOrderRequestCT> data);
       
    }
}
