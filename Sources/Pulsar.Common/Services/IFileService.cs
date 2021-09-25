using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Services
{
    public interface IFileService
    {
        Task Upload(Stream stream, string filename);
    }
}
