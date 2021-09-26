using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Services
{
    public interface ISpeechSynthesizer
    {
        public Task<string> SynthesizeCall(string calling, string place);
    }
}
