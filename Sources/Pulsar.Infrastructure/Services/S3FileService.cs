using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using Pulsar.Common.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Services
{
    public class S3FileService : IFileService
    {
        private string BucketName = null;
        private RegionEndpoint Region = null;
        public S3FileService(IConfiguration configuration)
        {
            BucketName = configuration.GetSection("S3")?.Get<S3ConfigurationSection>().BucketName;
            Region = RegionEndpoint.GetBySystemName(configuration.GetSection("S3")?.Get<S3ConfigurationSection>().Region);
        }

        public async Task Upload(Stream stream, string filename)
        {
            using var s3Client = new AmazonS3Client();
            using var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(stream, BucketName, filename);
        }
    }

    class S3ConfigurationSection
    {
        public string BucketName { get; set; }
        public string Region { get; set; }
    }
}
