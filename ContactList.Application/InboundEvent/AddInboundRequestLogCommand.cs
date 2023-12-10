//using MediatR;
////using RFL.TechStack.Core.Common;
////using RFL.TechStack.Core.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RFL.TechStack.Application.PurchaseOrderEvent
//{
//    public class AddPurchaseOrderRequestLogCommand : IRequest<PurchaseOrderRequestLog>
//    {
//        public AddPurchaseOrderRequestLogCommand(ExternalRequest request, string status, Enums.PurchaseOrderAPIEndpoint endPointType, string providerId, string response, string requestId)
//        {
//            Request = request;
//            RequestId = requestId;
//            Status = status;
//            EndPointType = endPointType;
//            ProviderId = providerId;
//            Response = response;
//        }

//        public ExternalRequest Request { get; set; }
//        public string Status { get; set; }
//        public Enums.PurchaseOrderAPIEndpoint EndPointType { get; set; }
//        public string ProviderId { get; set; } = "CEVA";
//        public string Response { get; set; }
//        public string RequestId { get; set; }
//    }
//}
