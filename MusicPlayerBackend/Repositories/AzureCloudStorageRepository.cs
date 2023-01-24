using MusicPlayerBackend.Repositories.Interfaces;
using Azure.Storage.Blobs;

namespace MusicPlayerBackend.Repositories
{
    public class AzureCloudStorageRepository : IAzureCloudStorageRepository
    {
        private string _connectionString = ConfigurationManager.AzureConnectionString.GetConnectionString("AzureConnectionString");

        public async Task<bool> Delete(string fileName, string containerName)
        {
            try
            {
                var blobClient = new BlobClient(_connectionString, containerName, fileName);
                await blobClient.DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Stream?> DownloadAsStream(string fileName, string containerName)
        {
            try
            {
                var blobClient = new BlobClient(_connectionString, containerName, fileName);
                Stream blobStream = await blobClient.OpenReadAsync();
                return blobStream;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Upload(Stream inputStream, string fileName, string containerName)
        {
            try
            {
                var container = new BlobContainerClient(_connectionString, containerName);
                await container.UploadBlobAsync(fileName, inputStream);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
