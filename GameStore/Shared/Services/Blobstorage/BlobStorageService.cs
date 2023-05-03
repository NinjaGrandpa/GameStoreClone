using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace GameStore.Shared.Services.Blobstorage;

public class BlobStorageService : IBlobStorageService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<BlobStorageService> _logger;
    private string blobStorageConnection = "DefaultEndpointsProtocol=https;AccountName=almedaldigital;AccountKey=hhY8C8cjQGSfhHpk7HQP9IxBWC5KXy1f5iNRrlJAqG0KAhncGAOEv5S7WRZGgkjwx4qc2Dwz/fHi+AStTIK/0A==;EndpointSuffix=core.windows.net";
    private string blobContainerName = "gamestoreimages";
    public BlobStorageService(IConfiguration configuration, ILogger<BlobStorageService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<bool> DeleteFileToBlobAsync(string strFileName)
    {
        try
        {
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);
            var createResponse = await container.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var blob = container.GetBlobClient(strFileName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            return true;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex.ToString());
            throw;
        }
    }

    public async Task<string> UploadFileToBlobAsync(string strFileName, string contentType, Stream fileStream)
    {
        try
        {
            blobStorageConnection = "DefaultEndpointsProtocol=https;AccountName=almedaldigital;AccountKey=hhY8C8cjQGSfhHpk7HQP9IxBWC5KXy1f5iNRrlJAqG0KAhncGAOEv5S7WRZGgkjwx4qc2Dwz/fHi+AStTIK/0A==;EndpointSuffix=core.windows.net";
            
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);

            var blob = container.GetBlobClient(strFileName);
            await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
            var urlString = blob.Uri.ToString();
            return urlString;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex.ToString());
            throw;
        }


    }
}
