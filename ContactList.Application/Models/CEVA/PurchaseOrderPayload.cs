using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Models.CEVA
{
    public class PurchaseOrderPayload
    {
        [JsonProperty("eventId", NullValueHandling = NullValueHandling.Ignore)]
        public string EventId { get; set; }

        [JsonProperty("eventTimeStamp", NullValueHandling = NullValueHandling.Ignore)]
        public string EventTimeStamp { get; set; }

        [JsonProperty("vendorId", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorId { get; set; }

        [JsonProperty("vendorPurchaseOrderNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorPurchaseOrderNumber { get; set; }

        [JsonProperty("purchaseOrderDate", NullValueHandling = NullValueHandling.Ignore)]
        public string PurchaseOrderDate { get; set; }

        [JsonProperty("shipmentID", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipmentID { get; set; }

        //[JsonProperty("additionalAttributes")]
        //public List<AdditionalData> AdditionalAttributes { get; set; }

        [JsonProperty("lines")]
        public List<ProductDetails> Lines { get; set; }

    }

    public class ProductDetails
    {
        //[JsonProperty("ingramPartNumber", NullValueHandling = NullValueHandling.Ignore)]
        //public string IngramPartNumber { get; set; } = "";

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("quantityUom", NullValueHandling = NullValueHandling.Ignore)]
        public string QuantityUom { get; set; }

        [JsonProperty("vendorPartNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorPartNumber { get; set; }

        [JsonProperty("vendorLineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorLineNumber { get; set; }

        [JsonProperty("receivingWarehouseId", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingWarehouseId { get; set; }

        [JsonProperty("receivingWarehouseLocation", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivingWarehouseLocation { get; set; }

        //[JsonProperty("additionalAttributes")]
        //public List<AdditionalData> AdditionalAttributes { get; set; }
    }
}
