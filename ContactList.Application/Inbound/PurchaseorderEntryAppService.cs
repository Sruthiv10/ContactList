using AutoMapper;
using Microsoft.Extensions.Logging;
using RFL.TechStack.Application.CTO;
using RFL.TechStack.Application.Interface;
using RFL.TechStack.Application.Models;
using RFL.TechStack.Core.Common;
using RFL.TechStack.Core.Entities;
using RFL.TechStack.Core.Interface;
using RFL.TechStack.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.PurchaseOrder
{
    public class PurchaseorderEntryAppService : IPurchaseorderEntryAppService
    {
        private readonly IPurchaseorderEntryService purchaseorderEntryService;
        //  private readonly IPurchaseOrderMessageSender inboundMessageService;
        private readonly IMapper mapper;
        private readonly ILogger<PurchaseorderEntryAppService> logger;

        public PurchaseorderEntryAppService(IMapper mapper, ILogger<PurchaseorderEntryAppService> logger, IPurchaseorderEntryService purchaseorderEntryService)
        {
            // this.inboundMessageService = inboundMessageService;
            this.mapper = mapper;
            this.logger = logger;
            this.purchaseorderEntryService = purchaseorderEntryService;
        }

      

        public ExecuteResult<int> Save(IEnumerable<PurchaseOrderRequestCT> data)
        {
            ExecuteResult<int> result = new ExecuteResult<int>();
            try
            {
                var purchaseOrderEntries = new List<PurchaseorderEntry>();

                foreach (var order in data)
                {
                    foreach (var orderEntry in order.PurchaseOrderEntries)
                    {
                        var purchaseEntity = new PurchaseorderEntry()
                        {
                            DeliveryNumber = order.DeliveryNumber,
                            EntryQuantity = orderEntry.Quantity,
                            EntryProduct = orderEntry.ProductCode,
                            EntryNumber = orderEntry.EntryNumber,
                            EntrySchLineNo = orderEntry.ScheduleLineNo,
                            EntryUom = orderEntry.UnitOfMeasure,
                            OrderDate = Helper.GetDatefromISO8601String(order.OrderDate),
                            OrderNumber = order.OrderNumber,
                            ProviderId = order.ProviderId,
                            VendorId = order.VendorId.ToString(),
                            //AdditionalData = (order.AdditionalData != null && order.AdditionalData.Any()) ? JsonConvert.SerializeObject(order.AdditionalData) : String.Empty,
                            // EntryAdditionalData = (orderEntry.AdditionalData != null && orderEntry.AdditionalData.Any()) ? JsonConvert.SerializeObject(orderEntry.AdditionalData) : String.Empty,
                            BlobId = order.BlobId,
                            ProcessId = order.ProcessId,
                            UserId = order.UserId,
                        };

                        purchaseOrderEntries.Add(purchaseEntity);
                    }
                }

                if (purchaseOrderEntries.Any())
                {
                    var response = purchaseorderEntryService.Save(purchaseOrderEntries);
                    if (response.Success && response.Results.Any())
                    {
                        result.Success = true;
                        result.Result += 1;
                        result.Messages = new List<ExecuteMessage>()
                        {
                            new ExecuteMessage() { Code = Enums.StatusCode.Success, Description = Constants.SuccessRequestProcessed },
                        };
                    }
                    else
                    {
                        result.Messages = new List<ExecuteMessage>()
                        {
                            new ExecuteMessage() { Code = Enums.StatusCode.NoRecordFound, Description = Constants.ErrorNoDataFound },
                        };
                    }
                }
                else
                {
                    result.Messages = new List<ExecuteMessage>()
                        {
                            new ExecuteMessage() { Code = Enums.StatusCode.NoRecordFound, Description = Constants.ErrorNoDataFound },
                        };
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, Constants.ErrorOccuredOnSave);
                throw;
            }

            return result;
        }
    }
}
