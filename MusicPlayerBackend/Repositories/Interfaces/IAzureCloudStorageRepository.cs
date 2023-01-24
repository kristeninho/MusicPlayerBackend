namespace MusicPlayerBackend.Repositories.Interfaces
{
    public interface IAzureCloudStorageRepository
    {
        Task<bool> Upload(Stream inputStream, string fileName, string containerName);
        Task<Stream?> DownloadAsStream(string fileName, string containerName);
        Task<bool> Delete(string fileName, string containerName);
    }
}
