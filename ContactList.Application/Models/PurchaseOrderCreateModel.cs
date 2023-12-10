using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Models
{
    public class PurchaseOrderCreateModel
    {
        public long Uid { get; set; }
        public string VendorId { get; set; } = null!;
        public string ProviderId { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string DeliveryNumber { get; set; } = null!;
        public string? AdditionalData { get; set; }
        public int EntryNumber { get; set; }
        public int EntryQuantity { get; set; }
        public string EntryUom { get; set; } = null!;
        public string EntryProduct { get; set; } = null!;
        public string? EntrySchLineNo { get; set; }
        public string? EntryAdditionalData { get; set; }
        public string? ProcessId { get; set; }
        public string? BlobId { get; set; }
        public string? UserId { get; set; }
    }
}
