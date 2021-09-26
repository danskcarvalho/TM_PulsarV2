using Amazon;
using Amazon.Polly;
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
    public class PollyService : ISpeechSynthesizer
    {
        private PollyConfigurationSection Configuration = null;
        private S3FileService FileService = null;
        private RegionEndpoint Region = null;
        public PollyService(IConfiguration configuration)
        {
            Configuration = configuration.GetSection("Polly")?.Get<PollyConfigurationSection>();
            Region = RegionEndpoint.GetBySystemName(configuration.GetSection("Polly")?.Get<PollyConfigurationSection>().Region);
            FileService = new S3FileService(configuration);
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public async Task<string> SynthesizeCall(string calling, string place)
        {
            var polly = new Amazon.Polly.AmazonPollyClient(Configuration.AccessKey, Configuration.SecretKey, Region);
            var mp3File = await polly.SynthesizeSpeechAsync(new Amazon.Polly.Model.SynthesizeSpeechRequest()
            {
                LanguageCode = LanguageCode.PtBR,
                OutputFormat = OutputFormat.Mp3,
                SampleRate = "16000",
                TextType = TextType.Ssml,
                VoiceId = VoiceId.Vitoria,
                Text = GetText(calling, place)
            });
            return await FileService.Upload(new MemoryStream(ReadFully(mp3File.AudioStream)), Guid.NewGuid().ToString() + ".mp3");
        }

        private string GetText(string calling, string place)
        {
            return $"<speak>{GetEscaped(calling)}<break strength=\"strong\"/>{GetEscaped(place)}</speak>";
        }

        private string GetEscaped(string nome)
        {
            var r = new string(nome.Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)).ToArray());
            var parts = r.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> f = new List<string>();
            foreach (var p in parts)
            {
                if (p.All(c => char.IsDigit(c)))
                    f.Add(p.TrimStart('0'));
                else
                    f.Add(p);
            }
            return string.Join(" ", f);
        }
    }

    class PollyConfigurationSection
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Region { get; set; }
    }
}
