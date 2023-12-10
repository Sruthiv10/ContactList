using RFL.TechStack.Core.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Application.Models
{
    public class PurchaseOrderMessageModel
    {
        private Guid? _messageId;
        [JsonProperty("uid")]
        public Guid messageId  // property
        {
            get { return _messageId ?? Guid.NewGuid(); }
            set => _messageId = value;
        }
        public string PurchaseOrderEndpoint { get; set; }

        [JsonProperty("requestData")]
        public dynamic RequestData { get; set; }

        //[JsonIgnore]
        //public dynamic RequestData { get; set; }
    }
}
