using RFL.TechStack.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Common
{
    public delegate IStorageService StorageServiceResolver(Enums.BlobStorageType serviceType);
    public delegate IRequestHandler RequestHandlereResolver(Enums.APIRequestHandlerType serviceType);
}
