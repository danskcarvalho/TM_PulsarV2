using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Services
{
    public interface IEmailService
    {
        Task Send(string to, string templateName, object templateData);
    }
}
