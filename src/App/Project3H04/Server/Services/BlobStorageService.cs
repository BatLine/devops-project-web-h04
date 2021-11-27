﻿using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using Project3H04.Shared.Fotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class BlobStorageService : IStorageService
    {
        private readonly string connectionString;
        private const string containerName = "images";

        public string StorageBaseUri => "https://devopsh04storage.blob.core.windows.net/fotos/images/";

        public BlobStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Storage");
        }

        public Uri CreateUploadUri(string filename)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename);
            var blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = DateTime.UtcNow.AddMinutes(-5),
                ExpiresOn = DateTime.UtcNow.AddMinutes(5),
                BlobContainerName = containerName,
                BlobName = filename,
            };
            blobSasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.Write | BlobSasPermissions.Create);
            var sas = blobClient.GenerateSasUri(blobSasBuilder);
            return sas;
        }
    }
}
