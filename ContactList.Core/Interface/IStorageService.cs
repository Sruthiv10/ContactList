using RFL.TechStack.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Interface
{
    public interface IStorageService
    {
        Task<ExecuteResult<string>> DownloadAsync(string requestId);
        Task<string> UploadAsync(string requestId, string jsonData, string mimeType = "application/json");
        Task<ExecuteResult<bool>> DeleteAsync(string requestId);
    }
}
