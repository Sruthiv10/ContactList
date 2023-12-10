using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Common
{
    public static class Constants
    {
        /// <summary>
        /// Set value for APISuccessCode.
        /// </summary>
        public const int APISuccessCode = 1;

        /// <summary>
        /// Set value for APIFailureCode.
        /// </summary>
        public const int APIFailureCode = 2;

        /// <summary>
        /// Set message for APISuccess.
        /// </summary>
        public const string APISuccessText = "Success";

        /// <summary>
        /// Set message for APIFailure.
        /// </summary>
        public const string APIFailureText = "Failure";
        /// <summary>
        /// Set message for SqlException.
        /// </summary>
        public const string SqlException = "16";

        /// <summary>
        /// Set message for SqExceptionRaisErrorNumber.
        /// </summary>
        public const int SqExceptionRaisErrorNumber = 50000;

        /// <summary>
        /// Set message for SuccessRequestProcessed.
        /// </summary>
        public const string SuccessRequestProcessed = "The request has been processed successfully";

        /// <summary>
        /// Set message for ErrorUnauthorised.
        /// </summary>
        public const string ErrorUnauthorised = "Unauthorised user.";

        /// <summary>
        /// Set message for ErrorNoDataFound.
        /// </summary>
        public const string ErrorNoDataFound = "No data found";

        /// <summary>
        /// Set message for ErrorNoDataFound.
        /// </summary>
        public const string ErrorInvalidEventType = "Invalid event type provided.";

        /// <summary>
        /// Set message for ErrorTimeOut.
        /// </summary>
        public const string ErrorTimeOut = "Time Out Error";
        /// <summary>
        /// Set message for ErrorNoDataFound.
        /// </summary>
        public const string ErrorOccured = "Error occured while processing";

        /// <summary>
        /// Set message for ErrorOccuredOnGetAll.
        /// </summary>
        public const string ErrorOccuredOnGetAll = "Error occured while processing";

        /// <summary>
        /// Set message for ErrorOccuredOnGetById.
        /// </summary>
        public const string ErrorOccuredOnGetById = "Error occured on GetById";

        /// <summary>
        /// Set message for ErrorOccuredNoWebhook.
        /// </summary>
        public const string ErrorOccuredNoWebhook = "There is no webhook registration for the supplied data";


        /// <summary>
        /// Set value for RequestId.
        /// </summary>
        public const string HeaderRequestId = "RequestId";

        /// <summary>
        /// Set value for timestamp.
        /// </summary>
        public const string HeaderTimestamp = "Timestamp";

        /// <summary>
        /// Set value for Provider.
        /// </summary>
        public const string HeaderProvider = "Provider";

        public const string SignatureHeaderName = "nec-hook-signature";
        public const string SignatureHeaderValueTemplate = "{0}|{1}|{2}";

        /// <summary>
        /// Set message for SuccessRequestProcessed.
        /// </summary>
        public const string SuccessWebhookSend = "The webhook request has been sent successfully.";

        /// <summary>
        /// Set message for SuccessRequestProcessed.
        /// </summary>
        public const string ErrorWebhookSend = "Error occured while sending webhook request.";
        public const string ErrorWebhookGone = "Access to the target resource is no longer available at the origin server.";

        public const string ActionKey = "Action";

        #region function names
        public const string WarehouseDeliveryOrchestration = "WarehouseDeliveryOrchestration";
        public const string WarehouseDeliveryActivity = "WarehouseDeliveryActivity";
        public const string RequestDBStorageActivity = "RequestDBStorageActivity";
        public const string RequestBlobStorageActivity = "RequestBlobStorageActivity";
        public const string RequestDataDeliveryActivity = "RequestDataDeliveryActivity";

        public const string AUShipmentPostActivity = "AUShipmentPostActivity";
        public const string AUCreateLablePostActivity = "AUCreateLablePostActivity";
        public const string ShopifyWebhookOrchestration = "ShopifyWebhookOrchestration";
        #endregion

        /// <summary>
        /// Set message for ErrorNoDataFound.
        /// </summary>
        public const string ErrorEventGrid = "Error occured on process the request while connecting with Event topic";
        public const string ErrorOnLog = "Error occured on log the proces details";

        /// <summary>
        /// Set message for ErrorOccuredOnGetById.
        /// </summary>
        public const string ErrorOccuredOnSortColumn = "Requested sort columns is not exists!.";
        public const string ErrorOccuredOnlastUpdatedGt = "lastUpdatedGt Date is not in ISO-8601 format!.";
        public const string ErrorOccuredOnlastUpdatedLt = "lastUpdatedLt Date is not in ISO-8601 format!.";
        public const string ErrorOccuredOnSortDirection = "Sort direction order is not valid!.";
        public const int defaultTakeCount = 5;
        public const int defaultTotalCount = 500;
        public const string ErrorOccuredOnISO8601 = "Date is not in ISO-8601 format!.";


        public const string ErrorOccuredOnModify = "Error occured on modify data.";
        public const string ErrorOccuredOnSave = "Error occured on saving the data.";
        public const string ErrorOccuredOnDelete = "Error occured on deletion.";
        public const string ErrorAlreadyExists = "Error on saving the data since it is already exists.";
        public const string ErrorAlreadyProviderExists = "Error on saving the data since it is already exists for the provider {0}.";
        public const string ErrorOnDeserialisation = "Invalid data format.";
        public const string ErrorOnEvents = "Invalid event name.";
        public const string ErrorOnProvider = "Invalid provider name.";
        public const string ErrorOnSubscriptionNotFound = "Subscription key is missing in request header.";
        public const string ErrorOnRequestHeaderNotFound = "Shopify header is missing in request header.";

        /// <summary>
        /// Set message for ErrorRequestProcessed.
        /// </summary>
        public const string ErrorRequestProcessed = "Error occured while processing this request.";
        public const string SignatureProviderHeader = "nec-provider-signature";
        public const string ErrorOccuredNoProvider = "The specified provider id is not valid.";
        //public const string SubscriptionHeader = "Ocp-Apim-Subscription-Key";


        // log info
        public const string PublisherReceivedLog = "WarehouseAPublisher, Publisher app received the request and in processing.";
        public const string PublisherPublishedLog = "WarehouseAPublisher, Publisher app sent the request to event grid.";
        public const string ErroronPublisherLog = "Error occured while processing request by publisher app";
        public const string ErroronSendWebhookMessage = "Error occured while sending webhook request message";

        public const string SubcriberReceivedLog = "Subscriber app received the request and in processing.";
        public const string SubcriberPublishedLog = "Subscriber app published the request and in processing. Total web-request(s) - {0}";
        public const string SubcriberNoPublishedLog = "No webrequest urls registered for the event.";
        //public const string SubcriberPublishedLog = "Subscriber app sent the {0} messages for processing webrequest.";
        public const string ErroronSubcriberLog = "Error occured while processing request by subcriber app";
        //public const string ErroronPublisherReceivedLog = "Error occured while processing request by {}";
        public const string WebhookPostLog = "Webhook id {0} requested processed with status {1}.";
        #region PurchaseOrder DeliveryAgent
        public const string DeliveyAgentOrchestration = "DeliveyAgentOrchestration";
        public const string CevaPayloadConverterActivity = "CevaPayloadConverterActivity";
        public const string CevaPayloadUploadActivity = "CevaPayloadUploadActivity";
        public const string CevaGenerateTokenActivity = "CevaGenerateTokenActivity";
        public const string CevaPostDataAPIActivity = "CevaPostDataAPIActivity";
        public const string CevaVendorIdQueryParam = "VendorID";
        public const string CevaPartnerIdQueryParam = "PartnerID";
        public const string ErrorNoBearerToken = "Token missing for the end point {0}, corresponding to the {1} is {2}.";
        public const string ErrorNoBearerTokenInvalidKey = "Token not generated for the end point {0} due to invalid {1} : {2}.";
        public const string CevaDefaultPartionerId = "363502";
        public const string ErrorNoCevaBlobUpload = "Error occured while uplaoding data to storage container.";
        public const string SuccessStoredPurchaseOrderRequest = "Request details stored in the database successfully.";
        public const int CevaKeyPairCount = 4;

        #endregion

        #region AU Post Integration
        public const string AUPostItemLength = "22";
        public const string AUPostItemHeight = "16.6";
        public const string AUPostItemWidth = "22";
        //public const string AUPostItemWeight = "0.3";
        public const bool AUPostItemAuthToLeave = false;

        public const string AUPostPreferenceType = "PRINT";
        public const string AUPostPreferenceFormat = "ZPL";
        public const string AUPostPreferenceGroup = "Parcel Post";
        public const string AUPostPreferenceGroupLayout = "A6-1pp";
        public const int AUPostPreferenceGroupLeft_offset = 0;
        public const int AUPostPreferenceGroupTop_offset = 0;
        public const bool AUPostPreferenceGroupBranded = true;
        public const string ErrorOnConfigureProductId = "Error occured on configuring ProductId";
        #endregion
        #region NZ Post Integration
        public const string NZPostItemLength = "22";
        public const string NZPostItemHeight = "16.6";
        public const string NZPostItemWidth = "22";
        public const string NZPostItemWeight = "0.3";
        #endregion



    }
}
