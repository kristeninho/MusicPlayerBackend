﻿using MusicPlayerBackend.Repositories.Interfaces;
using Azure.Storage.Blobs;

namespace MusicPlayerBackend.Repositories
{
    public class AzureCloudStorageRepository : IAzureCloudStorageRepository
    {
        private string _connectionString = ConfigurationManager.SecretAppSettings.GetConnectionString("Storage");

        public async Task<bool> DeleteAsync(string fileName, string containerName)
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

        public async Task<Stream?> DownloadAsStreamAsync(string fileName, string containerName)
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

        public async Task<bool> UploadAsync(Stream inputStream, string fileName, string containerName)
        {
            try
            {
                var container = new BlobContainerClient(_connectionString, containerName);
                await container.UploadBlobAsync(fileName, inputStream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> UploadFileToCloudAndReturnName(string userName, string fileName, string fileType, string file, string containerName)
        {
            // need some logic working with the file types, if other file types will be supported
            // possibly send the file type with the albumDTO
            try
            {
                var fileNameInCloud = $"{userName}-{fileName}-{Guid.NewGuid().ToString()}.{fileType}";

                Stream stream = new MemoryStream(Convert.FromBase64String(file));

                await UploadAsync(stream, fileNameInCloud, containerName);
                return fileNameInCloud;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DownloadFileAndReturnAsString(string fileName, string containerName)
        {
            // need some logic working with the file types, if other file types will be supported
            // possibly send the file type with the albumDTO
            try
            {
                var base64 = new byte[0];
                var stream = await DownloadAsStreamAsync(fileName, containerName);
                using (MemoryStream ms = new MemoryStream()) {
                    stream.CopyTo(ms);
                    base64 = ms.ToArray();
                }

                return Convert.ToBase64String(base64);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
