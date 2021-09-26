using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pulsar.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Services
{
    public class SESEmailService : IEmailService
    {
        private SESConfigurationSection Configuration = null;
        private RegionEndpoint Region = null;

        public SESEmailService(IConfiguration configuration)
        {
            Configuration = configuration.GetSection("SES")?.Get<SESConfigurationSection>();
            Region = RegionEndpoint.GetBySystemName(configuration.GetSection("SES")?.Get<SESConfigurationSection>().Region);
        }

        public async Task Send(string to, string templateName, object templateData)
        {
            using var client = new AmazonSimpleEmailServiceClient(Configuration.AccessKey, Configuration.SecretKey, Region);
            var sendRequest = new SendTemplatedEmailRequest
            {
                Source = !string.IsNullOrWhiteSpace(Configuration.FromEmail) ? 
                    $"{Configuration.FromName} <{Configuration.FromEmail}>" : Configuration.FromEmail,
                Destination = new Destination
                {
                    ToAddresses =
                        new List<string> { to }
                },
                Template = templateName,
                TemplateData = JsonConvert.SerializeObject(templateData ?? new object())
            };

            await client.SendTemplatedEmailAsync(sendRequest);
        }
    }

    class SESConfigurationSection
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Region { get; set; }
    }
}
