using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RFL.TechStack.Core.Common
{
    public class Enums
    {
        /// StatusCode.
        /// </summary>
        public enum StatusCode
        {
            /// <summary>
            /// Denote the success status.
            /// </summary>
            [Description("Success")]
            Success,

            /// <summary>
            /// Denote error status.
            /// </summary>
            [Description("Error")]
            Error,

            /// <summary>
            /// NO record found.
            /// </summary>
            [Description("No Record Found")]
            NoRecordFound,
        }
        /// <summary>
        /// Content Type.
        /// </summary>
        public enum ContenType
        {
            /// <summary>
            /// PDF
            /// </summary>
            [Description(".pdf")]
            PDF,

            /// <summary>
            /// JPG
            /// </summary>
            [Description("JPEG")]
            JPEG,

            /// <summary>
            /// Excel
            /// </summary>
            [Description(".xls")]
            EXCEL,

            ///// <summary>
            ///// Word
            ///// </summary>
            //[Description(".doc")]
            //WORD,
        }
        /// <summary>
        /// Status Code.
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// Inactive or deleted
            /// </summary>
            [Description("Inactive")]
            Inactive = 0, // deleted.

            /// <summary>
            /// Active status.
            /// </summary>
            [Description("Active")]
            Active = 1, // approved.
        }
        /// <summary>
        /// Indicates the result of inserting, updating, and deleting items in the <see cref="IWebHookStore"/>.
        /// </summary>
        public enum StoreResult
        {
            /// <summary>
            /// The operation succeeded.
            /// </summary>
            Success = 0,

            /// <summary>
            /// The targeted entity did not exist.
            /// </summary>
            NotFound,

            /// <summary>
            /// The operation resulted in a conflict.
            /// </summary>
            Conflict,

            /// <summary>
            /// The operation was not formulated correctly.
            /// </summary>
            OperationError,

            /// <summary>
            /// The operation resulted in an internal error.
            /// </summary>
            InternalError
        }
        public enum OutboundSubcriptionFilter
        {
            [Description("xpo-mx")]
            XPO_MX,
            [Description("xpo-us")]
            XPO_US,
            [Description("xpo-au")]
            XPO_AU,
            [Description("ceva")]
            CEVA,
        }
        public enum WebhookEvents
        {
            [Description("OrderStatus")]
            OrderStatus,
            [Description("OrderShipment")]
            OrderShipment,
            [Description("ReturnStatus")]
            ReturnStatus,
            [Description("ReturnReceived")]
            ReturnReceived,
            [Description("InventoryChange")]
            InventoryChange,
            [Description("InventorySnapshot")]
            InventorySnapshot
        }
        public enum WarehouseProvider
        {
            [Description("xpo-mx")]
            XPO_MX,
            [Description("xpo-us")]
            XPO_US,
            [Description("xpo-au")]
            XPO_AU,
            [Description("ceva")]
            CEVA,
        }
        public enum OutboundTraceLogStage
        {
            [Description("Publisher")]
            Publisher,

            [Description("Subscriber")]
            Subscriber,

            [Description("Webhook")]
            Webhook
        }
        
        public enum OutboundTraceLogStatus
        {
            [Description("None")]
            None,

            [Description("Publisher-Received")]
            PublisherReceived,

            [Description("Publisher-Published")]
            PublisherPublished,

            [Description("Subscriber-Received")]
            SubscriberReceived,

            [Description("Subscriber-Published")]
            SubscriberPublished,

            [Description("WebhookRequest-Posted")]
            WebHookRequestPosted,

            [Description("WebhookRequest-Success")]
            WebHookRequestSuccess,

            [Description("WebhookRequest-Failed")]
            WebHookRequstFailed
        }
        public enum BlobStorageType
        {
            OutboundPayload,
            PurchaseOrderRequest,
            PurchaseOrderDelivery,
            PurchaseOrderTracking
        }
        public enum PurchaseOrderAPIEndpoint
        {
            [Description("Product Master")]
            ProductMaster,

            [Description("Purchase Order")]
            PurchaseOrder,

            [Description("Create Order")]
            CreateOrder,

            [Description("Order Return")]
            ReturnOrder,

            [Description("Other")]
            Other
        }
        public enum LogAnalyticWorkspaceAssemblies
        {
            NEC_Fulfillment_PurchaseOrder,
            NEC_Fulfillment_PurchaseOrder_DeliveryAgent,
            NEC_Fulfillment_PurchaseOrder_Subscriber,
            NEC_Fulfillment_Integration_AU
        }
        public enum PurchaseOrderTraceLogStage
        {
            [Description("Publisher")]
            Publisher,

            [Description("Subscriber")]
            Subscriber,

            [Description("DeliveryAgent-PostAPI")]
            DeliveryAgent_PostAPI,

            [Description("DeliveryAgent-ConverterApp")]
            DeliveryAgent_ConverterApp,

            [Description("DeliveryAgent-TokenGen")]
            DeliveryAgent_TokenGen,

            [Description("DeliveryAgent-BlobUpload")]
            DeliveryAgent_BlobUpload
        }

        public enum PurchaseOrderTraceLogStatus
        {
            [Description("None")]
            None,

            [Description("Request recevied by publisher app.")]
            Publisher_Received,

            [Description("Request published to subcriber's service bus.")]
            Publisher_Published,

            [Description("Request received by subcriber app.")]
            Subscriber_Received,

            [Description("Request published to delivery agent's service bus.")]
            Subscriber_Published,

            [Description("Request posted to the Endpoint.")]
            Request_Posted,

            [Description("Request successfully posted to the Endpoint.")]
            RequesPost_Success,

            [Description("Request failed on posted to the Endpoint.")]
            RequesPost_Failed,

            [Description("Request not posted due to invalid Vendor id.")]
            Request_NotPosted_InValidVendor,

            [Description("Token Request posted to the Endpoint.")]
            TokenRequest_Posted,

            [Description("Token Request successfully posted to the Endpoint.")]
            TokenRequestPost_Success,

            [Description("Token Request failed on posted to the Endpoint.")]
            TokenRequestPost_Failed,

            [Description("Converter Request posted to the Endpoint.")]
            ConverterRequest_Posted,

            [Description("Converter Request successfully posted to the Endpoint.")]
            ConverterRequestPost_Success,

            [Description("Converter Request failed on posted to the Endpoint.")]
            ConverterRequestPost_Failed,
        }
        public enum AUPostEndpointType
        {
            [Description("Shopify Webhook")]
            ShopifyWebhook,

            [Description("Create Shipment")]
            CreateShipment,

            [Description("Create Label")]
            CreateLabel,
        }
        public enum AUPostEvent
        {
            [Description("Initiated")]
            Initiated,

            [Description("Request")]
            Request,

            [Description("Response")]
            Response,
        }
        public enum AUPostStatus
        {
            [Description("Success")]
            Success,

            [Description("Failed")]
            Failed,

            [Description("Processing")]
            Processing,
        }

        public enum PurchaseOrderAPIPostStatus
        {
            [Description("Success")]
            RequesPost_Success,

            [Description("Failed")]
            RequesPost_Failed,
        }
        public enum APIRequestHandlerType
        {
            Common,
            CEVA
        }
    }
}
