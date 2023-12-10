using RFL.TechStack.Core.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.CTO
{
    public class PurchaseOrderRequestCT
    {
        [JsonProperty("providerId")]
        public string ProviderId { get; set; }

        [JsonProperty("processId")]
        public string ProcessId { get; set; }

        [JsonProperty("blobId")]
        public string BlobId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; } = null!;

        [JsonProperty("requestId")]
        public string RequestId { get; set; } //Y

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; } //Y

        [JsonProperty("vendorId")]
        public int VendorId { get; set; } //Y

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; } //Y

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; } //Y

        [JsonProperty("deliveryNumber")]
        public string DeliveryNumber { get; set; } //Y

        //[JsonProperty("additionalData")]
        //public List<AdditionalDataCT> AdditionalData { get; set; } //Y

        [JsonProperty("entries")]
        public List<PurchaseOrderEntriesCT> PurchaseOrderEntries { get; set; } //Y
    }

    public class PurchaseOrderEntriesCT
    {
        [JsonProperty("entryNumber")]
        public int EntryNumber { get; set; } //Y

        [JsonProperty("quantity")]
        public int Quantity { get; set; } //Y

        [JsonProperty("unitOfMeasure")]
        public string UnitOfMeasure { get; set; } //Y

        [JsonProperty("productCode")]
        public string ProductCode { get; set; } //Y

        [JsonProperty("scheduleLineNo")]
        public string ScheduleLineNo { get; set; } //Y

       // [JsonProperty("additionalData")] //Y
       // public List<AdditionalDataCT> AdditionalData { get; set; }
    }
}
