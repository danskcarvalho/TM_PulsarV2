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
        private S3ConfigurationSection Configuration = null;
        private RegionEndpoint Region = null;
        public S3FileService(IConfiguration configuration)
        {
            Configuration = configuration.GetSection("S3")?.Get<S3ConfigurationSection>();
            Region = RegionEndpoint.GetBySystemName(configuration.GetSection("S3")?.Get<S3ConfigurationSection>().Region);
        }

        public async Task<string> Upload(Stream stream, string filename)
        {
            filename = filename ?? throw new ArgumentNullException(nameof(filename));
            filename = filename.Trim();
            using var s3Client = new AmazonS3Client(Configuration.AccessKey, Configuration.SecretKey, Region);
            using var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(stream, Configuration.BucketName, filename);
            return $"https://{Configuration.BucketName}.s3.{Configuration.Region}.amazonaws.com/{filename}";
        }
    }

    class S3ConfigurationSection
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
        public string Region { get; set; }
    }
}
