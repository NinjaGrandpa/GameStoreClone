using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Services.Blobstorage
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileToBlobAsync(string strFileName, string contecntType, Stream fileStream);
        Task<bool> DeleteFileToBlobAsync(string strFileName);
    }
}
