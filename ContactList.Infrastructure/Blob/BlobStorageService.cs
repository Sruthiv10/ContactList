

namespace RFL.TechStack.Infrastructure.Blob
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RFL.TechStack.Core.Common;
    using RFL.TechStack.Core.Interface;
    using Newtonsoft.Json;

    public abstract class BlobStorageService
    {
        private readonly string connectionKey;
        private readonly string containerName;
        private readonly ILogger<BlobStorageService> logger;
        public BlobStorageService(string connectionKey, string containerName, ILogger<BlobStorageService> logger)
        {
            this.connectionKey = connectionKey;
            this.containerName = containerName;
            this.logger = logger;
        }

        public async Task<ExecuteResult<bool>> DeleteAsync(string requestId)
        {
            var result = new ExecuteResult<bool>();

            try
            {
                //string connectionKey = configuraton["OutboundStorageConnection"];
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                //string strContainerName = configuraton["OutboundContainer"];
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(requestId);
                if (cloudBlockBlob != null)
                {
                    // delete blob from container
                    await cloudBlockBlob.DeleteAsync();
                    result.Success = result.Result = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occured while processing the request.");
                throw;
            }

            return result;
        }

        public async Task<string> UploadAsync(string requestId, string jsonData, string mimeType = "application/json")
        {
            try
            {
                try
                {
                    //string connectionKey = configuraton["OutboundStorageConnection"];
                    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionKey);
                    CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                    //string strContainerName = configuraton["OutboundContainer"];
                    CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(requestId);
                    cloudBlockBlob.Properties.ContentType = mimeType;

                    //string fileName = this.GenerateFileName(strFileName);
                    if (await cloudBlobContainer.CreateIfNotExistsAsync())
                    {
                        await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                    }

                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
                        {
                            await cloudBlockBlob.UploadFromStreamAsync(ms);
                        }
                        return cloudBlockBlob.Uri.AbsoluteUri;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occured while processing the request.");
                    throw;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExecuteResult<string>> DownloadAsync(string requestId)
        {
            var result = new ExecuteResult<string>();
            try
            {
                //string connectionKey = configuraton["OutboundStorageConnection"];
               // string strContainerName = configuraton["OutboundContainer"];

                //BlobServiceClient blobServiceClient = new BlobServiceClient(connectionKey);
                //BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(strContainerName);
                //BlobClient blobClient = containerClient.GetBlobClient($"{DateTime.Now.Ticks}.json");
                //if (await blobClient.ExistsAsync())
                //{
                //    var response = await blobClient.DownloadAsync();
                //    using (var streamReader = new StreamReader(response.Value.Content))
                //    {
                //        while (!streamReader.EndOfStream)
                //        {
                //            var line = await streamReader.ReadLineAsync();
                //            Console.WriteLine(line);
                //        }
                //    }


                //}    
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                var isExists = await cloudBlobContainer.GetBlockBlobReference(requestId).ExistsAsync().ConfigureAwait(false);
                if (isExists)
                {
                    var cloudBlob = cloudBlobContainer.GetBlobReference(requestId);
                    if (cloudBlob.Exists())
                    {
                        using (var stream = new MemoryStream())
                        {
                            await cloudBlob.DownloadToStreamAsync(stream);
                            stream.Position = 0;//resetting stream's position to 0
                            var serializer = new JsonSerializer();

                            using (var sr = new StreamReader(stream))
                            {
                                using (var jsonTextReader = new JsonTextReader(sr))
                                {
                                    object data = serializer.Deserialize(jsonTextReader);
                                    result.Result = data.ToString();
                                }
                            }
                        }
                    }

                    result.Success = result.Result != null;
                }
                else
                {
                    result.Success = false;
                    result.Messages.Add(new ExecuteMessage() { Code = Enums.StatusCode.Error, Description = "File not found" });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occured while processing the request.");
                throw;
            }

            return result;
        }
    }
}
