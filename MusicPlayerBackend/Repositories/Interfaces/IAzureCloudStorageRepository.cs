namespace MusicPlayerBackend.Repositories.Interfaces
{
    public interface IAzureCloudStorageRepository
    {
        Task<bool> UploadAsync(Stream inputStream, string fileName, string containerName);
        Task<Stream?> DownloadAsStreamAsync(string fileName, string containerName);
        Task<bool> DeleteAsync(string fileName, string containerName);
        Task<string> UploadFileToCloudAndReturnName(string userName, string fileName, string fileType, string file, string containerName);
        Task<string> DownloadFileAndReturnAsString(string fileName, string containerName);
    }
}
